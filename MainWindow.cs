using PKHeX.Core;
using SVTradePartnerViewer.Properties;
using SVTradePartnerViewer.Structures;
using SysBot.Base;
using System.Net.Sockets;
using static SVTradePartnerViewer.Structures.Offsets;

namespace SVTradePartnerViewer
{
    public partial class MainWindow : Form
    {
        private readonly static SwitchConnectionConfig Config = new() { Protocol = SwitchProtocol.WiFi, IP = Settings.Default.SwitchIP, Port = 6000 };
        private readonly static SwitchSocketAsync SwitchConnection = new(Config);

        private static ulong TradePartnerNIDOffset;

        private static string OT = string.Empty;
        private static int DisplayTID;
        private static int DisplaySID;

        readonly string CachedText = string.Empty;

        private bool Stop = false;

        public MainWindow()
        {
            string build = string.Empty;
#if DEBUG
            var date = File.GetLastWriteTime(System.Reflection.Assembly.GetEntryAssembly()!.Location);
            build = $" (dev-{date:yyyyMMdd})";
#endif
            var v = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version!;
            CachedText = "SVTradePartnerViewer v" + v.Major + "." + v.Minor + "." + v.Build + build;
            Text = CachedText;

            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            InputSwitchIP.Text = Settings.Default.SwitchIP;
            CheckAutoCopy.Checked = Settings.Default.AutoCopy;
            ButtonCopy.Enabled = !CheckAutoCopy.Checked;
            OutOT.Text = string.Empty;
            OutTID.Text = string.Empty;
            OutVersion.Text = string.Empty;
            OutNID.Text = string.Empty;
        }

        private void InputSwitchIP_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text != "192.168.0.0")
            {
                Settings.Default.SwitchIP = textBox.Text;
                Config.IP = textBox.Text;
            }
            Settings.Default.Save();
        }

        private void ButtonConnect_Click(object sender, EventArgs e)
        {
            ButtonStop.Enabled = true;
            Stop = false;
            Connect();
        }

        private void ButtonStop_Click(object sender, EventArgs e)
        {
            Stop = true;
            ButtonStop.Enabled = false;
        }

        private void ButtonCopy_Click(object sender, EventArgs e)
        {
            CopyOutputToClipboard(CheckPSWiFi.Checked);
        }

        private void CheckAutoCopy_CheckedChanged(object sender, EventArgs e)
        {
            ButtonCopy.Enabled = !CheckAutoCopy.Checked;
            Settings.Default.AutoCopy = CheckAutoCopy.Checked;
            Settings.Default.Save();
            if (SwitchConnection.Connected) CopyOutputToClipboard(CheckPSWiFi.Checked);
        }

        private void CheckPSWiFi_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.PSWiFi = CheckPSWiFi.Checked;
            Settings.Default.Save();
        }

        private void CopyOutputToClipboard(bool IsPS = false)
        {
            string n = Environment.NewLine;
            string OutString = IsPS ? $"{OutOT.Text}\t{OutTID.Text.Split("-")[1]}" : $"OT: {OutOT.Text}{n}ID: {OutTID.Text}{n}Version: {OutVersion.Text}{n}NID: {OutNID.Text}";
            Clipboard.SetText(OutString);
        }

        private async void Connect()
        {
            ButtonConnect.Enabled = false;
            if (!SwitchConnection.Connected)
            {
                try
                {
                    Text = CachedText + " | Connecting...";
                    var NewText = CachedText;
                    SwitchConnection.Connect();
                    string id = await GetGameID(CancellationToken.None);
                    if (id is ScarletID)
                    {
                        Text = CachedText + " | Connected to Scarlet";
                        NewText = CachedText + " - Sc";
                    }
                    else if (id is VioletID)
                    {
                        Text = CachedText + " | Connected to Violet";
                        NewText = CachedText + " - Vi";
                    }
                    else
                    {
                        MessageBox.Show("Unable to detect Pokémon Scarlet or Pokémon Violet running on your switch!");
                        SwitchConnection.Disconnect();
                    }

                    if (SwitchConnection.Connected)
                    {
                        Text = NewText + " | Identifying host trainer data...";
                        var sav = await IdentifyTrainer(CancellationToken.None);
                        OT = sav.OT;
                        DisplayTID = sav.DisplayTID;
                        DisplaySID = sav.DisplaySID;

                        NewText += $" | Connected to {OT} ({DisplayTID:D6})";
                        Text = NewText + " | Reading trade partner info...";

                        while (!Stop && SwitchConnection.Connected)
                        {
                            TradePartnerNIDOffset = await SwitchConnection.PointerAll(LinkTradePartnerNIDPointer, CancellationToken.None);
                            ulong NID = await GetTradePartnerNID(TradePartnerNIDOffset, CancellationToken.None);
                            if (NID == 0)
                            {
                                await Task.Delay(1_000);
                                continue;
                            }

                            var trader = await GetTradePartnerMyStatus(Trader1MyStatusPointer, CancellationToken.None);
                            if (trader.OT == OT && trader.DisplayTID == DisplayTID && trader.DisplaySID == DisplaySID)
                                trader = await GetTradePartnerMyStatus(Trader2MyStatusPointer, CancellationToken.None);

                            OutOT.Text = trader.OT;
                            OutTID.Text = $"({trader.DisplaySID:D4})-{trader.DisplayTID:D6}";
                            OutVersion.Text = $"{(trader.Game <= 51 ? "Scarlet" : "Violet")} ({trader.Game})";
                            OutNID.Text = $"{NID:X16}";

                            if (CheckAutoCopy.Checked) CopyOutputToClipboard(CheckPSWiFi.Checked);

                            await ClearTradePartnerNID(TradePartnerNIDOffset, CancellationToken.None);
                        }

                        Text = CachedText + $" | Disconnected from {OT} ({DisplayTID:D6})";
                        if (SwitchConnection.Connected) SwitchConnection.Disconnect();
                    }

                }
                catch (SocketException err)
                {
                    Text = CachedText + " | Failed to connect!";
                    if (SwitchConnection.Connected) await SwitchConnection.SendAsync(SwitchCommand.DetachController(true), CancellationToken.None).ConfigureAwait(false);
                    SwitchConnection.Disconnect();
                    // a bit hacky but it works
                    if (err.Message.Contains("failed to respond") || err.Message.Contains("actively refused"))
                    {
                        MessageBox.Show(err.Message);
                    }
                }
            }
            ButtonConnect.Enabled = true;
        }

        private static async Task<string> GetGameID(CancellationToken token) => await SwitchConnection.GetTitleID(token).ConfigureAwait(false);

        private static async Task<SAV9SV> IdentifyTrainer(CancellationToken token)
        {
            // Check title so we can warn if mode is incorrect.
            string title = await SwitchConnection.GetTitleID(token).ConfigureAwait(false);
            if (title is not (ScarletID or VioletID))
                throw new Exception($"{title} is not a valid SV title. Is your mode correct?");

            return await GetFakeTrainerSAV(token).ConfigureAwait(false);
        }

        private static async Task<SAV9SV> GetFakeTrainerSAV(CancellationToken token)
        {
            var sav = new SAV9SV();
            var info = sav.MyStatus;
            var read = await SwitchConnection.PointerPeek(info.Data.Length, MyStatusPointer, token).ConfigureAwait(false);
            read.CopyTo(info.Data, 0);
            return sav;
        }

        private static async Task<TradeMyStatus> GetTradePartnerMyStatus(IReadOnlyList<long> pointer, CancellationToken token)
        {
            var info = new TradeMyStatus();
            var read = await SwitchConnection.PointerPeek(info.Data.Length, pointer, token).ConfigureAwait(false);
            read.CopyTo(info.Data, 0);
            return info;
        }

        private static async Task<ulong> GetTradePartnerNID(ulong offset, CancellationToken token)
        {
            var data = await SwitchConnection.ReadBytesAbsoluteAsync(offset, 8, token).ConfigureAwait(false);
            return BitConverter.ToUInt64(data, 0);
        }

        private static async Task ClearTradePartnerNID(ulong offset, CancellationToken token)
        {
            var data = new byte[8];
            await SwitchConnection.WriteBytesAbsoluteAsync(data, offset, token).ConfigureAwait(false);
        }
    }
}
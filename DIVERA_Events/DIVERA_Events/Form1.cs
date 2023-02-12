using Client;
using Microsoft.Extensions.Configuration;
using Extensions;

namespace DIVERA_Events
{
    public partial class Form1 : Form
    {
        EventClient eventClient;
        AppConfig config;

        public Form1()
        {
            config = Program.Configuration.GetSection("app").Get<AppConfig>();
            InitializeComponent();
            var clientConfig = Program.Configuration.GetSection("client").Get<ClientConfig>();
            eventClient = new EventClient(clientConfig);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Text = config?.AppName;     
        }

        private async void export_events_click(object sender, EventArgs e)
        {
           await  DoExport();
        }

        async Task DoExport()
        {
            var dialog = new FolderBrowserDialog();

            string totalpath;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var exportPath = dialog.SelectedPath;
                totalpath = $"{exportPath}\\Events_{DateTime.Now:yyyyMMdd_HHmm}.csv";
                if (File.Exists(totalpath))
                {
                    MessageBox.Show($"ExportDatei [{totalpath}] existiert bereits!");
                    return;
                }
            }
            else return;

            try
            {
                var events = await eventClient.EventsGETAsync();

                if (!events.Data.Items.Any())
                {
                    MessageBox.Show($"Es wurden keine Events gefunden!");
                    return;
                }

                using (StreamWriter sw = File.CreateText(totalpath))
                {
                    foreach (var csvline in events.Data.Items.Values.Select(s => (CSVEvent)s).ToCsv(config.CsvSeparator, config.CsvSeparatorAlternative, true))
                    {
                        await sw.WriteLineAsync(csvline);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }   
        }
    }
}
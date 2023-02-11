using Client;

namespace DIVERA_Events
{
    public partial class Form1 : Form
    {
        EventClient eventClient;
        public Form1()
        {
            InitializeComponent();
            eventClient = new EventClient();
        }

        private void export_events_click(object sender, EventArgs e)
        {
            
        }
    }
}
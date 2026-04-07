using K3d.MyOrg.Core.Logging;

namespace MyOrg
{
    public partial class LogForm : Form
    {
        private readonly Logger _logger;

        public LogForm(Logger logger)
        {
            _logger = logger
                ?? throw new ArgumentNullException(nameof(logger));

            _logger.Message += (sender, args) =>
            {
                uiLogTextBox.AppendText(args.Message);
            };

            InitializeComponent();
        }

        private void uiClearMenuItem_Click(object sender, EventArgs e)
        {
            uiLogTextBox.Clear();
        }

        private void LogForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }
    }
}

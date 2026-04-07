using K3d.MyOrg.Application;
using K3d.MyOrg.Core.Logging;
using K3d.MyOrg.DataAccess;

namespace MyOrg
{
    public partial class MainForm : Form
    {
        private FolderDataProvider? _dataProvider;
        private UseCaseFactory? _useCaseFactory;
        private readonly Logger _logger = new();
        private LogForm _logForm;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            _logForm = new LogForm(_logger);
        }

        private void uiQuitMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void uiOpenDataBaseMenuItem_Click(object sender, EventArgs e)
        {
            var openDbFolderDialog = new OpenDbFolderDialog();

            if (openDbFolderDialog.ShowDialog() == DialogResult.OK)
            {
                _dataProvider = new FolderDataProvider(_logger, openDbFolderDialog.DbFolder);
                _dataProvider.Open();

                _useCaseFactory = new UseCaseFactory(_logger, _dataProvider);

                EnableInterface(true);
            }
        }

        private void uiSpendingsMenuItem_Click(object sender, EventArgs e)
        {
            var spendingsForm = new SpendingsForm(_useCaseFactory!.Spendings);

            spendingsForm.MdiParent = this;
            spendingsForm.Show();
        }

        private void uiLogMenuItem_Click(object sender, EventArgs e)
        {
            _logForm.MdiParent = this;
            _logForm.Show();
        }

        private void EnableInterface(bool enable)
        {
            uiSpendingsMenuItem.Enabled = enable;
        }
    }
}

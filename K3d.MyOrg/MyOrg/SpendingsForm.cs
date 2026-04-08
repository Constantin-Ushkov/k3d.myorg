using K3d.MyOrg.Application.Interface.Spendings;
using K3d.MyOrg.Domain.Spendings;

namespace MyOrg
{
    public partial class SpendingsForm : Form
    {
        private readonly ISpendingsUseCaseFactory _useCaseFactory;

        public SpendingsForm(ISpendingsUseCaseFactory useCaseFactory)
        {
            _useCaseFactory = useCaseFactory
                ?? throw new ArgumentNullException(nameof(useCaseFactory));

            InitializeComponent();
        }

        private void SpendingsForm_Shown(object sender, EventArgs e)
        {
            var useCase = _useCaseFactory.CreateGetOverviewReportUseCase();
            var report = useCase.Execute();

            UpdateGui(report);
        }

        private void UpdateGui(SpendingsOverview report)
        {
            if (report.CurrentYearSpendings != null)
            {
                uiTotalSpentYearLabel.Text = report.CurrentYearSpendings.Total.ToString();

                foreach (var category in report.CurrentYearSpendings.TotalByCategory)
                {
                    uiTotalSpentYearListBox.Items.Add(string.Format("{0}: {1}", category.Key, category.Value));
                }
            }

            if (report.CurrentMonthSpendings != null)
            {
                uiTotalSpentMonthLabel.Text = report.CurrentMonthSpendings.Total.ToString();

                foreach (var category in report.CurrentMonthSpendings.TotalByCategory)
                {
                    uiTotalSpentMonthListBox.Items.Add(string.Format("{0}: {1}", category.Key, category.Value));
                }
            }

            if (report.CurrentWeekSpendings != null)
            {
                uiTotalSpentWeekLabel.Text = report.CurrentWeekSpendings.Total.ToString();

                foreach (var category in report.CurrentWeekSpendings.TotalByCategory)
                {
                    uiTotalSpentWeekListBox.Items.Add(string.Format("{0}: {1}", category.Key, category.Value));
                }
            }
        }
    }
}

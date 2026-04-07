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
            //
        }
    }
}

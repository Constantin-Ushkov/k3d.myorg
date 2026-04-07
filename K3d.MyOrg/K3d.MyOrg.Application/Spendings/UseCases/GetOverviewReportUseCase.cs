using K3d.MyOrg.Application.Interface.Spendings.UseCases;
using K3d.MyOrg.DataAccess.Interface.Spendings;
using K3d.MyOrg.Domain.Spendings;

namespace K3d.MyOrg.Application.Spendings.UseCases
{
    internal class GetOverviewReportUseCase : IGetOverviewReportUseCase
    {
        private readonly ISpendingsDataProvider _spendingsDataProvider;

        public GetOverviewReportUseCase(ISpendingsDataProvider spendingsDataProvider)
        {
            _spendingsDataProvider = spendingsDataProvider
                ?? throw new ArgumentNullException(nameof(spendingsDataProvider));
        }

        public SpendingsOverview Execute()
        {
            throw new NotImplementedException();
        }
    }
}

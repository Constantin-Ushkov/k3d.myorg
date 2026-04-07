using K3d.MyOrg.Application.Interface.Spendings;
using K3d.MyOrg.Application.Interface.Spendings.UseCases;
using K3d.MyOrg.Application.Spendings.UseCases;
using K3d.MyOrg.DataAccess.Interface.Spendings;

namespace K3d.MyOrg.Application.Spendings
{
    internal class SpendingsUseCaseFactory : ISpendingsUseCaseFactory
    {
        private readonly ISpendingsDataProvider _spendingsDataProvider;

        public SpendingsUseCaseFactory(ISpendingsDataProvider spendingsDataProvider)
        {
            _spendingsDataProvider = spendingsDataProvider
                ?? throw new ArgumentNullException(nameof(spendingsDataProvider));
        }

        public IGetOverviewReportUseCase CreateGetOverviewReportUseCase()
            => new GetOverviewReportUseCase(_spendingsDataProvider);
    }
}

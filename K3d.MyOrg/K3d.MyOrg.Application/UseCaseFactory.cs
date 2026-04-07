using K3d.MyOrg.Application.Interface;
using K3d.MyOrg.Application.Interface.Spendings;
using K3d.MyOrg.Application.Spendings;
using K3d.MyOrg.Core.Logging;
using K3d.MyOrg.DataAccess.Interface;

namespace K3d.MyOrg.Application
{
    public class UseCaseFactory : IUseCaseFactory
    {
        private readonly IDataProvider _dataProvider;
        private readonly ILogger _logger;

        public ISpendingsUseCaseFactory Spendings { get; }

        public UseCaseFactory(ILogger logger, IDataProvider dataProvider)
        {
            _logger = logger
                ?? throw new ArgumentNullException(nameof(logger));

            _dataProvider = dataProvider
                ?? throw new ArgumentNullException(nameof(dataProvider));

            Spendings = new SpendingsUseCaseFactory(_dataProvider.SpendingsDataProvider);
        }
    }
}

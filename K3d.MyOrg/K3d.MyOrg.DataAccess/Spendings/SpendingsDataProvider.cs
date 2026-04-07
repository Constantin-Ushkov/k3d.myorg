using K3d.MyOrg.DataAccess.Interface.Spendings;
using K3d.MyOrg.Domain.Spendings;

namespace K3d.MyOrg.DataAccess.Spendings
{
    internal class SpendingsDataProvider : ISpendingsDataProvider
    {
        public SpendingsReport GetSpendingsReport(DateOnly fromDate, DateOnly toDate)
        {
            throw new NotImplementedException();
        }
    }
}

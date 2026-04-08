using K3d.MyOrg.Domain.Spendings;

namespace K3d.MyOrg.DataAccess.Interface.Spendings
{
    public interface ISpendingsDataProvider
    {
        SpendingsReport? GetSpendingsReport(DateOnly fromDate, DateOnly toDate);
    }
}


namespace K3d.MyOrg.Domain.Spendings
{
    public class SpendingsReport
    {
        DateOnly FromDate { get; }
        DateOnly ToDate { get; }

        uint Total { get; }
        IDictionary<string, uint> TotalByCategory { get; }

        IReadOnlyCollection<Spending> Spendings { get; }
    }
}

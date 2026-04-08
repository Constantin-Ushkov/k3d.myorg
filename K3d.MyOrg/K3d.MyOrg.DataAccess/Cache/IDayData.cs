using K3d.MyOrg.Domain.Spendings;

namespace K3d.MyOrg.DataAccess.Cache
{
    internal interface IDayData
    {
        int DayOfYear { get; }
        int DayOfMonth { get; }
        int DayOfWeek { get; }

        int Month { get; }
        int Year { get; }

        IList<Spending> Spendings { get; }
    }
}

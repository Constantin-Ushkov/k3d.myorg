
namespace K3d.MyOrg.Domain.Spendings
{
    public class SpendingsReport
    {
        public DateOnly FromDate { get; set; }
        public DateOnly ToDate { get; set; }

        public uint Total { get; set; }
        public Dictionary<string, uint> TotalByCategory { get; set; } = [];

        public List<Spending> Spendings { get; set; } = [];

        public SortedDictionary<uint, string> GetTotalByCategorySortedByAmount()
        {
            var sorted = new SortedDictionary<uint, string>(Comparer<uint>.Create((x, y) => y.CompareTo(x)));

            foreach (var category in TotalByCategory)
            {
                sorted[category.Value] = category.Key;
            }

            return sorted;
        }
    }
}

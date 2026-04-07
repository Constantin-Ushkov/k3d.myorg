using K3d.MyOrg.DataAccess.Interface.Spendings;

namespace K3d.MyOrg.DataAccess.Interface
{
    public interface IDataProvider
    {
        ISpendingsDataProvider SpendingsDataProvider { get; }
    }
}

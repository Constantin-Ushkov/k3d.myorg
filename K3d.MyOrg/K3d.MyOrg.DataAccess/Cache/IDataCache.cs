
namespace K3d.MyOrg.DataAccess.Cache
{
    internal interface IDataCache
    {
        IYearData? GetYear(int year);
    }
}

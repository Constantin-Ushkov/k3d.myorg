
using K3d.MyOrg.Core.Logging;

namespace K3d.MyOrg.DataAccess.Cache
{
    internal class DayData: IDayData
    {
        public int DayOfYear => throw new NotImplementedException();

        public int Month => throw new NotImplementedException();

        public int DayOfMonth => throw new NotImplementedException();

        public static DayData LoadFromFile(ILogger logger, string filePath)
        {
            throw new NotImplementedException();
        }
    }
}

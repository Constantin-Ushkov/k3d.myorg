using System;
using System.Collections.Generic;
using System.Text;

namespace K3d.MyOrg.DataAccess.Cache
{
    internal interface IDayData
    {
        int DayOfYear { get; }
        int Month { get; }
        int DayOfMonth { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace K3d.MyOrg.DataAccess.Cache
{
    internal interface IYearData
    {
        int Year { get; }

        IDayData? GetDay(int dayOfYear);
        IDayData? GetDay(int month, int dayOfMonth);
    }
}

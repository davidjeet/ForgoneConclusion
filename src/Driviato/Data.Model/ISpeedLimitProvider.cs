using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public interface ISpeedLimitProvider
    {
        Int32 GetSpeedLimit(double latitude, double longitude);
    }
}

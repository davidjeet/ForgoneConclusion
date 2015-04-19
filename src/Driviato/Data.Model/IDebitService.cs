using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public interface IDebitService
    {
        void DebitAccount(String customerId, String token, Decimal amount);
    }
}

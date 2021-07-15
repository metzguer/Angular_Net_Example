using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contracts.PaymentDetails
{
    public interface IPaymentDetailRepository<T> : IBaseRepository<T> where T : class
    {
    }
}

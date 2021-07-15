using DataAccess.Contracts.PaymentDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.PaymentDetails
{
    public class PaymentDetailRepository<T> : BaseRepository<T>, IPaymentDetailRepository<T> where T : class
    {
        public PaymentDetailRepository(DbDataContext context) : base(context)
        {

        }
    }
}

using DataAccess.Contracts.PaymentDetails;
using DataAccess.Contracts.Persons;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    public interface IUnitOfWork
    {
        IPersonRepository<Person> _personRepository { get; }
        IPaymentDetailRepository<PaymentDetail> paymentDetailRepository { get; }

        Task<int> Save();
    }
}

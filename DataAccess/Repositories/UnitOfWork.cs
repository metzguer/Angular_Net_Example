using DataAccess.Contracts;
using DataAccess.Contracts.PaymentDetails;
using DataAccess.Contracts.Persons;
using DataAccess.Entities;
using DataAccess.Repositories.PaymentDetails;
using DataAccess.Repositories.Persons;
using System;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork, IAsyncDisposable
    {
        private readonly DbDataContext _context; 
        private IPersonRepository<Person> personRepository;
        private IPaymentDetailRepository<PaymentDetail> _paymentDetailRepository;

        public UnitOfWork( DbDataContext context )
        {
            _context = context;
        }

        //exposed resources
        public IPaymentDetailRepository<PaymentDetail> paymentDetailRepository { 
            get { return _paymentDetailRepository = _paymentDetailRepository ??  new PaymentDetailRepository<PaymentDetail>(_context); } 
        }

        public IPersonRepository<Person> _personRepository
        {
            get { return personRepository = personRepository ?? new PersonRepository<Person>(_context); }
        }

        public ValueTask DisposeAsync()
        {
            return _context.DisposeAsync();
        }

        public async Task<int> Save() =>  await _context.SaveChangesAsync();
         
 
    }
}

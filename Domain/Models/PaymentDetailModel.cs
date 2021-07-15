using DataAccess.Contracts; 

namespace Domain.Models
{
    public class PaymentDetailModel : PaymentDetailAggregate
    { 
        public PaymentDetailModel(IUnitOfWork repository) : base(repository)
        {
              
        } 

        public int PaymentDetailId { get => paymentDetailId; set => paymentDetailId = value; }
        public string CardOwnerName { get => cardOwnerName; set => cardOwnerName = value; }
        public string CardNumber { get => cardNumber; set => cardNumber = value; }
        public string ExpirationDate { get => expirationDate; set => expirationDate = value; }
        public string SecurityCode { get => securityCode; set => securityCode = value; }
         
    }
}

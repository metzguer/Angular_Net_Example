using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Net_Core_Angular.DTOs.PaymentDetails
{
    public class NewPaymentDetail
    {
        public string CardOwnerName { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
    }
}

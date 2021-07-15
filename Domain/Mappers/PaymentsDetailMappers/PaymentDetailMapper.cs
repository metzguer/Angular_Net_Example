using DataAccess.Entities;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mappers.PaymentsDetailMappers
{
    public static class PaymentDetailMapper
    {

        public static PaymentDetail SetPaymentdetail(PaymentDetailModel entity) {
            return new PaymentDetail {
                PaymentDetailId = entity.PaymentDetailId,
                CardOwnerName = entity.CardOwnerName,
                CardNumber = entity.CardNumber,
                ExpirationDate = entity.ExpirationDate,
                SecurityCode = entity.SecurityCode
            };
        }

        public static PaymentDetailModel GetPaymentdetail(PaymentDetail entity)
        {
            return new PaymentDetailModel (null){
                PaymentDetailId = entity.PaymentDetailId,
                CardOwnerName = entity.CardOwnerName,
                CardNumber = entity.CardNumber,
                ExpirationDate = entity.ExpirationDate,
                SecurityCode = entity.SecurityCode
            };
        }
    }
}

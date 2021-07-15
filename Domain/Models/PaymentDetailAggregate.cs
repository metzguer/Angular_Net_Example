using DataAccess.Contracts;
using DataAccess.Entities;
using Domain.Mappers.PaymentsDetailMappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class PaymentDetailAggregate
    {
        private readonly IUnitOfWork _repository;
        public PaymentDetailAggregate(IUnitOfWork repository)
        {
            _repository = repository;
            PaymentDetailsModel = new List<PaymentDetailModel>();
        }
        protected int paymentDetailId;
        protected string cardOwnerName;
        protected string cardNumber;
        protected string expirationDate;
        protected string securityCode;


        public List<PaymentDetailModel> PaymentDetailsModel;
        public EntityState State { private get; set; }

        public async Task<List<PaymentDetailModel>> GetAll()
        {

            var result = await _repository.paymentDetailRepository.GetAll();
            PaymentDetailsModel = new List<PaymentDetailModel>();

            foreach (var item in result.ToList())
            { 
                PaymentDetailsModel.Add(new PaymentDetailModel(null)
                {
                    paymentDetailId = item.PaymentDetailId,
                    cardOwnerName = item.CardOwnerName,
                    cardNumber = item.CardNumber,
                    expirationDate = item.ExpirationDate,
                    securityCode = item.SecurityCode
                });
            }

            return PaymentDetailsModel;
        }

        public async Task<bool> SavePaymentDetail() {

            try
            { 
                if (State == EntityState.Added)
                {
                    var newPayment = new DataAccess.Entities.PaymentDetail
                    {
                        CardOwnerName = cardOwnerName,
                        CardNumber = cardNumber,
                        ExpirationDate = expirationDate,
                        SecurityCode = securityCode
                    };

                    await _repository.paymentDetailRepository.Add(newPayment);
                    await _repository.Save();
                    return true;
                }
                if (State == EntityState.Modified)
                {
                    var updatePayment = new DataAccess.Entities.PaymentDetail
                    {
                        PaymentDetailId = paymentDetailId,
                        CardOwnerName = cardOwnerName,
                        CardNumber = cardNumber,
                        ExpirationDate = expirationDate,
                        SecurityCode = securityCode
                    };

                    await _repository.paymentDetailRepository.Update(updatePayment);
                    await _repository.Save();
                    return true;
                }
                else {
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<PaymentDetail> SearchPaymentDetail()
        { 
            try
            {  
                return await _repository.paymentDetailRepository.Get(paymentDetailId);  
            }
            catch (Exception)
            { 
                return null;
            }
        }

        public async Task<bool> RemovePaymentDetail()
        {
            try
            {
                if (EntityState.Deleted == State) {
                    await _repository.paymentDetailRepository.Delete(paymentDetailId);
                    await _repository.Save();
                    return true;
                }
                return false;
            }
            catch (Exception)
            { 
                return false;
            }
        }
    }
}

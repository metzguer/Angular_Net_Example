using API_Net_Core_Angular.DTOs.PaymentDetails;
using DataAccess.Contracts;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Net_Core_Angular.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentDetailController : ControllerBase
    {
        private readonly PaymentDetailModel _paymentsModel;
        public PaymentDetailController(PaymentDetailModel payments)
        {
            _paymentsModel = payments;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var items = await _paymentsModel.GetAll(); 
            return Ok(items);
        }

        [HttpPost]
        public async Task<ActionResult> SavePaymentDetail(NewPaymentDetail entity) {

            _paymentsModel.PaymentDetailId = 0;
            _paymentsModel.CardOwnerName = entity.CardOwnerName;
            _paymentsModel.CardNumber = entity.CardNumber;
            _paymentsModel.ExpirationDate = entity.ExpirationDate;
            _paymentsModel.SecurityCode = entity.SecurityCode;
            _paymentsModel.State = EntityState.Added;
            
            var result =  await _paymentsModel.SavePaymentDetail();
            return (result)? Ok() : BadRequest();
            //return (result) ? CreatedAtAction("GetPaymentDetail", new { id = _paymentsModel.PaymentDetailId }, _paymentsModel) : BadRequest();
        }

        [HttpGet("id")]
        public async Task<ActionResult> GetPaymentDetail(int id)
        { 
            _paymentsModel.PaymentDetailId = id;
            var result = await _paymentsModel.SearchPaymentDetail(); 
            return (result != null) ? Ok(result) : NotFound();
        }

        [HttpPut]
        public async Task<ActionResult> UpdatePaymentDetail(UpdatePaymentDetail entity) {

            _paymentsModel.PaymentDetailId = entity.PaymentDetailId;
            _paymentsModel.CardOwnerName = entity.CardOwnerName;
            _paymentsModel.CardNumber = entity.CardNumber;
            _paymentsModel.ExpirationDate = entity.ExpirationDate;
            _paymentsModel.SecurityCode = entity.SecurityCode;
            _paymentsModel.State = EntityState.Modified;
            var result = await _paymentsModel.SavePaymentDetail();

            return (result) ? Ok() : BadRequest();
            
        }

        [HttpDelete("id")]
        public async Task<ActionResult> DeletePaymentDetail(int id)
        { 
            _paymentsModel.PaymentDetailId = id;
            _paymentsModel.State = EntityState.Deleted;
            var result = await _paymentsModel.RemovePaymentDetail();

            return (result) ? NoContent() : BadRequest();

        }
    }
}

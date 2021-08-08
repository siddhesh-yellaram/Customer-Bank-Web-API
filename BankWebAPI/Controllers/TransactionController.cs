using BankLib.Model;
using BankLib.Service;
using BankWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BankWebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/v1/Transaction/{userName}")]
    public class TransactionController : ApiController
    {
        IBankService _service;
        public TransactionController(IBankService service)
        {
            _service = service;
        }

        [Route("DoTransaction")]
        public IHttpActionResult DoTransaction(string userName, TransactionDTO transactionDTO)
        {
            Account acc = _service.GetAccountByName(userName);

            if (acc == null)
            {
                return BadRequest("Please Login To Do Transaction");
            }

            Transaction transaction = new Transaction
            {
                TransactionId = Guid.NewGuid(),
                Amount = transactionDTO.Amount,
                TransactionType = transactionDTO.TransactionType,
                Date = DateTime.Now
            };

            bool transactionResult = _service.AddTransaction(acc, transaction);

            if (!transactionResult)
            {
                return BadRequest("Transaction Failed!!!");
            }

            return Ok("Transaction Successfull!!!");
        }

        [Route("GetTransaction")]
        public IHttpActionResult GeTransactionDetails(string userName)
        {
            var transaction = _service.GetTransactionByName(userName);

            if (transaction == null)
            {
                return BadRequest("Please Login To Check Transaction Details");
            }
            return Ok(transaction);
        }
    }
}

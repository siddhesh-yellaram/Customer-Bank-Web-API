using BankLib.Model;
using BankLib.Repository;
using BankLib.Service;
using BankWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BankWebAPI.Controllers
{
    [EnableCors(origins:"*",headers:"*",methods:"*")]
    [RoutePrefix("api/v1/UserAuth")]
    public class BankController : ApiController
    {
        IBankService _service;
        public BankController(IBankService service)
        {
            _service = service;
        }

        [Route("Register")]
        public IHttpActionResult RegisterUser(RegisterDTO register)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please Fill All Details");
            }

            string hashPassword = GenrateHashPassword(register.Password);
            Account acc = new Account { UserName = register.UserName, Balance = register.Balance, Password = hashPassword };
            Transaction transaction = new Transaction
            {
                TransactionId = Guid.NewGuid(),
                Amount = register.Balance,
                TransactionType = "D",
                Date = DateTime.Now,
                Account = acc
            };

            if (_service.RegisterBankAccount(acc, transaction))
            {
                return Ok("Successfully Registered");
            }

            return BadRequest("Please Try Again");
        }

        [Route("Login")]
        public IHttpActionResult LoginUser(LoginDTO login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please Fill All Details");
            }

            Account acc = _service.GetAccountByName(login.UserName);
            string hashPassword = GenrateHashPassword(login.Password);

            if (acc != null && hashPassword == acc.Password)
            {
                return Ok("Login Successful!!");
            }
            return BadRequest("Invalid Credentials!!");
        }
        private string GenrateHashPassword(string password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] passwordBytes = Encoding.ASCII.GetBytes(password);
            byte[] encryptedPasswordBytes = md5.ComputeHash(passwordBytes);
            return Convert.ToBase64String(encryptedPasswordBytes);
        }
    }
}

using BankLib.Model;
using BankLib.Service;
using BankWebAPI.Controllers;
using BankWebAPI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Security.Cryptography;
using System.Text;

namespace CustomerBankAPIUnitTesting
{
    [TestClass]
    public class APITesting
    {
        //    BankController _ctrl;
        //    IBankService _service;
        //    public APITesting()
        //    {
        //        _service = new BankService();
        //        _ctrl = new BankController(_service);
        //    }

        //    [TestMethod]
        //    public void TestLoginSuccessfull()
        //    {
        //        LoginDTO lg;
        //        Account acc = _service.GetAccountByName(lg.UserName);
        //        string hashPassword = GenrateHashPassword(lg.Password);
        //        if (acc != null && hashPassword == acc.Password)
        //        {
        //            var res = OkNegotiatedContentResult<Account>;
        //        }
        //        return BadRequest("Invalid Credentials!!");
        //    }

        //    private string GenrateHashPassword(string password)
        //    {
        //        MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
        //        byte[] passwordBytes = Encoding.ASCII.GetBytes(password);
        //        byte[] encryptedPasswordBytes = md5.ComputeHash(passwordBytes);
        //        return Convert.ToBase64String(encryptedPasswordBytes);
        //    }
    }
}

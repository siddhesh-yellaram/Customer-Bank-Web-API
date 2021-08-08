using BankLib.Service;
using BankWebAPI.Controllers;
using BankWebAPI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Http;

namespace CustomerBankAPIUnitTesting
{
    [TestClass]
    public class BankControllerTest
    {
        [TestMethod]
        public void TestForValidatingLogin()
        {
            BankController bc = new BankController(new BankService());
            LoginDTO lg = new LoginDTO { UserName = "abc", Password = "1234"};
            IHttpActionResult res = bc.LoginUser(lg);
            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void TestForValidatingRegister()
        {
            BankController bc = new BankController(new BankService());
            RegisterDTO rg = new RegisterDTO { UserName = "sid", Password = "9876", RePassword = "9876", Balance = 4500 };
            IHttpActionResult res = bc.RegisterUser(rg);
            Assert.IsNotNull(res);
        }
    }
}

using BankLib.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLib.Service
{
    public interface IBankService
    {
        List<Account> GetAccounts();
        bool RegisterBankAccount(Account acc, Transaction transaction);
        Account GetAccountByName(string userName);
        IEnumerable GetTransactionByName(string userName);
        bool AddTransaction(Account acc, Transaction transaction);
    }
}

using BankLib.Model;
using BankLib.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLib.Service
{
    public class BankService:IBankService
    {
        private IBankRepository<Account> _accRepo;
        public BankService()
        {
            _accRepo = new BankRepository<Account>();
        }
        public bool AddTransaction(Account acc, Transaction transaction)
        {
            if (transaction.TransactionType == "D")
            {
                acc.Balance = acc.Balance + transaction.Amount;
                acc.Transactions.Add(transaction);
                return _accRepo.UpdateUser(acc);
            }
            else if (transaction.TransactionType == "W" && acc.Balance - transaction.Amount >= 500)
            {
                acc.Balance = acc.Balance - transaction.Amount;
                acc.Transactions.Add(transaction);
                return _accRepo.UpdateUser(acc);
            }
            return false;
        }
        public Account GetAccountByName(string userName)
        {
            return _accRepo.GetUserByName(userName);
        }

        public List<Account> GetAccounts()
        {
            return _accRepo.GetAllUsers();
        }

        public IEnumerable GetTransactionByName(string userName)
        {
            Account acc = _accRepo.GetUserByName(userName);
            return acc.Transactions.ToList().Select(t => new { t.TransactionId, t.Amount, t.TransactionType, t.Date });
        }

        public bool RegisterBankAccount(Account acc, Transaction transaction)
        {
            acc.Transactions = new List<Transaction>();
            acc.Transactions.Add(transaction);
            return _accRepo.AddUser(acc);
        }
    }
}

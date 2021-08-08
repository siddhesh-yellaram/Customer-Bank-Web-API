using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLib.Model
{
    public class Account
    {
        [Key]
        public string UserName { get; set; }
        public string Password { get; set; }
        public double Balance { get; set; }
        public virtual List<Transaction> Transactions { get; set; }
    }
}

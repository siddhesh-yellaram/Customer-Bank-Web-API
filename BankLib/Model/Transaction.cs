using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLib.Model
{
    public class Transaction
    {
        [Key]
        public Guid TransactionId { get; set; }
        public double Amount { get; set; }
        public string TransactionType { get; set; }
        public DateTime Date { get; set; }
        public virtual Account Account { get; set; }
    }
}

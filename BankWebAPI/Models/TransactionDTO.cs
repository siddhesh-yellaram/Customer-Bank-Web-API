using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankWebAPI.Models
{
    public class TransactionDTO
    {
        [Required]
        public double Amount { get; set; }
        [Required]
        public string TransactionType { get; set; }
    }
}
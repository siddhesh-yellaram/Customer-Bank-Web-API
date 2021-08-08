using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankWebAPI.Models
{
    public class RegisterDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string RePassword { get; set; }
        [Required]
        [Range(1000, Double.MaxValue, ErrorMessage = "Balance Should Be Atleast 1000")]
        public double Balance { get; set; }
    }
}
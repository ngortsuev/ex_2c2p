using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransactionService.Models
{
    public class Transaction
    {
        public string Id { get; set; }
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }
}

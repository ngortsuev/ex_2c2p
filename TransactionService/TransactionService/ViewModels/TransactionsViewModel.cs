using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using TransactionService.Models;

namespace TransactionService.ViewModels
{
    public class TransactionsViewModel
    {
        public IEnumerable<Transaction> List { get; set; }
        public bool CurrencyFlag { get; set; }
        public bool DateFlag { get; set; }
        public bool StatusFlag { get; set; }
        public string SelectedCurrency { get; set; }
        public string SelectedDate { get; set; }
        public string SelectedStatus { get; set; }
        
        public SelectList CurrencyList { get; set; }
        public SelectList StatusList { get; set; }
    }
}

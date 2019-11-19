using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TransactionService.Domain;

namespace TransactionService.Controllers
{
    public class TransactionsController : Controller
    {
        private TransactionDb db;

        public TransactionsController(TransactionDb transactionDb)
        {
            db = transactionDb;
        }

        public IActionResult Index()
        {
            return View(db.Transactions);
        }
    }
}
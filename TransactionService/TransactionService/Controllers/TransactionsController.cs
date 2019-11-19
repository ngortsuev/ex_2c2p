using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TransactionService.Domain;
using TransactionService.ViewModels;

namespace TransactionService.Controllers
{
    public class TransactionsController : Controller
    {
        private TransactionDb db;

        public TransactionsController(TransactionDb transactionDb)
        {
            db = transactionDb;
        }

        public IActionResult Index(TransactionsViewModel model)
        {
            if(model == null)
                model = new TransactionsViewModel();

            if (model.SelectedStatus != null)
            {
                model.List = db.Transactions.Where(t => (model.FlagStatus && t.Status == model.SelectedStatus));
            }
            else
            {
                model.List = db.Transactions;
            }
            model.StatusList = new SelectList(db.Transactions.Select(c => new { Name = c.Status }).Distinct().ToList(), "Name", "Name");
            model.CurrencyList = new SelectList(db.Transactions.Select(c => new { Name = c.CurrencyCode }).Distinct().ToList(), "Name", "Name");
            return View(model);
        }
    }
}
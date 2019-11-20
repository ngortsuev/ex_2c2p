using System;
using System.Collections.Generic;
using System.Globalization;
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

            var list = db.Transactions.AsQueryable();

            if (model.FlagStatus && model.SelectedStatus != null)            
                list = list.Where(t => t.Status == model.SelectedStatus);

            if (model.FlagCurrency && model.SelectedCurrency != null)
                list = list.Where(t => t.CurrencyCode == model.SelectedCurrency);

            if (model.FlagDate && model.SelectedDate != null)
            {
                DateTime date;

                if(DateTime.TryParse(model.SelectedDate, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal, out date))
                {
                    list = list.Where(t => t.Date >= date);
                }
            }
            model.List = list;
            model.StatusList = new SelectList(db.Transactions.Select(c => new { Name = c.Status }).Distinct().ToList(), "Name", "Name");
            model.CurrencyList = new SelectList(db.Transactions.Select(c => new { Name = c.CurrencyCode }).Distinct().ToList(), "Name", "Name");
            return View(model);
        }
    }
}
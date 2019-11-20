using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransactionAPI.Domain;
using ParserLib.Models;
using System.Globalization;

namespace TransactionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private TransactionDb db;

        public TransactionsController(TransactionDb transactionDb)
        {
            db = transactionDb;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Transaction>> Get(Dictionary<string,string> filter = null)
        {
            var list = db.Transactions.AsQueryable();

            if (filter == null) return list.ToList();

            string value;

            if (filter.TryGetValue("Status", out value)) list = list.Where(t => t.Status == value);

            if (filter.TryGetValue("Currency", out value)) list = list.Where(t => t.CurrencyCode == value);

            if (filter.TryGetValue("Date", out value))
            {
                DateTime date;

                if (DateTime.TryParse(value, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal, out date))
                {
                    list = list.Where(t => t.Date >= date);
                }
            }
            
            return list.ToList();
        }
    }
}
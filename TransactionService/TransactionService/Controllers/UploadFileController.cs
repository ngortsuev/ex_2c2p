using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransactionService.Domain;
using ParserLib.Concrete;
using ParserLib.Models;

namespace TransactionService.Controllers
{
    public class UploadFileController : Controller
    {
        private TransactionDb db;

        public UploadFileController(TransactionDb transactionDb)
        {
            db = transactionDb;
        }

        [HttpGet]
        public IActionResult Index() => View();

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            var provider = new SimpleParserProvider();

            var parser = provider.GetParser(file);

            var list = await parser.Parse();

            if(list != null && list.Count != 0)
            {
                db.Transactions.AddRange(list);
                db.SaveChanges();

                return Ok(new { message = "upload success", filesize = file.Length });
            }            

            return Ok(new { message = "upload failed" });
        }
    }
}
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransactionService.Models;
using TransactionService.Domain;

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
            List<Transaction> list = null;
            if(file?.Length > 0)
            {
                string ext = Path.GetExtension(file.FileName);

                using (var stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);

                    if (ext == ".csv")
                        list = CSVParser.ConvertCSVtoList(stream);
                    
                    if (ext == ".xml")
                        list = XMLParser.ConvertCSVtoList(stream);

                    if(list != null && list.Count != 0)
                    {
                        db.Transactions.AddRange(list);
                        db.SaveChanges();
                    }
                }
                return Ok(new { message = "upload success", filesize = file.Length });
            }

            return Ok(new { message = "upload failed" });
        }
    }
}
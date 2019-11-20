using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using Microsoft.AspNetCore.Http;
using ParserLib.Models;
using ParserLib.Abstract;

namespace ParserLib
{
    public class CSVParser : BaseParser
    {
        public CSVParser(IFormFile file) : base(file) { }

        public override async Task<List<Transaction>> Parse()
        {
            DateTime date;

            await LoadData();

            if (memory.Length == 0) return null;

            var list = new List<Transaction>();

            using (var sr = new StreamReader(memory, Encoding.ASCII))
            {                                
                while (!sr.EndOfStream)
                {
                    string[] rows = sr.ReadLine().Split(';');

                    if (rows.Length == 5)
                    {
                        var tr = new Transaction();

                        tr.Id = rows[0];
                        tr.Amount = Convert.ToDouble(rows[1]);
                        tr.CurrencyCode = rows[2];
                        if(DateTime.TryParse(rows[3], CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal, out date))
                        { 
                            tr.Date = date;
                        }
                        tr.Status = rows[4];
                        
                        list.Add(tr);
                    }
                }
            }            

            return list;
        }
    }
}

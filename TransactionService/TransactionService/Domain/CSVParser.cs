using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionService.Models;

namespace TransactionService.Domain
{
    public class CSVParser
    {
        public static List<Transaction> ConvertCSVtoList(MemoryStream memoryStream)
        {
            memoryStream.Position = 0;
            List<Transaction> list = new List<Transaction>();

            using (var sr = new StreamReader(memoryStream, Encoding.ASCII))
            {                                
                while (!sr.EndOfStream)
                {
                    string[] rows = sr.ReadLine().Split(';');

                    if (rows.Length == 5)
                    {
                        var tr = new Transaction()
                        {
                            Id = rows[0],
                            Amount = Convert.ToDouble(rows[1]),
                            CurrencyCode = rows[2],
                            Date = Convert.ToDateTime(rows[3]),
                            Status = rows[4]
                        };
                        list.Add(tr);
                    }
                }
            }            

            return list;
        }
    }
}

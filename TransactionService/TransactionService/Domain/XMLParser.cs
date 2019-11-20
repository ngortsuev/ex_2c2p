using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using TransactionService.Models;
using TransactionService.Domain.Abstract;
using Microsoft.AspNetCore.Http;

namespace TransactionService.Domain
{
    public class XMLParser : BaseParser
    {        
        public XMLParser(IFormFile file) : base(file) { }

        public override async Task<List<Transaction>> Parse()
        {
            await LoadData();

            if (memory.Length == 0) return null;

            var list = new List<Transaction>();            
            var xml = new XmlDocument();

            xml.Load(memory);

            XmlElement root = xml.DocumentElement;

            foreach(XmlNode node in root)
            {
                var tr = new Transaction();

                tr.Id = node.Attributes[0].Value;

                foreach(XmlNode child in node.ChildNodes)
                {
                    switch (child.Name)
                    {
                        case "TransactionDate":
                            tr.Date = Convert.ToDateTime(child.LastChild.Value);
                            break;

                        case "PaymentDetails":
                            tr.Amount = Convert.ToDouble(child["Amount"].LastChild.Value, CultureInfo.InvariantCulture);
                            tr.CurrencyCode = child["CurrencyCode"].LastChild.Value;
                            break;

                        case "Status":
                            tr.Status = child.LastChild.Value;
                            break;
                    }                    
                }
                list.Add(tr);
            }            

            return list;
        }
    }
}

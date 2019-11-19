using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionService.Models;
using System.Globalization;

namespace TransactionService.Domain
{
    public class XMLParser
    {
        public static List<Transaction> ConvertCSVtoList(MemoryStream memoryStream)
        {
            memoryStream.Position = 0;

            List<Transaction> list = new List<Transaction>();            
            
            XmlDocument xml = new XmlDocument();

            xml.Load(memoryStream);

            XmlElement root = xml.DocumentElement;

            foreach(XmlNode node in root)
            {
                var tr = new Transaction();

                tr.Id = node.Attributes[0].Value;

                foreach(XmlNode child in node.ChildNodes)
                {
                    if(child.Name == "TransactionDate")
                    {
                        tr.Date = Convert.ToDateTime(child.LastChild.Value);
                    }
                    if(child.Name == "PaymentDetails")
                    {
                        tr.Amount = Convert.ToDouble(child["Amount"].LastChild.Value, CultureInfo.InvariantCulture);

                        tr.CurrencyCode = child["CurrencyCode"].LastChild.Value;
                    }
                    if(child.Name == "Status")
                    {
                        tr.Status = child.LastChild.Value;
                    }
                }
                list.Add(tr);
            }            

            return list;
        }
    }
}

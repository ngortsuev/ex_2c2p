using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TransactionService.Domain.Abstract;

namespace TransactionService.Domain.Concrete
{
    public class SimpleParserProvider : IParserProvider
    {
        public IParser GetParser(IFormFile file)
        {
            string ext = Path.GetExtension(file.FileName);

            switch (ext)
            {
                case ".csv": return new CSVParser(file);
                case ".xml": return new XMLParser(file);
            }

            return null;
        }
    }
}

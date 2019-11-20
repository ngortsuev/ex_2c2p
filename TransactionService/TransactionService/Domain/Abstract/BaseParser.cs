using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionService.Models;

namespace TransactionService.Domain.Abstract
{
    public abstract class BaseParser : IParser
    {
        protected IFormFile file;
        protected MemoryStream memory;

        public BaseParser(IFormFile file)
        {
            this.file = file;

            memory = new MemoryStream();
        }

        protected async Task LoadData()
        {
            if (file == null || file.Length == 0) return;            

            await file.CopyToAsync(memory);

            memory.Position = 0;            
        }

        public abstract Task<List<Transaction>> Parse();
    }
}

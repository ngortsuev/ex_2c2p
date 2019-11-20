using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TransactionService.Models;

namespace TransactionService.Domain.Abstract
{
    public interface IParser
    {
        Task<List<Transaction>> Parse();
    }
}

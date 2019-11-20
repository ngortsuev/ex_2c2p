using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ParserLib.Models;

namespace ParserLib.Abstract
{
    public interface IParser
    {
        Task<List<Transaction>> Parse();
    }
}

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParserLib.Abstract
{
    public interface IParserProvider
    {
        IParser GetParser(IFormFile file);
    }
}

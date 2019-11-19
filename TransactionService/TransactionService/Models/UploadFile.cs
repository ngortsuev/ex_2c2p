using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace TransactionService.Models
{
    public class FileUpload
    {
        [Required]
        [Display(Name = "File")]
        public IFormFile FormFile { get; set; }

        [Display(Name = "Note")]
        [StringLength(50, MinimumLength = 0)]
        public string Note { get; set; }
    }

    public class UploadFile
    {
        private readonly long fileSize;
        private readonly string[] extensions = { ".csv", ".xml" };
        private readonly string targetPath;

        public UploadFile()
        {
            fileSize = 2097152;
            targetPath = @"C:\files";
        }

        [BindProperty]
        public FileUpload FileUpload { get; set; }

        public string Result { get; private set; }

        public void OnGet()
        {
        }
    }
}

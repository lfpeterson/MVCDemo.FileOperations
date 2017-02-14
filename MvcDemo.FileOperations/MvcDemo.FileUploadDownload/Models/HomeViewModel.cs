using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcDemo.FileUploadDownload.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Document> Documents { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcDemo.FileUploadDownload.Models
{
    public enum DocumentType
    {
        PdfUpload,
        DocuSign
    }
    public class Document
    {
        public string DocumentId { get; set; }

        public DocumentType DocumentType { get; set; }

        public string DocumentName { get; set; }

        public string Template { get; set; }

        public string UploadedFileName { get; set; }

        public bool FileUploaded { get { return !string.IsNullOrWhiteSpace(UploadedFileName); } }

        public bool HasTemplate { get { return !string.IsNullOrWhiteSpace(Template); } }
    }
}
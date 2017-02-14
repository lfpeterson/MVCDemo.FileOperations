using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcDemo.FileUploadDownload.Models;

namespace MvcDemo.FileUploadDownload.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var vm = new HomeViewModel();
            vm.Documents = DemoInitialDocuments();

            return View(vm);
        }

        private static List<Document> DemoInitialDocuments()
        {
            return new List<Document>()
            {
                new Document()
                {
                    DocumentId = "1",
                    DocumentType = DocumentType.PdfUpload,
                    DocumentName = "Application Form",
                    Template = "Application.pdf",
                    UploadedFileName = "Application_JaneDoe.pdf"
                    
                },
                new Document()
                {
                    DocumentId = "2",
                    DocumentType = DocumentType.PdfUpload,
                    DocumentName = "Employment History",
                    Template = "EmploymentHistory.pdf",
                    UploadedFileName = "EmploymentHistory_JaneDoe.pdf"
                },
                new Document()
                {
                    DocumentId = "3",
                    DocumentType = DocumentType.PdfUpload,
                    DocumentName = "Residence History",
                    Template = "ResidenceHistory_JaneDoe.pdf"
                },
                new Document()
                {
                    DocumentId = "4",
                    DocumentType = DocumentType.PdfUpload,
                    DocumentName = "Copy of Driver's License, State Id or Passport",
                },
                new Document()
                {
                    DocumentId = "5",
                    DocumentType = DocumentType.PdfUpload,
                    DocumentName = "Proof of Income",
                },

            };
        }

        [HttpPost]
        public JsonResult UploadFile()
        {
            var fileName = string.Empty;
            try
            {
                var fileContent = Request.Files[0];
                if (fileContent != null && fileContent.ContentLength > 0)
                {
                    fileName = Path.GetFileName(fileContent.FileName);
                    var savedFile = Path.Combine(Server.MapPath("~/Uploads/"), fileName);
                    fileContent.SaveAs(savedFile);
                }
            }
            catch (Exception)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Upload Failed");
            }

            return Json(fileName);
        }

        public PartialViewResult ReloadDocuments(string fileName)
        {
            var vm = new HomeViewModel();
            vm.Documents = DemoInitialDocuments();
            vm.Documents.First(d => !d.FileUploaded).UploadedFileName = fileName;
            return PartialView("~/Views/Home/_UploadedDocuments.cshtml", vm);
        }

    }


}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientApplication.Controllers
{
    public class FileController : Controller
    {
        [HttpGet]
        public ActionResult SaveFiles()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveFiles(HttpPostedFileBase UploadedFile)
        {
            if (UploadedFile.ContentLength > 0)
            {
                string EncryptFileName = Path.GetFileName(UploadedFile.FileName);
                string FolderPath = Path.Combine(Server.MapPath("~/UploadedFiles"), EncryptFileName);

                UploadedFile.SaveAs(FolderPath);
            }

            ViewBag.Message = "Vos fichiers ont été insérés avec succès";

            return View();
        }
    }
}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace birSifirUcuzaUc.WebUI.Admin2
{
    /// <summary>
    /// Summary description for ImageUpload
    /// </summary>
    public class ImageUpload : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";

            var postedFile = context.Request.Files[0];

            var path = context.Server.MapPath("~/ArticleImages");
            DirectoryInfo pathFolder = new DirectoryInfo(path);

            if (pathFolder.Exists)
            {
                var file = new FileInfo(postedFile.FileName);
                var fileExtension = file.Extension;

                string tarih = DateTime.Now.ToString("ddMMyyyy#HHmm#");
                string fileName = tarih + postedFile.FileName;

                string saveFile = string.Format(path + "/" + fileName);

                postedFile.SaveAs(saveFile);

                context.Response.Write(JsonConvert.SerializeObject(new { status = 200, msg = "File has been uploaded successfully", fileName = postedFile.FileName, savePath = "~/ArticleImages/" + postedFile.FileName }));
            }
            else
            {
                context.Response.Write(JsonConvert.SerializeObject(new { status = 500, msg = "Kök dizin bulunamadi." }));
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
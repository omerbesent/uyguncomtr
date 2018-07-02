
//<%@ WebHandler Language="C#" Class="Upload" %>

using System;
using System.Web;
using System.IO;


namespace birSifirUcuzaUc.WebUI.Admin
{
    /// <summary>
    /// Summary description for Upload
    /// </summary>
    public class Upload : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            context.Response.Expires = -1;


            try
            {
                HttpPostedFile postedFile2 = context.Request.Files["image"];
                HttpPostedFile postedFile =  context.Request.Files.Get(0) as HttpPostedFile;
                //HttpPostedFile postedFile = context.Request.Files["Filedata"];

                string savepath = "~/kapaklar";

                string tempPath = "~/kapaklar";

                tempPath = System.Configuration.ConfigurationManager.AppSettings["FolderPath"];

                savepath = context.Server.MapPath(tempPath);

                string filename = postedFile.FileName;

                if (!Directory.Exists(savepath))

                    Directory.CreateDirectory(savepath);

                postedFile.SaveAs(savepath + @"\" + filename);

                context.Response.Write(tempPath + "/" + filename);

                context.Response.StatusCode = 200;

                context.Response.Write("File Uploaded Successfully!");

            }

            catch (Exception ex)
            {

                context.Response.Write("Error: " + ex.Message);
                context.Response.Write("File ERROR!");

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
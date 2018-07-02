using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

//using Corendon.Custom.Data.Repository;
//using Corendon.Custom.WebPage.DefaultValue;
//using EAM.Web.WebServices.Context;

namespace birSifirUcuzaUc.WebUI.Admin
{
    /// <summary>
    /// Summary description for DocumentsScreenUpload
    /// </summary>
    public class DocumentsScreenUpload : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.Files.Count > 0)
            {
                #region upload edilecek dosyanin bilgilerini alma
                var jsonData = context.Request.QueryString["jsondata"];

                string pageCode, primaryCode, lineType, lineID, documentType, fileName, user, organization;

                var jsonParse = JObject.Parse(jsonData);

                pageCode = (jsonParse["pageCode"] != null ? Convert.ToString(jsonParse["pageCode"]) : "");
                primaryCode = (jsonParse["primaryCode"] != null ? Convert.ToString(jsonParse["primaryCode"]) : "");
                lineType = (jsonParse["lineType"] != null ? Convert.ToString(jsonParse["lineType"]) : "");
                lineID = (jsonParse["lineID"] != null ? Convert.ToString(jsonParse["lineID"]) : "");
                documentType = (jsonParse["documentType"] != null ? Convert.ToString(jsonParse["documentType"]) : "");
                fileName = (jsonParse["fileName"] != null ? Convert.ToString(jsonParse["fileName"]) : "");
                user = (jsonParse["user"] != null ? Convert.ToString(jsonParse["user"]) : "");
                organization = (jsonParse["organization"] != null ? Convert.ToString(jsonParse["organization"]) : "");

                #endregion

                try
                {
                    var documentsParentPath = string.Format(@"{0}\{1}", ConfigurationManager.AppSettings["DocumentsScreenFolder"]);

                    context.Response.ContentType = "application/json";
                    context.Response.Expires = -1;

                    var postedFile = context.Request.Files[0];

                    var file = new FileInfo(postedFile.FileName);
                    var fileExtension = file.Extension;

                    var fileFullName = string.Format("{0}#{1}#{2}#{3}{4}", primaryCode, lineID, documentType, fileName, fileExtension);
                    if (pageCode == "/Tasks.aspx")
                    {
                        fileFullName = string.Format("{0}{1}", lineID, fileExtension);
                    }
                    var fileFullPath = string.Format(@"{0}\{1}\{2}\{3}\{4}", documentsParentPath, organization, primaryCode, documentType);

                    if (!Directory.Exists(fileFullPath))
                        Directory.CreateDirectory(fileFullPath);

                    postedFile.SaveAs(string.Format(@"{0}\{1}", fileFullPath, fileFullName));

                    context.Response.Write(JsonConvert.SerializeObject(new { status = 200, msg = "File has been uploaded successfully", fileName = fileFullName }));

                }
                catch (Exception ex)
                {
                    context.Response.Write(JsonConvert.SerializeObject(new { status = 500, msg = ex.Message }));
                }
            }

            context.Response.End();
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
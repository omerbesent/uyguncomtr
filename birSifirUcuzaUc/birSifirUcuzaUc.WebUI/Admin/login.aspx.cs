using birSifirUcuzaUc.Data.Repository.Admin;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace birSifirUcuzaUc.WebUI.Admin
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        [WebMethod]
        public static string adminGiris(string kulAdi, string pass)
        {
            var result = new RepositoryLogin().KullaniciGetir(kulAdi, pass);
            
            if (result != null)
            {
                System.Web.HttpContext.Current.Session["login"] = result.logKulAdi;
                result.logPass = "";
                return JsonConvert.SerializeObject(new
                {
                    message = "success",
                    status = 200,
                    data = result
                });
            }
            else
                return JsonConvert.SerializeObject(new
                {
                    message = "Bir hata oluştu",
                    status = 500,
                    data = result
                });


        }


    }
}
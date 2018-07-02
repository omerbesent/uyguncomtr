using birSifirUcuzaUc.Data.Repository;
using birSifirUcuzaUc.Data.Tables;
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
    public partial class articleList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string makaleListesi()
        {
            var result = new RepositoryMakale().Makaleler();

            return JsonConvert.SerializeObject(new
            {
                message = "success",
                status = 200,
                data = result
            });


        }

        [WebMethod]
        public static string makaleSil(int makaleId)
        {
            var result = new RepositoryMakale().Sil(makaleId);

            if (result)
                return JsonConvert.SerializeObject(new
                {
                    message = "success",
                    status = 200,
                    data = result
                });
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
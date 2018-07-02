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

namespace birSifirUcuzaUc.WebUI.Admin2
{
    public partial class AddArticle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string makaleKaydet(string baslik, string icerik, string makaleId, string makaleKapakResmi)
        {
            if (string.IsNullOrWhiteSpace(makaleId))
            {
                var makale = new Makale()
                {
                    illerBaslik = baslik,
                    illerMakale = icerik,
                    illerKapakResim = makaleKapakResmi,
                    illerTarih = DateTime.Now,
                };
                var result = new RepositoryMakale().Save(makale);

                if (result)
                {
                    return JsonConvert.SerializeObject(new
                    {
                        message = "success",
                        status = 200,
                        data = ""
                    });
                }
                else
                {
                    return JsonConvert.SerializeObject(new
                    {
                        message = "error",
                        status = 500,
                        data = "Bir hata ile karşılaşıldı."
                    });
                }
            }
            else
            {
                int makaleNo = Convert.ToInt32(makaleId);
                var makale = new RepositoryMakale().GetMakale(makaleNo);
                if (makale != null)
                {
                    makale.illerBaslik = baslik;
                    makale.illerMakale = icerik;
                    makale.illerKapakResim = makaleKapakResmi;
                    makale.illerTarih = DateTime.Now;
                }

                var result = new RepositoryMakale().Update(makale);

                if (result)
                {
                    return JsonConvert.SerializeObject(new
                    {
                        message = "success",
                        status = 200,
                        data = ""
                    });
                }
                else
                {
                    return JsonConvert.SerializeObject(new
                    {
                        message = "error",
                        status = 500,
                        data = "Bir hata ile karşılaşıldı."
                    });
                }
            }


        }

        [WebMethod]
        public static string makaleGetir(int id)
        {
            var makale = new RepositoryMakale().GetMakale(id);
            return JsonConvert.SerializeObject(new
            {
                message = "success",
                status = 200,
                data = makale
            });

        }




    }
}
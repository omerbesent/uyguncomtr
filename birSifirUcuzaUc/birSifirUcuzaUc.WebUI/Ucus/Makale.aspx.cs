using birSifirUcuzaUc.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace birSifirUcuzaUc.WebUI.Ucus
{
    public partial class Makale : System.Web.UI.Page
    {
        RepositoryMakale rm = new RepositoryMakale();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    int id = Convert.ToInt32(Request.QueryString["id"].ToString());
                    Data.Tables.Makale sonuc = (Data.Tables.Makale)rm.Makaleler(id);
                    makale.InnerHtml = sonuc.illerMakale;
                }
            }
        }
    }
}
using birSifirUcuzaUc.Data.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace birSifirUcuzaUc.WebUI
{
    public partial class flightSearch : System.Web.UI.Page
    {
        RepositoryMakale rm = new RepositoryMakale();
        StringBuilder sb = new StringBuilder();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //var makleler = rm.Makaleler();
                //foreach (var item in makleler)
                //{
                //    string sonuc = makaleDesignMetot(item.illerKapakResim, item.illerNereyeAdi, item.illerYon, item.illerBaslik, item.illerFiyat, item.illerTarih, item.illerID);
                //    sb.Append(sonuc);
                //}
                //lastminute.InnerHtml = sb.ToString();
            }
            catch (Exception)
            {

            }
        }

        #region SearchAirport(string _KEYWORD)
        [WebMethod]
        public static string searchAirport(string _KEYWORD)
        {
            //string result = "";

            char[] trChar = new char[] { 'Ü', 'Ö', 'Ç', 'Ğ', 'İ', 'Ş' };
            char[] enChar = new char[] { 'U', 'O', 'C', 'G', 'I', 'S' };
            List<string> keywordList = new List<string>();
            keywordList.Add(_KEYWORD);

            for (int i = 0; i < enChar.Length; i++)
            {
                char item = enChar[i];
                if (_KEYWORD.ToUpper().IndexOf(item) != -1)
                {
                    keywordList.Add(_KEYWORD.ToUpper().Replace(item, trChar[i]));
                }
            }
            for (int i = 0; i < trChar.Length; i++)
            {
                char item = trChar[i];
                if (_KEYWORD.ToUpper().IndexOf(item) != -1)
                {
                    keywordList.Add(_KEYWORD.ToUpper().Replace(item, enChar[i]));
                }
            }
            string whereKosulu = "";

            for (int i = 0; i < keywordList.Count; i++)
            {
                string item = keywordList[i];
                if (i == 0)
                {
                    if (keywordList.Count == 1)
                    {
                        whereKosulu += "CityCode LIKE '" + item.ToUpper() + "%' OR CityName LIKE '" + item.ToUpper() + "%' OR LocalizedCityName LIKE '" + item.ToUpper() + "%' OR AirportName LIKE '" + item.ToUpper() + "%' OR AirportCode LIKE '" + item.ToUpper() + "%'" + "OR LocalizedCountryName LIKE '" + item.ToUpper() + "%'" + "OR CountryName LIKE '" + item.ToUpper() + "%'";
                    }
                    else
                    {
                        whereKosulu += "CityCode LIKE '" + item.ToUpper() + "%' OR CityName LIKE '" + item.ToUpper() + "%' OR LocalizedCityName LIKE '" + item.ToUpper() + "%' OR AirportName LIKE '" + item.ToUpper() + "%' OR AirportCode LIKE '" + item.ToUpper() + "%'" + "OR LocalizedCountryName LIKE '" + item.ToUpper() + "%'" + "OR CountryName LIKE '" + item.ToUpper() + "%'";
                    }
                }
                else
                {
                    if ((i + 1) == keywordList.Count)
                    {
                        whereKosulu += "OR CityCode LIKE '" + item.ToUpper() + "%' OR CityName LIKE '" + item.ToUpper() + "%' OR LocalizedCityName LIKE '" + item.ToUpper() + "%' OR AirportName LIKE '" + item.ToUpper() + "%' OR AirportCode LIKE '" + item.ToUpper() + "%'" + "OR LocalizedCountryName LIKE '" + item.ToUpper() + "%'" + "OR CountryName LIKE '" + item.ToUpper() + "%'";
                    }
                    else
                    {
                        whereKosulu += "OR CityCode LIKE '" + item.ToUpper() + "%' OR CityName LIKE '" + item.ToUpper() + "%' OR LocalizedCityName LIKE '" + item.ToUpper() + "%' OR AirportName LIKE '" + item.ToUpper() + "%' OR AirportCode LIKE '" + item.ToUpper() + "%'" + "OR LocalizedCountryName LIKE '" + item.ToUpper() + "%'" + "OR CountryName LIKE '" + item.ToUpper() + "%'";
                    }
                }
            }

            //var sonuc = new RepositoryAirport().customList("SELECT TOP 12 * FROM airport where " + whereKosulu + " Order By IsDomesticDestination DESC, Rating DESC, CityName ASC");
            var sonuc = new RepositoryAirport().customList(_KEYWORD);


            foreach (var item in sonuc)
            {
                if (item.LocalizedCityName == null || string.IsNullOrWhiteSpace(item.LocalizedCityName))
                {
                    item.LocalizedCityName = item.CityName;
                }

            }

            foreach (var item in sonuc)
            {
                if (item.LocalizedCountryName == null || string.IsNullOrWhiteSpace(item.LocalizedCountryName))
                {
                    item.LocalizedCountryName = item.CountryName;
                }

            }


            return JsonConvert.SerializeObject(new
            {
                message = "success",
                status = 200,
                data = sonuc
            });
        }
        #endregion

        private string makaleDesignMetot(string resimYol, string nereye, string yon, string ortaBaslik, decimal fiyat, DateTime tarih, int id)
        {
            return string.Format(makaleDesign, resimYol, nereye, yon, ortaBaslik, fiyat.ToString(), tarih.ToShortDateString(), id.ToString());
        }

        string makaleDesign =
                    "<div class=\"col-grid\" id=\"{6}\">" +
                        "<div class=\"wrapper\">" +
                             "<img src=\"{0}\" alt=\"cruise\">" +
                            "<h5 class=\"location\">{1}</h5>" +
                        "</div>" +
                        "<div class=\"body text-center\">" +
                            "<h5>{2}</h5>" +
                            "<p><i class=\"fa fa-star\"></i><i class=\"fa fa-star\"></i><i class=\"fa fa-star\"></i><i class=\"fa fa-star\"></i></p>" +
                            "<p class=\"back-line\">{3}</p>" +
                            "<h3>{4}</h3>" +
                            "<p class=\"text-sm\">{5}</p>" +
                        "</div>" +
                        "<div class=\"bottom\">" +
                            "<a id=\"myLink\" href=\"/Ucus/Makale.aspx?shr={1}&id={6}\">Detay Göster</a>" +
                        "</div>" +
                    "</div>";
        //onclick=\"MakaleFunction({6});return false;\"
    }
}
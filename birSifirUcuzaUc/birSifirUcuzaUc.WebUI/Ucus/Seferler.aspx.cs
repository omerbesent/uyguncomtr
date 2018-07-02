using birSifirUcuzaUc.Data;
using birSifirUcuzaUc.Data.Repository;
using birSifirUcuzaUc.WebUI.birSifirServis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace birSifirUcuzaUc.WebUI.Ucus
{
    public partial class Seferler : System.Web.UI.Page
    {
        bool dishat = false;
        /// <summary>
        /// true TekYon - false ÇiftYon
        /// </summary>
        bool tekYon = true;
        /// <summary>
        /// SatınAl butonuna verdiğimiz bilgi
        /// </summary>
        string strTekyon = "OW";
        protected void Page_Load(object sender, EventArgs e)
        {
            BirsifirSoapClient cl = new BirsifirSoapClient();
            RepositoryHavayoluFirmalari rhf = new RepositoryHavayoluFirmalari();
            RepositoryAirport rap = new RepositoryAirport();


            if (IsPostBack == true)
            {

                Page.Response.Redirect("~/Ucus/Seferler.aspx" + Session["url"].ToString(), true);

            }

            if ((Request.QueryString["gdOriginCode"] != null && Request.QueryString["gdDestinationCode"] != null && Request.QueryString["gTarih"] != null && Request.QueryString["ysYetiskin"] != null) && (Request.QueryString["gdOriginCode"] != "" && Request.QueryString["gdDestinationCode"] != "" && Request.QueryString["gTarih"] != "" && Request.QueryString["ysYetiskin"] != ""))
            {

                Session["url"] = Request.Url.Query;

                #region querStringNerden_NereyeDolumu
                string gidisKod = Request.QueryString["gdOriginCode"].ToString();
                string varisKod = Request.QueryString["gdDestinationCode"].ToString();
                Session["gdOriginCode"] = gidisKod;
                Session["gdDestinationCode"] = varisKod;


                inpNeredenAirportCode.Value = gidisKod;
                //İstanbul - Türkiye (Atatürk-İST)
                var xG = rap.ulkeKodu(gidisKod.Substring(0, 3))[0];
                inpNereden.Value = xG.LocalizedCityName + " - " + xG.LocalizedCountryName + "(" + xG.AirportName + "-" + xG.AirportCode + ")";
                inpNeredenCountryCode.Value = xG.CountryCode;
                inpNeredenCountryName.Value = xG.LocalizedCountryName;
                inpNeredenCityName.Value = xG.CityName;

                //İstanbul - Türkiye (Atatürk-İST)
                var yD = rap.ulkeKodu(varisKod.Substring(0, 3))[0];
                inpNereye.Value = yD.LocalizedCityName + " - " + yD.LocalizedCountryName + "(" + yD.AirportName + "-" + yD.AirportCode + ")";
                inpNereyeCountryCode.Value = yD.CountryCode;
                inpNereyeCityName.Value = yD.CityName;
                inpNereyeAirportCode.Value = varisKod;
                #endregion

                #region gelenTariheGore_Tekyon-Ciftyon
                string gTarih = Request.QueryString["gTarih"].ToString().Replace("/", ".");
                departure_date.Value = gTarih;
                string dTarih = "";
                if (Request.QueryString["dTarih"] != null && Request.QueryString["dTarih"] != "")
                {
                    dTarih = Request.QueryString["dTarih"].ToString().Replace("/", ".");
                    return_date.Value = dTarih;
                    tekYon = false;
                    strTekyon = "RT";
                }
                #endregion

                #region queryStringKisileriToplama
                Yolcular.yolcuTipSayi.Clear();
                int totalPassenger = 0;
                int yetiskinPassenger = 0;
                int cocukPassenger = 0;
                int bebekPassenger = 0;
                if (Method.IsInt(Request.QueryString["ysYetiskin"].ToString()))//Sayısal Değer ise kişileri topladık..
                {
                    totalPassenger += Convert.ToInt32(Request.QueryString["ysYetiskin"].ToString());
                    yetiskinPassenger = Convert.ToInt32(Request.QueryString["ysYetiskin"].ToString());
                    Yolcu ylc1 = new Yolcu();
                    ylc1.yolcuSayisi = Request.QueryString["ysYetiskin"].ToString();
                    ylc1.yolcuTipi = "Yetiskin";
                    if (Convert.ToInt32(Request.QueryString["ysYetiskin"].ToString()) > 0)
                        Yolcular.yolcuTipSayi.Add(ylc1);
                }
                if (Method.IsInt(Request.QueryString["ysCocuk"].ToString()))
                {
                    totalPassenger += Convert.ToInt32(Request.QueryString["ysCocuk"].ToString());
                    cocukPassenger = Convert.ToInt32(Request.QueryString["ysCocuk"].ToString());
                    Yolcu ylc2 = new Yolcu();
                    ylc2.yolcuSayisi = Request.QueryString["ysCocuk"].ToString();
                    ylc2.yolcuTipi = "Cocuk";
                    if (Convert.ToInt32(Request.QueryString["ysCocuk"].ToString()) > 0)
                        Yolcular.yolcuTipSayi.Add(ylc2);

                }
                if (Method.IsInt(Request.QueryString["ysBebek"].ToString()))
                {
                    totalPassenger += Convert.ToInt32(Request.QueryString["ysBebek"].ToString());
                    bebekPassenger = Convert.ToInt32(Request.QueryString["ysBebek"].ToString());
                    Yolcu ylc3 = new Yolcu();
                    ylc3.yolcuSayisi = Request.QueryString["ysBebek"].ToString();
                    ylc3.yolcuTipi = "Bebek";
                    if (Convert.ToInt32(Request.QueryString["ysBebek"].ToString()) > 0)
                        Yolcular.yolcuTipSayi.Add(ylc3);
                }
                #endregion
                string _ucusTipi = "";
                if (Request.QueryString["ucusTipi"] != null && Request.QueryString["ucusTipi"] != "")
                {
                    _ucusTipi = Request.QueryString["ucusTipi"].ToString();
                }


                #region ulkeKodunaGore_IcHat-DisHat
                string _gidisCountryCode = gidisKod.Substring(gidisKod.ToString().Length - 2);
                string _donusCountryCode = varisKod.Substring(varisKod.ToString().Length - 2);
                if ((_gidisCountryCode == "TR" && _donusCountryCode == "CY") || (_gidisCountryCode == "CY" && _donusCountryCode == "TR") || (_gidisCountryCode == "TR" && _donusCountryCode == "TR"))
                {
                    dishat = false;
                    Method.seferTipi = false;
                    inpDisHat.Value = "false";
                }
                else if (_gidisCountryCode != _donusCountryCode ||
                            (
                            !_gidisCountryCode.Equals("TR") ||
                            !_donusCountryCode.Equals("TR") ||
                            !_gidisCountryCode.Equals("CY") ||
                            !_donusCountryCode.Equals("CY")
                            )
                       )
                {
                    dishat = true;
                    Method.seferTipi = true;
                    inpDisHat.Value = "true";
                }
                #endregion

                //try
                //{
                //string topla = "";
                //string sonucTopla = "";
                StringBuilder sbGidis = new StringBuilder();
                StringBuilder sbDonus = new StringBuilder();
                StringBuilder sbGidisDonusDisHat = new StringBuilder();
                Dictionary<string, string> dicHavayoluFirmaListe = new Dictionary<string, string>();
                Guid guidID = Guid.NewGuid(); Guid guidID2 = Guid.NewGuid();
                Dictionary<Guid, FlightSegmentResults> topluListe = new Dictionary<Guid, FlightSegmentResults>();
                Dictionary<Guid, OriginDestinationOptionList> topluListeDisHat = new Dictionary<Guid, OriginDestinationOptionList>();
                Dictionary<Guid, PricedItineraryList> pricedItineraryList = new Dictionary<Guid, PricedItineraryList>();
                System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
                var sonuc = cl.FlightSearch(gidisKod, varisKod, gTarih, dTarih, yetiskinPassenger.ToString(), cocukPassenger.ToString(), bebekPassenger.ToString(), _ucusTipi, "");
                watch.Start();
                Session["seferSonuc"] = sonuc;
                int siraNo = 0;
                if (dishat == false)
                {
                    #region Yurt İçi Gidiş

                    foreach (var item in sonuc.GidisUcuslari.FlightSegmentResults)
                    {
                        siraNo++;
                        Session["uu_SessionID"] = sonuc.GidisUcuslari.uu_SessionId;

                        string havayoluAdi = "";

                        string ucusSinifi = item.FlightItems[0].ClassCode;
                        string ucusKodu = item.FlightItems[0].FlightNo;
                        string bagajBilgi = item.Luggage;
                        //airCode = rhf.havayoluKodlari(item.FlightItems[0].CustomField3)[0].AirlineCode;
                        string airCode = item.FlightItems[0].Carrier;//Logo için..
                        string airCodeOut = "";

                        havayoluAdi = item.FlightItems[0].CustomField3;
                        bool varMi = dicHavayoluFirmaListe.TryGetValue(airCode, out airCodeOut);
                        if (!varMi)
                        {
                            dicHavayoluFirmaListe.Add(airCode, havayoluAdi);
                        }

                        guidID = Guid.NewGuid();
                        topluListe.Add(guidID, item);

                        string gidisHavaalaniKodu = item.FlightItems[0].OriginCode;
                        string gidisSaati = item.FlightItems[0].DepartureTime.Substring(11, 5);
                        string gidisTarihi = item.FlightItems[0].DepartureTime.Substring(0, 10);
                        string gidisSehir = item.FlightItems[0].OriginCityCountry.Split(',')[0].ToString();
                        string gidisUlkeKodu = rap.ulkeKodu(gidisHavaalaniKodu)[0].CountryCode;
                        string gidisAirPortName = rap.ulkeKodu(gidisHavaalaniKodu)[0].AirportName;
                        //string gidisUlkeKodu = item.FlightItems[0].OriginCityCountry.Split(',')[1].ToString().Trim() == "Türkiye" ? "TR" : item.FlightItems[0].OriginCityCountry.Split(',')[1].ToString();


                        string varisHavaalaniKodu = item.FlightItems[0].DestinationCode;
                        string varisSaati = item.FlightItems[0].ArrivalTime.Substring(11, 5);
                        string varisTarihi = item.FlightItems[0].ArrivalTime.Substring(0, 10);
                        string varisSehir = item.FlightItems[0].DestinationCityCountry.Split(',')[0].ToString();
                        string varisUlkeKodu = rap.ulkeKodu(varisHavaalaniKodu)[0].CountryCode;
                        string varisAirPortName = rap.ulkeKodu(varisHavaalaniKodu)[0].AirportName;
                        //string varisUlkeKodu = item.FlightItems[0].DestinationCityCountry.Split(',')[1].ToString().Trim() == "Türkiye" ? "TR" : item.FlightItems[0].DestinationCityCountry.Split(',')[1].ToString();

                        int aktSayisi = item.FlightItems.Length - 1;
                        string durationBir = KacSaatUcus(item.FlightItems[0].DepartureTime, item.FlightItems[0].ArrivalTime);
                        double biletFiyati = item.FlightPriceTotal;

                        StringBuilder aktBilgiSB = new StringBuilder();
                        aktBilgiSB.Clear();
                        for (int i = 0; i < item.FlightItems.Length; i++)
                        {

                            if (i != 0)
                            {
                                string airCodeAkt = item.FlightItems[i].Carrier;//Logo için..
                                string havayoluAdiAkt = item.FlightItems[i].CustomField3;

                                string gidisHavaalaniKoduAkt = item.FlightItems[i].OriginCode;
                                string gidisSaatiAkt = item.FlightItems[i].DepartureTime.Substring(11, 5);
                                string gidisTarihiAkt = item.FlightItems[i].DepartureTime.Substring(0, 10);
                                string gidisSehirAkt = item.FlightItems[i].OriginCityCountry.Split(',')[0].ToString();
                                string gidisUlkeKoduAkt = rap.ulkeKodu(gidisHavaalaniKoduAkt)[0].CountryCode;
                                string ucusSinifiAkt = item.FlightItems[i].ClassCode;
                                string gidisAirPortNameAkt = rap.ulkeKodu(gidisHavaalaniKoduAkt)[0].AirportName;
                                //string gidisUlkeKoduAkt = item.FlightItems[i].OriginCityCountry.Split(',')[1].ToString().Trim() == "Türkiye" ? "TR" : item.FlightItems[i].OriginCityCountry.Split(',')[1].ToString();


                                string varisHavaalaniKoduAkt = item.FlightItems[i].DestinationCode;
                                string varisSaatiAkt = item.FlightItems[i].ArrivalTime.Substring(11, 5);
                                string varisTarihiAkt = item.FlightItems[i].ArrivalTime.Substring(0, 10);
                                string varisSehirAkt = item.FlightItems[i].DestinationCityCountry.Split(',')[0].ToString();
                                string varisUlkeKoduAkt = rap.ulkeKodu(varisHavaalaniKoduAkt)[0].CountryCode;
                                string varisUcusKoduAkt = item.FlightItems[i].FlightNo;
                                string varisAirPortNameAkt = rap.ulkeKodu(varisHavaalaniKoduAkt)[0].AirportName;
                                //string varisUlkeKoduAkt = item.FlightItems[i].DestinationCityCountry.Split(',')[1].ToString().Trim() == "Türkiye" ? "TR" : item.FlightItems[i].DestinationCityCountry.Split(',')[1].ToString();

                                string durationAkt = KacSaatUcus(item.FlightItems[i].DepartureTime, item.FlightItems[i].ArrivalTime);

                                aktBilgiSB.Append(GidisAktarmaBilgisi("", gidisHavaalaniKoduAkt, gidisSaatiAkt, gidisTarihiAkt, gidisSehirAkt, gidisUlkeKoduAkt, durationAkt, varisHavaalaniKoduAkt, varisSaatiAkt, varisTarihiAkt, varisSehirAkt, varisUlkeKoduAkt, varisUcusKoduAkt, gidisAirPortNameAkt, varisAirPortNameAkt, airCodeAkt, havayoluAdiAkt));
                            }
                        }

                        string aktarmaSayisiHTML = "";
                        string aktarmaTrueFalse = "false";
                        if (aktSayisi > 0)
                        {
                            aktarmaTrueFalse = "true";
                            aktarmaSayisiHTML = AktarmaSayisi(aktSayisi.ToString());
                        }
                        //gidisHavayoluKodu, varisHavayoluKodu, gidisHavayoluKoduLong, varisHavayoluKoduLong, data_custom1, data_custom2, orginDateTime, varisDateTime, ucusSinifi, airLongName, airLineCode, aktarmaDurum

                        string sonVarisTarihi = item.FlightItems[item.FlightItems.Length - 1].ArrivalTime.Substring(0, 10);
                        string sonVarisSaati = item.FlightItems[item.FlightItems.Length - 1].ArrivalTime.Substring(11, 5);
                        string classBilgiler = ClassDataInfo(gidisHavaalaniKodu, varisHavaalaniKodu, gidisSehir, varisSehir, ucusKodu, aktSayisi.ToString(), gidisTarihi + " " + gidisSaati, sonVarisTarihi + " " + sonVarisSaati, ucusSinifi, havayoluAdi.ToLower(), airCode, aktarmaTrueFalse, Math.Ceiling(biletFiyati).ToString(), guidID.ToString());





                        sbGidis.Append(GidisUcusBilgi(classBilgiler, gidisHavaalaniKodu, gidisSaati, gidisTarihi, gidisSehir, gidisUlkeKodu, varisHavaalaniKodu, varisSaati, varisTarihi, varisSehir, varisUlkeKodu, airCode, havayoluAdi, aktarmaSayisiHTML, durationBir, aktBilgiSB.ToString(), string.Format("{0:0.##} TL", Math.Ceiling(biletFiyati)), ucusKodu, bagajBilgi, gidisAirPortName, varisAirPortName, ucusKodu + siraNo, guidID.ToString() + "\',\'" + strTekyon + "\',\'GIDIS"));
                    }
                    #endregion

                    if (tekYon == false)
                    {
                        #region Yurt İçi Dönüş
                        foreach (var item in sonuc.DonusUcuslari.FlightSegmentResults)
                        {
                            siraNo++;
                            string havayoluAdi = "";

                            string ucusSinifi = item.FlightItems[0].ClassCode;
                            string ucusKodu = item.FlightItems[0].FlightNo;
                            string bagajBilgi = item.Luggage;
                            //airCode = rhf.havayoluKodlari(item.FlightItems[0].CustomField3)[0].AirlineCode;
                            string airCode = item.FlightItems[0].Carrier;//Logo için..
                            string airCodeOut = "";

                            havayoluAdi = item.FlightItems[0].CustomField3.ToString();
                            bool varMi = dicHavayoluFirmaListe.TryGetValue(airCode, out airCodeOut);
                            if (!varMi)
                            {
                                dicHavayoluFirmaListe.Add(airCode, havayoluAdi);
                            }

                            guidID = Guid.NewGuid();
                            topluListe.Add(guidID, item);

                            string gidisHavaalaniKodu = item.FlightItems[0].OriginCode;
                            string gidisSaati = item.FlightItems[0].DepartureTime.Substring(11, 5);
                            string gidisTarihi = item.FlightItems[0].DepartureTime.Substring(0, 10);
                            string gidisSehir = item.FlightItems[0].OriginCityCountry.Split(',')[0].ToString();
                            string gidisUlkeKodu = rap.ulkeKodu(gidisHavaalaniKodu)[0].CountryCode;
                            string gidisAirPortName = rap.ulkeKodu(gidisHavaalaniKodu)[0].AirportName;
                            //string gidisUlkeKodu = item.FlightItems[0].OriginCityCountry.Split(',')[1].ToString().Trim() == "Türkiye" ? "TR" : item.FlightItems[0].OriginCityCountry.Split(',')[1].ToString();


                            string varisHavaalaniKodu = item.FlightItems[0].DestinationCode;
                            string varisSaati = item.FlightItems[0].ArrivalTime.Substring(11, 5);
                            string varisTarihi = item.FlightItems[0].ArrivalTime.Substring(0, 10);
                            string varisSehir = item.FlightItems[0].DestinationCityCountry.Split(',')[0].ToString();
                            string varisUlkeKodu = rap.ulkeKodu(varisHavaalaniKodu)[0].CountryCode;
                            string varisAirPortName = rap.ulkeKodu(varisHavaalaniKodu)[0].AirportName;
                            //string varisUlkeKodu = item.FlightItems[0].DestinationCityCountry.Split(',')[1].ToString().Trim() == "Türkiye" ? "TR" : item.FlightItems[0].DestinationCityCountry.Split(',')[1].ToString();

                            int aktSayisi = item.FlightItems.Length - 1;
                            string durationBir = KacSaatUcus(item.FlightItems[0].DepartureTime, item.FlightItems[0].ArrivalTime);
                            double biletFiyati = item.FlightPriceTotal;

                            StringBuilder aktBilgiSB = new StringBuilder();
                            aktBilgiSB.Clear();
                            for (int i = 0; i < item.FlightItems.Length; i++)
                            {

                                if (i != 0)
                                {
                                    string airCodeAkt = item.FlightItems[i].Carrier;//Logo için..
                                    string havayoluAdiAkt = item.FlightItems[i].CustomField3;

                                    string gidisHavaalaniKoduAkt = item.FlightItems[i].OriginCode;
                                    string gidisSaatiAkt = item.FlightItems[i].DepartureTime.Substring(11, 5);
                                    string gidisTarihiAkt = item.FlightItems[i].DepartureTime.Substring(0, 10);
                                    string gidisSehirAkt = item.FlightItems[i].OriginCityCountry.Split(',')[0].ToString();
                                    string gidisUlkeKoduAkt = rap.ulkeKodu(gidisHavaalaniKoduAkt)[0].CountryCode;
                                    string ucusSinifiAkt = item.FlightItems[i].ClassCode;
                                    string gidisAirPortNameAkt = rap.ulkeKodu(gidisHavaalaniKoduAkt)[0].AirportName;
                                    //string gidisUlkeKoduAkt = item.FlightItems[i].OriginCityCountry.Split(',')[1].ToString().Trim() == "Türkiye" ? "TR" : item.FlightItems[i].OriginCityCountry.Split(',')[1].ToString();


                                    string varisHavaalaniKoduAkt = item.FlightItems[i].DestinationCode;
                                    string varisSaatiAkt = item.FlightItems[i].ArrivalTime.Substring(11, 5);
                                    string varisTarihiAkt = item.FlightItems[i].ArrivalTime.Substring(0, 10);
                                    string varisSehirAkt = item.FlightItems[i].DestinationCityCountry.Split(',')[0].ToString();
                                    string varisUlkeKoduAkt = rap.ulkeKodu(varisHavaalaniKoduAkt)[0].CountryCode;
                                    string varisUcusKoduAkt = item.FlightItems[i].FlightNo;
                                    string varisAirPortNameAkt = rap.ulkeKodu(varisHavaalaniKoduAkt)[0].AirportName;
                                    //string varisUlkeKoduAkt = item.FlightItems[i].DestinationCityCountry.Split(',')[1].ToString().Trim() == "Türkiye" ? "TR" : item.FlightItems[i].DestinationCityCountry.Split(',')[1].ToString();

                                    string durationAkt = KacSaatUcus(item.FlightItems[i].DepartureTime, item.FlightItems[i].ArrivalTime);

                                    aktBilgiSB.Append(GidisAktarmaBilgisi("", gidisHavaalaniKoduAkt, gidisSaatiAkt, gidisTarihiAkt, gidisSehirAkt, gidisUlkeKoduAkt, durationAkt, varisHavaalaniKoduAkt, varisSaatiAkt, varisTarihiAkt, varisSehirAkt, varisUlkeKoduAkt, varisUcusKoduAkt, gidisAirPortNameAkt, varisAirPortNameAkt, airCodeAkt, havayoluAdiAkt));
                                }
                            }

                            string aktarmaSayisiHTML = "";
                            string aktarmaTrueFalse = "false";
                            if (aktSayisi > 0)
                            {
                                aktarmaTrueFalse = "true";
                                aktarmaSayisiHTML = AktarmaSayisi(aktSayisi.ToString());
                            }
                            //gidisHavayoluKodu, varisHavayoluKodu, gidisHavayoluKoduLong, varisHavayoluKoduLong, data_custom1, data_custom2, orginDateTime, varisDateTime, ucusSinifi, airLongName, airLineCode, aktarmaDurum

                            string sonVarisTarihi = item.FlightItems[item.FlightItems.Length - 1].ArrivalTime.Substring(0, 10);
                            string sonVarisSaati = item.FlightItems[item.FlightItems.Length - 1].ArrivalTime.Substring(11, 5);
                            string classBilgiler = ClassDataInfo(gidisHavaalaniKodu, varisHavaalaniKodu, gidisSehir, varisSehir, ucusKodu, aktSayisi.ToString(), gidisTarihi + " " + gidisSaati, sonVarisTarihi + " " + sonVarisSaati, ucusSinifi, havayoluAdi.ToLower(), airCode, aktarmaTrueFalse, Math.Ceiling(biletFiyati).ToString(), guidID.ToString());






                            sbDonus.Append(GidisUcusBilgi(classBilgiler, gidisHavaalaniKodu, gidisSaati, gidisTarihi, gidisSehir, gidisUlkeKodu, varisHavaalaniKodu, varisSaati, varisTarihi, varisSehir, varisUlkeKodu, airCode, havayoluAdi, aktarmaSayisiHTML, durationBir, aktBilgiSB.ToString(), string.Format("{0:0.##} TL", Math.Ceiling(biletFiyati)), ucusKodu, bagajBilgi, gidisAirPortName, varisAirPortName, ucusKodu + siraNo, guidID.ToString() + "\',\'" + strTekyon + "\',\'DONUS"));
                        }
                        #endregion
                    }
                    Session["topluListe"] = topluListe;
                }
                else
                {
                    #region Dış Hat Tek Yön
                    if (tekYon)//Dış Hat Tek Yön
                    {
                        foreach (var item3 in sonuc.GidisUcuslari.PricedItineraryList)
                        {
                            Session["uu_SessionID"] = sonuc.GidisUcuslari.uu_SessionId;
                            Session["AspNet_SessionID"] = sonuc.GidisUcuslari.sessionid;
                            foreach (var item in item3.OriginDestinationOptionList)
                            {
                                //foreach (var item in item2.FlightSegment)
                                //{
                                siraNo++;
                                string havayoluAdi = "";

                                string ucusSinifi = item.FlightSegment[0].ResBookDesigCode;
                                string ucusKodu = item.FlightSegment[0].FlightNumber;
                                string bagajBilgi = item.FlightSegment[0].Luggage;
                                //airCode = rhf.havayoluKodlari(item.FlightItems[0].CustomField3)[0].AirlineCode;
                                string airCode = item.FlightSegment[0].OperatingAirline;
                                string airCodeOut = "";

                                havayoluAdi = item.FlightSegment[0].OperatingAirlineName;
                                bool varMi = dicHavayoluFirmaListe.TryGetValue(airCode, out airCodeOut);
                                if (!varMi)
                                {
                                    dicHavayoluFirmaListe.Add(airCode, havayoluAdi);
                                }

                                guidID = Guid.NewGuid();
                                topluListeDisHat.Add(guidID, item);
                                pricedItineraryList.Add(guidID, item3);

                                string gidisHavaalaniKodu = item.FlightSegment[0].DepartureAirport.Split('(')[1].Split(')')[0].ToString();
                                string gidisSaati = item.FlightSegment[0].DepartureDateTime.Substring(11, 5);
                                string gidisTarihi = item.FlightSegment[0].DepartureDateTime.Substring(0, 10);
                                string gidisSehir = item.FlightSegment[0].DepartureCityCountry.Split(',')[0].ToString();
                                string gidisUlkeKodu = rap.ulkeKodu(gidisHavaalaniKodu)[0].CountryCode;
                                string gidisAirPortName = rap.ulkeKodu(gidisHavaalaniKodu)[0].AirportName;


                                ////string gidisUlkeKodu = item.FlightItems[0].OriginCityCountry.Split(',')[1].ToString().Trim() == "Türkiye" ? "TR" : item.FlightItems[0].OriginCityCountry.Split(',')[1].ToString();


                                string varisHavaalaniKodu = item.FlightSegment[0].ArrivalAirport.Split('(')[1].Split(')')[0].ToString();
                                string varisSaati = item.FlightSegment[0].ArrivalDateTime.Substring(11, 5);
                                string varisTarihi = item.FlightSegment[0].ArrivalDateTime.Substring(0, 10);
                                string varisSehir = item.FlightSegment[0].ArrivaliCityCountry.Split(',')[0].ToString();
                                string varisUlkeKodu = rap.ulkeKodu(varisHavaalaniKodu)[0].CountryCode;
                                string varisAirPortName = rap.ulkeKodu(varisHavaalaniKodu)[0].AirportName;
                                ////string varisUlkeKodu = item.FlightItems[0].DestinationCityCountry.Split(',')[1].ToString().Trim() == "Türkiye" ? "TR" : item.FlightItems[0].DestinationCityCountry.Split(',')[1].ToString();

                                int aktSayisi = item.FlightSegment.Length - 1;
                                string durationBir = KacSaatUcus(item.FlightSegment[0].DepartureDateTime, item.FlightSegment[0].ArrivalDateTime);
                                double biletFiyati = item3.ItinTotalFare.TotalFare;

                                StringBuilder aktBilgiSB = new StringBuilder();
                                aktBilgiSB.Clear();
                                for (int i = 0; i < item.FlightSegment.Length; i++)
                                {

                                    if (i != 0)
                                    {
                                        string airCodeAkt = item.FlightSegment[i].OperatingAirline;//Logo için..
                                        string havayoluAdiAkt = item.FlightSegment[i].OperatingAirlineName;

                                        string gidisHavaalaniKoduAkt = item.FlightSegment[i].DepartureAirport.Split('(')[1].Split(')')[0].ToString();
                                        string gidisSaatiAkt = item.FlightSegment[i].DepartureDateTime.Substring(11, 5);
                                        string gidisTarihiAkt = item.FlightSegment[i].DepartureDateTime.Substring(0, 10);
                                        string gidisSehirAkt = item.FlightSegment[i].DepartureCityCountry.Split(',')[0].ToString();
                                        string gidisUlkeKoduAkt = rap.ulkeKodu(gidisHavaalaniKoduAkt)[0].CountryCode;
                                        string ucusSinifiAkt = item.FlightSegment[i].ResBookDesigCode;
                                        string gidisAirPortNameAkt = rap.ulkeKodu(gidisHavaalaniKoduAkt)[0].AirportName;
                                        //string gidisUlkeKoduAkt = item.FlightItems[i].OriginCityCountry.Split(',')[1].ToString().Trim() == "Türkiye" ? "TR" : item.FlightItems[i].OriginCityCountry.Split(',')[1].ToString();


                                        string varisHavaalaniKoduAkt = item.FlightSegment[i].ArrivalAirport.Split('(')[1].Split(')')[0].ToString();
                                        string varisSaatiAkt = item.FlightSegment[i].ArrivalDateTime.Substring(11, 5);
                                        string varisTarihiAkt = item.FlightSegment[i].ArrivalDateTime.Substring(0, 10);
                                        string varisSehirAkt = item.FlightSegment[i].ArrivaliCityCountry.Split(',')[0].ToString();
                                        string varisUlkeKoduAkt = rap.ulkeKodu(varisHavaalaniKoduAkt)[0].CountryCode;
                                        string varisUcusKoduAkt = item.FlightSegment[i].FlightNumber;
                                        string varisAirPortNameAkt = rap.ulkeKodu(varisHavaalaniKoduAkt)[0].AirportName;
                                        //string varisUlkeKoduAkt = item.FlightItems[i].DestinationCityCountry.Split(',')[1].ToString().Trim() == "Türkiye" ? "TR" : item.FlightItems[i].DestinationCityCountry.Split(',')[1].ToString();

                                        string durationAkt = KacSaatUcus(item.FlightSegment[i].DepartureDateTime, item.FlightSegment[i].ArrivalDateTime);

                                        aktBilgiSB.Append(GidisAktarmaBilgisi("", gidisHavaalaniKoduAkt, gidisSaatiAkt, gidisTarihiAkt, gidisSehirAkt, gidisUlkeKoduAkt, durationAkt, varisHavaalaniKoduAkt, varisSaatiAkt, varisTarihiAkt, varisSehirAkt, varisUlkeKoduAkt, varisUcusKoduAkt, gidisAirPortNameAkt, varisAirPortNameAkt, airCodeAkt, havayoluAdiAkt));
                                    }
                                }

                                string aktarmaSayisiHTML = "";
                                string aktarmaTrueFalse = "false";
                                if (aktSayisi > 0)
                                {
                                    aktarmaTrueFalse = "true";
                                    aktarmaSayisiHTML = AktarmaSayisi(aktSayisi.ToString());
                                }
                                //gidisHavayoluKodu, varisHavayoluKodu, gidisHavayoluKoduLong, varisHavayoluKoduLong, data_custom1, data_custom2, orginDateTime, varisDateTime, ucusSinifi, airLongName, airLineCode, aktarmaDurum

                                string sonVarisTarihi = item.FlightSegment[item.FlightSegment.Length - 1].ArrivalDateTime.Substring(0, 10);
                                string sonVarisSaati = item.FlightSegment[item.FlightSegment.Length - 1].ArrivalDateTime.Substring(11, 5);
                                string classBilgiler = ClassDataInfo(gidisHavaalaniKodu, varisHavaalaniKodu, gidisSehir, varisSehir, ucusKodu, aktSayisi.ToString(), gidisTarihi + " " + gidisSaati, sonVarisTarihi + " " + sonVarisSaati, ucusSinifi, havayoluAdi.ToLower(), airCode, aktarmaTrueFalse, Math.Ceiling(biletFiyati).ToString(), guidID.ToString());


                                sbGidis.Append(GidisUcusBilgi(classBilgiler, gidisHavaalaniKodu, gidisSaati, gidisTarihi, gidisSehir, gidisUlkeKodu, varisHavaalaniKodu, varisSaati, varisTarihi, varisSehir, varisUlkeKodu, airCode, havayoluAdi, aktarmaSayisiHTML, durationBir, aktBilgiSB.ToString(), string.Format("{0:0.##} TL", Math.Ceiling(biletFiyati)), ucusKodu, bagajBilgi, gidisAirPortName, varisAirPortName, ucusKodu + siraNo, guidID.ToString() + "\',\'OW"));
                                //}
                            }
                        }
                        watch.Stop();
                        string totalSure = "Toplam çalışma süresi " + watch.Elapsed.Milliseconds;
                    }
                    #endregion
                    if (tekYon == false)
                    {
                        #region Dış Hat Gidiş-Dönüş
                        foreach (var item3 in sonuc.GidisUcuslari.PricedItineraryList)
                        {
                            Session["uu_SessionID"] = sonuc.GidisUcuslari.uu_SessionId;
                            Session["AspNet_SessionID"] = sonuc.GidisUcuslari.sessionid;
                            var Gidis = item3.OriginDestinationOptionList.Where(x => x.DirectionId == "0");
                            var Donus = item3.OriginDestinationOptionList.Where(x => x.DirectionId == "1");
                            foreach (var item in Gidis)
                            {
                                Session["uu_SessionID"] = sonuc.GidisUcuslari.uu_SessionId;
                                double biletFiyatiDis = item3.FareBreakdowns[0].TotalFare;
                                //Gidis
                                siraNo++;
                                string havayoluAdi = "";

                                string ucusSinifi = item.FlightSegment.First().ResBookDesigCode;
                                string ucusKodu = item.FlightSegment.First().FlightNumber;
                                string bagajBilgi = item.FlightSegment.First().Luggage;
                                //airCode = rhf.havayoluKodlari(item.FlightItems[0].CustomField3)[0].AirlineCode;
                                string airCode = item.FlightSegment.First().OperatingAirline;
                                string airCodeOut = "";

                                havayoluAdi = item.FlightSegment.First().OperatingAirlineName;
                                bool varMi = dicHavayoluFirmaListe.TryGetValue(airCode, out airCodeOut);
                                if (!varMi)
                                {
                                    dicHavayoluFirmaListe.Add(airCode, havayoluAdi);
                                }

                                guidID = Guid.NewGuid();
                                topluListeDisHat.Add(guidID, item);
                                pricedItineraryList.Add(guidID, item3);

                                string gidisHavaalaniKodu = item.FlightSegment.First().DepartureAirport.Split('(')[1].Split(')')[0].ToString();
                                string gidisSaati = item.FlightSegment.First().DepartureDateTime.Substring(11, 5);
                                string gidisTarihi = item.FlightSegment.First().DepartureDateTime.Substring(0, 10);
                                string gidisSehir = item.FlightSegment.First().DepartureCityCountry.Split(',')[0].ToString();
                                string gidisUlkeKodu = rap.ulkeKodu(gidisHavaalaniKodu).First().CountryCode;
                                string gidisAirPortName = rap.ulkeKodu(gidisHavaalaniKodu)[0].AirportName;

                                ////string gidisUlkeKodu = item.FlightItems[0].OriginCityCountry.Split(',')[1].ToString().Trim() == "Türkiye" ? "TR" : item.FlightItems[0].OriginCityCountry.Split(',')[1].ToString();


                                string varisHavaalaniKodu = item.FlightSegment.First().ArrivalAirport.Split('(')[1].Split(')')[0].ToString();
                                string varisSaati = item.FlightSegment.First().ArrivalDateTime.Substring(11, 5);
                                string varisTarihi = item.FlightSegment.First().ArrivalDateTime.Substring(0, 10);
                                string varisSehir = item.FlightSegment.First().ArrivaliCityCountry.Split(',')[0].ToString();
                                string varisUlkeKodu = rap.ulkeKodu(varisHavaalaniKodu).First().CountryCode;
                                string varisAirPortName = rap.ulkeKodu(varisHavaalaniKodu)[0].AirportName;

                                int aktSayisi = item.FlightSegment.Length - 1;
                                string durationBir = KacSaatUcus(item.FlightSegment[0].DepartureDateTime, item.FlightSegment[0].ArrivalDateTime);
                                double biletFiyati = item3.ItinTotalFare.TotalFare;
                                StringBuilder aktBilgiSB = new StringBuilder();
                                aktBilgiSB.Clear();
                                for (int i = 0; i < item.FlightSegment.Length; i++)
                                {

                                    if (i != 0)
                                    {
                                        string airCodeAkt = item.FlightSegment[i].OperatingAirline;//Logo için..
                                        string havayoluAdiAkt = item.FlightSegment[i].OperatingAirlineName;

                                        string gidisHavaalaniKoduAkt = item.FlightSegment[i].DepartureAirport.Split('(')[1].Split(')')[0].ToString();
                                        string gidisSaatiAkt = item.FlightSegment[i].DepartureDateTime.Substring(11, 5);
                                        string gidisTarihiAkt = item.FlightSegment[i].DepartureDateTime.Substring(0, 10);
                                        string gidisSehirAkt = item.FlightSegment[i].DepartureCityCountry.Split(',')[0].ToString();
                                        string gidisUlkeKoduAkt = rap.ulkeKodu(gidisHavaalaniKoduAkt)[0].CountryCode;
                                        string ucusSinifiAkt = item.FlightSegment[i].ResBookDesigCode;
                                        string gidisAirPortNameAkt = rap.ulkeKodu(gidisHavaalaniKoduAkt)[0].AirportName;
                                        //string gidisUlkeKoduAkt = item.FlightItems[i].OriginCityCountry.Split(',')[1].ToString().Trim() == "Türkiye" ? "TR" : item.FlightItems[i].OriginCityCountry.Split(',')[1].ToString();


                                        string varisHavaalaniKoduAkt = item.FlightSegment[i].ArrivalAirport.Split('(')[1].Split(')')[0].ToString();
                                        string varisSaatiAkt = item.FlightSegment[i].ArrivalDateTime.Substring(11, 5);
                                        string varisTarihiAkt = item.FlightSegment[i].ArrivalDateTime.Substring(0, 10);
                                        string varisSehirAkt = item.FlightSegment[i].ArrivaliCityCountry.Split(',')[0].ToString();
                                        string varisUlkeKoduAkt = rap.ulkeKodu(varisHavaalaniKoduAkt)[0].CountryCode;
                                        string varisUcusKoduAkt = item.FlightSegment[i].FlightNumber;
                                        string varisAirPortNameAkt = rap.ulkeKodu(varisHavaalaniKoduAkt)[0].AirportName;
                                        //string varisUlkeKoduAkt = item.FlightItems[i].DestinationCityCountry.Split(',')[1].ToString().Trim() == "Türkiye" ? "TR" : item.FlightItems[i].DestinationCityCountry.Split(',')[1].ToString();

                                        string durationAkt = KacSaatUcus(item.FlightSegment[i].DepartureDateTime, item.FlightSegment[i].ArrivalDateTime);

                                        aktBilgiSB.Append(GidisAktarmaBilgisi("", gidisHavaalaniKoduAkt, gidisSaatiAkt, gidisTarihiAkt, gidisSehirAkt, gidisUlkeKoduAkt, durationAkt, varisHavaalaniKoduAkt, varisSaatiAkt, varisTarihiAkt, varisSehirAkt, varisUlkeKoduAkt, varisUcusKoduAkt, gidisAirPortNameAkt, varisAirPortNameAkt, airCodeAkt, havayoluAdiAkt));
                                    }
                                }
                                string aktarmaSayisiHTML = "";
                                string aktarmaTrueFalse = "false";
                                if (aktSayisi > 0)
                                {
                                    aktarmaTrueFalse = "true";
                                    aktarmaSayisiHTML = AktarmaSayisi(aktSayisi.ToString());
                                }

                                string sonVarisTarihi = item.FlightSegment.First().ArrivalDateTime.Substring(0, 10);
                                string sonVarisSaati = item.FlightSegment.First().ArrivalDateTime.Substring(11, 5);
                                string classBilgiler = ClassDataInfo(gidisHavaalaniKodu, varisHavaalaniKodu, gidisSehir, varisSehir, ucusKodu + siraNo, aktSayisi.ToString(), gidisTarihi + " " + gidisSaati, sonVarisTarihi + " " + sonVarisSaati, ucusSinifi, havayoluAdi.ToLower(), airCode, aktarmaTrueFalse, Math.Ceiling(biletFiyati).ToString(), guidID.ToString());


                                //Dönüş uçuşları bu bölümde toplanacak..
                                //--------------------------------------------------------------------------------------------
                                foreach (var item2 in Donus)
                                {
                                    siraNo++;
                                    string havayoluAdi2 = "";

                                    string ucusSinifi2 = item2.FlightSegment.First().ResBookDesigCode;
                                    string ucusKodu2 = item2.FlightSegment.First().FlightNumber;
                                    string bagajBilgi2 = item2.FlightSegment.First().Luggage;
                                    //airCode = rhf.havayoluKodlari(item.FlightItems[0].CustomField3)[0].AirlineCode;
                                    string airCode2 = item2.FlightSegment.First().OperatingAirline;
                                    string airCodeOut2 = "";

                                    havayoluAdi2 = item2.FlightSegment.First().OperatingAirlineName;
                                    //bool varMi2 = dicHavayoluFirmaListe.TryGetValue(airCode2, out airCodeOut2);
                                    //if (!varMi2)
                                    //{
                                    //    dicHavayoluFirmaListe.Add(airCode2, havayoluAdi2);
                                    //}
                                    guidID2 = Guid.NewGuid();
                                    topluListeDisHat.Add(guidID2, item2);

                                    string gidisHavaalaniKodu2 = item2.FlightSegment.First().DepartureAirport.Split('(')[1].Split(')')[0].ToString();
                                    string gidisSaati2 = item2.FlightSegment.First().DepartureDateTime.Substring(11, 5);
                                    string gidisTarihi2 = item2.FlightSegment.First().DepartureDateTime.Substring(0, 10);
                                    string gidisSehir2 = item2.FlightSegment.First().DepartureCityCountry.Split(',')[0].ToString();
                                    string gidisUlkeKodu2 = rap.ulkeKodu(gidisHavaalaniKodu2).First().CountryCode;
                                    string gidisAirPortName2 = rap.ulkeKodu(gidisHavaalaniKodu2)[0].AirportName;
                                    ////string gidisUlkeKodu = item2.FlightItems[0].OriginCityCountry.Split(',')[1].ToString().Trim() == "Türkiye" ? "TR" : item2.FlightItems[0].OriginCityCountry.Split(',')[1].ToString();


                                    string varisHavaalaniKodu2 = item2.FlightSegment.First().ArrivalAirport.Split('(')[1].Split(')')[0].ToString();
                                    string varisSaati2 = item2.FlightSegment.First().ArrivalDateTime.Substring(11, 5);
                                    string varisTarihi2 = item2.FlightSegment.First().ArrivalDateTime.Substring(0, 10);
                                    string varisSehir2 = item2.FlightSegment.First().ArrivaliCityCountry.Split(',')[0].ToString();
                                    string varisUlkeKodu2 = rap.ulkeKodu(varisHavaalaniKodu2).First().CountryCode;
                                    string varisAirPortName2 = rap.ulkeKodu(varisHavaalaniKodu2)[0].AirportName;

                                    int aktSayisi2 = item2.FlightSegment.Length - 1;
                                    string durationBir2 = KacSaatUcus(item2.FlightSegment[0].DepartureDateTime, item2.FlightSegment[0].ArrivalDateTime);
                                    double biletFiyati2 = item3.ItinTotalFare.TotalFare;
                                    StringBuilder aktBilgiSB2 = new StringBuilder();
                                    aktBilgiSB2.Clear();
                                    for (int i = 0; i < item2.FlightSegment.Length; i++)
                                    {

                                        if (i != 0)
                                        {
                                            string airCodeAkt = item2.FlightSegment[i].OperatingAirline;//Logo için..
                                            string havayoluAdiAkt = item2.FlightSegment[i].OperatingAirlineName;

                                            string gidisHavaalaniKoduAkt2 = item2.FlightSegment[i].DepartureAirport.Split('(')[1].Split(')')[0].ToString();
                                            string gidisSaatiAkt2 = item2.FlightSegment[i].DepartureDateTime.Substring(11, 5);
                                            string gidisTarihiAkt2 = item2.FlightSegment[i].DepartureDateTime.Substring(0, 10);
                                            string gidisSehirAkt2 = item2.FlightSegment[i].DepartureCityCountry.Split(',')[0].ToString();
                                            string gidisUlkeKoduAkt2 = rap.ulkeKodu(gidisHavaalaniKoduAkt2)[0].CountryCode;
                                            string ucusSinifiAkt2 = item2.FlightSegment[i].ResBookDesigCode;
                                            string gidisAirPortNameAkt2 = rap.ulkeKodu(gidisHavaalaniKoduAkt2)[0].AirportName;
                                            //string gidisUlkeKoduAkt = item.FlightItems[i].OriginCityCountry.Split(',')[1].ToString().Trim() == "Türkiye" ? "TR" : item.FlightItems[i].OriginCityCountry.Split(',')[1].ToString();


                                            string varisHavaalaniKoduAkt2 = item2.FlightSegment[i].ArrivalAirport.Split('(')[1].Split(')')[0].ToString();
                                            string varisSaatiAkt2 = item2.FlightSegment[i].ArrivalDateTime.Substring(11, 5);
                                            string varisTarihiAkt2 = item2.FlightSegment[i].ArrivalDateTime.Substring(0, 10);
                                            string varisSehirAkt2 = item2.FlightSegment[i].ArrivaliCityCountry.Split(',')[0].ToString();
                                            string varisUlkeKoduAkt2 = rap.ulkeKodu(varisHavaalaniKoduAkt2)[0].CountryCode;
                                            string varisUcusKoduAkt2 = item2.FlightSegment[i].FlightNumber;
                                            string varisAirPortNameAkt2 = rap.ulkeKodu(varisHavaalaniKoduAkt2)[0].AirportName;
                                            //string varisUlkeKoduAkt = item.FlightItems[i].DestinationCityCountry.Split(',')[1].ToString().Trim() == "Türkiye" ? "TR" : item.FlightItems[i].DestinationCityCountry.Split(',')[1].ToString();

                                            string durationAkt2 = KacSaatUcus(item2.FlightSegment[i].DepartureDateTime, item2.FlightSegment[i].ArrivalDateTime);

                                            aktBilgiSB2.Append(GidisAktarmaBilgisi("", gidisHavaalaniKoduAkt2, gidisSaatiAkt2, gidisTarihiAkt2, gidisSehirAkt2, gidisUlkeKoduAkt2, durationAkt2, varisHavaalaniKoduAkt2, varisSaatiAkt2, varisTarihiAkt2, varisSehirAkt2, varisUlkeKoduAkt2, varisUcusKoduAkt2, gidisAirPortNameAkt2, varisAirPortNameAkt2, airCodeAkt, havayoluAdiAkt));
                                        }
                                    }
                                    string aktarmaSayisiHTML2 = "";
                                    string aktarmaTrueFalse2 = "false";
                                    if (aktSayisi2 > 0)
                                    {
                                        aktarmaTrueFalse2 = "true";
                                        aktarmaSayisiHTML2 = AktarmaSayisi(aktSayisi2.ToString());
                                    }

                                    string sonVarisTarihi2 = item2.FlightSegment.First().ArrivalDateTime.Substring(0, 10);
                                    string sonVarisSaati2 = item2.FlightSegment.First().ArrivalDateTime.Substring(11, 5);
                                    string classBilgiler2 = ClassDataInfo(gidisHavaalaniKodu2, varisHavaalaniKodu2, gidisSehir2, varisSehir2, ucusKodu2, aktSayisi2.ToString(), gidisTarihi2 + " " + gidisSaati2, sonVarisTarihi2 + " " + sonVarisSaati2, ucusSinifi2, havayoluAdi2.ToLower(), airCode2, aktarmaTrueFalse2, Math.Ceiling(biletFiyati2).ToString(), guidID.ToString());

                                    string toplaDonus = string.Format(gDisHatDonusSefer, "", gidisHavaalaniKodu2, gidisSaati2, gidisTarihi2, gidisSehir2, gidisUlkeKodu2, varisHavaalaniKodu2, varisSaati2, varisTarihi2, varisSehir2, varisUlkeKodu2, airCode2, havayoluAdi2, aktarmaSayisiHTML2, durationBir2, aktBilgiSB2.ToString(), "", ucusKodu2, "", gidisAirPortName2, varisAirPortName2, ucusKodu2 + siraNo);



                                    //classInfo, gidisHavayoluKodu, gidisSaati, gidisTarihi, gidisSehir, gidisUlkeKodu, varisHavayoluKodu, varisSaati, varisTarihi, varisSehir, varisUlkeKodu, havayoluLogo, havayoluAdi, aktSayisi, ucusSuresi, gSeferAktarmaBilgi, biletFiyat, ucusKodu, bagajKg, DonusSEFER
                                    //guidID.ToString() + "\',\'OW"
                                    sbGidisDonusDisHat.Append(GidisUcusBilgiDisHat(classBilgiler, gidisHavaalaniKodu, gidisSaati, gidisTarihi, gidisSehir, gidisUlkeKodu, varisHavaalaniKodu, varisSaati, varisTarihi, varisSehir, varisUlkeKodu, airCode, havayoluAdi, aktarmaSayisiHTML, durationBir, aktBilgiSB.ToString(), string.Format("{0:0.##} TL", Math.Ceiling(biletFiyatiDis)), ucusKodu, "", gidisAirPortName, varisAirPortName, ucusKodu + siraNo, toplaDonus, guidID.ToString() + "','" + guidID2.ToString() + "\',\'RT"));

                                }
                                //DONUS END-----------------------------------------------------

                            }
                            //foreach (var item in item3.OriginDestinationOptionList)
                            //{
                            //}
                        }
                        #endregion
                    }
                    Session["topluListeDisHat"] = topluListeDisHat;
                    Session["pricedItineraryList"] = pricedItineraryList;
                }


                if (dishat == true && tekYon == false)
                {
                    ucusListesiTumu.InnerHtml = "<div class=\"ucus-listesi-baslik\">GİDİŞ LİSTESİ</div>" + "<div id=\"ucusListesi\" runat=\"server\" clientidmode=\"static\">" +
             sbGidisDonusDisHat.ToString() + "</div>" + "<div class=\"sefer-degistir-gidis\">Gidiş Seferini Değiştirmek İçin Tıklayınız!</div>";
                    airLinelist.InnerHtml = filterAirLineList(dicHavayoluFirmaListe);
                }
                else
                {
                    //string siralamaStr="<div class=\"col-md-3 col-sm-3 col-xs-6 sort\"> <select class=\"selectpicker\"> <option>Name</option> "+
                    //"<option>Ascending</option> <option>Descending</option> </select> </div>";

                    airLinelist.InnerHtml = filterAirLineList(dicHavayoluFirmaListe);
                    ucusListesiTumu.InnerHtml = "<div class=\"ucus-listesi-baslik\">GİDİŞ LİSTESİ</div>" + "<div id=\"ucusListesi\" runat=\"server\" clientidmode=\"static\">" +
             sbGidis.ToString() + "</div>" + "<div class=\"sefer-degistir-gidis\">Gidiş Seferini Değiştirmek İçin Tıklayınız!</div>";
                    if (tekYon == false)
                    {

                        ucusListesiTumu.InnerHtml = ucusListesiTumu.InnerHtml + "<div class=\"ucus-listesi-baslik\">DÖNÜŞ LİSTESİ</div>" + "<div id=\"donusUcusListesi\" runat=\"server\" clientidmode=\"static\">" + sbDonus.ToString() + "</div>" + "<div class=\"sefer-degistir-donus\">Dönüş Seferini Değiştirmek İçin Tıklayınız!</div>";
                    }

                }
                // 

                //}
                //catch
                //{

                //}
            }

        }



        private string GidisUcusBilgi(string classInfo, string gidisHavayoluKodu, string gidisSaati, string gidisTarihi, string gidisSehir, string gidisUlkeKodu, string varisHavayoluKodu, string varisSaati, string varisTarihi, string varisSehir, string varisUlkeKodu, string havayoluLogo, string havayoluAdi, string aktSayisi, string ucusSuresi, string gSeferAktarmaBilgi, string biletFiyat, string ucusKodu, string bagajKg, string gAirportName, string dAirtportName, string ucusKoduSiraNo, string guidYon)
        {
            return String.Format(gSefer, classInfo, gidisHavayoluKodu, gidisSaati, gidisTarihi, gidisSehir, gidisUlkeKodu, varisHavayoluKodu, varisSaati, varisTarihi, varisSehir, varisUlkeKodu, havayoluLogo, havayoluAdi, aktSayisi, ucusSuresi, gSeferAktarmaBilgi, biletFiyat, ucusKodu, bagajKg, gAirportName, dAirtportName, ucusKoduSiraNo, guidYon);
        }



        /*
         1  - gidisHavayoluKodu     (DEL 21:00)
         2  - gisiSaat              (DEL 21:00)
         3  - gidisTarih            (SAT, 21 SEP) - Havaalanı gelecek..!
         4  - gidisSehir            (London)
         5  - gidisUlkeKodu         (TR)
         
         6  - varisHavayoluKodu     (DEL 21:00)
         7  - varisaat              (DEL 21:00)
         8  - varisTarih            (SAT, 21 SEP)
         9  - varisSehir            (London)
         10 - varisUlkeKodu         (TR) 
         
         11 - Havayolu Logosu
         12 - HavaYolu Adı (hidden olarak yazdırdık)
         13 - aktSayisi Aktarma varsa kaç akatarma olduğu (2)
         14 - ucusSuresi           (2h 30m)
         15 - Aktarmar varsa eklenen HTML gSeferAktarma
         16 - Fiyat
         17 - Ucuk Kodu (TK2730)
         18 - Bagaj Kapasite
         19 - Havaalanı Adı (Kalkıs)
         20 - Havaalanı adı (Varış)
         21 - Ucuk Kodu (TK2730)+SıraNo
         22 - guid ve Yön durumu (OW-RT)
         */
        string gSefer = "<div style=\"display: block;\" {0} class=\"flight-list-v2\"> " +
                     "<div class=\"flight-list-main {21}\">" +
                         "<div class=\"col-md-2 col-sm-2 text-center airline\">" +
                             "<img src=\"/assets/images/airline/{11}.png\" alt=\"{12}\">" +
            //"<h6>Vistara</h6>" +
                             "<input type=\"hidden\" id=\"kim\" class=\"{11}\" value=\"{12}\">" +
                             "<input type=\"hidden\" id=\"kalkisTarih\" value=\"{3}\">" +
                             "<input type=\"hidden\" id=\"varisTarih\" value=\"{8}\">" +
                             "<div class=\"flyCode\"><span><i class=\"fa fa-plane\"></i> {17}</span></div>" +
                         "</div>" +
                         "<div class=\"col-md-3 col-sm-3 departure\">" +
                             "<h3><i class=\"fa fa-plane\"></i> {2}</h3>" +
            //"<h5 class=\"bold\">{3}</h5>" +
                             "<span>{19} ({1})</span>" +
                             "<h5>{4}, {5}</h5>" +
                         "</div>" +
                         "<div class=\"col-md-4 col-sm-4 stop-duration\">" +
                           "<div class=\"duration text-center\">" +
                                 "<span><i class=\"fa fa-clock-o\"></i> {14}</span>" +
                             "</div>" +
                             "<div class=\"flight-direction\">" +
                             "</div>" +
                             "<div class=\"stop\">" +
                             "</div>" +
                             "{13}" +

                         "</div>" +
                         "<div class=\"col-md-3 col-sm-3 destination\">" +
                             "<h3><i class=\"fa fa-plane fa-rotate-90\"></i> {7}</h3>" +
            //"<h5 class=\"bold\">{8}</h5>" +
                             "<span>{20} ({6})</span>" +
                             "<h5>{9}, {10}</h5>" +
                         "</div>" +
                         "<div class=\"clearfix\"></div>" +
                     "</div>" +
                     "<div class=\"flight-list-main {21}Akt\" style=\"display:none\">" +
                     "{15}" +
                      "<div class=\"clearfix\"></div>" +
                        "</div>" +

                     "<div class=\"flight-list-footer\">" +
                         "<div class=\"col-md-7 col-sm-6 col-xs-6 sm-invisible\">" +
                             "<span><i class=\"fa fa-plane\"></i>{17}</span>" +
                             "<span class=\"refund\"><i class=\"fa fa-undo\"></i>Refundable</span>" +
                             "<span><i class=\"fa fa-suitcase\"></i>{18} KG</span>" +
                             "<span data-toggle=\"modal\" data-target=\".flight-details\"><i class=\"fa fa-info-circle\"></i></span>" +
                         "</div>" +
                         "<div class=\"btnFiyat\">" +
            //"<div class=\"fiyat-right\"> <span>{16}</span>" +
            //"<a href=\"#\">BOOK</a>" +
            "<button type=\"button\" id=\"btnAirSearch\" onclick=\"detaylandir(\'{22}\');\" class=\"sec-button btn transition-effect\">{16}</button>" +
            //"</div>" +
                         "</div>" +
                     "</div>" +
                 "</div>";

        private string AktarmaSayisi(string aktSayisi)
        {
            return String.Format(gAktarmaSayisi, aktSayisi);
        }

        string gAktarmaSayisi = "<div class=\"stop-box\" style=\"z-index: 999; cursor: pointer;\" onclick=\"aktGoster(this);\">" +
                                 "<span>{0} Aktarma</span>" +
                             "</div>";

        private string GidisAktarmaBilgisi(string bosKALACAK, string gidisHavayoluKodu, string gidisSaati, string gidisTarihi, string gidisSehir, string gidisUlkeKodu, string ucusSuresi, string varisHavayoluKodu, string varisSaati, string varisTarihi, string varisSehir, string varisUlkeKodu, string ucusKodu, string gAirportName, string vAirportName, string logoCode, string havayoluAdi)
        {
            return String.Format(gSeferAktarma, "", gidisHavayoluKodu, gidisSaati, gidisTarihi, gidisSehir, gidisUlkeKodu, ucusSuresi, varisHavayoluKodu, varisSaati, varisTarihi, varisSehir, varisUlkeKodu, ucusKodu, gAirportName, vAirportName, logoCode, havayoluAdi);
        }
        // 0  - BOŞ KALACAK
        // 1  - gidisHavayoluKodu     (DEL 21:00)
        // 2  - gisiSaat              (DEL 21:00)
        // 3  - gidisTarih            (SAT, 21 SEP)
        // 4  - gidisSehir            (London)
        // 5  - gidisUlkeKodu         (TR)

        // 6  - ucusSuresi           (2h 30m)

        // 7  - varisHavayoluKodu     (DEL 21:00)
        // 8  - varisaat              (DEL 21:00)
        // 9  - varisTarih            (SAT, 21 SEP)
        // 10 - varisSehir            (London)
        // 11 - varisUlkeKodu         (TR) 
        // 13 - gAirportName          (Sabigökçen)
        // 14 - vAirportName          (Sabigökçen)
        // 15 - airCpde               (TK)
        // 16 - havayoluAdi           (Türk Hava Yollari)
        string gSeferAktarma =
              "<div class=\"flight-list-main\" >" +

"<div class=\"col-md-2 col-sm-2 text-center airline\"><img src=\"/assets/images/airline/{15}.png\" alt=\"{16}\"><input type=\"hidden\" id=\"kim\" value=\"{16}\">" +
"<div class=\"flyCode\"><span><i class=\"fa fa-plane\"></i> {12}</span></div>" +
        "</div>" +

"{0}" +

"<div class=\"col-md-3 col-sm-3 departure \">" +
"<h3><i class=\"fa fa-plane\"></i> {2}</h3>" +
            //"<h5 class=\"bold\">{3}</h5>"+
         "<span>{13} ({1})</span>" +
        "<h5>{4}, {5}</h5></div>" +

"<div class=\"col-md-4 col-sm-4 stop-duration \"><div class=\"duration text-center\"><span><i class=\"fa fa-clock-o\"></i> {6}</span></div><div class=\"flight-direction\"></div><div class=\"stop\"></div></div>" +

"<div class=\"col-md-3 col-sm-3 destination\">" +
"<h3><i class=\"fa fa-plane fa-rotate-90\"></i> {8}</h3>" +
            //"<h5 class=\"bold\">{9}</h5>"+
        "<span>{14} ({7})</span>" +
        "<h5>{10}, {11}</h5></div>" +

          "<div class=\"clearfix\"></div>" +
                        "</div>";


        //string gSeferData = "data-destination=\"SAW\" data-arrival=\"AYT\" data-origindestination=\"Sabiha Gokcen (SAW);Antalya (AYT)\" data-custom1=\"1\" data-custom2=\"3\" data-datetime=\"22.02.2018 22:35:00\" data-arrivaldatetime=\"22.02.2018 23:55:00\" data-class=\"A\" data-airlinename=\"SunExpress\" data-airline=\"XQ\" data-isconnect=\"false\""
        private string ClassDataInfo(string gidisHavaalaniKodu, string varisHavaalaniKodu, string gidisHavayoluKoduLong, string varisHavayoluKoduLong, string ucakKodu, string data_custom2, string orginDateTime, string varisDateTime, string ucusSinifi, string airLongName, string airLineCode, string aktarmaDurum, string biletFiyat, string gID)
        {
            return String.Format(gClassSeferData, gidisHavaalaniKodu, varisHavaalaniKodu, gidisHavayoluKoduLong, varisHavayoluKoduLong, ucakKodu, data_custom2, orginDateTime, varisDateTime, ucusSinifi, airLongName, airLineCode, aktarmaDurum, biletFiyat, gID);
        }
        string gClassSeferData = "data-destination=\"{0}\" data-arrival=\"{1}\" data-originLong=\"{2}\" data-destinationLong=\"{3}\" data-ucakSinif=\"{4}\" data-aktSayisi=\"{5}\"  data-datetime=\"{6}\" data-arrivaldatetime=\"{7}\" data-class=\"{8}\" data-airlineName=\"{9}\" data-airlineCode=\"{10}\" data-AktarmaMi=\"{11}\" data-price=\"{12}\" data-guidID=\"{13}\" ";


        string KacSaatUcus(string kalkisTarih, string varisTarih)
        {
            string toplamSure = "";
            try
            {
                DateTime tarih = new DateTime();
                DateTime tarih2 = new DateTime();

                tarih = Convert.ToDateTime(kalkisTarih);
                tarih2 = Convert.ToDateTime(varisTarih);


                // diff1 gets 185 days, 14 hours, and 47 minutes.
                int saat = Math.Abs(Convert.ToInt32(tarih.Subtract(tarih2).ToString().Split(':')[0].ToString()));
                int dakika = Math.Abs(Convert.ToInt32(tarih.Subtract(tarih2).ToString().Split(':')[1].ToString()));

                if (saat > 0)
                {
                    toplamSure = saat + "saat ";
                }
                if (dakika > 0)
                {
                    toplamSure += dakika + "dk";
                }
            }
            catch
            {

            }
            return toplamSure;
        }


        //private List<Dictionary<String, Object>> ValidateScenarioProductItemData(List<Dictionary<String, Object>> pList)
        //{
        //    var tPeriods = new List<dynamic>();
        //    var tCycleProductItemSales = new List<dynamic>();
        //    foreach (var tItem in pList.Where(x => !string.IsNullOrEmpty(x["IsInternal"].ToString())))
        //    {
        //        var i = 0;
        //        foreach (var item in tPeriods)
        //        {
        //            i++;
        //            var tHasSails = tCycleProductItemSales.Where(CPIS => CPIS.CycleId == Convert.ToInt32(tItem["CycleId"].ToString()) && CPIS.ProductItemId == Convert.ToInt32(tItem["ProductItemId"].ToString()) && CPIS.PeriodId == Convert.ToInt32(item.Id.ToString()));
        //            if (!tHasSails.Any())
        //            {
        //                tItem[string.Format("Datasource{0}Id", i)] = 0;
        //            }
        //        }
        //    }
        //    return pList;
        //}
        private string filterAirLineList(Dictionary<string, string> listeGon)
        {
            string liListe = "";
            foreach (var item in listeGon)
            {
                string birlesik = item.Value.Replace(" ", "_");
                //liListe += "<li class=\"meals-trip\" id=" + item.Key + "><input id=" + item.Key + " type=\"checkbox\"><img src=\"/assets/images/airline/" + item.Key + ".png\" alt=" + birlesik + ">" + item.Value + "</li>";
                liListe += "<li class=\"meals-trip\" id=" + item.Key + "><input id=" + item.Key + " type=\"checkbox\">" + item.Value + "</li>";
            }

            return String.Format(filterAirLine, liListe);
        }

        string filterAirLine = "<h5><i class=\"fa fa-plane\"></i>Hava Yollari</h5>" +
                            "<ul class=\"clickMeLi\">" +
                            "{0}" +
                            "</ul>";



        //
        private string GidisUcusBilgiDisHat(string classInfo, string gidisHavayoluKodu, string gidisSaati, string gidisTarihi, string gidisSehir, string gidisUlkeKodu, string varisHavayoluKodu, string varisSaati, string varisTarihi, string varisSehir, string varisUlkeKodu, string havayoluLogo, string havayoluAdi, string aktSayisi, string ucusSuresi, string gSeferAktarmaBilgi, string biletFiyat, string ucusKodu, string bagajKg, string gidisAirPortName, string varisAirPortName, string blaUcusKod, string DonusSEFER, string guidIDInfo)
        {
            return String.Format(gDisHatGidisSefer, classInfo, gidisHavayoluKodu, gidisSaati, gidisTarihi, gidisSehir, gidisUlkeKodu, varisHavayoluKodu, varisSaati, varisTarihi, varisSehir, varisUlkeKodu, havayoluLogo, havayoluAdi, aktSayisi, ucusSuresi, gSeferAktarmaBilgi, biletFiyat, ucusKodu, bagajKg, gidisAirPortName, varisAirPortName, blaUcusKod, DonusSEFER, guidIDInfo);
        }



        /*
         1  - gidisHavayoluKodu     (DEL 21:00)
         2  - gisiSaat              (DEL 21:00)
         3  - gidisTarih            (SAT, 21 SEP)
         4  - gidisSehir            (London)
         5  - gidisUlkeKodu         (TR)
         
         6  - varisHavayoluKodu     (DEL 21:00)
         7  - varisaat              (DEL 21:00)
         8  - varisTarih            (SAT, 21 SEP)
         9  - varisSehir            (London)
         10 - varisUlkeKodu         (TR) 
         
         11 - Havayolu Logosu
         12 - HavaYolu Adı (hidden olarak yazdırdık)
         13 - aktSayisi Aktarma varsa kaç akatarma olduğu (2)
         14 - ucusSuresi           (2h 30m)
         15 - Aktarma varsa eklenen HTML gSeferAktarma
         16 - Fiyat
         17 - Ucuk Kodu (TK2730)
         18 - Bagaj Kapasite
         19 - Havaalanı Adı (Kalkıs)
         20 - Havaalanı adı (Varış)
         21 - Ucuk Kodu (TK2730)+SıraNo
         */
        string gDisHatGidisSefer = "<div style=\"display: block;\" {0} class=\"flight-list-v2\"> " +
                     "<div class=\"flight-list-main {21}\">" +
                         "<div class=\"col-md-2 col-sm-2 text-center airline\">" +
                             "<img src=\"/assets/images/airline/{11}.png\" alt=\"cruise\">" +
            //"<h6>Vistara</h6>" +
                             "<input type=\"hidden\" id=\"kim\" class=\"{11}\" value=\"{12}\">" +
                              "<input type=\"hidden\" id=\"kalkisTarih\" value=\"{3}\">" +
                             "<input type=\"hidden\" id=\"varisTarih\" value=\"{8}\">" +
                             "<div class=\"flyCode\"><span><i class=\"fa fa-plane\"></i> {17}</span></div>" +
                         "</div>" +
                         "<div class=\"col-md-3 col-sm-3 departure\">" +
                             "<h3><i class=\"fa fa-plane\"></i> {2}</h3>" +
            //"<h5 class=\"bold\">{3}</h5>" +
                             "<span>{19} ({1})</span>" +
                             "<h5>{4}, {5}</h5>" +
            //"<h5>{17}</h5>" +
                         "</div>" +
                         "<div class=\"col-md-4 col-sm-4 stop-duration\">" +
                           "<div class=\"duration text-center\">" +
                                 "<span><i class=\"fa fa-clock-o\"></i> {14}</span>" +
                             "</div>" +
                             "<div class=\"flight-direction\">" +
                             "</div>" +
                             "<div class=\"stop\">" +
                             "</div>" +
                             "{13}" +

                         "</div>" +
                         "<div class=\"col-md-3 col-sm-3 destination\">" +
                             "<h3><i class=\"fa fa-plane fa-rotate-90\"></i> {7}</h3>" +
            //"<h5 class=\"bold\">{8}</h5>" +
                              "<span>{20} ({6})</span>" +
                             "<h5>{9}, {10}</h5>" +
                         "</div>" +
                         "<div class=\"clearfix\"></div>" +
                     "</div>" +
                        "<div class=\"flight-list-main {21}Akt\" style=\"display:none\">" +
                     "{15}" +
                      "<div class=\"clearfix\"></div>" +
                        "</div>" +
                          "<hr />" +

                     "{22}" +
                     "<div class=\"flight-list-footer\">" +
                         "<div class=\"col-md-7 col-sm-6 col-xs-6 sm-invisible\">" +
                             "<span><i class=\"fa fa-plane\"></i>{17}</span>" +
                             "<span class=\"refund\"><i class=\"fa fa-undo\"></i>Refundable</span>" +
                             "<span><i class=\"fa fa-suitcase\"></i>{18} KG</span>" +
                             "<span data-toggle=\"modal\" data-target=\".flight-details\"><i class=\"fa fa-info-circle\"></i></span>" +
                         "</div>" +
                         "<div class=\"btnFiyat\">" +
            //"<div class=\"fiyat-right\"> <span>{16}</span>" +
            //"<a href=\"#\">BOOK</a>" +
            "<button type=\"button\" id=\"btnAirSearch\" onclick=\"detaylandir2(\'{23}\');\" class=\"sec-button btn transition-effect\">{16}</button>" +
            //"</div>" +
                         "</div>" +
                     "</div>" +
            //         "<div class=\"flight-list-footer\">" +
            //             "<div class=\"col-md-7 col-sm-6 col-xs-6 sm-invisible\">" +
            //                 "<span><i class=\"fa fa-plane\"></i>{17}</span>" +
            //                 "<span class=\"refund\"><i class=\"fa fa-undo\"></i>Refundable</span>" +
            //                 "<span><i class=\"fa fa-suitcase\"></i>{18} KG</span>" +
            //                 "<span data-toggle=\"modal\" data-target=\".flight-details\"><i class=\"fa fa-info-circle\"></i></span>" +
            //             "</div>" +
            //             "<div class=\"btnFiyat\">" +
            //                "{16}"+
            //                     //"<span></span>" +
            ////"<a href=\"#\">BOOK</a>" +
            //"<button type=\"button\" id=\"btnAirSearch\" onclick=\"detaylandir(\'{17}\');\" class=\"sec-button btn transition-effect\">{16}</button>" +

            //             "</div>" +
            //         "</div>" +



                 "</div>";

        string gDisHatDonusSefer = "<div class=\"flight-list-main {21}\">" +
                    "<div class=\"col-md-2 col-sm-2 text-center airline\">" +
                        "<img src=\"/assets/images/airline/{11}.png\" alt=\"cruise\">" +
            //"<h6>Vistara</h6>" +
                        "<input type=\"hidden\" id=\"kim\" class=\"{11}\" value=\"{12}\">" +
                         "<input type=\"hidden\" id=\"kalkisTarih\" value=\"{3}\">" +
                        "<input type=\"hidden\" id=\"varisTarih\" value=\"{8}\">" +
                        "<div class=\"flyCode\"><span><i class=\"fa fa-plane\"></i> {17}</span></div>" +
                    "</div>" +
                    "{0}" + //boş öylesine
                    "<div class=\"col-md-3 col-sm-3 departure\">" +
                        "<h3><i class=\"fa fa-plane\"></i> {2}</h3>" +

                        "<span>{19} ({1})</span>" +
                        "<h5>{4}, {5}</h5>" +

                    "</div>" +
                    "<div class=\"col-md-4 col-sm-4 stop-duration\">" +
                      "<div class=\"duration text-center\">" +
                            "<span><i class=\"fa fa-clock-o\"></i> {14}</span>" +
                        "</div>" +
                        "<div class=\"flight-direction\">" +
                        "</div>" +
                        "<div class=\"stop\">" +
                        "</div>" +
                        "{13}" +

                    "</div>" +
                    "<div class=\"col-md-3 col-sm-3 destination\">" +
                        "<h3><i class=\"fa fa-plane fa-rotate-90\"></i> {7}</h3>" +

                         "<span>{20} ({6})</span>" +
                        "<h5>{9}, {10}</h5>" +
                    "</div>" +
                    "<div class=\"clearfix\"></div>" +
                "</div>" +
                   "<div class=\"flight-list-main {21}Akt\" style=\"display:none\">" +
                "{15}" +
                 "<div class=\"clearfix\"></div>" +
                   "</div>{16}{18}";//16-18 öylesine

        //string gDisHatDonusSefer = "<div class=\"flight-list-main {19} {0}\">" +
        //                 "<div class=\"col-md-2 col-sm-2 text-center airline\">" +
        //                     "<img src=\"/assets/images/airline/{11}.png\" alt=\"cruise\">" +
        //    //"<h6>Vistara</h6>" +
        //                     "<input type=\"hidden\" id=\"kim\" class=\"{11}\" value=\"{12}\">" +
        //                 "</div>" +
        //                 "<div class=\"col-md-3 col-sm-3 departure\">" +
        //                     "<h3><i class=\"fa fa-plane\"></i>{1} {2}</h3>" +
        //                     "<h5 class=\"bold\">{3}</h5>" +
        //                     "<h5>{4}, {5}</h5>" +
        //                       "<h5>{17}</h5>" +
        //                 "</div>" +
        //                 "<div class=\"col-md-4 col-sm-4 stop-duration\">" +
        //                   "<div class=\"duration text-center\">" +
        //                         "<span><i class=\"fa fa-clock-o\"></i> {14}</span>" +
        //                     "</div>" +
        //                     "<div class=\"flight-direction\">" +
        //                     "</div>" +
        //                     "<div class=\"stop\">" +
        //                     "</div>" +
        //                     "{13}" +

        //                 "</div>" +
        //                 "<div class=\"col-md-3 col-sm-3 destination\">" +
        //                     "<h3><i class=\"fa fa-plane fa-rotate-90\"></i>{6} {7}</h3>" +
        //                     "<h5 class=\"bold\">{8}</h5>" +
        //                     "<h5>{9}, {10}</h5>" +
        //                 "</div>" +
        //             "</div>" +
        //                "<div class=\"flight-list-main {21}Akt\" style=\"display:none\">" +
        //             "{15}" +
        //              "<div class=\"clearfix\"></div>" +
        //                "</div>" +
        //             "<div class=\"clearfix\"></div>" +
        //             "<div class=\"flight-list-footer\">" +
        //                 "<div class=\"col-md-6 col-sm-6 col-xs-6 sm-invisible\">" +
        //                     "<span><i class=\"fa fa-plane\"></i>{17}</span>" +
        //                     "<span class=\"refund\"><i class=\"fa fa-undo\"></i>Refundable</span>" +
        //                     "<span><i class=\"fa fa-suitcase\"></i>{18} KG</span>" +
        //                     "<span data-toggle=\"modal\" data-target=\".flight-details\"><i class=\"fa fa-info-circle\"></i></span>" +
        //                 "</div>" +
        //                 "<div class=\"col-md-6 col-sm-6 col-xs-12 clear-padding\">" +
        //                     "<div class=\"pull-right\">" +
        //                         "<span>{16}</span>" +
        //                         "<a href=\"#\">BOOK</a>" +
        //                     "</div>" +
        //                 "</div>" +
        //             "</div>";
    }
}
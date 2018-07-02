using birSifirUcuzaUc.Data;
using birSifirUcuzaUc.Data.Repository;
using birSifirUcuzaUc.WebUI.birSifirServis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace birSifirUcuzaUc.WebUI.Ucus
{
    public partial class Satis : System.Web.UI.Page
    {
        BirsifirSoapClient cl = new BirsifirSoapClient();
        RepositoryAirport rap = new RepositoryAirport();

        protected void Page_Load(object sender, EventArgs e)
        {
            //ContentPlaceHolder1_gidisBilgileri.InnerHtml = generalInfo;

            if (!IsPostBack)
            {
                string gidisJsonSonuc = "";
                string donusJsonSonuc = "";
                int trasferIndex = 0;
                var kisiListesi = Yolcular.yolcuTipSayi;
                #region yolcuTipleriSayilari
                string yetiskinSayi = "0";
                string cocukSayi = "0";
                string bebekSayi = "0";
                foreach (var item in kisiListesi)
                {
                    if (item.yolcuTipi == "Yetiskin")
                    {
                        yetiskinSayi = item.yolcuSayisi;
                    }
                    if (item.yolcuTipi == "Cocuk")
                    {
                        cocukSayi = item.yolcuSayisi;
                    }
                    if (item.yolcuTipi == "Bebek")
                    {
                        bebekSayi = item.yolcuSayisi;
                    }

                }
                #endregion





                if (Request.QueryString["disHat"] != null && Request.QueryString["disHat"].ToString() == "false")
                {
                    #region İçHat-Gidiş (Session["topluListe"] != null && Request.QueryString["gFlightID"] != null && Session["uu_SessionID"] != null)
                    if (Session["topluListe"] != null && Request.QueryString["gFlightID"] != null && Session["uu_SessionID"] != null)
                    {
                        string uu_SessionID = Session["uu_SessionID"].ToString();

                        Dictionary<Guid, FlightSegmentResults> tekYonListe = (Dictionary<Guid, FlightSegmentResults>)Session["topluListe"];
                        Guid guID = new Guid(Request.QueryString["gFlightID"].ToString());
                        FlightSegmentResults sonuc = tekYonListe[guID];
                        Session["gSeciliSefer"] = sonuc;
                        StringBuilder gidisSeferTopla = new StringBuilder();
                        StringBuilder donusSeferTopla = new StringBuilder();

                        string havayoluAdi = "";

                        string ucusSinifi = sonuc.FlightItems[0].ClassCode;
                        string ucusKodu = sonuc.FlightItems[0].FlightNo;
                        string bagajBilgi = sonuc.Luggage;
                        //airCode = rhf.havayoluKodlari(item.FlightItems[0].CustomField3)[0].AirlineCode;
                        string airCode = sonuc.FlightItems[0].Carrier;//Logo için..

                        havayoluAdi = sonuc.FlightItems[0].CustomField3.ToString();

                        string gidisHavaalaniKodu = sonuc.FlightItems[0].OriginCode;
                        string gidisSaati = sonuc.FlightItems[0].DepartureTime.Substring(11, 5);
                        string gidisTarihi = Convert.ToDateTime(sonuc.FlightItems[0].DepartureTime.Substring(0, 10)).ToString("dd/MM/yyyy");
                        string gidisSehir = sonuc.FlightItems[0].OriginCityCountry.Split(',')[0].ToString();
                        string gidisUlkeKodu = rap.ulkeKodu(gidisHavaalaniKodu)[0].CountryCode;
                        string gidisAirPortName = rap.ulkeKodu(gidisHavaalaniKodu)[0].AirportName;

                        string gidisAirPortCityCountry = sonuc.FlightItems[0].Origin + ", " + sonuc.FlightItems[0].OriginCityCountry;
                        //string gidisUlkeKodu = item.FlightItems[0].OriginCityCountry.Split(',')[1].ToString().Trim() == "Türkiye" ? "TR" : item.FlightItems[0].OriginCityCountry.Split(',')[1].ToString();


                        string varisHavaalaniKodu = sonuc.FlightItems[0].DestinationCode;
                        string varisSaati = sonuc.FlightItems[0].ArrivalTime.Substring(11, 5);
                        string varisTarihi = Convert.ToDateTime(sonuc.FlightItems[0].ArrivalTime.Substring(0, 10)).ToString("dd/MM/yyyy");
                        string varisSehir = sonuc.FlightItems[0].DestinationCityCountry.Split(',')[0].ToString();
                        string varisUlkeKodu = rap.ulkeKodu(varisHavaalaniKodu)[0].CountryCode;
                        string varisAirPortName = rap.ulkeKodu(varisHavaalaniKodu)[0].AirportName;

                        string varisAirPortCityCountry = sonuc.FlightItems[0].Destination + ", " + sonuc.FlightItems[0].DestinationCityCountry;

                        gidisSeferTopla.Append(FlightItem(airCode, ucusKodu, ucusSinifi, gidisTarihi, gidisSaati, gidisAirPortCityCountry, varisTarihi, varisSaati, varisAirPortCityCountry, havayoluAdi));

                        string isConnection = "false";
                        if (sonuc.FlightItems.Count() > 1)
                            isConnection = "true";

                        gidisJsonSonuc += gidis_jSon("0", trasferIndex, gidisHavaalaniKodu, varisHavaalaniKodu, sonuc.FlightItems[0].DepartureTime, sonuc.FlightItems[0].ArrivalTime, airCode, ucusKodu, ucusSinifi, isConnection, sonuc.FlightItems[0].CustomField1, sonuc.FlightItems[0].CustomField2, sonuc.FlightItems[0].Origin, sonuc.FlightItems[0].Destination, sonuc.FlightItems[0].CustomField3);

                        for (int i = 0; i < sonuc.FlightItems.Length; i++)
                        {

                            if (i != 0)
                            {
                                gidisSeferTopla.Append(aktarmaGosterge);

                                string havayoluAdiAkt = sonuc.FlightItems[i].CustomField3.ToString();

                                string ucusSinifiAkt = sonuc.FlightItems[i].ClassCode;
                                string ucusKoduAkt = sonuc.FlightItems[i].FlightNo;
                                //string bagajBilgiAkt = sonuc.Luggage;
                                //airCode = rhf.havayoluKodlari(item.FlightItems[0].CustomField3)[0].AirlineCode;
                                string airCodeAkt = sonuc.FlightItems[i].Carrier;//Logo için..

                                string gidisHavaalaniKoduAkt = sonuc.FlightItems[i].OriginCode;
                                string gidisSaatiAkt = sonuc.FlightItems[i].DepartureTime.Substring(11, 5);
                                string gidisTarihiAkt = Convert.ToDateTime(sonuc.FlightItems[i].DepartureTime.Substring(0, 10)).ToString("dd/MM/yyyy");
                                string gidisSehirAkt = sonuc.FlightItems[i].OriginCityCountry.Split(',')[0].ToString();
                                string gidisUlkeKoduAkt = rap.ulkeKodu(gidisHavaalaniKoduAkt)[0].CountryCode;

                                string gidisAirPortNameAkt = rap.ulkeKodu(gidisHavaalaniKoduAkt)[0].AirportName;

                                string gidisAirPortCityCountryAkt = sonuc.FlightItems[i].Origin + ", " + sonuc.FlightItems[i].OriginCityCountry;
                                //string gidisUlkeKoduAkt = item.FlightItems[i].OriginCityCountry.Split(',')[1].ToString().Trim() == "Türkiye" ? "TR" : item.FlightItems[i].OriginCityCountry.Split(',')[1].ToString

                                string varisHavaalaniKoduAkt = sonuc.FlightItems[i].DestinationCode;
                                string varisSaatiAkt = sonuc.FlightItems[i].ArrivalTime.Substring(11, 5);
                                string varisTarihiAkt = Convert.ToDateTime(sonuc.FlightItems[i].ArrivalTime.Substring(0, 10)).ToString("dd/MM/yyyy");
                                string varisSehirAkt = sonuc.FlightItems[i].DestinationCityCountry.Split(',')[0].ToString();
                                string varisUlkeKoduAkt = rap.ulkeKodu(varisHavaalaniKoduAkt)[0].CountryCode;
                                string varisUcusKoduAkt = sonuc.FlightItems[i].FlightNo;
                                string varisAirPortNameAkt = rap.ulkeKodu(varisHavaalaniKoduAkt)[0].AirportName;

                                string varisAirPortCityCountryAkt = sonuc.FlightItems[i].Destination + ", " + sonuc.FlightItems[i].DestinationCityCountry;
                                //string varisUlkeKoduAkt = item.FlightItems[i].DestinationCityCountry.Split(',')[1].ToString().Trim() == "Türkiye" ? "TR" : item.FlightItems[i].DestinationCityCountry.Split(',')[1].ToString();

                                string durationAkt = KacSaatUcus(sonuc.FlightItems[i].DepartureTime, sonuc.FlightItems[i].ArrivalTime);

                                //aktBilgiSB.Append(GidisAktarmaBilgisi("", gidisHavaalaniKoduAkt, gidisSaatiAkt, gidisTarihiAkt, gidisSehirAkt, gidisUlkeKoduAkt, durationAkt, varisHavaalaniKoduAkt, varisSaatiAkt, varisTarihiAkt, varisSehirAkt, varisUlkeKoduAkt, varisUcusKoduAkt, gidisAirPortNameAkt, varisAirPortNameAkt));
                                gidisSeferTopla.Append(FlightItemAkt(airCodeAkt, ucusKoduAkt, ucusSinifiAkt, gidisTarihiAkt, gidisSaatiAkt, gidisAirPortCityCountryAkt, varisTarihiAkt, varisSaatiAkt, varisAirPortCityCountryAkt, havayoluAdiAkt));
                                trasferIndex++;
                                gidisJsonSonuc += "," + gidis_jSon("0", trasferIndex, gidisHavaalaniKoduAkt, varisHavaalaniKoduAkt, sonuc.FlightItems[i].DepartureTime, sonuc.FlightItems[i].ArrivalTime, airCodeAkt, ucusKoduAkt, ucusSinifiAkt, "true", sonuc.FlightItems[i].CustomField1, sonuc.FlightItems[i].CustomField2, sonuc.FlightItems[i].Origin, sonuc.FlightItems[i].Destination, sonuc.FlightItems[i].CustomField3);
                            }
                        }

                        if (Request.QueryString["dFlightID"] != null && Request.QueryString["dFlightID"] != "")
                        {

                            Guid guID2 = new Guid(Request.QueryString["dFlightID"].ToString());
                            FlightSegmentResults sonuc2 = tekYonListe[guID2];
                            Session["dSeciliSefer"] = sonuc2;

                            havayoluAdi = "";
                            ucusSinifi = sonuc2.FlightItems[0].ClassCode;
                            ucusKodu = sonuc2.FlightItems[0].FlightNo;
                            bagajBilgi = sonuc2.Luggage;
                            //airCode = rhf.havayoluKodlari(item.FlightItems[0].CustomField3)[0].AirlineCode;
                            airCode = sonuc2.FlightItems[0].Carrier;//Logo için..

                            havayoluAdi = sonuc2.FlightItems[0].CustomField3.ToString();

                            gidisHavaalaniKodu = sonuc2.FlightItems[0].OriginCode;
                            gidisSaati = sonuc2.FlightItems[0].DepartureTime.Substring(11, 5);
                            gidisTarihi = Convert.ToDateTime(sonuc2.FlightItems[0].DepartureTime.Substring(0, 10)).ToString("dd/MM/yyyy");
                            gidisSehir = sonuc2.FlightItems[0].OriginCityCountry.Split(',')[0].ToString();
                            gidisUlkeKodu = rap.ulkeKodu(gidisHavaalaniKodu)[0].CountryCode;
                            gidisAirPortName = rap.ulkeKodu(gidisHavaalaniKodu)[0].AirportName;
                            gidisAirPortCityCountry = sonuc2.FlightItems[0].Origin + ", " + sonuc2.FlightItems[0].OriginCityCountry;
                            //string gidisUlkeKodu = item.FlightItems[0].OriginCityCountry.Split(',')[1].ToString().Trim() == "Türkiye" ? "TR" : item.FlightItems[0].OriginCityCountry.Split(',')[1].ToString();


                            varisHavaalaniKodu = sonuc2.FlightItems[0].DestinationCode;
                            varisSaati = sonuc2.FlightItems[0].ArrivalTime.Substring(11, 5);
                            varisTarihi = Convert.ToDateTime(sonuc2.FlightItems[0].ArrivalTime.Substring(0, 10)).ToString("dd/MM/yyyy");
                            varisSehir = sonuc2.FlightItems[0].DestinationCityCountry.Split(',')[0].ToString();
                            varisUlkeKodu = rap.ulkeKodu(varisHavaalaniKodu)[0].CountryCode;
                            varisAirPortName = rap.ulkeKodu(varisHavaalaniKodu)[0].AirportName;
                            varisAirPortCityCountry = sonuc2.FlightItems[0].Destination + ", " + sonuc2.FlightItems[0].DestinationCityCountry;

                            donusSeferTopla.Append(FlightItemDonus(airCode, ucusKodu, ucusSinifi, gidisTarihi, gidisSaati, gidisAirPortCityCountry, varisTarihi, varisSaati, varisAirPortCityCountry, havayoluAdi));
                            trasferIndex = 0;

                            string isConnection2 = "false";
                            if (sonuc2.FlightItems.Count() > 1)
                                isConnection2 = "true";

                            donusJsonSonuc += gidis_jSon("1", trasferIndex, gidisHavaalaniKodu, varisHavaalaniKodu, sonuc2.FlightItems[0].DepartureTime, sonuc2.FlightItems[0].ArrivalTime, airCode, ucusKodu, ucusSinifi, isConnection2, sonuc2.FlightItems[0].CustomField1, sonuc2.FlightItems[0].CustomField2, sonuc2.FlightItems[0].Origin, sonuc2.FlightItems[0].Destination, sonuc2.FlightItems[0].CustomField3);

                            for (int i = 0; i < sonuc2.FlightItems.Length; i++)
                            {

                                if (i != 0)
                                {
                                    donusSeferTopla.Append(aktarmaGosterge);

                                    string havayoluAdiAkt = sonuc2.FlightItems[i].CustomField3.ToString();

                                    string ucusSinifiAkt = sonuc2.FlightItems[i].ClassCode;
                                    string ucusKoduAkt = sonuc2.FlightItems[i].FlightNo;
                                    //string bagajBilgiAkt = sonuc2.Luggage;
                                    //airCode = rhf.havayoluKodlari(item.FlightItems[0].CustomField3)[0].AirlineCode;
                                    string airCodeAkt = sonuc2.FlightItems[i].Carrier;//Logo için..

                                    string gidisHavaalaniKoduAkt = sonuc2.FlightItems[i].OriginCode;
                                    string gidisSaatiAkt = sonuc2.FlightItems[i].DepartureTime.Substring(11, 5);
                                    string gidisTarihiAkt = Convert.ToDateTime(sonuc2.FlightItems[i].DepartureTime.Substring(0, 10)).ToString("dd/MM/yyyy");
                                    string gidisSehirAkt = sonuc2.FlightItems[i].OriginCityCountry.Split(',')[0].ToString();
                                    string gidisUlkeKoduAkt = rap.ulkeKodu(gidisHavaalaniKoduAkt)[0].CountryCode;

                                    string gidisAirPortNameAkt = rap.ulkeKodu(gidisHavaalaniKoduAkt)[0].AirportName;

                                    string gidisAirPortCityCountryAkt = sonuc2.FlightItems[i].Origin + ", " + sonuc2.FlightItems[i].OriginCityCountry;
                                    //string gidisUlkeKoduAkt = item.FlightItems[i].OriginCityCountry.Split(',')[1].ToString().Trim() == "Türkiye" ? "TR" : item.FlightItems[i].OriginCityCountry.Split(',')[1].ToString();


                                    string varisHavaalaniKoduAkt = sonuc2.FlightItems[i].DestinationCode;
                                    string varisSaatiAkt = sonuc2.FlightItems[i].ArrivalTime.Substring(11, 5);
                                    string varisTarihiAkt = Convert.ToDateTime(sonuc2.FlightItems[i].ArrivalTime.Substring(0, 10)).ToString("dd/MM/yyyy");
                                    string varisSehirAkt = sonuc2.FlightItems[i].DestinationCityCountry.Split(',')[0].ToString();
                                    string varisUlkeKoduAkt = rap.ulkeKodu(varisHavaalaniKoduAkt)[0].CountryCode;
                                    string varisUcusKoduAkt = sonuc2.FlightItems[i].FlightNo;
                                    string varisAirPortNameAkt = rap.ulkeKodu(varisHavaalaniKoduAkt)[0].AirportName;

                                    string varisAirPortCityCountryAkt = sonuc2.FlightItems[i].Destination + ", " + sonuc2.FlightItems[i].DestinationCityCountry;
                                    //string varisUlkeKoduAkt = item.FlightItems[i].DestinationCityCountry.Split(',')[1].ToString().Trim() == "Türkiye" ? "TR" : item.FlightItems[i].DestinationCityCountry.Split(',')[1].ToString();

                                    string durationAkt = KacSaatUcus(sonuc2.FlightItems[i].DepartureTime, sonuc2.FlightItems[i].ArrivalTime);

                                    //aktBilgiSB.Append(GidisAktarmaBilgisi("", gidisHavaalaniKoduAkt, gidisSaatiAkt, gidisTarihiAkt, gidisSehirAkt, gidisUlkeKoduAkt, durationAkt, varisHavaalaniKoduAkt, varisSaatiAkt, varisTarihiAkt, varisSehirAkt, varisUlkeKoduAkt, varisUcusKoduAkt, gidisAirPortNameAkt, varisAirPortNameAkt));
                                    donusSeferTopla.Append(FlightItemAkt(airCodeAkt, ucusKoduAkt, ucusSinifiAkt, gidisTarihiAkt, gidisSaatiAkt, gidisAirPortCityCountryAkt, varisTarihiAkt, varisSaatiAkt, varisAirPortCityCountryAkt, havayoluAdiAkt));
                                    trasferIndex++;
                                    donusJsonSonuc += "," + gidis_jSon("1", trasferIndex, gidisHavaalaniKoduAkt, varisHavaalaniKoduAkt, sonuc2.FlightItems[i].DepartureTime, sonuc2.FlightItems[i].ArrivalTime, airCodeAkt, ucusKoduAkt, ucusSinifiAkt, "true", sonuc2.FlightItems[i].CustomField1, sonuc2.FlightItems[i].CustomField2, sonuc2.FlightItems[i].Origin, sonuc2.FlightItems[i].Destination, sonuc2.FlightItems[i].CustomField3);
                                }
                            }

                        }
                        //BURAYA DÖNÜŞ BİLGİLERİ GELSİN
                        Session["gidisJsonSonuc"] = gidisJsonSonuc;
                        Session["donusJsonSonuc"] = donusJsonSonuc;
                        var fiyatSonuc = cl.DomesticFlightPrice(uu_SessionID, yetiskinSayi, cocukSayi, bebekSayi, gidisJsonSonuc, donusJsonSonuc);
                        //var bla = cl.CreateTicket3D
                        string birimFiyat = "";
                        if (fiyatSonuc.FareResult.Fares[0] != null)
                        {
                            birimFiyat = birimFiyatIslem(fiyatSonuc);
                            string totalFiyat = string.Format("{0:0.##}", fiyatSonuc.FareResult.GrandTotalPrice).ToString();
                            kisiFiyatListesi.InnerHtml = kisiFiyatlamasi(birimFiyat, totalFiyat);
                            Session["birimFiyat"] = fiyatSonuc.FareResult.Fares[0].BasePrice.ToString().Replace(",", ".");
                            Session["totalFiyat"] = totalFiyat.Replace(",", ".");
                        }
                        _PessengerItems.InnerHtml = passangerMetot(fiyatSonuc);

                        ContentPlaceHolder1_gidisBilgileri.InnerHtml = GeneralInfo(gidisSeferTopla.ToString(), donusSeferTopla.ToString());
                    }
                    #endregion
                }
                else if (Request.QueryString["disHat"] != null && Request.QueryString["disHat"].ToString() == "true")
                {
                    #region DışHat-Gidiş (Session["topluListeDisHat"] != null && Request.QueryString["gFlightID"] != null && Session["uu_SessionID"] != null)
                    if (Session["topluListeDisHat"] != null && Request.QueryString["gFlightID"] != null && Session["uu_SessionID"] != null && Session["AspNet_SessionID"] != null && Session["pricedItineraryList"] != null)
                    {
                        Method.gFlightID = Request.QueryString["gFlightID"].ToString();
                        string uu_SessionID = Session["uu_SessionID"].ToString();
                        Dictionary<Guid, OriginDestinationOptionList> tekYonListe = (Dictionary<Guid, OriginDestinationOptionList>)Session["topluListeDisHat"];
                        Guid guID = new Guid(Request.QueryString["gFlightID"].ToString());
                        OriginDestinationOptionList sonuc = tekYonListe[guID];
                        Session["gSeciliSefer"] = sonuc;
                        StringBuilder gidisSeferTopla = new StringBuilder();
                        StringBuilder donusSeferTopla = new StringBuilder();

                        string havayoluAdi = "";

                        string ucusSinifi = sonuc.FlightSegment[0].ResBookDesigCode;
                        string ucusKodu = sonuc.FlightSegment[0].FlightNumber;
                        string bagajBilgi = sonuc.FlightSegment[0].Luggage;
                        //airCode = rhf.havayoluKodlari(item.FlightItems[0].CustomField3)[0].AirlineCode;
                        string airCode = sonuc.FlightSegment[0].OperatingAirline;
                        //string airCodeOut = "";

                        havayoluAdi = sonuc.FlightSegment[0].OperatingAirlineName;


                        string gidisHavaalaniKodu = sonuc.FlightSegment[0].DepartureAirport.Split('(')[1].Split(')')[0].ToString();
                        string gidisSaati = sonuc.FlightSegment[0].DepartureDateTime.Substring(11, 5);
                        string gidisTarihi = Convert.ToDateTime(sonuc.FlightSegment[0].DepartureDateTime.Substring(0, 10)).ToString("dd/MM/yyyy");
                        string gidisSehir = sonuc.FlightSegment[0].DepartureCityCountry.Split(',')[0].ToString();
                        string gidisUlkeKodu = rap.ulkeKodu(gidisHavaalaniKodu)[0].CountryCode;
                        string gidisAirPortName = rap.ulkeKodu(gidisHavaalaniKodu)[0].AirportName;

                        string gidisAirPortCityCountry = sonuc.FlightSegment[0].DepartureAirport + ", " + sonuc.FlightSegment[0].DepartureCityCountry;
                        ////string gidisUlkeKodu = item.FlightItems[0].OriginCityCountry.Split(',')[1].ToString().Trim() == "Türkiye" ? "TR" : item.FlightItems[0].OriginCityCountry.Split(',')[1].ToString();


                        string varisHavaalaniKodu = sonuc.FlightSegment[0].ArrivalAirport.Split('(')[1].Split(')')[0].ToString();
                        string varisSaati = sonuc.FlightSegment[0].ArrivalDateTime.Substring(11, 5);
                        string varisTarihi = Convert.ToDateTime(sonuc.FlightSegment[0].ArrivalDateTime.Substring(0, 10)).ToString("dd/MM/yyyy");
                        string varisSehir = sonuc.FlightSegment[0].ArrivaliCityCountry.Split(',')[0].ToString();
                        string varisUlkeKodu = rap.ulkeKodu(varisHavaalaniKodu)[0].CountryCode;
                        string varisAirPortName = rap.ulkeKodu(varisHavaalaniKodu)[0].AirportName;

                        string varisAirPortCityCountry = sonuc.FlightSegment[0].ArrivalAirport + ", " + sonuc.FlightSegment[0].ArrivaliCityCountry;
                        ////string varisUlkeKodu = item.FlightItems[0].DestinationCityCountry.Split(',')[1].ToString().Trim() == "Türkiye" ? "TR" : item.FlightItems[0].DestinationCityCountry.Split(',')[1].ToString();
                        gidisSeferTopla.Append(FlightItem(airCode, ucusKodu, ucusSinifi, gidisTarihi, gidisSaati, gidisAirPortCityCountry, varisTarihi, varisSaati, varisAirPortCityCountry, havayoluAdi));

                        string isConnection = "false";
                        if (sonuc.FlightSegment.Count() > 1)
                            isConnection = "true";

                        gidisJsonSonuc += gidis_jSon("0", trasferIndex, gidisHavaalaniKodu, varisHavaalaniKodu, sonuc.FlightSegment[0].DepartureDateTime, sonuc.FlightSegment[0].ArrivalDateTime, airCode, ucusKodu, ucusSinifi, isConnection, "4", "2", sonuc.FlightSegment[0].DepartureAirport, sonuc.FlightSegment[0].ArrivalAirport, sonuc.FlightSegment[0].OperatingAirlineName);

                        for (int i = 0; i < sonuc.FlightSegment.Length; i++)
                        {

                            if (i != 0)
                            {
                                gidisSeferTopla.Append(aktarmaGosterge);

                                string airCodeAkt = sonuc.FlightSegment[i].OperatingAirline;//Logo için..
                                string havayoluAdiAkt = sonuc.FlightSegment[i].OperatingAirlineName;
                                string ucusKoduAkt = sonuc.FlightSegment[i].FlightNumber;

                                string gidisHavaalaniKoduAkt = sonuc.FlightSegment[i].DepartureAirport.Split('(')[1].Split(')')[0].ToString();
                                string gidisSaatiAkt = sonuc.FlightSegment[i].DepartureDateTime.Substring(11, 5);
                                string gidisTarihiAkt = sonuc.FlightSegment[i].DepartureDateTime.Substring(0, 10);
                                string gidisSehirAkt = sonuc.FlightSegment[i].DepartureCityCountry.Split(',')[0].ToString();
                                string gidisUlkeKoduAkt = rap.ulkeKodu(gidisHavaalaniKoduAkt)[0].CountryCode;
                                string ucusSinifiAkt = sonuc.FlightSegment[i].ResBookDesigCode;
                                string gidisAirPortNameAkt = rap.ulkeKodu(gidisHavaalaniKoduAkt)[0].AirportName;
                                //string gidisUlkeKoduAkt = item.FlightItems[i].OriginCityCountry.Split(',')[1].ToString().Trim() == "Türkiye" ? "TR" : item.FlightItems[i].OriginCityCountry.Split(',')[1].ToString();
                                string gidisAirPortCityCountryAkt = sonuc.FlightSegment[i].DepartureAirport + ", " + sonuc.FlightSegment[i].DepartureCityCountry;


                                string varisHavaalaniKoduAkt = sonuc.FlightSegment[i].ArrivalAirport.Split('(')[1].Split(')')[0].ToString();
                                string varisSaatiAkt = sonuc.FlightSegment[i].ArrivalDateTime.Substring(11, 5);
                                string varisTarihiAkt = sonuc.FlightSegment[i].ArrivalDateTime.Substring(0, 10);
                                string varisSehirAkt = sonuc.FlightSegment[i].ArrivaliCityCountry.Split(',')[0].ToString();
                                string varisUlkeKoduAkt = rap.ulkeKodu(varisHavaalaniKoduAkt)[0].CountryCode;
                                string varisUcusKoduAkt = sonuc.FlightSegment[i].FlightNumber;
                                string varisAirPortNameAkt = rap.ulkeKodu(varisHavaalaniKoduAkt)[0].AirportName;
                                //string varisUlkeKoduAkt = item.FlightItems[i].DestinationCityCountry.Split(',')[1].ToString().Trim() == "Türkiye" ? "TR" : item.FlightItems[i].DestinationCityCountry.Split(',')[1].ToString();
                                string varisAirPortCityCountryAkt = sonuc.FlightSegment[i].ArrivalAirport + ", " + sonuc.FlightSegment[i].ArrivaliCityCountry;

                                gidisSeferTopla.Append(FlightItemAkt(airCodeAkt, ucusKoduAkt, ucusSinifiAkt, gidisTarihiAkt, gidisSaatiAkt, gidisAirPortCityCountryAkt, varisTarihiAkt, varisSaatiAkt, varisAirPortCityCountryAkt, havayoluAdiAkt));

                                trasferIndex++;
                                gidisJsonSonuc += "," + gidis_jSon("0", trasferIndex, gidisHavaalaniKoduAkt, varisHavaalaniKoduAkt, sonuc.FlightSegment[i].DepartureDateTime, sonuc.FlightSegment[i].ArrivalDateTime, airCodeAkt, ucusKoduAkt, ucusSinifiAkt, "true", "4", "2", sonuc.FlightSegment[i].DepartureAirport, sonuc.FlightSegment[i].ArrivalAirport, sonuc.FlightSegment[i].OperatingAirlineName);
                            }
                        }
                        if (Request.QueryString["dFlightID"] != null)
                        {
                            Guid guID2 = new Guid(Request.QueryString["dFlightID"].ToString());
                            OriginDestinationOptionList sonuc2 = tekYonListe[guID2];

                            string _havayoluAdi = "";

                            string _ucusSinifi = sonuc2.FlightSegment[0].ResBookDesigCode;
                            string _ucusKodu = sonuc2.FlightSegment[0].FlightNumber;
                            string _bagajBilgi = sonuc2.FlightSegment[0].Luggage;
                            //airCode = rhf.havayoluKodlari(item.FlightItems[0].CustomField3)[0].AirlineCode;
                            string _airCode = sonuc2.FlightSegment[0].OperatingAirline;
                            //string _airCodeOut = "";

                            _havayoluAdi = sonuc2.FlightSegment[0].OperatingAirlineName;


                            string _gidisHavaalaniKodu = sonuc2.FlightSegment[0].DepartureAirport.Split('(')[1].Split(')')[0].ToString();
                            string _gidisSaati = sonuc2.FlightSegment[0].DepartureDateTime.Substring(11, 5);
                            string _gidisTarihi = Convert.ToDateTime(sonuc2.FlightSegment[0].DepartureDateTime.Substring(0, 10)).ToString("dd/MM/yyyy");
                            string _gidisSehir = sonuc2.FlightSegment[0].DepartureCityCountry.Split(',')[0].ToString();
                            string _gidisUlkeKodu = rap.ulkeKodu(_gidisHavaalaniKodu)[0].CountryCode;
                            string _gidisAirPortName = rap.ulkeKodu(_gidisHavaalaniKodu)[0].AirportName;

                            string _gidisAirPortCityCountry = sonuc2.FlightSegment[0].DepartureAirport + ", " + sonuc2.FlightSegment[0].DepartureCityCountry;
                            ////string gidisUlkeKodu = item.FlightItems[0].OriginCityCountry.Split(',')[1].ToString().Trim() == "Türkiye" ? "TR" : item.FlightItems[0].OriginCityCountry.Split(',')[1].ToString();


                            string _varisHavaalaniKodu = sonuc2.FlightSegment[0].ArrivalAirport.Split('(')[1].Split(')')[0].ToString();
                            string _varisSaati = sonuc2.FlightSegment[0].ArrivalDateTime.Substring(11, 5);
                            string _varisTarihi = Convert.ToDateTime(sonuc2.FlightSegment[0].ArrivalDateTime.Substring(0, 10)).ToString("dd/MM/yyyy");
                            string _varisSehir = sonuc2.FlightSegment[0].ArrivaliCityCountry.Split(',')[0].ToString();
                            string _varisUlkeKodu = rap.ulkeKodu(_varisHavaalaniKodu)[0].CountryCode;
                            string _varisAirPortName = rap.ulkeKodu(_varisHavaalaniKodu)[0].AirportName;

                            string _varisAirPortCityCountry = sonuc2.FlightSegment[0].ArrivalAirport + ", " + sonuc2.FlightSegment[0].ArrivaliCityCountry;
                            ////string varisUlkeKodu = item.FlightItems[0].DestinationCityCountry.Split(',')[1].ToString().Trim() == "Türkiye" ? "TR" : item.FlightItems[0].DestinationCityCountry.Split(',')[1].ToString();
                            donusSeferTopla.Append(FlightItemDonus(_airCode, _ucusKodu, _ucusSinifi, _gidisTarihi, _gidisSaati, _gidisAirPortCityCountry, _varisTarihi, _varisSaati, _varisAirPortCityCountry, _havayoluAdi));

                            isConnection = "false";
                            if (sonuc2.FlightSegment.Count() > 1)
                                isConnection = "true";
                            trasferIndex = 0;

                            donusJsonSonuc += gidis_jSon("1", trasferIndex, _gidisHavaalaniKodu, _varisHavaalaniKodu, sonuc2.FlightSegment[0].DepartureDateTime, sonuc2.FlightSegment[0].ArrivalDateTime, _airCode, _ucusKodu, _ucusSinifi, isConnection, "SINT3MEFLX", "08db719eb4550a12dbd126c55b23f930b8efafe9ee6674793bdafd63c9bb60e95c96631e611d916165ab46650d85c39f647fdda5f25f20a61179df7e5c48ee7a", sonuc2.FlightSegment[0].DepartureAirport, sonuc2.FlightSegment[0].ArrivalAirport, sonuc2.FlightSegment[0].OperatingAirlineName);

                            for (int i = 0; i < sonuc2.FlightSegment.Length; i++)
                            {

                                if (i != 0)
                                {
                                    donusSeferTopla.Append(aktarmaGosterge);

                                    string _airCodeAkt = sonuc2.FlightSegment[i].OperatingAirline;//Logo için..
                                    string _havayoluAdiAkt = sonuc2.FlightSegment[i].OperatingAirlineName;
                                    string _ucusKoduAkt = sonuc2.FlightSegment[i].FlightNumber;

                                    string _gidisHavaalaniKoduAkt = sonuc2.FlightSegment[i].DepartureAirport.Split('(')[1].Split(')')[0].ToString();
                                    string _gidisSaatiAkt = sonuc2.FlightSegment[i].DepartureDateTime.Substring(11, 5);
                                    string _gidisTarihiAkt = sonuc2.FlightSegment[i].DepartureDateTime.Substring(0, 10);
                                    string _gidisSehirAkt = sonuc2.FlightSegment[i].DepartureCityCountry.Split(',')[0].ToString();
                                    string _gidisUlkeKoduAkt = rap.ulkeKodu(_gidisHavaalaniKoduAkt)[0].CountryCode;
                                    string _ucusSinifiAkt = sonuc2.FlightSegment[i].ResBookDesigCode;
                                    string _gidisAirPortNameAkt = rap.ulkeKodu(_gidisHavaalaniKoduAkt)[0].AirportName;
                                    //string gidisUlkeKoduAkt = item.FlightItems[i].OriginCityCountry.Split(',')[1].ToString().Trim() == "Türkiye" ? "TR" : item.FlightItems[i].OriginCityCountry.Split(',')[1].ToString();
                                    string _gidisAirPortCityCountryAkt = sonuc2.FlightSegment[i].DepartureAirport + ", " + sonuc2.FlightSegment[i].DepartureCityCountry;


                                    string _varisHavaalaniKoduAkt = sonuc2.FlightSegment[i].ArrivalAirport.Split('(')[1].Split(')')[0].ToString();
                                    string _varisSaatiAkt = sonuc2.FlightSegment[i].ArrivalDateTime.Substring(11, 5);
                                    string _varisTarihiAkt = sonuc2.FlightSegment[i].ArrivalDateTime.Substring(0, 10);
                                    string _varisSehirAkt = sonuc2.FlightSegment[i].ArrivaliCityCountry.Split(',')[0].ToString();
                                    string _varisUlkeKoduAkt = rap.ulkeKodu(_varisHavaalaniKoduAkt)[0].CountryCode;
                                    string _varisUcusKoduAkt = sonuc2.FlightSegment[i].FlightNumber;
                                    string _varisAirPortNameAkt = rap.ulkeKodu(_varisHavaalaniKoduAkt)[0].AirportName;
                                    //string varisUlkeKoduAkt = item.FlightItems[i].DestinationCityCountry.Split(',')[1].ToString().Trim() == "Türkiye" ? "TR" : item.FlightItems[i].DestinationCityCountry.Split(',')[1].ToString();
                                    string _varisAirPortCityCountryAkt = sonuc2.FlightSegment[i].ArrivalAirport + ", " + sonuc2.FlightSegment[i].ArrivaliCityCountry;

                                    donusSeferTopla.Append(FlightItemAkt(_airCodeAkt, _ucusKoduAkt, _ucusSinifiAkt, _gidisTarihiAkt, _gidisSaatiAkt, _gidisAirPortCityCountryAkt, _varisTarihiAkt, _varisSaatiAkt, _varisAirPortCityCountryAkt, _havayoluAdiAkt));

                                    trasferIndex++;
                                    donusJsonSonuc += "," + gidis_jSon("1", trasferIndex, _gidisHavaalaniKoduAkt, _varisHavaalaniKoduAkt, sonuc2.FlightSegment[i].DepartureDateTime, sonuc2.FlightSegment[i].ArrivalDateTime, _airCodeAkt, _ucusKoduAkt, _ucusSinifiAkt, "true", "SINT3MEFLX", "08db719eb4550a12dbd126c55b23f930b8efafe9ee6674793bdafd63c9bb60e95c96631e611d916165ab46650d85c39f647fdda5f25f20a61179df7e5c48ee7a", sonuc2.FlightSegment[i].DepartureAirport, sonuc2.FlightSegment[i].ArrivalAirport, sonuc2.FlightSegment[i].OperatingAirlineName);
                                }
                            }
                        }
                        //Dictionary<Guid, PricedItineraryList> pricedItineraryList = (Dictionary<Guid, PricedItineraryList>)Session["topluListeDisHat"];
                        //var fiyatSonuc = cl.DomesticFlightPrice(uu_SessionID, yetiskinSayi, cocukSayi, bebekSayi, gidisJsonSonuc, donusJsonSonuc);
                        Session["gidisJsonSonuc"] = gidisJsonSonuc;
                        Session["donusJsonSonuc"] = donusJsonSonuc;
                        Dictionary<Guid, PricedItineraryList> fiyatSonuc = (Dictionary<Guid, PricedItineraryList>)Session["pricedItineraryList"];
                        string birimFiyat = "";
                        if (fiyatSonuc != null)
                        {
                            PricedItineraryList pricedIT = fiyatSonuc[guID];
                            if (pricedIT.FareBreakdowns != null)
                            {
                                birimFiyat = birimFiyatIslem(pricedIT);
                            }
                            string totalFiyat = string.Format("{0:0.##}", pricedIT.ItinTotalFare.TotalFare).ToString();
                            kisiFiyatListesi.InnerHtml = kisiFiyatlamasi(birimFiyat, totalFiyat);
                            double basePriceIT = 0;
                            double totalPriceIT = 0;
                            foreach (var item in pricedIT.FareBreakdowns)
                            {
                                basePriceIT += item.BaseFare * item.PassengerQuantity;
                                totalPriceIT += item.TotalFare * item.PassengerQuantity;
                            }
                            Session["birimFiyat"] = basePriceIT.ToString().Replace(",", ".");
                            Session["totalFiyat"] = totalPriceIT.ToString().Replace(",", ".");
                            _PessengerItems.InnerHtml = passangerMetot(pricedIT);
                        }

                        ContentPlaceHolder1_gidisBilgileri.InnerHtml = GeneralInfo(gidisSeferTopla.ToString(), donusSeferTopla.ToString());

                    }
                    #endregion
                }
            }
        }


        private string FlightItem(string logoCode, string ucusKodu, string ucusSinifi, string gidisTarihi, string gidisSaati, string lokasyonBilgi, string varisGidisTarihi, string varisGidisSaati, string varisLokasyonBilgi, string havaYoluAdi)
        {
            return String.Format(flightItem, logoCode, ucusKodu, ucusSinifi, gidisTarihi, gidisSaati, lokasyonBilgi, varisGidisTarihi, varisGidisSaati, varisLokasyonBilgi, havaYoluAdi);
        }

        string flightItem = "<div class=\"flight-info-heading\" style=\"\">Gidiş Seferiii</div>" +
                    "<div class=\"reservation-flight-item\">" +
                        "<div class=\"row\">" +

                            "<div class=\"col-sm-2 col-xs-6\"><i class=\"airline-icon airline-icon-airline-{0}\"></i><span class=\"airline-name\">{9}</span></div>" +
                            "<div class=\"col-sm-1 col-xs-6 flight-class\">" +
                                "<div><span class=\"flight-info-text\">{1}</span></div>" +
                                "<div><span class=\"flight-info-text\">Sınıfı: {2}</span></div>" +
                            "</div>" +
                            "<div class=\"col-sm-8 col-xs-12\">" +
                                "<div class=\"departure-return-info text-underline\"><span class=\"flight-info-text\"><strong class=\"heading text-underline\">Kalkış&nbsp;:&nbsp;&nbsp;</strong><i class=\"fa fa-calendar\"></i> {3}  <i class=\"fa fa-clock-o\"></i> {4} <span data-ng-class=\"'airline-warning': airlineWarningDeparture.departure.IST \"> <i class=\"fa fa-map-marker fa-fw\"></i>{5}</span></span><input type=\"hidden\" id=\"inpDepartureDate\" value=\"{3}\"></div>" +
                                "<div class=\"departure-return-info\"><span class=\"flight-info-text\"><strong class=\"heading\">Varış&nbsp;&nbsp;&nbsp;:&nbsp;&nbsp;</strong><i class=\"fa fa-calendar\"></i> {6} <i class=\"fa fa-clock-o\"></i> {7} <span data-ng-class=\"'airline-warning':  airlineWarningArrival.departure.DOH\"> <i class=\"fa fa-map-marker fa-fw\"></i>{8}</span></span><input type=\"hidden\" id=\"inpDepartureReturnDate\" value=\"{6}\"></div>" +
            //"<div class=\"promotion\" style=\"display: default\"><span class=\"flight-info-text\">Promosyon (İptal, iade ve değişiklik yapılamaz)</span></div>" +
                            "</div>" +
                        "</div>" +
                    "</div>";

        private string FlightItemDonus(string logoCode, string ucusKodu, string ucusSinifi, string gidisTarihi, string gidisSaati, string lokasyonBilgi, string varisGidisTarihi, string varisGidisSaati, string varisLokasyonBilgi, string havaYoluAdi)
        {
            return String.Format(flightItemDonus, logoCode, ucusKodu, ucusSinifi, gidisTarihi, gidisSaati, lokasyonBilgi, varisGidisTarihi, varisGidisSaati, varisLokasyonBilgi, havaYoluAdi);
        }

        string flightItemDonus = "<div class=\"flight-info-heading\" style=\"\">Dönüş Seferii</div>" +
                    "<div class=\"reservation-flight-item\">" +
                        "<div class=\"row\">" +

                            "<div class=\"col-sm-2 col-xs-6\"><i class=\"airline-icon airline-icon-airline-{0}\"></i><span class=\"airline-name\">{9}</span></div>" +
                            "<div class=\"col-sm-1 col-xs-6 flight-class\">" +
                                "<div><span class=\"flight-info-text\">{1}</span></div>" +
                                "<div><span class=\"flight-info-text\">Sınıfı: {2}</span></div>" +
                            "</div>" +
                            "<div class=\"col-sm-8 col-xs-12\">" +
                                "<div class=\"departure-return-info text-underline\"><span class=\"flight-info-text\"><strong class=\"heading text-underline\">Kalkış&nbsp;:&nbsp;&nbsp;</strong><i class=\"fa fa-calendar\"></i> {3}  <i class=\"fa fa-clock-o\"></i> {4} <span data-ng-class=\"'airline-warning': airlineWarningDeparture.departure.IST \"> <i class=\"fa fa-map-marker fa-fw\"></i>{5}</span></span><input type=\"hidden\" id=\"inpDepartureDate\" value=\"{3}\"></div>" +
                                "<div class=\"departure-return-info\"><span class=\"flight-info-text\"><strong class=\"heading\">Varış&nbsp;&nbsp;&nbsp;:&nbsp;&nbsp;</strong><i class=\"fa fa-calendar\"></i> {6} <i class=\"fa fa-clock-o\"></i> {7} <span data-ng-class=\"'airline-warning':  airlineWarningArrival.departure.DOH\"> <i class=\"fa fa-map-marker fa-fw\"></i>{8}</span></span><input type=\"hidden\" id=\"inpDepartureReturnDate\" value=\"{6}\"></div>" +
            //"<div class=\"promotion\" style=\"display: default\"><span class=\"flight-info-text\">Promosyon (İptal, iade ve değişiklik yapılamaz)</span></div>" +
                            "</div>" +
                        "</div>" +
                    "</div>";

        private string FlightItemAkt(string logoCode, string ucusKodu, string ucusSinifi, string gidisTarihi, string gidisSaati, string lokasyonBilgi, string varisGidisTarihi, string varisGidisSaati, string varisLokasyonBilgi, string havaYoluAdi)
        {
            return String.Format(flightItemAkt, logoCode, ucusKodu, ucusSinifi, gidisTarihi, gidisSaati, lokasyonBilgi, varisGidisTarihi, varisGidisSaati, varisLokasyonBilgi, havaYoluAdi);
        }

        string flightItemAkt = "<div class=\"reservation-flight-item\">" +
                        "<div class=\"row\">" +

                            "<div class=\"col-sm-2 col-xs-6\"><i class=\"airline-icon airline-icon-airline-{0}\"></i><span class=\"airline-name\">{9}</span></div>" +
                            "<div class=\"col-sm-1 col-xs-6 flight-class\">" +
                                "<div><span class=\"flight-info-text\">{1}</span></div>" +
                                "<div><span class=\"flight-info-text\">Sınıfı: {2}</span></div>" +
                            "</div>" +
                            "<div class=\"col-sm-8 col-xs-12\">" +
                                "<div class=\"departure-return-info text-underline\"><span class=\"flight-info-text\"><strong class=\"heading text-underline\">Kalkış&nbsp;:&nbsp;&nbsp;</strong><i class=\"fa fa-calendar\"></i> {3}  <i class=\"fa fa-clock-o\"></i> {4} <span data-ng-class=\"'airline-warning': airlineWarningDeparture.departure.IST \"> <i class=\"fa fa-map-marker fa-fw\"></i>{5}</span></span><input type=\"hidden\" id=\"inpDepartureDate\" value=\"{3}\"></div>" +
                                "<div class=\"departure-return-info\"><span class=\"flight-info-text\"><strong class=\"heading\">Varış&nbsp;&nbsp;&nbsp;:&nbsp;&nbsp;</strong><i class=\"fa fa-calendar\"></i> {6} <i class=\"fa fa-clock-o\"></i> {7} <span data-ng-class=\"'airline-warning':  airlineWarningArrival.departure.DOH\"> <i class=\"fa fa-map-marker fa-fw\"></i>{8}</span></span><input type=\"hidden\" id=\"inpDepartureReturnDate\" value=\"{6}\"></div>" +
            //"<div class=\"promotion\" style=\"display: default\"><span class=\"flight-info-text\">Promosyon (İptal, iade ve değişiklik yapılamaz)</span></div>" +
                            "</div>" +
                        "</div>" +
                    "</div>";

        string aktarmaGosterge = "<div class=\"delay-seperator\" style=\"display: block\">" +
                        "<div class=\"delay-text\"><i class=\"fa fa-clock-o\"></i>Aktarma</div>" +
                    "</div>";

        private string GeneralInfo(string gidisGenelBilgiler, string donusGenelBilgiler)
        {
            return String.Format(generalInfo, gidisGenelBilgiler, donusGenelBilgiler);
        }

        string generalInfo =
                 "<div id=\"ContentPlaceHolder1_departure\" class=\"departure\">" +
                 "{0}" +//flightItem
            //"{1}" +//aktarmaGosterge
            //"{1}" +
                "</div>" +
                "<div id=\"ContentPlaceHolder1_gidisEkBilgileri\" class=\"flight-notes\" style=\"display: block;\">" +
                    "<div class=\"reservation-situation\">" +
                        "<div class=\"reservation-situation-text clearfix\">" +
                            "<div class=\"col-xs-12\">" +
                                "<div class=\"row bagaj\">" +


                                    "<div>" +
                                        "<div id=\"ContentPlaceHolder1_gidisbagaj\">Bagaj (1 yolcu) :  15 Kg ve 8 KG El Bagajı Hakkı Bulunmaktadır</div>" +
                                    "</div>" +
                                "</div>" +
                            "</div>" +
                        "</div>" +
                    "</div>" +
                "</div>" +

                //--------------------------------------------DÖNÜŞ-------------------------------------------

                "<div id=\"ContentPlaceHolder1_donusBilgileri\" class=\"return\" style=\"display: block;\">" +
                "{1}" +//flightItem
                "</div>" +
                "<div id=\"ContentPlaceHolder1_donusEkBilgileri\" class=\"flight-notes\" style=\"display: block;\">" +
                    "<div class=\"reservation-situation\">" +
                        "<div class=\"reservation-situation-text clearfix\">" +
                            "<div class=\"col-xs-12\">" +
                                "<div class=\"row bagaj\">" +
                                    "<div>" +
                                        "<div id=\"ContentPlaceHolder1_donusbagaj\">Bagaj (1 yolcu) : 15 Kg ve 8 KG El Bagajı Hakkı Bulunmaktadır</div>" +
                                    "</div>" +
                                "</div>" +
                            "</div>" +

                        "</div>" +
                    "</div>" +
                "</div>";


        string KacSaatUcus(string kalkisTarih, string varisTarih)
        {
            string toplamSure = "";
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
            return toplamSure;
        }

        string TarihFormatla(string tarihGir)
        {
            //08.05.2018 08:50:00
            //string text = dateTime.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture);

            string date = Convert.ToDateTime(tarihGir).ToString("dd.MM.yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

            return date;
        }

        string gidis_jSon(string direction, int transferIndex, string OriginCode, string DestinationCode, string DepartureTime, string ArrivalTime, string Carrier, string FlightNo, string ClassCode, string isConnectedPrevSeg, string CustomField1, string CustomField2, string Origin, string Destination, string CustomField3)
        {
            jsonTipi2 jsTip = new jsonTipi2();
            jsTip.direction = direction; //"0";
            jsTip.transferindex = transferIndex.ToString(); //"0";
            jsTip.originlocation = OriginCode; //"SAW";
            jsTip.destinationlocation = DestinationCode; //"AYT";
            jsTip.flightdatetime = TarihFormatla(DepartureTime); //"08.05.2018 08:50:00";
            jsTip.arrivaldatetime = TarihFormatla(ArrivalTime); //"08.05.2018 10:10:00";
            jsTip.airline = Carrier; //"XQ";
            jsTip.flightno = FlightNo; //"7527";
            jsTip.classcode = ClassCode; //"A";
            jsTip.isconnect = isConnectedPrevSeg; //"false";
            jsTip.custom1 = CustomField1;
            jsTip.custom2 = CustomField2;
            jsTip.origindestination = Origin + ";" + Destination; //"Sabiha Gokcen (SAW);Antalya (AYT)";
            jsTip.airlinename = CustomField3; //"SunExpress";

            return JsonConvert.SerializeObject(jsTip);
        }
        //string birimFiyatlar = "<div class=\"col-sm-2 mb-passenger passenger\">1 . Yetişkin</div>" +
        //                    "<div class=\"col-sm-2 mb-price passenger\">60TL</div>" +
        //                    "<div class=\"col-sm-2 mb-tax passenger\">81,98TL</div>" +
        //                    "<div class=\"col-sm-2 mb-cost passenger\">17TL</div>" +
        //                    "<div class=\"col-sm-2 mb-total passenger total\">158,98TL</div>";

        private string birimFiyatIslem(ResultDomesticFlightPrice gonderilen)
        {
            string birimFiyat = "";
            foreach (var item in gonderilen.FareResult.Fares)
            {
                birimFiyat += "<div class=\"passenger-container clearfix\">" +
              "<div class=\"col-sm-2 mb-passenger passenger\">" + item.PassangerCount + "  " + item.PassangerType + "</div>" +
              "<div class=\"col-sm-2 mb-price passenger\">" + string.Format("{0:0.##} TL", Convert.ToDouble(item.BasePrice) * Convert.ToDouble(item.PassangerCount)) + "</div>" +
              "<div class=\"col-sm-2 mb-tax passenger\">" + string.Format("{0:0.##} TL", Convert.ToDouble(item.Taxes) * Convert.ToDouble(item.PassangerCount)) + "</div>" +
              "<div class=\"col-sm-2 mb-cost passenger\">" + string.Format("{0:0.##} TL", Convert.ToDouble(item.ServicePrice) * Convert.ToDouble(item.PassangerCount)) + "</div>" +
              "<div class=\"col-sm-2 mb-total passenger total\">" + string.Format("{0:0.##} TL", Convert.ToDouble(item.TotalPrice)) + "</div>" +
              "</div>";
            }
            return birimFiyat;
        }

        //PricedItineraryList
        private string birimFiyatIslem(PricedItineraryList gonderilen)
        {
            string birimFiyat = "";
            foreach (var item in gonderilen.FareBreakdowns)
            {
                birimFiyat += "<div class=\"passenger-container clearfix\">" +
              "<div class=\"col-sm-2 mb-passenger passenger\">" + item.PassengerQuantity + "  " + item.PassengerType + "</div>" +
              "<div class=\"col-sm-2 mb-price passenger\">" + string.Format("{0:0.##} TL", Convert.ToDouble(item.BaseFare) * Convert.ToDouble(item.PassengerQuantity)) + "</div>" +
              "<div class=\"col-sm-2 mb-tax passenger\">" + string.Format("{0:0.##} TL", (Convert.ToDouble(item.TotalFare) - (item.BaseFare + item.ServiceFare)) * Convert.ToDouble(item.PassengerQuantity)) + "</div>" +
              "<div class=\"col-sm-2 mb-cost passenger\">" + string.Format("{0:0.##} TL", Convert.ToDouble(item.ServiceFare) * Convert.ToDouble(item.PassengerQuantity)) + "</div>" +
              "<div class=\"col-sm-2 mb-total passenger total\">" + string.Format("{0:0.##} TL", Convert.ToDouble(item.TotalFare) * Convert.ToDouble(item.PassengerQuantity)) + "</div>" +
              "</div>";
            }
            return birimFiyat;
        }


        private string kisiFiyatlamasi(string kisiFiyatBilgileri, string totalFiyatBilgisi)
        {
            return String.Format(price, kisiFiyatBilgileri, totalFiyatBilgisi);
        }

        string price =
                    "<div class=\"heading-container clearfix\">" +
                        "<div class=\"col-sm-2 mb-passenger heading\">Yolcu</div>" +
                        "<div class=\"col-sm-2 mb-price heading\">Fiyat</div>" +
                        "<div class=\"col-sm-2 mb-tax heading\">Vergi</div>" +
                        "<div class=\"col-sm-2 mb-cost heading\">Hizmet</div>" +
                        "<div class=\"col-sm-2 mb-total  heading total\">Toplam</div>" +
                    "</div>" +

                    "<div id=\"ContentPlaceHolder1_yolcuBilgileri\" class=\"passenger-container clearfix\">" +

                        "{0}" + //kisiFiyatListesi

                    "</div>" +

                    "<div class=\"insurance-container\">" +
                        "<div id=\"insurance-offer\" style=\"display: none\">" +
                            "<input type=\"checkbox\" class=\"insurance-checkbox\" id=\"insurance-checkbox\" value=\"1\" name=\"insurance-checkbox\">" +
                            "<label for=\"insurance-checkbox\" class=\"insurance-label\">" +
                                "<span id=\"insurance-price\">9,90 TL</span> karşılığında bu seyahatim için Seyahat Sigortası da istiyorum." +
                            "</label>" +
                            "<div style=\"display: none\">" +
                                "<div class=\"insurance-total clearfix hide\" id=\"insurance-total\">" +
                                    "<span class=\"heading\">Sigorta Bedeli (1 Kişi)</span>" +
                                    "<span class=\"price\">9,90 TL</span>" +
                                "</div>" +
                            "</div>" +

                        "</div>" +

                        "<div class=\"total-price-bottom\">" +
                            "<span class=\"heading\">Toplam Ücret : </span>" +
                            "<span id=\"ContentPlaceHolder1_toplamUcret\" class=\"price-green total-fare\">{1} TL</span>" +
                        "</div>" +

                    "</div>";

        private string passangerTopla(string kisiTip, int siraNo, string kisaTip)
        {
            return String.Format(passanger, kisiTip, siraNo, kisaTip);
        }
        private string passangerMetot(ResultDomesticFlightPrice gonderilen)
        {
            string passangers = "";

            int sayac = 0;
            int eklenen = 1;

            for (int i = 0; i < gonderilen.FareResult.Fares.Count(); i++)
            {
                switch (gonderilen.FareResult.Fares[i].PassangerType)
                {
                    case "Yetişkin":
                        sayac = 0;
                        while (sayac < gonderilen.FareResult.Fares[i].PassangerCount)
                        {
                            passangers += passangerTopla("Yetişkin", eklenen++, "ADT");
                            sayac++;
                        }
                        break;
                    case "Çocuk":
                        sayac = 0;
                        while (sayac < gonderilen.FareResult.Fares[i].PassangerCount)
                        {
                            passangers += passangerTopla("Çocuk", eklenen++, "CHD");
                            sayac++;
                        }
                        break;
                    case "Bebek":
                        sayac = 0;
                        while (sayac < gonderilen.FareResult.Fares[i].PassangerCount)
                        {
                            passangers += passangerTopla("Bebek", eklenen++, "INF");
                            sayac++;
                        }
                        break;
                }
            }
            //foreach (var item in gonderilen.FareResult.Fares)
            //{
            //    passangers += "<div class=\"passenger-container clearfix\">" +
            //  "<div class=\"col-sm-2 mb-passenger passenger\">" + item.PassangerCount + "  " + item.PassangerType + "</div>" +
            //  "<div class=\"col-sm-2 mb-price passenger\">" + string.Format("{0:0.##} TL", Convert.ToDouble(item.BasePrice) * Convert.ToDouble(item.PassangerCount)) + "</div>" +
            //  "<div class=\"col-sm-2 mb-tax passenger\">" + string.Format("{0:0.##} TL", Convert.ToDouble(item.Taxes) * Convert.ToDouble(item.PassangerCount)) + "</div>" +
            //  "<div class=\"col-sm-2 mb-cost passenger\">" + string.Format("{0:0.##} TL", Convert.ToDouble(item.ServicePrice) * Convert.ToDouble(item.PassangerCount)) + "</div>" +
            //  "<div class=\"col-sm-2 mb-total passenger total\">" + string.Format("{0:0.##} TL", Convert.ToDouble(item.TotalPrice)) + "</div>" +
            //  "</div>";
            //}
            return passangers;
        }

        private string passangerMetot(PricedItineraryList gonderilen)
        {
            string passangers = "";

            int sayac = 0;
            int eklenen = 1;

            for (int i = 0; i < gonderilen.FareBreakdowns.Count(); i++)
            {
                switch (gonderilen.FareBreakdowns[i].PassengerType)
                {
                    case "Yetişkin":
                        sayac = 0;
                        while (sayac < gonderilen.FareBreakdowns[i].PassengerQuantity)
                        {
                            passangers += passangerTopla("Yetişkin", eklenen++, "ADT");
                            sayac++;
                        }
                        break;
                    case "Çocuk":
                        sayac = 0;
                        while (sayac < gonderilen.FareBreakdowns[i].PassengerQuantity)
                        {
                            passangers += passangerTopla("Çocuk", eklenen++, "CHD");
                            sayac++;
                        }
                        break;
                    case "Bebek":
                        sayac = 0;
                        while (sayac < gonderilen.FareBreakdowns[i].PassengerQuantity)
                        {
                            passangers += passangerTopla("Bebek", eklenen++, "INF");
                            sayac++;
                        }
                        break;
                }
            }
            //foreach (var item in gonderilen.FareResult.Fares)
            //{
            //    passangers += "<div class=\"passenger-container clearfix\">" +
            //  "<div class=\"col-sm-2 mb-passenger passenger\">" + item.PassangerCount + "  " + item.PassangerType + "</div>" +
            //  "<div class=\"col-sm-2 mb-price passenger\">" + string.Format("{0:0.##} TL", Convert.ToDouble(item.BasePrice) * Convert.ToDouble(item.PassangerCount)) + "</div>" +
            //  "<div class=\"col-sm-2 mb-tax passenger\">" + string.Format("{0:0.##} TL", Convert.ToDouble(item.Taxes) * Convert.ToDouble(item.PassangerCount)) + "</div>" +
            //  "<div class=\"col-sm-2 mb-cost passenger\">" + string.Format("{0:0.##} TL", Convert.ToDouble(item.ServicePrice) * Convert.ToDouble(item.PassangerCount)) + "</div>" +
            //  "<div class=\"col-sm-2 mb-total passenger total\">" + string.Format("{0:0.##} TL", Convert.ToDouble(item.TotalPrice)) + "</div>" +
            //  "</div>";
            //}
            return passangers;
        }

        string passanger =
            "<div style=\"clear: both;\">" +
                                    "<input type=\"hidden\" id=\"inpPaxType{1}\" onchange=\"this.setAttribute('value', this.value);\" value=\"{2}\"><div class=\"col-xs-12 col-md-12\" style=\"line-height: 30px;\">{0} yolcu:</div>" +
                                    "<div class=\"col-xs-12 col-md-1 yolcu-input-alani\">" +
                                        "<div class=\"gender-main-label eu-label\"></div>" +
                                        "<select id=\"slcBilgiCinsiyet{1}\" class=\"form-control\" onchange=\"this.setAttribute('value', this.value);\" style=\"display: inline-block\">" +
                                            "<option selected=\"\" value=\"X\">Seçin</option>" +
                                            "<option value=\"MR\">Bay</option>" +
                                            "<option value=\"MS\">Bayan</option>" +
                                        "</select>" +
                                    "</div>" +
                                    "<div class=\"col-xs-12  col-md-2 yolcu-input-alani\">" +
                                        "<input placeholder=\"Ad\" maxlength=\"20\" type=\"text\" id=\"inpBilgiAd{1}\" onkeyup=\"myFunction(this)\" class=\"form-control passengerFirstname required pattern-check storage-persist\" data-pattern=\"^[a-zA-ZÇÖİŞÜĞığüşöç\\.]*$\" data-content=\"Lütfen yolcunun adını girin\" data-placement=\"bottom\" data-original-title=\"\" title=\"Ad Alanı Boş Geçilemez.\">" +
                                    "</div>" +
                                    "<div class=\"col-xs-12 col-md-2 yolcu-input-alani\">" +
                                        "<input placeholder=\"Soyad\" maxlength=\"20\" type=\"text\" id=\"inpBilgiSoyad{1}\" onkeyup=\"myFunction(this)\" class=\"passengerLastname form-control required pattern-check storage-persist\" data-pattern=\"^[a-zA-ZÇÖİŞÜĞığüşöç\\]*$\" data-content=\"Lütfen yolcunun soyadını girin\" data-placement=\"bottom\" data-original-title=\"\" title=\"Soyad Alanı Boş Geçilemez.\">" +
                                    "</div>" +
                                    "<div class=\"col-xs-12 col-md-2 yolcu-input-alani\" data-passenger-type=\"{2}\" data-min-year=\"August 25, 1950\" data-max-year=\"August 25, 2003\" data-content=\"\" data-placement=\"bottom\" data-original-title=\"\" title=\"\">" +
                                        "<input placeholder=\"Doğum Tarihi\" class=\"form-control return-date-input\"  id=\"date{1}\" data-inputmask=\"'alias': 'datetime','inputFormat': 'dd/mm/yyyy'\" maxlength=\"10\">" +
                                    "</div>" +
                                    "<div class=\"col-xs-12 col-md-2 yolcu-input-alani\" style=\"\">" +
                                        "<input placeholder=\"TC Kimlik No\" maxlength=\"11\" type=\"text\" id=\"inpBilgiTc{1}\" onchange=\"this.setAttribute('value', this.value);\" onkeypress=\"return event.charCode >= 48 &amp;&amp; event.charCode <= 57\" class=\"form-control passengerFirstname required pattern-check storage-persist\" data-placement=\"bottom\" data-original-title=\"\" title=\"TC Alanı Boş Geçilemez.\">" +
                                    "</div>" +

                                    "<div style=\"\" class=\"checkboxTcNo col-md-2 col-xs-12\">" +
                                        "<input type=\"checkbox\" id=\"checkboxtcno{1}\" onclick=\"handleClick(this,{1});\" name=\"optionsRadiosUcusTipi\" class=\"tcVatandasiCheckBox\" checked=\"\" index=\"1\" value=\"option1\">" +
                                        "<span class=\"checkmark\" id=\"after\"></span>" +
                                        "<p>TC Vatandaşıyım</p>" +
                                        "<p>(I'm Turkish)</p>" +
                                    "</div>" +

                                "</div>";

        #region satinAl(string json)


        [WebMethod]
        public static string satinAl(string json)
        {
            //dynamic stuff = JObject.Parse("{ 'Name': 'Jon Smith', 'Address': { 'City': 'New York', 'State': 'NY' }, 'Age': 42 }");
            string _error = "";
            bool disHat = false;

            Dictionary<int, string> _satisInsertIDList = HttpContext.Current.Session["satisInsertList"] != null ? HttpContext.Current.Session["satisInsertList"] as Dictionary<int, string> : new Dictionary<int, string>();
            BirsifirSoapClient cl2 = new BirsifirSoapClient();
            CreateTicket3DInfo blt = new CreateTicket3DInfo();
            try
            {

                dynamic buyInfo = JObject.Parse(json);
                string sonuc = "";
                if (Method.seferTipi == false)//Yurt ici ucusu ise buraya gir
                {
                    #region Yurt Ici
                    blt.flighttype = "domestic";
                    blt.destination = HttpContext.Current.Session["gdOriginCode"].ToString();
                    blt.arrival = HttpContext.Current.Session["gdDestinationCode"].ToString();
                    BirsifirResult seferSonuc = (BirsifirResult)HttpContext.Current.Session["seferSonuc"];
                    blt.sessionId = seferSonuc.GidisUcuslari.uu_SessionId;
                    blt.aspNetSessionid = seferSonuc.GidisUcuslari.sessionid == null ? "" : seferSonuc.GidisUcuslari.sessionid;
                    blt.passengers = buyInfo.Pessengers.ToString().Substring(1, buyInfo.Pessengers.ToString().Length - 2);
                    blt.adultcount = "0";
                    blt.childcount = "0";
                    blt.infcount = "0";
                    foreach (var item in Yolcular.yolcuTipSayi)
                    {
                        switch (item.yolcuTipi)
                        {
                            case "Yetiskin":
                                blt.adultcount = item.yolcuSayisi;
                                break;
                            case "Cocuk":
                                blt.childcount = item.yolcuSayisi;
                                break;
                            case "Bebek":
                                blt.infcount = item.yolcuSayisi;
                                break;
                        }
                    }
                    blt.gidisJson = HttpContext.Current.Session["gidisJsonSonuc"] != null ? HttpContext.Current.Session["gidisJsonSonuc"].ToString() : "";
                    blt.donusJson = HttpContext.Current.Session["donusJsonSonuc"] != null ? HttpContext.Current.Session["donusJsonSonuc"].ToString() : "";
                    blt.combinationId = "";
                    blt.sequenceNumber = "";

                    blt.cardname = buyInfo.CreditCardInfo.BillingName;
                    blt.cardnumber = buyInfo.CreditCardInfo.CardNumber;
                    blt.cardmonth = buyInfo.CreditCardInfo.ExpirationMonth;
                    blt.cardyear = buyInfo.CreditCardInfo.ExpirationYear;
                    blt.cardcvv = buyInfo.CreditCardInfo.CV2;
                    FlightSegmentResults gSeciliSefer = (FlightSegmentResults)HttpContext.Current.Session["gSeciliSefer"];
                    double basePrice = gSeciliSefer.FlightPrice;
                    double totalPrice = gSeciliSefer.FlightPriceTotal;
                    //if (HttpContext.Current.Session["gSeciliSefer"] != null)
                    //{
                    //    FlightSegmentResults dSeciliSefer = (FlightSegmentResults)HttpContext.Current.Session["gSeciliSefer"];
                    //    basePrice += dSeciliSefer.FlightPrice;
                    //    totalPrice += dSeciliSefer.FlightPriceTotal;
                    //}
                    blt.baseprice = "";
                    blt.totalprice = "";
                    if (HttpContext.Current.Session["birimFiyat"] != null)
                        blt.baseprice = HttpContext.Current.Session["birimFiyat"].ToString();
                    if (HttpContext.Current.Session["totalFiyat"] != null)
                        blt.totalprice = HttpContext.Current.Session["totalFiyat"].ToString();
                    blt.bankid = "0";
                    blt.installment = "0";
                    blt.email = buyInfo.mailPhone.Mail;
                    blt.phone = "0" + buyInfo.mailPhone.Phone.ToString().Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "").Trim();

                    var biletle = cl2.CreateTicket3D(blt.flighttype, blt.destination, blt.arrival, blt.sessionId, blt.aspNetSessionid, blt.passengers, blt.adultcount, blt.childcount, blt.infcount, blt.gidisJson, blt.donusJson, blt.combinationId, blt.sequenceNumber, blt.cardname, blt.cardnumber, blt.cardmonth, blt.cardyear, blt.cardcvv, blt.baseprice, blt.totalprice, blt.bankid, blt.installment, blt.email, blt.phone);

                    sonuc = biletle.Status.ToString().ToLower() + "#" + biletle.Result;
                    #endregion
                }
                else
                {
                    //Yurt disi ucusu ise buraya gir
                    #region Yurt Disi

                    Dictionary<Guid, OriginDestinationOptionList> topluListeDisHat = (Dictionary<Guid, OriginDestinationOptionList>)HttpContext.Current.Session["topluListeDisHat"];
                    Dictionary<Guid, PricedItineraryList> pricedItineraryList = (Dictionary<Guid, PricedItineraryList>)HttpContext.Current.Session["pricedItineraryList"];
                    Guid guID = new Guid(Method.gFlightID);
                    OriginDestinationOptionList originDes = topluListeDisHat[guID];
                    PricedItineraryList pricedIti = pricedItineraryList[guID];
                    blt.flighttype = "abroad";
                    blt.destination = HttpContext.Current.Session["gdOriginCode"].ToString();
                    blt.arrival = HttpContext.Current.Session["gdDestinationCode"].ToString();
                    BirsifirResult seferSonuc = (BirsifirResult)HttpContext.Current.Session["seferSonuc"];
                    blt.sessionId = seferSonuc.GidisUcuslari.uu_SessionId;
                    blt.aspNetSessionid = seferSonuc.GidisUcuslari.sessionid == null ? "" : seferSonuc.GidisUcuslari.sessionid;
                    blt.passengers = buyInfo.Pessengers.ToString().Substring(1, buyInfo.Pessengers.ToString().Length - 2);
                    blt.adultcount = "0";
                    blt.childcount = "0";
                    blt.infcount = "0";
                    foreach (var item in Yolcular.yolcuTipSayi)
                    {
                        switch (item.yolcuTipi)
                        {
                            case "Yetiskin":
                                blt.adultcount = item.yolcuSayisi;
                                break;
                            case "Cocuk":
                                blt.childcount = item.yolcuSayisi;
                                break;
                            case "Bebek":
                                blt.infcount = item.yolcuSayisi;
                                break;
                        }
                    }
                    blt.gidisJson = HttpContext.Current.Session["gidisJsonSonuc"] != null ? HttpContext.Current.Session["gidisJsonSonuc"].ToString() : "";
                    blt.donusJson = HttpContext.Current.Session["donusJsonSonuc"] != null ? HttpContext.Current.Session["donusJsonSonuc"].ToString() : "";
                    blt.combinationId = originDes.RefNumber;
                    blt.sequenceNumber = pricedIti.SequenceNumber;

                    blt.cardname = buyInfo.CreditCardInfo.BillingName;
                    blt.cardnumber = buyInfo.CreditCardInfo.CardNumber;
                    blt.cardmonth = buyInfo.CreditCardInfo.ExpirationMonth;
                    blt.cardyear = buyInfo.CreditCardInfo.ExpirationYear;
                    blt.cardcvv = buyInfo.CreditCardInfo.CV2;


                    blt.baseprice = "";
                    blt.totalprice = "";
                    if (HttpContext.Current.Session["birimFiyat"] != null)
                        blt.baseprice = HttpContext.Current.Session["birimFiyat"].ToString();
                    if (HttpContext.Current.Session["totalFiyat"] != null)
                        blt.totalprice = HttpContext.Current.Session["totalFiyat"].ToString();
                    blt.bankid = "0";
                    blt.installment = "0";
                    blt.email = buyInfo.mailPhone.Mail;
                    blt.phone = "0" + buyInfo.mailPhone.Phone.ToString().Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "").Trim();

                    var biletle = cl2.CreateTicket3D(blt.flighttype, blt.destination, blt.arrival, blt.sessionId, blt.aspNetSessionid, blt.passengers, blt.adultcount, blt.childcount, blt.infcount, blt.gidisJson, blt.donusJson, blt.combinationId, blt.sequenceNumber, blt.cardname, blt.cardnumber, blt.cardmonth, blt.cardyear, blt.cardcvv, blt.baseprice, blt.totalprice, blt.bankid, blt.installment, blt.email, blt.phone);

                    sonuc = biletle.Status.ToString().ToLower() + "#" + biletle.Result;
                    #endregion
                }

                return sonuc;

            }
            catch (Exception et)
            {


                //_deleteSatis(_satisInsertIDList);
                //Log.SaveSystemLog(
                //         new LogEntity()
                //         {
                //             PassengerInfo = tcYildizla(json) + HttpContext.Current.Session["UcusBilgileri"],
                //             SessionId = searchRequest.AuthenticationHeader != null ? searchRequest.AuthenticationHeader.SessionId.ToString() : "0",
                //             ErrorMessage = _error,
                //             RequestIP = HttpContext.Current.Request.UserHostAddress,
                //             RequestBrowser = HttpContext.Current.Request.UserAgent + "<br /><br />_" + HttpContext.Current.Session["tarayiciBilgi"] + "_",
                //             WebSite = HttpContext.Current.Request.Url.ToString() + "<br /><br />" + HttpContext.Current.Session["mobile"],
                //             LogSubject = "Taksim Turizm - Web Site Hatası"
                //         }
                //);

                //if (searchRequest != null &&
                //searchRequest.AuthenticationHeader != null &&
                //searchRequest.AuthenticationHeader.SessionId > 0)
                //    return String.Format("Session ID : {0} , Bir hata meydana geldi lütfen destek talep ediniz. Kredi kartınızdan para tahsil edilemedi. Hata kodu: #96548#" + _error + " === " + et.Message, searchRequest.AuthenticationHeader.SessionId);
                //else
                //    return String.Format("Bir hata meydana geldi lütfen destek talep ediniz. Kredi kartınızdan para tahsil edilemedi. Hata kodu: #96548#" + _error + " === " + et.Message);
            }
            //_deleteSatis(_satisInsertIDList); // buraya ulaştıysa runtime... hata vardır demektir id ler silinsin

            //Log.SaveSystemLog(
            //         new LogEntity()
            //         {
            //             PassengerInfo = tcYildizla(json) + HttpContext.Current.Session["UcusBilgileri"],
            //             SessionId = searchRequest.AuthenticationHeader != null ? searchRequest.AuthenticationHeader.SessionId.ToString() : "0",
            //             ErrorMessage = _error,
            //             RequestIP = HttpContext.Current.Request.UserHostAddress,
            //             RequestBrowser = HttpContext.Current.Request.UserAgent + "<br /><br />_" + HttpContext.Current.Session["tarayiciBilgi"] + "_",
            //             WebSite = HttpContext.Current.Request.Url.ToString() + "<br /><br />" + HttpContext.Current.Session["mobile"],
            //             LogSubject = "Taksim Turizm - Web Site Hatası"
            //         }
            //);

            //if (searchRequest != null &&
            //    searchRequest.AuthenticationHeader != null &&
            //    searchRequest.AuthenticationHeader.SessionId > 0)
            //    return String.Format("Session Id : {0} , Bir hata meydana geldi lütfen destek talep ediniz. Hata Kodu: #687525#" + _error, searchRequest.AuthenticationHeader.SessionId);
            //else
            //    return String.Format("Bir hata meydana geldi lütfen destek talep ediniz. Hata Kodu: #687525#" + _error);
            return "Hata";
        }
        #endregion

    }
}
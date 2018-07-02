using birSifirUcuzaUc.WebUI.birSifirServis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace birSifirUcuzaUc.WebUI.Ucus
{
    public partial class Bilet : System.Web.UI.Page
    {
        BirsifirSoapClient cl = new BirsifirSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            //?pnr=80904855-1022-4cea-ab62-6685e18a8457&email=acikgozali@hotmail.com
            //?pnr=96a072e9-b16b-44e1-9a76-c5efa2535880&email=suleymansulun@outlook.com
            //?pnr=30c14d61-9a22-4ff9-934b-833ff2620ef4&email=suleymansulun@outlook.com&type=domestic
            if (Request.QueryString["pnr"] != null && Request.QueryString["email"] != null)
            {
                string gidisBilgiler = "";
                string donusBilgiler = "";
                string yolcuBilgiler = "";
                string odemeBilgiler = "";
                string pnr = "";
                var sonuc = cl.TicketInfo(Request.QueryString["pnr"].ToString(), Request.QueryString["email"].ToString());
                int bla = sonuc.TicketInfoList.Count();
                //<b style=\"color: #22B509;\">A2DJ2A</b> ve <b style=\"color: #22B509;\">K0LQJF</b>
                for (int i = 0; i < bla; i++)
                {
                    string adiSoyadi = sonuc.TicketInfoList[0].billingname;
                    if (i != 0)
                        pnr += " ve ";
                    pnr += "<b style=\"color: #22B509;\">" + sonuc.TicketInfoList[i].pnr + "</b>";

                    foreach (var item in sonuc.TicketInfoList[i].fresult.flightlist)
                    {
                        if (item.direction == 0)
                        {
                            DateTime gTarih = Convert.ToDateTime(item.flightdatetime);
                            DateTime dTarih = Convert.ToDateTime(item.arrivaldatetime);
                            gidisBilgiler += gidisTopla(sonuc.TicketInfoList[i].pnr, item.airline, item.airline, item.flightno, gTarih.ToShortDateString(), item.origin, gTarih.ToShortTimeString(), item.destination, dTarih.ToShortTimeString(), item.classcode);
                        }
                        if (item.direction == 1)
                        {
                            DateTime gTarih = Convert.ToDateTime(item.flightdatetime);
                            DateTime dTarih = Convert.ToDateTime(item.arrivaldatetime);
                            donusBilgiler += donusTopla(sonuc.TicketInfoList[i].pnr, item.airline, item.airline, item.flightno, gTarih.ToShortDateString(), item.origin, gTarih.ToShortTimeString(), item.destination, dTarih.ToShortTimeString(), item.classcode);
                        }
                    }
                    //string adi = "";    
                    //string soyadi = "";
                    //string havAdi = "";
                    //string ebilet = "";
                    //string pnr1 = "";
                    ////-------------
                    //string adi2 = "";
                    //string soyadi2 = "";
                    //string havAdi2 = "";
                    //string ebilet2 = "";
                    //string pnr2 = "";
                    //foreach (var item in sonuc.TicketInfoList[i].fresult.passengerlist)
                    //{
                    //    if (bla > 1)
                    //    {
                    //        if (i == 0)
                    //        {
                    //            adi = item.firstname;
                    //            soyadi = item.lastname;
                    //            havAdi = sonuc.TicketInfoList[i].fresult.flightlist[0].airline;
                    //            ebilet = item.eticketnumber;
                    //            pnr1 = sonuc.TicketInfoList[i].pnr;
                    //        }
                    //        else
                    //        {
                    //            adi2 = item.firstname;
                    //            soyadi2 = item.lastname;
                    //            havAdi2 = sonuc.TicketInfoList[i].fresult.flightlist[0].airline;
                    //            ebilet2 = item.eticketnumber;
                    //            pnr2 = sonuc.TicketInfoList[i].pnr;
                    //        }
                    //        yolcuBilgiler = yolcuCiftPNR(item.firstname, item.lastname, sonuc.TicketInfoList[0].fresult.flightlist[0].airline, item.eticketnumber, pnr, sonuc.TicketInfoList[1].fresult.flightlist[0].airline, sonuc.TicketInfoList[1].fresult.passengerlist[0].eticketnumber, sonuc.TicketInfoList[1].pnr);
                    //    }
                    //    else
                    //    {
                    //        yolcuBilgiler = yolcuTekPNR(item.firstname, item.lastname, sonuc.TicketInfoList[i].fresult.flightlist[0].airline, item.eticketnumber, pnr);
                    //    }
                    //}
                }
                load.InnerHtml = govdeMetot(sonuc.TicketInfoList[0].billingname, pnr, gidisUcusBodyMetot(gidisBilgiler), donusUcusBodyMetot(donusBilgiler), "", "");
                //for (int i = 0; i < bla; i++)
                //{
                //    string adi = sonuc.TicketInfoList[0].fresult.passengerlist[i].firstname;
                //    string soyadi = sonuc.TicketInfoList[0].fresult.passengerlist[i].lastname;
                //    string havAdi = sonuc.TicketInfoList[i].fresult.flightlist[0].airline;
                //    string eticket = sonuc.TicketInfoList[0].fresult.passengerlist[i].lastname;
                //    string pnr1 = sonuc.TicketInfoList[i].pnr;//ilk pnr icin kullanilacak

                //    string havAdi2 = sonuc.TicketInfoList[1].fresult.flightlist[0].airline;
                //    string eticket2 = sonuc.TicketInfoList[1].fresult.passengerlist[i].eticketnumber;
                //    string pnr2 = sonuc.TicketInfoList[1].pnr;
                //    if (i < 1)
                //    {
                //        yolcuBilgiler = yolcuCiftPNR(adi, soyadi, havAdi, item.eticketnumber, pnr, sonuc.TicketInfoList[1].fresult.flightlist[0].airline, sonuc.TicketInfoList[1].fresult.passengerlist[0].eticketnumber, sonuc.TicketInfoList[1].pnr);
                //    }
                //    //foreach (var item in sonuc.TicketInfoList[i].fresult.passengerlist)
                //    //{


                //    //}
                //}

            }
        }
        private string gidisTopla(string PNR, string Havayolu, string noHavayolu, string UcusNo, string Tarih, string Kalkis, string kalSaat, string Varis, string varSaat, string Sinif)
        {
            string sonuc = string.Format(gidisUcus, PNR, Havayolu, noHavayolu, UcusNo, Tarih, Kalkis, kalSaat, Varis, varSaat, Sinif);
            return sonuc;
        }
        //http://88.250.178.229:4545/images/airlogo/b/8Q.gif\
        string gidisUcus = "<tr>" +
                           "<td>{0}</td>" +
                            "<td>" +
                                "<img src=\"/assets/images/airline/{1}.png\" onerror=\"this.onerror=null;this.src={2};\" alt=\"8Q\"></td>" +
                            "<td>{3}</td>" +
                            "<td>{4}</td>" +
                            "<td>{5} <b>{6}</b></td>" +
                            "<td>{7} <b>{8}</b></td>" +
                            "<td>{9}</td>" +
                        "</tr>";
        private string gidisUcusBodyMetot(string detay)
        {
            string sonuc = string.Format(gidisUcusBody, detay);
            return sonuc;
        }
        string gidisUcusBody = "<h4 class=\"dir\">Gidiş Uçuşları</h4>" +
                "<table class=\"resulttable\">" +
                    "<thead>" +
                        "<tr>" +
                            "<th>PNR</th>" +
                            "<th>Havayolu</th>" +
                            "<th>Uçuş No</th>" +
                            "<th>Tarih</th>" +
                            "<th>Kalkış</th>" +
                            "<th>Varış</th>" +
                            "<th>Sınıf</th>" +
                        "</tr>" +
                    "</thead>" +
                    "<tbody>" +
                    "{0}" +
                    "</tbody>" +
                "</table>";
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private string donusTopla(string PNR, string Havayolu, string noHavayolu, string UcusNo, string Tarih, string Kalkis, string kalSaat, string Varis, string varSaat, string Sinif)
        {
            string sonuc = string.Format(donusUcus, PNR, Havayolu, noHavayolu, UcusNo, Tarih, Kalkis, kalSaat, Varis, varSaat, Sinif);
            return sonuc;
        }
        string donusUcus = "<tr>" +
                            "<td>{0}</td>" +
                            "<td>" +
                                "<img src=\"/assets/images/airline/{1}.png\" onerror=\"this.onerror=null;this.src={2};\" alt=\"8Q\"></td>" +
                            "<td>{3}</td>" +
                            "<td>{4}</td>" +
                            "<td>{5} <b>{6}</b></td>" +
                            "<td>{7} <b>{8}</b></td>" +
                            "<td>{9}</td>" +
                        "</tr>";
        private string donusUcusBodyMetot(string detay)
        {
            string sonuc = string.Format(donusUcusBody, detay);
            return sonuc;
        }
        string donusUcusBody = "<h4 class=\"dir\">Dönüş Uçuşları</h4>" +
                "<table class=\"resulttable\">" +
                    "<thead>" +
                        "<tr>" +
                            "<th>PNR</th>" +
                            "<th>Havayolu</th>" +
                            "<th>Uçuş No</th>" +
                            "<th>Tarih</th>" +
                            "<th>Kalkış</th>" +
                            "<th>Varış</th>" +
                            "<th>Sınıf</th>" +
                        "</tr>" +
                    "</thead>" +
                    "<tbody>" +
                    "{0}" +
                    "</tbody>" +
                "</table>";
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private string yolcuTekPNR(string adi, string soyAdi, string Havayolu, string eBiletNo, string PNR)
        {
            string sonuc = string.Format(yolcu, adi, soyAdi, Havayolu, eBiletNo, PNR);
            return sonuc;
        }
        string yolcu = "<tr>" +
                            "<td>{0} {1}</td>" +
                            "<td>{2}</td>" +
                            "<td>{3}&nbsp;<a href=\"http://88.250.178.229:4545/onlinecheckin.aspx?pnr={4}&amp;name={0}&amp;surname={1}&amp;prov=3\" target=\"_blank\" style=\"float: right; font-size: 14px; margin-left: 10px;\" class=\"btn btn-success\"><i class=\"fa fa-check-square-o\"></i>&nbsp;Check-in</a></td>" +
                        "</tr>";
        private string yolcuBodyMetotTek(string detay)
        {
            string sonuc = string.Format(yolcuBodyTek, detay);
            return sonuc;
        }
        string yolcuBodyTek = "<table class=\"resulttable\">" +
                    "<thead>" +
                        "<tr>" +
                            "<th>Yolcu Bilgileri</th>" +
                            "<th>Firma</th>" +
                            "<th>E-Bilet Numarası</th>" +
                        "</tr>" +
                    "</thead>" +
                    "<tbody>" +
                    "{0}" +
                    "</tbody>" +
                "</table>";
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private string yolcuCiftPNR(string adi, string soyAdi, string Havayolu, string eBiletNo, string PNR, string Havayolu2, string ebiletNo2, string PNR2)
        {
            string sonuc = string.Format(yolcuGD, adi, soyAdi, Havayolu, eBiletNo, PNR, Havayolu2, ebiletNo2, PNR2);
            return sonuc;
        }
        string yolcuGD = "<tr>" +
                            "<td>{0} {1}</td>" +
                            "<td>{2}</td>" +
                            "<td>{3}&nbsp;<a href=\"http://88.250.178.229:4545/onlinecheckin.aspx?pnr={4}&amp;name={0}&amp;surname={1}&amp;prov=3\" target=\"_blank\" style=\"float: right; font-size: 14px; margin-left: 10px;\" class=\"btn btn-success\"><i class=\"fa fa-check-square-o\"></i>&nbsp;Check-in</a></td>" +
                            "<td>{5}</td>" +
                            "<td>{6}&nbsp;<a href=\"http://88.250.178.229:4545/onlinecheckin.aspx?pnr={7}&amp;name={0}&amp;surname={1}&amp;prov=4\" target=\"_blank\" style=\"float: right; font-size: 14px; margin-left: 10px;\" class=\"btn btn-success\"><i class=\"fa fa-check-square-o\"></i>&nbsp;Check-in</a></td>" +
                        "</tr>";
        private string yolcuBodyMetotCift(string detay)
        {
            string sonuc = string.Format(yolcuBodyCift, detay);
            return sonuc;
        }
        string yolcuBodyCift = "<table class=\"resulttable\">" +
                    "<thead>" +
                        "<tr>" +
                            "<th>Yolcu Bilgileri</th>" +
                            "<th>Firma</th>" +
                            "<th>E-Bilet Numarası</th>" +
                            "<th>Firma</th>" +
                            "<th>E-Bilet Numarası</th>" +
                        "</tr>" +
                    "</thead>" +
                    "<tbody>" +
                    "{0}" +
                    "</tbody>" +
                "</table>";
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        string odeme = "<table class=\"resulttable\">" +
                        "<thead>" +
                            "<tr>" +
                                "<th\">Sayı</th>" +
                                "<th\">Tip</th>" +
                                "<th\">Ücret</th>" +
                                "<th\">Vergi</th>" +
                                "<th\">Hizmet Bedeli</th>" +
                                "<th\">Genel Toplam</th>" +
                            "</tr>" +
                        "</thead>" +
                        "<tbody>" +
                            "<tr>" +
                                "<td>1</td>" +
                                "<td>Yetişkin</td>" +
                                "<td>{0} TL</td>" +
                                "<td>{1} TL</td>" +
                                "<td>{2} TL</td>" +
                                "<td>{3} TL</td>" +
                            "</tr>" +
                        "</tbody>" +
                    "</table>" +
                    "<table style=\"float: right;\">" +
                        "<tbody>" +
                            "<tr>" +
                                "<td>Genel Toplam</td>" +
                                "<td>{4} TL</td>" +
                            "</tr>" +
                        "</tbody>" +
                    "</table>";
        private string govdeMetot(string adiSoyadi, string pnr, string gidisUcus, string donusUcus, string yolcuBilgi, string odemeBilgi)
        {
            string sonuc = string.Format(govde, adiSoyadi, pnr, gidisUcus, donusUcus, yolcuBilgi, odemeBilgi);
            return sonuc;
        }
        //{0}   Adı Soyadı
        //{1}   Pnr No örn: <b style=\"color: #22B509;\">A2DJ2A</b> ve <b style=\"color: #22B509;\">K0LQJF</b>
        //{2}   Gidis Ucuslari
        //{3}   Donus Ucuslari
        //{4}   Yolcu Bilgileri
        //{5}   Ödeme Bilgileri
        string govde = "<div id=\"bilet-content\">" +
            "<div id=\"bilet-tab\" class=\"ic\">" +
                "<ul>" +

                    "<li><a href=\"/flightsearch.aspx\"><span><b class=\"fa fa-plane\"></b>Uçuş İşlemleri</span></a></li>" +
                    "<li class=\"active\"><a href=\"javascript:void(0)\"><span><b class=\"fa fa-ticket\"></b>Sonuç</span></a></li>" +
                "</ul>" +
                "<div class=\"clear\"></div>" +
            "</div>" +
            "<div class=\"ic resultpage\" id=\"bilet-in\">" +

                "<a href=\"/voucher.aspx?op=view&amp;pnr=2ab5248b-bfdf-426e-a81a-49ffcfd71ad3&amp;email=acikgozali@hotmail.com\" onclick=\"window.open(this.href, '', 'resizable=yes,status=no,location=no,toolbar=no,menubar=no, fullscreen=no,scrollbars=yes,dependent=no,width=800,height=600'); return false;\" style=\"float: right; font-size: 14px; margin-left: 5px\" class=\"btn btn-info\"><i class=\"fa fa-eye\"></i>&nbsp;Görüntüle</a>" +
                "<a href=\"/voucher.aspx?op=createdticket&amp;pnr=2ab5248b-bfdf-426e-a81a-49ffcfd71ad3&amp;email=acikgozali@hotmail.com\" onclick=\"window.open(this.href, '', 'resizable=yes,status=no,location=no,toolbar=no,menubar=no, fullscreen=no,scrollbars=yes,dependent=no,width=800,height=600'); return false;\" style=\"float: right; font-size: 14px;\" class=\"btn btn-warning\"><i class=\"fa fa-print\"></i>&nbsp;Yazdır</a>" +
                "<br/>" +
                "Sayın <b>{0}</b>,<br/>" +
                "<br/>" +
                "Bizi tercih ettiğiniz için teşekkür ederiz.<br/>" +
                "Detayları aşağıda belirtilen uçuşunuz/uçuşlarınız için satın almış olduğunuz bilete/biletlere ait rezervasyon kayıt numaranız/numaralarınız {1} olarak düzenlenmiştir.<br/>" +
                "<br/>" +
                "<p style=\"color: #d30e0e; font-weight: bold;\">" +
                 "   * Lütfen biletinizin isim, tarih , saat ve parkur bilgisini kontrol ediniz.<br/>" +
                 "   * Biletinizdeki isim bilgisi ile pasaport veya kimlikteki bilginizin aynı olması gerekmektedir." +
                "</p>" +
                "<h3><i class=\"fa fa-plane\"></i>&nbsp;Uçuş Bilgileri</h3>" +
                "{2}" +
                "{3}" +
                 "<br/>" +
                "<h3><i class=\"fa fa-group\"></i>&nbsp;Yolcu Bilgileri</h3>" +
                "{4}" +
                "<br/>" +
                "<h3><i class=\"fa fa-credit-card\"></i>&nbsp;Ödeme Bilgileri</h3>" +
                "<div>" +
                "{5}" +
                "</div>" +
                "<br/>" +
                "<br/>" +
                "<p>Uçuş için yukarıda belirtilen rezervasyon kayıt numarası ve fotoğraflı kimliğiniz (yurtdışı uçuşlarında pasaport) yeterlidir. Lütfen uçuşunuzun kalkış saatinden en geç 2 saat önce havaalanında olunuz.</p>" +
                "<br/>" +
            "</div>" +
        "</div>";
    }
}
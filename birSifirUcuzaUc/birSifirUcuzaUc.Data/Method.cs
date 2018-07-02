using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace birSifirUcuzaUc.Data
{
    public static class Method
    {
        /// <summary>
        /// Ic Hat? Dis Hat?
        /// 
        /// </summary>
        public static bool seferTipi { get; set; }
        /// <summary>
        /// GidisID
        /// </summary>
        public static string gFlightID { get; set; }
        /// <summary>
        /// DonusID
        /// </summary>
        public static string dFlightID { get; set; }
        //queryString'den gelen kişilerin int değer olup olmadığını kontrol ediyoruz.
        public static bool IsInt(this string gonDeger)
        {
            int x = 0;
            return int.TryParse(gonDeger, out x);
        }

    }

    public class Yolcu
    {
        public string yolcuTipi { get; set; }
        public string yolcuSayisi { get; set; }
    }

    public static class Yolcular
    {
        public static List<Yolcu> yolcuTipSayi = new List<Yolcu>();
    }

    //public static class jsonTipi
    //{
    //    public static int direction = 0;
    //    public static int transferindex = 0;
    //    public static string originlocation = "AYT";
    //    public static string destinationlocation = "SAW";
    //    public static string flightdatetime = "05.05.2018 07:00:00";
    //    public static string arrivaldatetime = "05.05.2018 08:20:00";
    //    public static string airline = "XQ";
    //    public static string flightno = "7526";
    //    public static string classcode = "A";
    //    public static string isconnect = "false";
    //    public static string custom1 = "4";
    //    public static string custom2 = "2";
    //    public static string origindestination = "Antalya (AYT);Sabiha Gokcen (SAW)";
    //    public static string airlinename = "SunExpress";
    //}

    public class jsonTipi2
    {
        public string direction { get; set; }
        public string transferindex { get; set; }
        public string originlocation { get; set; }
        public string destinationlocation { get; set; }
        public string flightdatetime { get; set; }
        public string arrivaldatetime { get; set; }
        public string airline { get; set; }
        public string flightno { get; set; }
        public string classcode { get; set; }
        public string isconnect { get; set; }
        public string custom1 { get; set; }
        public string custom2 { get; set; }
        public string origindestination { get; set; }
        public string airlinename { get; set; }
    }


    //public static class BiletOlustur
    //{
    //    public static CreateTicket3DInfo bilet = new CreateTicket3DInfo();
    //}

    public class CreateTicket3DInfo
    {
        /// <summary>
        /// "abroad" -> yurt dışı
        /// "domestic" -> yurt içi
        /// </summary>
        public string flighttype { get; set; }
        /// <summary>
        /// ISTCTR
        /// </summary>
        public string destination { get; set; }
        /// <summary>
        /// AYTTR
        /// </summary>
        public string arrival { get; set; }
        /// <summary>
        /// oluşturulan uçuş listesinin uu_SessionId değişkeni gönderilecek.
        /// </summary>
        public string sessionId { get; set; }
        /// <summary>
        /// ASP.NET SessionId gönderilecek.
        /// </summary>
        public string aspNetSessionid { get; set; }
        /// <summary>
        /// Tek yolcu Örnek: { gender: "MR", type: "ADT", name: "omer", surname: "besent", tckimlik: "11111111111" }
        /// Uçuşta pasaport isteniyorsa Tek yolcu Örnek:  gender: "MR", type: "ADT", name: "omer", surname: "besent", tckimlik: "11111111111", national: "TR",  passportnumber: "asdfasdf", passportdate: "13.01.2022" }
        /// </summary>
        public string passengers { get; set; }//: aşağıdaki gibi gönderilecektir. birden fazla olduğundan süslü parantezlerin arasına virgül koyulur. çocuk veya bebekte doğum tarihi zorunludur.

        public string adultcount { get; set; }
        /// <summary>
        ///  yok ise 0 veya boş gönderilebilir.
        /// </summary>
        public string childcount { get; set; }
        /// <summary>
        /// yok ise 0 veya boş gönderilebilir.
        /// </summary>
        public string infcount { get; set; }
        /// <summary>
        /// { direction: 0, transferindex: 0, originlocation: "AYT", destinationlocation: "SAW", flightdatetime: "05.05.2018 07:00:00", arrivaldatetime: "05.05.2018 08:20:00", airline: "XQ", flightno: "7526", classcode: "A", isconnect: "false", custom1: "4", custom2: "2", origindestination: "Antalya (AYT);Sabiha Gokcen (SAW)", airlinename: "SunExpress" },{....}
        /// </summary>
        public string gidisJson { get; set; }//: SADECE YURTİÇİ UÇUŞLARINDA KULLANILACAK.
        /// <summary>
        /// { direction: 0, transferindex: 0, originlocation: "AYT", destinationlocation: "SAW", flightdatetime: "05.05.2018 07:00:00", arrivaldatetime: "05.05.2018 08:20:00", airline: "XQ", flightno: "7526", classcode: "A", isconnect: "false", custom1: "4", custom2: "2", origindestination: "Antalya (AYT);Sabiha Gokcen (SAW)", airlinename: "SunExpress" },{....}
        /// </summary>
        public string donusJson { get; set; }//: SADECE YURTİÇİ UÇUŞLARINDA KULLANILACAK.
        /// <summary>
        /// uçuşa ait CombinationId gönderilecek
        /// </summary>
        public string combinationId { get; set; }
        /// <summary>
        /// uçuşa ait SequenceNumber gönderilecek
        /// </summary>
        public string sequenceNumber { get; set; }
        /// <summary>
        /// Kart sahibinin ad soyad
        /// </summary>
        public string cardname { get; set; }
        /// <summary>
        /// Kart numarası
        /// </summary>
        public string cardnumber { get; set; }
        /// <summary>
        /// Kart ay
        /// </summary>
        public string cardmonth { get; set; }
        /// <summary>
        /// Kart yıl
        /// </summary>
        public string cardyear { get; set; }
        /// <summary>
        /// Kart cvv
        /// </summary>
        public string cardcvv { get; set; }
        /// <summary>
        /// Uçuşa ait TotalFare değeri yazılacak.
        /// </summary>
        public string baseprice { get; set; }
        /// <summary>
        /// Uçuşa ait TotalFare değeri yazılacak.
        /// </summary>
        public string totalprice { get; set; }
        /// <summary>
        /// varsayılan banka için 0 gönderilecek.
        /// </summary>
        public string bankid { get; set; }
        /// <summary>
        /// 0 gönderilecek.
        /// </summary>
        public string installment { get; set; }
        /// <summary>
        /// email adresi
        /// </summary>
        public string email { get; set; }
        /// <summary>
        /// Telefon numarası
        /// </summary>
        public string phone { get; set; }

    }


}

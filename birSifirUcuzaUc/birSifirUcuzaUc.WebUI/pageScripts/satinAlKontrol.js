
$(":input[data-inputmask-mask]").inputmask();
$(":input[data-inputmask-alias]").inputmask();
$(":input[data-inputmask-regex]").inputmask("Regex");
//$('.email').inputmask('email');

function handleClick(checkB, sira) {

    var birCheck = checkB.checked; //document.getElementById('checkboxtcno0').checked;
    var siraNo = sira;
    if (birCheck == true) {
        $('#inpBilgiTc' + siraNo).attr("disabled", false);
        $('#inpBilgiTc' + sira).val('');
    }
    else {
        $('#inpBilgiTc' + siraNo).attr("disabled", true);
        $('#inpBilgiTc' + siraNo).val('');
    }

}

$("#_PessengerItems").click(function (e) {
    //searchAirValidate();

    ////açılan div haricinde biryer tıkladığımızda divAirPortSearch1 divAirPortSearch2 kapanacak..
    //if (e.target.id != "divAirPortSearch1") {
    //    //neredenVana = false;
    //    $("#divAirPortSearch1").removeClass("open");
    //}
    ////açılan div haricinde biryer tıkladığımızda divAirPortSearch1 divAirPortSearch2 kapanacak..
    //if (e.target.id != "divAirPortSearch2") {
    //    //nereyeVana = false;
    //    $("#divAirPortSearch2").removeClass("open");
    //}

    //inputa girdiğimiz de içeriği seçilmiş olacak.. 
    //if (e.target.id == "inpBilgiTc1") {

    //$("#inpNeredenAirportCode").val('');
    //$("#inpNereden").val('');
    //$("#inpNereden").select();
    //iphone da select komutu calismadigindan selectionStart ve SelectionEnd komutlarini kullandik..
    $("#" + e.target.id).get(0).selectionStart = 0;
    $("#" + e.target.id).get(0).selectionEnd = 999;
    //$("#inpNereden").css('color', '#00adef');
    //}

});
function objPessengerItem(SequenceNo, FirstName, LastName, BirthDate, CitizenNo, Email, Gender, IfContact, Phone, Type, WheelChairServiceType, tc) {
    this.gender = Gender;
    this.type = Type;
    this.name = FirstName;
    this.surname = LastName;
    this.tckimlik = tc;
    this.birthdate = BirthDate;
}
objSatinAl = {
    General: {
        FlightType: "",
        GidisProductID: "",
        GidisHavayolu: "",
        GidisSefer: "",
        GidisTarih: "",
        GidisDestinasyon: "",
        GidisVarisTarih: "",
        GidisVarisDestinasyon: "",
        DonusTarih: "",
        DonusHavayolu: "",
        DonusSefer: "",
        DonusDestinasyon: "",
        DonusVarisTarih: "",
        DonusVarisDestinasyon: "",
        DonusProductID: "",
        GidisFlightID: "",
        DonusFlightID: "",
        AltAcenteLink: "",
        YolcuBilgileriHTML: ""
    },
    Pessengers: [],
    mailPhone:
        {
            Mail: "",
            Phone: ""
        },
    CreditCardInfo: {
        BillingName: "",
        CardHolder: "",
        CardNumber: "",
        CardType: "",
        CV2: "",
        ExpirationYear: 0,
        ExpirationMonth: 0
    },
    finalizeShopping: {
        IfCompany: false,
        BillingName: "",
        TaxOffice: "",
        TaxNo: "",
        Address_City: "",
        Address_ZipCode: "",
        Address_Detail: "",
        CountryCode: "",
        PhoneNumber: "",
        MobileNumber: "",
        EMail: ""
    },
    disHat: false,
    InstallmentOptionId: ""
}

function satisFinis() {
    var isimSoyisim = [];
    var strAdiSoyadi;
    var count = $("#_PessengerItems").children().length;
    //alert(count);
    var validate = true;
    for (var i = 1; i <= count; i++) {
        //alert("for (var i = 1; i <= divPessengers.length; i++) içine girdi.");
        //var paxType = "inpPaxType" + i;
        var _cinsiyet = "slcBilgiCinsiyet" + i;
        var _ad = "inpBilgiAd" + i;
        var _soyad = "inpBilgiSoyad" + i;
        var _date = "date" + i;
        var _tcNo = "inpBilgiTc" + i;
        var _eMail = "inpIletisimEposta";
        var _tel = "inpIletisimCepNo";

        if (!validateSatinAlInput(_cinsiyet)) {
            if (validate) {
                validate = false;
            }
        }

        if (!validateSatinAlInput(_ad)) {
            if (validate) {
                validate = false;
            }
        }
        //alert("_ad validate sonrası sıkıntı yok");

        if (!validateSatinAlInput(_soyad)) {
            if (validate) {
                validate = false;
            }
        }

        if (!validateSatinAlInput(_date)) {
            if (validate) {
                validate = false;
            }
        }

        if (!validateSatinAlInput(_tcNo)) {
            if (validate) {
                validate = false;
            }

        }

        if ($('#' + _ad).val() != "Alan boş geçilemez!" && 0 < $('#' + _ad).val().length) {
            strAdiSoyadi = $('#' + _ad).val().trim() + " " + $('#' + _soyad).val().trim();
            for (var h = 0; h < isimSoyisim.length; h++) {
                if (isimSoyisim[h] == strAdiSoyadi) {
                    $('#lblGenelUyari').text("Birden fazla aynı İsim ve Soyisim içeren yolcu olduğundan işlem yapılamamaktadır. Lütfen 000 00 00 numaralı telefonu arayın ya da yolcuya ayrı bilet işlemi düzenleyin.");
                    $('#lblGenelUyari').css("color", "rgb(199, 0, 0)");
                    return false;
                }
            }
            isimSoyisim.push(strAdiSoyadi);
            $('#lblGenelUyari').text("");
        }
    }

    if (!validateSatinAlInput("inpOdemeKartCVC2")) {
        if (validate) {
            validate = false;
        }
    }
    if (!validateSatinAlInput("inpOdemeKartNo")) {
        if (validate) {
            validate = false;
        }
    }
    //alert("_ad validate sonrası sıkıntı yok");
    //alert("5");
    if (!validateSatinAlInput("inpOdemeKartSahibi")) {
        if (validate) {
            validate = false;
        }
    }


    if (validate) {

        for (var i = 1; i <= count; i++) {
            var cinsiyet = "#slcBilgiCinsiyet" + i + " option:selected";
            //-----------------------------
            var _ad = "#inpBilgiAd" + i;
            //-----------------------------
            var _soyad = "#inpBilgiSoyad" + i;
            //-----------------------------
            var _date = "#date" + i;
            //-----------------------------
            var _tc = "#inpBilgiTc" + i;
            //-----------------------------
            var _ePosta = "#inpIletisimEposta";
            //-----------------------------
            var _cep = "#inpIletisimCepNo";
            //-----------------------------
            var _type = "#inpPaxType" + i;
            //-----------------------------

            var _SequenceNo = i;

            var _Gender = $(cinsiyet).val();
            //-----------------------------
            var _FirstName = $(_ad).val();
            //-----------------------------
            var _LastName = $(_soyad).val();
            //-----------------------------
            var _BirthDate = $(_date).val().replace(/\//g, '.');
            //-----------------------------
            var _tcNoo = $(_tc).val();
            //-----------------------------
            var _Email = $(_ePosta).val();
            //-----------------------------
            var _Phone = $(_cep).val().replace(/\(/g, '').replace(/\)/g, '').replace(/\-/g, '').replace(/\s/g, '');
            //-----------------------------
            var _Type = $(_type).val();
            //-----------------------------

            var _IfContact = true;
            //-----------------------------
            var _WheelChairServiceType = 0;
            //-----------------------------

            //SequenceNo, _FirstName, _LastName, _BirthDate, " ", _Email, _Gender,_IfContact, _Phone, _Type, _WheelChairServiceType, _tcNo
            var newObjPessengerItem = new objPessengerItem(_SequenceNo, _FirstName, _LastName, _BirthDate, " ", _Email, _Gender, _IfContact, _Phone, _Type, _WheelChairServiceType, _tcNoo);
            objSatinAl.Pessengers[i - 1] = newObjPessengerItem;
            objSatinAl.mailPhone.Mail = _Email;
            objSatinAl.mailPhone.Phone = _Phone;
        }
        //CREDIT CARD
        objSatinAl.CreditCardInfo.BillingName = $("#inpOdemeKartSahibi").val();
        objSatinAl.CreditCardInfo.CardHolder = $("#inpOdemeKartSahibi").val();
        objSatinAl.CreditCardInfo.CardNumber = $("#inpOdemeKartNo").val().replace(/\s/g, '');
        objSatinAl.CreditCardInfo.CardType = $("#spnOdemeKartTuru").text();
        objSatinAl.CreditCardInfo.CV2 = $("#inpOdemeKartCVC2").val();
        objSatinAl.CreditCardInfo.ExpirationMonth = $("#spnOdemeKartTarihAy option:selected").text();
        objSatinAl.CreditCardInfo.ExpirationYear = $("#spnOdemeKartTarihYil option:selected").text();
        //GENERAL
        objSatinAl.General.YolcuBilgileriHTML = $("#_PessengerItems").html();
        //-------------------------------------------------------------------------------------------------

        var jsonText = JSON.stringify(objSatinAl);

        JS_satinAl(jsonText);

    }


}

function satisRez() {
    var isimSoyisim = [];
    var strAdiSoyadi;
    var count = $("#_PessengerItems").children().length;
    //alert(count);
    var validate = true;
    for (var i = 1; i <= count; i++) {
        //alert("for (var i = 1; i <= divPessengers.length; i++) içine girdi.");
        //var paxType = "inpPaxType" + i;
        var _cinsiyet = "slcBilgiCinsiyet" + i;
        var _ad = "inpBilgiAd" + i;
        var _soyad = "inpBilgiSoyad" + i;
        var _date = "date" + i;
        var _tcNo = "inpBilgiTc" + i;
        var _eMail = "inpIletisimEposta";
        var _tel = "inpIletisimCepNo";

        if (!validateSatinAlInput(_cinsiyet)) {
            if (validate) {
                validate = false;
            }
        }

        if (!validateSatinAlInput(_ad)) {
            if (validate) {
                validate = false;
            }
        }
        //alert("_ad validate sonrası sıkıntı yok");

        if (!validateSatinAlInput(_soyad)) {
            if (validate) {
                validate = false;
            }
        }

        if (!validateSatinAlInput(_date)) {
            if (validate) {
                validate = false;
            }
        }

        if (!validateSatinAlInput(_tcNo)) {
            if (validate) {
                validate = false;
            }

        }

        //if (!validateSatinAlInput(_eMail)) {
        //    if (validate) {
        //        validate = false;
        //    }

        //}

        //if (!validateSatinAlInput(_tel)) {
        //    if (validate) {
        //        validate = false;
        //    }

        //}

        if ($('#' + _ad).val() != "Alan boş geçilemez!" && 0 < $('#' + _ad).val().length) {
            strAdiSoyadi = $('#' + _ad).val().trim() + " " + $('#' + _soyad).val().trim();
            for (var h = 0; h < isimSoyisim.length; h++) {
                if (isimSoyisim[h] == strAdiSoyadi) {
                    $('#lblGenelUyari').text("Birden fazla aynı İsim ve Soyisim içeren yolcu olduğundan işlem yapılamamaktadır. Lütfen 000 00 00 numaralı telefonu arayın ya da yolcuya ayrı bilet işlemi düzenleyin.");
                    $('#lblGenelUyari').css("color", "rgb(199, 0, 0)");
                    return false;
                }
            }
            isimSoyisim.push(strAdiSoyadi);
            $('#lblGenelUyari').text("");
        }
    }
    if (validate) {
        $("#payment-panel").css("display", "block");
    }


}

function validateSatinAlInput(validateInputName) {
    //alert("validateInputName : " + $("#" + validateInputName).val() + " " + $("#" + validateInputName).val().length);
    if (!validateInputName.startsWith('slcBilgiCinsiyet') && !validateInputName.startsWith('inpIletisimEposta')) {
        if ($("#" + validateInputName).val().replace(/^\s+|\s+$/gm, '').length > 1 && $("#" + validateInputName).val().replace(/^\s+|\s+$/gm, '') != "Alan boş geçilemez!") {
            $("#" + validateInputName).attr("validate", "true");
            $("#" + validateInputName).removeClass("errorInput");
            $("#" + validateInputName).css("color", "#000000");
            return true;
        } else {
            $("#" + validateInputName).css("color", "rgb(199, 0, 0)");
            if (!validateInputName.startsWith('date')) {
                $("#" + validateInputName).val("Alan boş geçilemez!");
            }
            $("#" + validateInputName).attr("validate", "false");
            return false;
        }
    }
    else {
        if ($("#" + validateInputName).val() != 'X' && validateInputName.startsWith('slcBilgiCinsiyet')) {
            $("#" + validateInputName).attr("validate", "true");
            $("#" + validateInputName).css("font-weight", "100");
            $("#" + validateInputName).removeClass("errorInput");
            $("#" + validateInputName).css("color", "#000000");
            return true;
        } else {
            $("#" + validateInputName).css("color", "rgb(199, 0, 0)");
            $("#" + validateInputName).css("font-weight", "700");
            //$("#" + validateInputName).val("Alan boş geçilemez!");
            $("#" + validateInputName).attr("validate", "false");
            return false;
        }
    }
}


function myFunction(ths) {//Ad,Soyad ve Mail kısmındaki karakter düzeltme metodumuz..
    var charMap = {
        Ç: 'C',
        Ö: 'O',
        Ş: 'S',
        İ: 'I',
        I: 'I',
        Ü: 'U',
        Ğ: 'G',
        ç: 'c',
        ö: 'o',
        ş: 's',
        ı: 'i',
        ü: 'u',
        ğ: 'g'
    };

    var str = ths;

    str_array = str.value.split('');

    for (var i = 0, len = str_array.length; i < len; i++) {
        str_array[i] = charMap[str_array[i]] || str_array[i];
    }

    str = str_array.join('');

    var clearStr = str.replace(/[çöşüğı]/gi, "");

    ths.value = clearStr;

}

function JS_satinAl(_json) {
    var newJson = {
        json: _json
    }

    $.ajax({
        type: "POST",
        url: "/../Ucus/Satis.aspx/satinAl",
        data: JSON.stringify(newJson),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            var bla = "";
            if (msg.d.split('#')[0] == "true") {
                $('#container').css('display', 'block');
                window.open(msg.d.split('#')[1], "theFrame");
                //window.location = msg.d.split('#')[1];
                var wait = "é";
            }
            else {
                $("#_divUyari").css("display", "block");
                //alert("Geçti");
                $("#_spnUyari").text(msg.d);
                //progressOnOff(false);
            }
        },
        error: function (error) {
            alert('error; ' + error.d);
        }

    });

}

function PopupCenter(SayfaURL, Baslik, genislik, yukseklik) {
    var sol = (screen.width / 2) - (genislik / 2);
    var ust = (screen.height / 2) - (yukseklik / 2);
    var targetWin = window.open(SayfaURL, Baslik, 'toolbar=yes, location=no, directories=no, status=no, menubar=yes, scrollbars=no, resizable=no, copyhistory=no, width=' + yukseklik + ', height=' + genislik + ', top=' + sol + ', left=' + ust);
}

window.addEventListener("message", function (event) {
    var result = event.data;
    var varmi = JSON.stringify(result).indexOf('proxy_ready');
    if (varmi < 0) {
        if (result.status) {
            window.location = "Bilet.aspx?pnr=" + result.resultfiled1 + "&email=" + result.resultfiled2 + "&type=" + result.flighttype; // Bilet oluştuysa yönlenilecek sayfa. Bu sayfada ticketinfo methodu kullanılarak bilet gösterilecek.
        }
        else {
            alert(result.message); // Hata oluştu ise hata gösterilecek.
        }
    }
});


function satinAlRezervalidate() {
    var count = $("#_PessengerItems").children().length;
    for (var i = 1; i <= count; i++) {
        var _ad1 = "inpBilgiAd" + i;
        var _soyad2 = "inpBilgiSoyad" + i;

        $('#' + _ad1).keypress(function (evt) {

            var charCode = (evt.which) ? evt.which : event.keyCode

            if (((charCode <= 93 && charCode >= 65) || (charCode <= 122 && charCode >= 97) || charCode == 8) || charCode == 32 || charCode == 350 || charCode == 351 || charCode == 304 || charCode == 286 || charCode == 287 || charCode == 231 || charCode == 199 || charCode == 305 || charCode == 214 || charCode == 246 || charCode == 220 || charCode == 252) {

                return true;

            }
            if (charCode == 192 || charCode == 193 || charCode == 194 || charCode == 195 || charCode == 196 || charCode == 197 || charCode == 198 || charCode == 200 || charCode == 201 || charCode == 202 || charCode == 203 || charCode == 204 || charCode == 205 || charCode == 206 || charCode == 207 || charCode == 209 || charCode == 210 || charCode == 211 || charCode == 212 || charCode == 213 || charCode == 214 || charCode == 216 || charCode == 217 || charCode == 218 || charCode == 219 || charCode == 220 || charCode == 221 || charCode == 222 || charCode == 225 || charCode == 226 || charCode == 227 || charCode == 228 || charCode == 229 || charCode == 233 || charCode == 234 || charCode == 235 || charCode == 236 || charCode == 237 || charCode == 238 || charCode == 239 || charCode == 241 || charCode == 242 || charCode == 243 || charCode == 244 || charCode == 245 || charCode == 246 || charCode == 247 || charCode == 248 || charCode == 249 || charCode == 250 || charCode == 251 || charCode == 252 || charCode == 253 || charCode == 254 || charCode == 255) {
                return false;
            }
            return false;

        });
        $('#' + _soyad2).keypress(function (evt) {

            var charCode = (evt.which) ? evt.which : event.keyCode

            //Bu şartımız ile harf girildiği takdirde true olarak geri dönüş sağlıyoruz. 

            //Türkçe karakter desteği için ascii kod şartları aşağıya eklenmiştir.
            if (((charCode <= 93 && charCode >= 65) || (charCode <= 122 && charCode >= 97) || charCode == 8) || charCode == 32 || charCode == 350 || charCode == 351 || charCode == 304 || charCode == 286 || charCode == 287 || charCode == 231 || charCode == 199 || charCode == 305 || charCode == 214 || charCode == 246 || charCode == 220 || charCode == 252) {

                return true;

            }
            if (charCode == 192 || charCode == 193 || charCode == 194 || charCode == 195 || charCode == 196 || charCode == 197 || charCode == 198 || charCode == 200 || charCode == 201 || charCode == 202 || charCode == 203 || charCode == 204 || charCode == 205 || charCode == 206 || charCode == 207 || charCode == 209 || charCode == 210 || charCode == 211 || charCode == 212 || charCode == 213 || charCode == 214 || charCode == 216 || charCode == 217 || charCode == 218 || charCode == 219 || charCode == 220 || charCode == 221 || charCode == 222 || charCode == 225 || charCode == 226 || charCode == 227 || charCode == 228 || charCode == 229 || charCode == 233 || charCode == 234 || charCode == 235 || charCode == 236 || charCode == 237 || charCode == 238 || charCode == 239 || charCode == 241 || charCode == 242 || charCode == 243 || charCode == 244 || charCode == 245 || charCode == 246 || charCode == 247 || charCode == 248 || charCode == 249 || charCode == 250 || charCode == 251 || charCode == 252 || charCode == 253 || charCode == 254 || charCode == 255) {
                return false;
            }
            return false;

        });

    }
}

//function clearInput(id) {

//    var charMap = { Ç: 'c', Ö: 'o', Ş: 's', İ: 'i', I: 'i', Ü: 'u', Ğ: 'g', ç: 'c', ö: 'o', ş: 's', ı: 'i', ü: 'u', ğ: 'g' };
//    /*
//     Anlık input değerini (value) alıyoruz.
//     */
//    var str = id;
//    /*
//     Inputa girilen Türkçe karakterleri yukarıda tanımladığımız değerlerle değiştiriyoruz.
//     Bu zahmete katlanmamızın nedeni JavaScript ile Türkçe karakterleri sağlıklı biçimde,
//     herhangi bir bug oluşmasına mahal vermeden değiştirebilmek.
//     */
//    str_array = str.split('');

//    for (var i = 0, len = str_array.length; i < len; i++) {
//        str_array[i] = charMap[str_array[i]] || str_array[i];
//    }

//    str = str_array.join('');
//    /*
//     Alfanumerik olmayan özel karakterlerin temizlendiği yeni bir value oluşturuyoruz:
//     1. replace(" ","") ile boşlukları "" işaretiyle değiştiriyoruz.
//     3. replace(/[^a-z0-9-.]/gi,"") ile temizlik işlemini gerçekleştiriyor, - ve . gibi karakterlerin
//     temizlenme işleminden hariç tutulmasını sağlıyoruz.
//     4. toLowerCase() ile değişkeni tamamen küçük harflere çeviriyoruz.
//     */
//    var clearStr = str.replace(" ", "").replace(/[^a-z0-9-.çöşüğı]+@/gi, "").toLowerCase();
//    /*
//     Son olarak işlemden geçirdiğimiz değeri tekrar inputa basıyoruz
//     */
//    return clearStr;
//}


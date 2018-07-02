
var makaleId = null;
var formDataSend = null;

//$(document).ready(function () {

//$('#inpNereden').on('input', function () {
//    //&& neredenVana == true
//    if (this.value.trim().length >= 3) {
//        searchAirPort(this, "NEREDEN");
//    }
//    else if (this.value.trim().length == 0) {
//        $("#divAirPortSearch1").removeClass("open");
//        $("#inpAirportOneri1").html('');
//    }
//});

//$('#inpNereye').on('input', function () {

//    if (this.value.trim().length >= 3) {
//        searchAirPort(this, "NEREYE");
//    } else if (this.value.trim().length == 0) {
//        $("#divAirPortSearch2").removeClass("open");
//        $("#inpAirportOneri2").html('');
//    }
//});

//$("#content").click(function (e) {
//    //açılan div haricinde biryer tıkladığımızda divAirPortSearch1 divAirPortSearch2 kapanacak..
//    if (e.target.id != "divAirPortSearch1") {
//        //neredenVana = false;
//        $("#divAirPortSearch1").removeClass("open");
//    }
//    //açılan div haricinde biryer tıkladığımızda divAirPortSearch1 divAirPortSearch2 kapanacak..
//    if (e.target.id != "divAirPortSearch2") {
//        //nereyeVana = false;
//        $("#divAirPortSearch2").removeClass("open");
//    }

//});


//});
 
 
$(window).load(function () {
    // run code
    documentReady();
     
});

 

function myFunction(gelen) {
    //alert(gelen.value);
    if (gelen.value.trim().length >= 3) {
        searchAirPort(gelen, "NEREDEN");
    }
    else if (gelen.value.trim().length == 0) {
        $("#divAirPortSearch1").removeClass("open");
        $("#inpAirportOneri1").html('');
    }
}
 
function documentReady() {
    makaleId = getParameterByName('MakaleID');//url den queryString değeri getirir.
    if (makaleId != null) {
        $('#lblSave').text('Güncelle')

        var query = JSON.stringify({ id: makaleId });
        $.ajax({
            type: "POST",
            url: "addArticle.aspx/makaleGetir",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: query,
            success: function (data) {
                var d = JSON.parse(data.d);
                if (d.status == 500) {
                    alert(d.message);
                }
                else if (d.status == 200) {
                    $('#txtArticleHeader').val(d.data.illerBaslik);
                    //$('#editor-wysiwyg-iframe').val(d.data.illerMakale);
                    $('#editor-wysiwyg-iframe').contents().find('.wysiwyg').html(d.data.illerMakale);
                }
            },
            error: function (xhr, err) {
                alert(err);
            }
        });

    } else
        $('#lblSave').text('Kaydet')




}
function makaleKaydet() {
     
    var baslik = $('#txtArticleHeader').val();
    var icerik = $('#editor').val();

    var query = JSON.stringify({ baslik: baslik, icerik: icerik, makaleId: makaleId, kapakResim: "RESIM.jpg" });
    $.ajax({
        type: "POST",
        url: "addArticle.aspx/makaleKaydet",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: query,
        success: function (data) {
            var d = JSON.parse(data.d);
            if (d.status == 500) {
                alert(d.message);
            }
            else if (d.status == 200) {
                alert('başarılı')
            }
        },
        error: function (xhr, err) {
            alert(err);
        }
    });
}

//url den queryString değeri getirir.
function getParameterByName(name, url) {
    if (!url) url = window.location.href;
    name = name.replace(/[\[\]]/g, "\\$&");
    var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, " "));
}


function searchAirPort(INPUT, TYPE) {
    var keyword = INPUT.value;
    if (keyword.trim().length > 0) {
        JS_searchAirport(keyword, TYPE);
    }
}

function JS_searchAirport(_KEYWORD, _TYPE) {

    $.ajax({
        type: "POST",
        url: "/../flightSearch.aspx/searchAirport",
        data: "{_KEYWORD:'" + _KEYWORD + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var list = JSON.parse(data.d);
            if (_TYPE == "NEREDEN") {

                $("#inpAirportOneri1").html('');

                if (list.data.length > 0) {
                    $("#divAirPortSearch1").addClass("open");

                }
                else {
                    $("#divAirPortSearch1").removeClass("open");
                }

                for (var i = 0; i < list.data.length; i++) {
                    var airportCode = list.data[i].AirportCode;
                    var countryCode = list.data[i].CountryCode;
                    var cityName = list.data[i].CityName;
                    var text = list.data[i].CityName + ' - ' + list.data[i].LocalizedCountryName;

                    if (airportCode.length > 3) {

                        $("#inpAirportOneri1").append("<li><a class=\"baslik\" id=\"anchor_" + airportCode + "\" onclick=\"selectNeredenEvent(this, '" + airportCode + countryCode + "', '" + countryCode + "', '" + cityName + "');\"> <i class=\"plane icon\"></i> <b>" + text + ' (' + list.data[i].AirportName + '-' + list.data[i].AirportCode + ')' + "</b></a></li>");
                    }
                    else
                        $("#inpAirportOneri1").append("<li><a id=\"anchor_" + airportCode + "\" onclick=\"selectNeredenEvent(this, '" + airportCode + countryCode + "', '" + countryCode + "', '" + cityName + "');\"> <i class=\"fa fa-angle-right\"></i> " + text + ' (' + list.data[i].AirportName + '-' + list.data[i].AirportCode + ')' + "</a></li>");


                }

                $('ul#inpAirportOneri1 li:first').addClass('selectedLi');
            }
            else {

                $("#inpAirportOneri2").html('');

                if (list.data.length > 0) {
                    $("#divAirPortSearch2").addClass("open");
                }
                else {
                    $("#divAirPortSearch2").removeClass("open");
                }

                for (var i = 0; i < list.data.length; i++) {
                    var airportCode = list.data[i].AirportCode;
                    var countryCode = list.data[i].CountryCode;
                    var cityName = list.data[i].CityName;
                    var text = list.data[i].CityName + ' - ' + list.data[i].LocalizedCountryName;

                    if (airportCode.length > 3) {

                        $("#inpAirportOneri2").append("<li ><a class=\"baslik\" id=\"anchor_" + airportCode + "\" onclick=\"selectNereyeEvent(this, '" + airportCode + countryCode + "', '" + countryCode + "', '" + cityName + "');\"> <i class=\"plane icon\"></i> <b>" + text + ' (' + list.data[i].AirportName + '-' + list.data[i].AirportCode + ')' + "</b></a></li>");
                    }
                    else
                        $("#inpAirportOneri2").append("<li ><a id=\"anchor_" + airportCode + "\" onclick=\"selectNereyeEvent(this, '" + airportCode + countryCode + "', '" + countryCode + "', '" + cityName + "');\"> <i class=\"fa fa-angle-right\"></i> " + text + ' (' + list.data[i].AirportName + '-' + list.data[i].AirportCode + ')' + "</a></li>");


                }


                $('ul#inpAirportOneri2 li:first').addClass('selectedLi2');
            }
        }
    });
}

//divAirPortSearch1 herhangi bir şegir seçimini yapan function
function selectNeredenEvent(anchor, airportCode, countryCode, cityName) {

    $('#inpNereden').val($(anchor).text().trimLeft());
    $('#inpNeredenAirportCode').val(airportCode);
    $('#inpNeredenCountryCode').val(countryCode);
    $('#inpNeredenCityName').val(cityName);
    $("#divAirPortSearch1").removeClass("open");
    //countryCodes.kalkisCountryCode = countryCode;

    //if (countryCodes.kalkisCountryCode == "TR" && countryCodes.varisCountryCode == "TR") {
    //    divYolcuForTR.style.display = "block";
    //} else {
    //    divYolcuForTR.style.display = "none";
    //}

}
//divAirPortSearch2 herhangi bir şegir seçimini yapan function
function selectNereyeEvent(anchor, airportCode, countryCode, cityName) {
    $('#inpNereye').val($(anchor).text().trimLeft());
    $('#inpNereyeAirportCode').val(airportCode);
    $('#inpNereyeCountryCode').val(countryCode);
    $('#inpNereyeCityName').val(cityName);
    $("#divAirPortSearch2").removeClass("open");
    //countryCodes.varisCountryCode = countryCode;
    //if (countryCodes.kalkisCountryCode == "TR" && countryCodes.varisCountryCode == "TR") {
    //    divYolcuForTR.style.display = "block";
    //} else {
    //    divYolcuForTR.style.display = "none";
    //}
}
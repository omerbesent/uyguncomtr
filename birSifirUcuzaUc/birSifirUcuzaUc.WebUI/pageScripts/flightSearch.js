
$(document).ready(function () {

    try {
        $('#inpNereden').val(checkCookie("inpNereden"));
        $('#inpNeredenAirportCode').val(checkCookie("inpNeredenAirportCode"));
        $('#inpNeredenCountryCode').val(checkCookie("inpNeredenCountryCode"));
        $('#inpNeredenCityName').val(checkCookie("inpNeredenCityName"));
        //$('#dpd1').val(checkCookie("dpd1"));

        $('#inpNereye').val(checkCookie("inpNereye"));
        $('#inpNereyeAirportCode').val(checkCookie("inpNereyeAirportCode"));
        $('#inpNereyeCountryCode').val(checkCookie("inpNereyeCountryCode"));
        $('#inpNereyeCityName').val(checkCookie("inpNereyeCityName"));
    } catch (e) {
        //
    }


    var x = getQueryStrings();
    var YetiskinCount = x["ysYetiskin"];
    //var OgrenciCount = x["ysOgrenci"];
    //var YasliCount = x["ysYasli"];
    var CocukCount = x["ysCocuk"];
    var BebekCount = x["ysBebek"];

    if (typeof YetiskinCount === 'undefined' || typeof CocukCount === 'undefined' || typeof BebekCount === 'undefined') {
        $("#slcYolcuYetiskin").text(1);
        $("#slcYolcuCocuk").text(0);
        $("#slcYolcuBebek").text(0);
        $("#totalPassenger").text(1);
    }
    else if ((YetiskinCount != "undefined") && (CocukCount != "undefined") && (BebekCount != "undefined")) {
        $("#slcYolcuYetiskin").text(YetiskinCount);
        $("#slcYolcuCocuk").text(CocukCount);
        $("#slcYolcuBebek").text(BebekCount);
        $("#totalPassenger").text(parseInt(YetiskinCount) + parseInt(CocukCount) + parseInt(BebekCount));

    }

    neredenNereyeKey();

    $('#inpNereden').on('input', function () {
        //&& neredenVana == true
        if (this.value.trim().length >= 3) {
            searchAirPort(this, "NEREDEN");
        }
        else if (this.value.trim().length == 0) {
            $("#divAirPortSearch1").removeClass("open");
            $("#inpAirportOneri1").html('');
        }
    });


    $('#inpNereye').on('input', function () {


        if (this.value.trim().length >= 3) {
            searchAirPort(this, "NEREYE");
            //$("#divAirPortSearch1").css("background", "#C0C0C0")

        } else if (this.value.trim().length == 0) {
            $("#divAirPortSearch2").removeClass("open");
            $("#inpAirportOneri2").html('');
        }
    });


    $("body").click(function (e) {
        //searchAirValidate();

        //açılan div haricinde biryer tıkladığımızda divAirPortSearch1 divAirPortSearch2 kapanacak..
        if (e.target.id != "divAirPortSearch1") {
            //neredenVana = false;
            $("#divAirPortSearch1").removeClass("open");
        }
        //açılan div haricinde biryer tıkladığımızda divAirPortSearch1 divAirPortSearch2 kapanacak..
        if (e.target.id != "divAirPortSearch2") {
            //nereyeVana = false;
            $("#divAirPortSearch2").removeClass("open");
        }

        //inputa girdiğimiz de içeriği seçilmiş olacak.. 
        if (e.target.id == "inpNereden") {
            neredenVana = true;
            //$("#inpNeredenAirportCode").val('');
            //$("#inpNereden").val('');
            //$("#inpNereden").select();
            //iphone da select komutu calismadigindan selectionStart ve SelectionEnd komutlarini kullandik..
            $("#inpNereden").get(0).selectionStart = 0;
            $("#inpNereden").get(0).selectionEnd = 999;
            //$("#inpNereden").css('color', '#00adef');
        }

        if (e.target.id == "inpNereye") {
            //nereyeVana = true;
            //$("#inpNereyeAirportCode").val('');
            //$("#inpNereye").val('');
            //$("#inpNereye").select();
            //iphone da select komutu calismadigindan selectionStart ve SelectionEnd komutlarini kullandik..
            $("#inpNereye").get(0).selectionStart = 0;
            $("#inpNereye").get(0).selectionEnd = 999;
            //$("#inpNereye").css('color', '#00adef');

        }

    });


    $("#yetiskinArttir").click(function () {
        //passenger-count studentCount slcYolcuOgrenci
        var x = parseInt($("#totalPassenger").text());
        if (x != 8) {
            var y = parseInt($("#slcYolcuYetiskin").text());
            if (y != 8) {
                y += 1
                x += 1;
                $("#slcYolcuYetiskin").text(y);
                isle();
            }
        }
        //show("deneme");
    });

    $("#yetiskinAzalt").click(function () {
        var x = parseInt($("#totalPassenger").text());
        if (x != 0) {
            var y = parseInt($("#slcYolcuYetiskin").text());
            if (y != 0) {
                y -= 1
                x -= 1;
                $("#slcYolcuYetiskin").text(y);
                isle();
            }
        }
        //show("deneme");
    });

    $("#cocukAzalt").click(function () {
        //passenger-count studentCount slcYolcuOgrenci
        var x = parseInt($("#totalPassenger").text());
        if (x != 0) {
            var y = parseInt($("#slcYolcuCocuk").text());
            if (y != 0) {
                y -= 1;
                x -= 1;
                $("#slcYolcuCocuk").text(y);
                isle();
            }
        }
        //show("deneme");
    });

    $("#cocukArttir").click(function () {
        var x = parseInt($("#totalPassenger").text());
        if (x != 8) {
            var y = parseInt($("#slcYolcuCocuk").text());
            if (y != 8) {
                y += 1;
                x += 1;
                $("#slcYolcuCocuk").text(y);
                isle();
            }
        }
        //show("deneme");
    });

    $("#bebekAzalt").click(function () {
        //passenger-count studentCount slcYolcuOgrenci
        var x = parseInt($("#totalPassenger").text());
        if (x != 0) {
            var y = parseInt($("#slcYolcuBebek").text());
            if (y != 0) {
                y -= 1
                x -= 1;
                $("#slcYolcuBebek").text(y);
                isle();
            }
        }
        //show("deneme");
    });

    $("#bebekArttir").click(function () {
        var x = parseInt($("#totalPassenger").text());
        if (x != 8) {
            var y = parseInt($("#slcYolcuBebek").text());
            if (y != 8) {
                y += 1
                x += 1;
                $("#slcYolcuBebek").text(y);
                isle();
            }
        }
        //show("deneme");
    });

    $("#return_date").fadeTo("slow", 1, function () { });
    $("#orUcusTipiTekYon").change(function () {
        if ($(this).is(":checked")) {
            $("#return_date").val(null);
            $("#orUcusTipiGidisDonus").prop("checked", false)
            $("#return_date").fadeTo("slow", 0.2, function () { });
            $("#return_span").fadeTo("slow", 0.2, function () { });

        } else {
            $("#orUcusTipiGidisDonus").prop("checked", true)
            $("#return_date").fadeTo("slow", 1, function () { });
            $("#return_span").fadeTo("slow", 1, function () { });
            //$("#return_date").prop("disabled", false);
        }
    });
    $('#oneway-label1').click(function () {
        //$("#orUcusTipiTekYon").prop("checked", true)
        //var chk = $("#orUcusTipiTekYon").prop().is(":checked");
        if (document.getElementById('orUcusTipiGidisDonus').checked) {
            $("#return_date").val(null);
            $("#orUcusTipiGidisDonus").prop("checked", false)
            $("#orUcusTipiTekYon").prop("checked", true)
            $("#return_date").fadeTo("slow", 0.2, function () { });
            $("#return_span").fadeTo("slow", 0.2, function () { });

        } else {
            $("#orUcusTipiGidisDonus").prop("checked", true)
            $("#orUcusTipiTekYon").prop("checked", false)
            $("#return_date").fadeTo("slow", 1, function () { });
            $("#return_span").fadeTo("slow", 1, function () { });
            //$("#return_date").prop("disabled", false);
        }
    });
    $('#oneway-label').click(function () {
        //$("#orUcusTipiTekYon").prop("checked", true)
        //var chk = $("#orUcusTipiTekYon").prop().is(":checked");
        if (document.getElementById('orUcusTipiGidisDonus').checked) {
            $("#return_date").val(null);
            $("#orUcusTipiGidisDonus").prop("checked", false)
            $("#orUcusTipiTekYon").prop("checked", true)
            $("#return_date").fadeTo("slow", 0.2, function () { });
            $("#return_span").fadeTo("slow", 0.2, function () { });

        } else {
            $("#orUcusTipiGidisDonus").prop("checked", true)
            $("#orUcusTipiTekYon").prop("checked", false)
            $("#return_date").fadeTo("slow", 1, function () { });
            $("#return_span").fadeTo("slow", 1, function () { });
            //$("#return_date").prop("disabled", false);
        }
    });
    $("#orUcusTipiGidisDonus").change(function () {
        if ($(this).is(":checked")) {

            $("#orUcusTipiTekYon").prop("checked", false)
            $("#return_date").fadeTo("slow", 1, function () { });
            $("#return_span").fadeTo("slow", 1, function () { });

        } else {
            $("#return_date").val(null);
            $("#orUcusTipiTekYon").prop("checked", true)
            $("#return_date").fadeTo("slow", 0.2, function () { });
            $("#return_span").fadeTo("slow", 0.2, function () { });
            //$("#return_date").prop("disabled", false);
        }
    });

    $('#return_date').change(function () {
        if (this.value.trim().length >= 1) {
            $("#orUcusTipiGidisDonus").prop("checked", true)
            $("#orUcusTipiTekYon").prop("checked", false)
            $("#return_date").fadeTo("slow", 1, function () { });
            $("#return_span").fadeTo("slow", 1, function () { });
        }
        else {
            $("#return_date").val(null);
            $("#orUcusTipiGidisDonus").prop("checked", false)
            $("#return_date").fadeTo("slow", 0.2, function () { });
            $("#return_span").fadeTo("slow", 0.2, function () { });
        }
    });

    $('#loading').hide();
});


function isle() {
    var totalPassenger = 0;
    var slcYolcuYetiskin = $("#slcYolcuYetiskin").text();
    var slcYolcuCocuk = $("#slcYolcuCocuk").text();
    var slcYolcuBebek = $("#slcYolcuBebek").text();
    totalPassenger = parseInt(slcYolcuYetiskin) + parseInt(slcYolcuCocuk) + parseInt(slcYolcuBebek);
    $("#totalPassenger").text(totalPassenger);
}

var hide2 = true;
function hide(id) { var divObject = document.getElementById(id); divObject.style.display = "none"; hide2 = true; }
function show(id) {
    var divObject = document.getElementById(id);

    if (divObject.style.display == "block") {
        hide('flightpassengerbox');
    }
    else {
        divObject.style.display = "block";
        hide2 = false;
    }
}

function neredenNereyeKey() {
    //Nereden---------BAŞLANGIÇ--------------------------
    $(window).keydown(function (e) {

        var neredenLen = $('#inpNereden').val();

        if (neredenLen.length <= 1) {
            $('#inpNeredenAirportCode').val('');
            $('#inpNeredenCountryCode ').val('');
            $('#inpNeredenCountryName').val('');
            $('#inpNeredenCityName').val('');
        }

        var nereyeLen = $('#inpNereye').val();

        if (nereyeLen.length <= 1) {
            $('#inpNereyeAirportCode').val('');
            $('#inpNereyeCountryCode ').val('');
            $('#inpNereyeCityName').val('');
        }

        //window.scrollTo(0, document.body.scrollHeight);
        //document.body.scrollTop = document.body.scrollHeight;
        var oneri1 = $('#divAirPortSearch1');
        if (oneri1.hasClass("open")) {

            var selected = $('.selectedLi');
            var index = selected.index();
            //key down arrow
            if (e.keyCode == 40) {
                //var index = selected.index();
                var count = $('#inpAirportOneri1 li').size();
                if (index == (count - 1)) {
                    return;
                }
                selected.removeClass('selectedLi').next().addClass('selectedLi');
                $('#inpNereden').val($('.selectedLi').text().trimLeft());
                //$("#inpAirportOneri1 li.selectedAirPort a").click();
            }
            if (e.keyCode == 38) {

                //var count = $('#ulLer').count();
                if (index == 0) {
                    return;
                }
                selected.removeClass('selectedLi').prev().addClass('selectedLi');
                $('#inpNereden').val($('.selectedLi').text().trimLeft());
                // $("#inpAirportOneri1 li.selectedAirPort a").click();

            }
        }
        //Nereden---------SON--------------------------

        //Nereye---------BAŞLANGIÇ--------------------------
        var oneri2 = $('#divAirPortSearch2');
        if (oneri2.hasClass("open")) {

            var selected = $('.selectedLi2');
            var index = selected.index();
            //key down arrow
            if (e.keyCode == 40) {
                //var index = selected.index();
                var count = $('#inpAirportOneri2 li').size();
                if (index == (count - 1)) {
                    return;
                }
                selected.removeClass('selectedLi2').next().addClass('selectedLi2');
                $('#inpNereye').val($('.selectedLi2').text().trimLeft());
                //$("#inpAirportOneri1 li.selectedAirPort a").click();
            }
            if (e.keyCode == 38) {

                //var count = $('#ulLer').count();
                if (index == 0) {
                    return;
                }
                selected.removeClass('selectedLi2').prev().addClass('selectedLi2');
                $('#inpNereye').val($('.selectedLi2').text().trimLeft());
                // $("#inpAirportOneri1 li.selectedAirPort a").click();

            }
        }
        //Nereye---------SON--------------------------

        if (e.keyCode == 9 || e.keyCode == 13) {

            if (oneri1.hasClass("open")) {
                $("#divAirPortSearch1").removeClass("open");
                //$('#inpNereye').focus();
                $("#inpAirportOneri1 li.selectedLi a").click();
            }
            if (oneri2.hasClass("open")) {
                $("#divAirPortSearch2").removeClass("open");
                //$('#dpd1').focus();
                $("#inpAirportOneri2 li.selectedLi2 a").click();
            }
        }
    });

}
function mouseEnter() {
    var seciliLi = $('.selectedLi');
    var seciliLi2 = $('.selectedLi2');

    var oneri1 = $('#divAirPortSearch1');
    var oneri2 = $('#divAirPortSearch2');

    if (oneri1.hasClass("open")) {
        seciliLi.removeClass('selectedLi').addClass('xxx');
    }

    if (oneri2.hasClass("open")) {
        seciliLi2.removeClass('selectedLi2').addClass('xxx');
    }

}
function mouseLeave() {
    var seciliLi = $('.xxx');
    var seciliLi2 = $('.xxx');

    var oneri1 = $('#divAirPortSearch1');
    var oneri2 = $('#divAirPortSearch2');

    if (oneri1.hasClass("open")) {
        seciliLi.removeClass('xxx').addClass('selectedLi');
    }
    if (oneri2.hasClass("open")) {
        seciliLi2.removeClass('xxx').addClass('selectedLi2');
    }

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
                //var a = [];
                //var b = [];
                //for (var j = 0; j < list.data.length ; j++) {

                //    a.push(list.data[j].LocalizedCountryName);
                //}
                //var uniqli = $.unique(a);

                if (list.data.length > 0) {
                    $("#divAirPortSearch1").addClass("open");

                }
                else {
                    $("#divAirPortSearch1").removeClass("open");
                }

                //var ilkKez = true;
                //for (var k = 0; k < uniqli.length; k++) {
                //    var adi = uniqli[k];
                //    b.push(adi);

                for (var i = 0; i < list.data.length; i++) {
                    //var datas = list[i].split('|');
                    var airportCode = list.data[i].AirportCode;
                    var countryCode = list.data[i].CountryCode;
                    var cityName = list.data[i].CityName;
                    var text = list.data[i].CityName + ' - ' + list.data[i].LocalizedCountryName;

                    if (airportCode.length > 3) {
                        //$("#inpAirportOneri1").append("<li id=\"left\"><a class=\"baslik\" id=\"anchor_" + airportCode + "\" onclick=\"selectNeredenEvent(this, '" + airportCode + "C" + countryCode + "', '" + cityName + "');\"> <i class=\"plane icon\"></i> <b>" + text + "</b></a></li>");
                        $("#inpAirportOneri1").append("<li id=\"left\"><a class=\"baslik\" id=\"anchor_" + airportCode + "\" onclick=\"selectNeredenEvent(this, '" + airportCode + countryCode + "', '" + countryCode + "', '" + cityName + "');\"> <i class=\"plane icon\"></i> <b>" + text + ' (' + list.data[i].AirportName + '-' + list.data[i].AirportCode + ')' + "</b></a></li>");
                    }
                    else
                        $("#inpAirportOneri1").append("<li id=\"right\"><a id=\"anchor_" + airportCode + "\" onclick=\"selectNeredenEvent(this, '" + airportCode + countryCode + "', '" + countryCode + "', '" + cityName + "');\"> <i class=\"fa fa-angle-right\"></i> " + text + ' (' + list.data[i].AirportName + '-' + list.data[i].AirportCode + ')' + "</a></li>");

                    //if (list.data[i].LocalizedCountryName == adi) {
                    //    if (ilkKez == true) {
                    //        ilkKez = false;
                    //        $("#inpAirportOneri1").append("<li id=\"left\"><a class=\"baslik\" id=\"anchor_" + airportCode + "\" onclick=\"selectNeredenEvent(this, '" + airportCode + "C" + countryCode + "', '" + cityName + "');\"> <i class=\"plane icon\"></i> <b>" + text + " (Tümü)" + "</b></a></li>");
                    //    }

                    //    $("#inpAirportOneri1").append("<li id=\"right\"><a id=\"anchor_" + airportCode + "\" onclick=\"selectNeredenEvent(this, '" + airportCode + countryCode + "', '" + countryCode + "', '" + cityName + "');\"> <i class=\"fa fa-angle-right\"></i> " + text + ' (' + list.data[i].AirportName + '-' + list.data[i].AirportCode + ')' + "</a></li>");


                    //}
                }
                //ilkKez = true;
                //}
                $('ul#inpAirportOneri1 li:first').addClass('selectedLi');
            }
            else {

                $("#inpAirportOneri2").html('');
                //var a = [];
                //var b = [];
                //for (var j = 0; j < list.data.length ; j++) {

                //    a.push(list.data[j].LocalizedCountryName);
                //}
                //var uniqli = $.unique(a);

                if (list.data.length > 0) {
                    $("#divAirPortSearch2").addClass("open");
                }
                else {
                    $("#divAirPortSearch2").removeClass("open");
                }

                for (var i = 0; i < list.data.length; i++) {
                    //var datas = list[i].split('|');
                    var airportCode = list.data[i].AirportCode;
                    var countryCode = list.data[i].CountryCode;
                    var cityName = list.data[i].CityName;
                    var text = list.data[i].CityName + ' - ' + list.data[i].LocalizedCountryName;

                    if (airportCode.length > 3) {
                        //$("#inpAirportOneri1").append("<li id=\"left\"><a class=\"baslik\" id=\"anchor_" + airportCode + "\" onclick=\"selectNeredenEvent(this, '" + airportCode + "C" + countryCode + "', '" + cityName + "');\"> <i class=\"plane icon\"></i> <b>" + text + "</b></a></li>");
                        $("#inpAirportOneri2").append("<li id=\"left\"><a class=\"baslik\" id=\"anchor_" + airportCode + "\" onclick=\"selectNereyeEvent(this, '" + airportCode + countryCode + "', '" + countryCode + "', '" + cityName + "');\"> <i class=\"plane icon\"></i> <b>" + text + ' (' + list.data[i].AirportName + '-' + list.data[i].AirportCode + ')' + "</b></a></li>");
                    }
                    else
                        $("#inpAirportOneri2").append("<li id=\"right\"><a id=\"anchor_" + airportCode + "\" onclick=\"selectNereyeEvent(this, '" + airportCode + countryCode + "', '" + countryCode + "', '" + cityName + "');\"> <i class=\"fa fa-angle-right\"></i> " + text + ' (' + list.data[i].AirportName + '-' + list.data[i].AirportCode + ')' + "</a></li>");

                    //if (list.data[i].LocalizedCountryName == adi) {
                    //    if (ilkKez == true) {
                    //        ilkKez = false;
                    //        $("#inpAirportOneri1").append("<li id=\"left\"><a class=\"baslik\" id=\"anchor_" + airportCode + "\" onclick=\"selectNeredenEvent(this, '" + airportCode + "C" + countryCode + "', '" + cityName + "');\"> <i class=\"plane icon\"></i> <b>" + text + " (Tümü)" + "</b></a></li>");
                    //    }

                    //    $("#inpAirportOneri1").append("<li id=\"right\"><a id=\"anchor_" + airportCode + "\" onclick=\"selectNeredenEvent(this, '" + airportCode + countryCode + "', '" + countryCode + "', '" + cityName + "');\"> <i class=\"fa fa-angle-right\"></i> " + text + ' (' + list.data[i].AirportName + '-' + list.data[i].AirportCode + ')' + "</a></li>");


                    //}
                }

                //var ilkKez = true;
                //for (var k = 0; k < uniqli.length; k++) {
                //    var adi = uniqli[k];
                //    b.push(adi);

                //    for (var i = 0; i < list.data.length; i++) {
                //        //var datas = list[i].split('|');
                //        var airportCode = list.data[i].AirportCode;
                //        var countryCode = list.data[i].CountryCode;
                //        var cityName = list.data[i].CityName;
                //        var text = list.data[i].CityName + ' - ' + list.data[i].LocalizedCountryName;
                //        if (list.data[i].LocalizedCountryName == adi) {
                //            if (ilkKez == true) {
                //                ilkKez = false;
                //                $("#inpAirportOneri2").append("<li id=\"left\"><a class=\"baslik\" id=\"anchor_" + airportCode + "\" onclick=\"selectNereyeEvent(this, '" + airportCode + "C" + countryCode + "', '" + cityName + "');\"> <i class=\"plane icon\"></i> <b>" + text + " (Tümü)" + "</b></a></li>");
                //            }

                //            $("#inpAirportOneri2").append("<li id=\"right\"><a id=\"anchor_" + airportCode + "\" onclick=\"selectNereyeEvent(this, '" + airportCode + countryCode + "', '" + countryCode + "', '" + cityName + "');\"> <i class=\"fa fa-angle-right\"></i> " + text + ' (' + list.data[i].AirportName + '-' + list.data[i].AirportCode + ')' + "</a></li>");


                //        }
                //    }
                //    ilkKez = true;

                //}
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
    //countryCodes.varisCountryCode = countryCode;
    //if (countryCodes.kalkisCountryCode == "TR" && countryCodes.varisCountryCode == "TR") {
    //    divYolcuForTR.style.display = "block";
    //} else {
    //    divYolcuForTR.style.display = "none";
    //}
}

function searchAir() {
    
    var validate = searchAirValidate();

    //alert(validate);
    //        if (Request.QueryString["ysYetiskin"] != null &&
    //Request.QueryString["ysCocuk"] != null &&
    //Request.QueryString["ysBebek"] != null &&
    //Request.QueryString["gdOriginCode"] != null &&
    //Request.QueryString["gdDestinationCode"] != null &&
    //Request.QueryString["gTarih"] != null &&
    //Request.QueryString["dTarih"] != null &&
    //Request.QueryString["ucusTipi"] != null)
    if (validate) {

        progressOnOff(true);

        var _yolcuSayisiYetiskin = $("#slcYolcuYetiskin").text();
        var _yolcuSayisiCocuk = $("#slcYolcuCocuk").text();
        var _yolcuSayisiBebek = $("#slcYolcuBebek").text();
        var _gidisOriginCode = $('#inpNeredenAirportCode').val();
        var _gidisDestinationCode = $('#inpNereyeAirportCode').val();
        var _gidisOriginCountryCode = $('#inpNeredenCountryCode').val();
        var _gidisOriginIsCity = "1";
        var _gidisOriginName = $('#inpNeredenCityName').val(); //optional
        var _gidisDestinationCountryCode = $('#inpNereyeCountryCode').val();
        var _gidisDestinationName = $('#inpNereyeCityName').val(); //optional

        var dateGidisTarihi = $("#departure_date").val();
        if (dateGidisTarihi.match(/[a-zA-Z\s]/g)) {
            return false;
        }
        else {
            if (dateGidisTarihi.length > 0) {
                $("#departure_date").css("color", "#000");
            }
            else {
                $("#departure_date").css("color", "#d14300");
                $("#departure_date").val("Bu alan boş geçilemez!");
                return false;
            }
        }
        var _gidisTarih = dateGidisTarihi; //after
        var _donusTarih = $("#return_date").val();
        var _ucusYonu = 'RT';
        if (_donusTarih == "" || _donusTarih == null) {
            //alert("tek yön");
            _ucusYonu = "OW";
        }

        var e = document.getElementById("flight-class-select");
        var _ucusTipi = e.options[e.selectedIndex].value;



        setCookie("inpNeredenAirportCode", _gidisOriginCode, 15);
        setCookie("inpNeredenCountryCode", _gidisOriginCountryCode, 15);
        setCookie("inpNeredenCityName", _gidisOriginName, 15);
        setCookie("inpNereden", $('#inpNereden').val(), 15);

        setCookie("inpNereyeAirportCode", _gidisDestinationCode, 15);
        setCookie("inpNereyeCountryCode", _gidisDestinationCountryCode, 15);
        setCookie("inpNereyeCityName", _gidisDestinationName, 15);
        setCookie("inpNereye", $('#inpNereye').val(), 15);
        $('#loading').show();
        var requestPath = '/Ucus/Seferler.aspx?gdOriginCode=' + _gidisOriginCode
            + '&gdDestinationCode=' + _gidisDestinationCode
            + '&gTarih=' + _gidisTarih
            + '&dTarih=' + _donusTarih
            + '&ysYetiskin=' + _yolcuSayisiYetiskin
            + '&ysCocuk=' + _yolcuSayisiCocuk
            + '&ysBebek=' + _yolcuSayisiBebek
            + '&ucucTipi=' + _ucusTipi;
        //+ '&direction=' + _ucusYonu;
        //if (window.location.href.indexOf("flightSearch.aspx") > 0)
        window.location = requestPath;
        //else
        //window.location.search = "?gdOriginCode=ISTCTR&gdDestinationCode=AYTCTR&gTarih=30/03/2018&dTarih=&ysYetiskin=2&ysCocuk=0&ysBebek=0";

    }


}
function tipSec(secilen) {


    $("#flight-class-select option[value='" + secilen.value + "']").attr("selected", true).siblings()
  .removeAttr("selected");

}

function getQueryStrings() {
    var assoc = {};
    var decode = function (s) { return decodeURIComponent(s.replace(/\+/g, " ")); };
    var queryString = location.search.substring(1);
    var keyValues = queryString.split('&');

    for (var i in keyValues) {
        var key = keyValues[i].split('=');
        if (key.length > 1) {
            assoc[decode(key[0])] = decode(key[1]);
        }
    }

    return assoc;
}

function searchAirValidate() {

    if (!validateInput("inpNeredenAirportCode", "inpNereden") ||
        !validateInput("inpNereyeAirportCode", "inpNereye")) {
        return false;
    }
    var _yolcuSayisiYetiskin = parseInt($("#slcYolcuYetiskin").text());
    //var _yolcuSayisiOgrenci = parseInt($("#slcYolcuOgrenci").text());
    //var _yolcuSayisiYasli = parseInt($("#slcYolcuYasli").text());
    var _yolcuSayisiCocuk = parseInt($("#slcYolcuCocuk").text());
    var _yolcuSayisiBebek = parseInt($("#slcYolcuBebek").text());
    //var _yolcuSayisiAsker = parseInt($("#slcYolcuAsker").text());
    var yolcuSayisi = (_yolcuSayisiYetiskin +
        _yolcuSayisiCocuk +
        _yolcuSayisiBebek);
    if (!(yolcuSayisi > 0)) {
        $("#pUyari").text("Lütfen yolcu seçiniz!");
        return false;
    }
    else if (yolcuSayisi > 7) {
        $("#pUyari").text("Bir seferde en fazla 7 yolcu seçebilirsiniz!");
        return false;
    }

    $("#pUyari").text("");
    return true;
}

function validateInput(validateInputName, errorInputName) {
    if ($("#" + validateInputName).val().length > 0) {
        $("#" + errorInputName).removeClass("errorInput");
        $("#" + errorInputName).css("color", "#000");
        //$("#" + errorInputName).style.fontWeight = "900";
        return true;
    } else {
        $("#" + errorInputName).css("color", "rgb(199, 0, 0)");
        if (errorInputName == "inpNereden") {
            $("#" + errorInputName).val("Hareket noktası giriniz!");
        } else if (errorInputName == "inpNereye") {
            $("#" + errorInputName).val("Varış noktası giriniz!");
        }
        return false;
    }
}

function progressOnOff(onOff) {
    if (onOff) {
        //document.getElementById("divLoading").style.visibility = "visible";
        $("#spnSatinAl").text("İşleminiz yapılıyor.Lütfen Bekleyin.");
        $("#ContentPlaceHolder1_btnSatinAl").prop("disabled", true);
        $("#btnPreLoad").css("visibility", "visible");
        //$("body").css("overflow", 'hidden');
        //$("#divContainer").css("opacity", '0.4');
    }
    else {
        //document.getElementById("divLoading").style.visibility = "hidden";
        $("#spnSatinAl").text("SATIN AL.");
        $("#btnPreLoad").css("visibility", "hidden");
        $("body").css("overflow", 'visible');
        $("#divContainer").css("opacity", '1');

    }
}

function MakaleFunction(id) {
    alert(id + " gelen");
}

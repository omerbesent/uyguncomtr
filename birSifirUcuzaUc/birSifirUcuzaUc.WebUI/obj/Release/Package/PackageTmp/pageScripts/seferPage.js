
//var gFlightID = null;
//var dFlightID = null;
//var a = moment('2000-01-01T00:00');
var _variables = {
    //gProductID: 0,
    //dProductID: 0,
    gFlightID: null,
    dFlightID: null,
    seciliVaris: moment('2000-01-01T00:00')
}

$(document).ready(function () {

    var h4 = document.createElement("h4");
    h4.textContent = $('#ucusListesi > div').length + " adet uçuş listelenmiştir.";
    $('#ucusSayisi').append(h4);




    $(".clickMeLi li").click(function (event) {

        var cekList = false; //Checkbox'ların hiç biri seçili değilse.. false ise..
        $(".clickMeLi >" + " li").each(function (index) {
            var input = $("#airLinelist li")[index].firstChild.checked;
            if (input == true) {
                cekList = true;
                return false;
            }
        });
        if (cekList == false) {//Checkbox ların hepsi false ise..!

            if (_variables.gFlightID != null) {

                $("#" + "donusUcusListesi >" + " div").each(function (index) {
                    var kalkisSaat = moment($(this).data("datetime"));
                    var flyCode = $(this).data("airlinecode");
                    if (_variables.gFlightID != null) {
                        var sonuc = (kalkisSaat.diff(seciliVaris, 'hours'));
                        if (sonuc < 1) {
                            $(this).hide();
                        }
                        else
                            $(this).css("display", "block");
                    }
                    else
                        $(this).css("display", "block");


                });
            }

            if (_variables.dFlightID != null) {

                $("#" + "ucusListesi >" + " div").each(function (index) {
                    var kalkisSaat = moment($(this).data("datetime"));
                    var flyCode = $(this).data("airlinecode");
                    if (_variables.dFlightID != null) {
                        var sonuc = (kalkisSaat.diff(seciliVaris, 'hours'));
                        if (sonuc < 1) {
                            $(this).hide();
                        }
                        else
                            $(this).css("display", "block");
                    }
                    else
                        $(this).css("display", "block");


                });
            }

            if (_variables.gFlightID == null && _variables.dFlightID == null) {
                $("#" + "ucusListesi >" + " div").show();
                $("#" + "donusUcusListesi >" + " div").show();
            }


        }
        else {//hepsi ya da herhangi biri true ise

            $(".clickMeLi >" + " li").each(function (index) {
                var input = $("#airLinelist li")[index].firstChild.checked;
                var inputId = $(this).attr("id");


                if (_variables.dFlightID != null) {
                    $("#" + "ucusListesi >" + " div").each(function (index) {

                        var kalkisSaat = moment($(this).data("datetime"));
                        var flyCode = $(this).data("airlinecode");
                        if (flyCode == inputId) { //&& input == true

                            var sonuc = (kalkisSaat.diff(seciliVaris, 'hours'));
                            if (sonuc < 1) {
                                $(this).hide();
                            }
                            else {
                                if (input == true)
                                    $(this).show();
                                else
                                    $(this).hide();
                            }
                        }
                    });
                }
                else
                    $(this).show();


                if (_variables.gFlightID != null) {
                    $("#" + "donusUcusListesi >" + " div").each(function (index) {

                        var kalkisSaat = moment($(this).data("datetime"));
                        var flyCode = $(this).data("airlinecode");
                        if (flyCode == inputId) { //&& input == true

                            var sonuc = (kalkisSaat.diff(seciliVaris, 'hours'));
                            if (sonuc < 1) {
                                $(this).hide();
                            }
                            else {
                                if (input == true)
                                    $(this).show();
                                else
                                    $(this).hide();
                            }
                        }
                    });
                }
                else
                    $(this).show();


                //seçimler null ve herhangi bir checkbox seçili ise..
                if (_variables.gFlightID == null && _variables.dFlightID == null) {

                    $("#" + "ucusListesi >" + " div").each(function (index) {

                        var kalkisSaat = moment($(this).data("datetime"));
                        var flyCode = $(this).data("airlinecode");
                        if (flyCode == inputId) { //&& input == true

                            if (input == true)
                                $(this).show();
                            else
                                $(this).hide();

                        }
                    });
                    $("#" + "donusUcusListesi >" + " div").each(function (index) {

                        var kalkisSaat = moment($(this).data("datetime"));
                        var flyCode = $(this).data("airlinecode");
                        if (flyCode == inputId) { //&& input == true

                            if (input == true)
                                $(this).show();
                            else
                                $(this).hide();
                        }
                    });
                }

            });


        }

    });





    $(".sefer-degistir-gidis").click(function () {
        $("#" + "ucusListesi >" + " div").css("display", "block");
        $(".sefer-degistir-gidis").css("display", "none");

        _variables.gFlightID = null;
        $("#" + "donusUcusListesi >" + " div").css("display", "block");
        window.location.href = '#ucusListesiTumu';
    });
    $(".sefer-degistir-donus").click(function () {
        $("#" + "donusUcusListesi >" + " div").css("display", "block");
        $(".sefer-degistir-donus").css("display", "none");

        _variables.dFlightID = null;
        $("#" + "ucusListesi >" + " div").css("display", "block");
        window.location.href = '#donusUcusListesi';
    });

    $('#FiyatFiltre').on('change', function () {
        var value = $(this).val();
        if ('Azalan Fiyat' == value) {
            var divList = $('#ucusListesi .flight-list-v2');

            divList.sort(function (b, a) { return parseFloat($(a).data("price")) - parseFloat($(b).data("price")) });
            $("#ucusListesi").html(divList);

            var divList = $('#donusUcusListesi .flight-list-v2');

            divList.sort(function (b, a) { return parseFloat($(a).data("price")) - parseFloat($(b).data("price")) });
            $("#donusUcusListesi").html(divList);
        }
        else if ('Artan Fiyat' == value) {
            var divList = $('#ucusListesi .flight-list-v2');

            divList.sort(function (a, b) { return parseFloat($(a).data("price")) - parseFloat($(b).data("price")) });
            $("#ucusListesi").html(divList);

            var divList = $('#donusUcusListesi .flight-list-v2');

            divList.sort(function (a, b) { return parseFloat($(a).data("price")) - parseFloat($(b).data("price")) });
            $("#donusUcusListesi").html(divList);
        }
    });

    $('#HavaYolunaGore').on('change', function () {
        var value = $(this).val();
     
        if ('Z den A ya' == value) {
            var divList = $('#ucusListesi .flight-list-v2');
            var alphabeticallyOrderedDivs = divList.sort(function (a, b) {
                return $(a).data('airlinename').substring(0, 1) < $(b).data('airlinename').substring(0, 1);
            });
            //divList.sort(function (b, a) { return $(a).data("airlinename") < $(b).data("airlinename") });
            $("#ucusListesi").html(alphabeticallyOrderedDivs);

            var divList = $('#donusUcusListesi .flight-list-v2');

            divList.sort(function (b, a) { return $(a).data("airlinename") < $(b).data("airlinename") });
            $("#donusUcusListesi").html(divList);
        }
        else if ('A dan Z ye' == value) {
            var divList = $('#ucusListesi .flight-list-v2');
            var alphabeticallyOrderedDivs = divList.sort(function (a, b) {
                return $(a).data('airlinename').substring(0, 1) > $(b).data('airlinename').substring(0, 1);
            });
            //divList.sort(function (a, b) { return $(a).data("airlinename") > $(b).data("airlinename") });
            $("#ucusListesi").html(alphabeticallyOrderedDivs);

            var divList = $('#donusUcusListesi .flight-list-v2');

            divList.sort(function (a, b) { return $(a).data("airlinename") > $(b).data("airlinename") });
            $("#donusUcusListesi").html(divList);
        }
    });
    //$("#artan").click(function () {
    //    var divList = $('#ucusListesi .flight-list-v2');

    //    divList.sort(function (a, b) { return parseFloat($(a).data("price")) - parseFloat($(b).data("price")) });
    //    $("#ucusListesi").html(divList);
    //});
    //$("#azalan").click(function () {
    //    var divList = $('#ucusListesi .flight-list-v2');

    //    divList.sort(function (b, a) { return parseFloat($(a).data("price")) - parseFloat($(b).data("price")) });
    //    $("#ucusListesi").html(divList);
    //});

});


//Hava yolu firma adına göre arama
function airNameChange(txt) {
    if (txt.value.length > 0) {

        $("#" + "ucusListesi >" + " div").hide();

        $("#" + "ucusListesi >" + " div").each(function (index) {
            var flyName = $(this).data("airlinename");
            if (flyName.toLowerCase().indexOf(txt.value.toLowerCase()) > -1) {
                $(this).show();
            }
        });
    }
    else if (txt.value.length <= 0) {
        $("#" + "ucusListesi >" + " div").show();
    }
}

function AktShowHide(id) {

    if (id == 'ALL') {
        $("#" + "ucusListesi >" + " div").show();
    }

    var topAkt = $("#" + "ucusListesi >" + " div").filter(function () {
        return $(this).data('aktsayisi') === id
    }).length;
    if (topAkt <= 0) {
        return false;
    }
    $("#" + "ucusListesi >" + " div").hide();
    //$("#" + "ucusListesi >" + " div").data("aktsayisi").indexOf(id).hide();
    $("#" + "ucusListesi >" + " div").filter(function () {
        return $(this).data('aktsayisi') === id
    }).show();

}

//stop-box ile aktarma açıp kapama..
function aktGoster(id) {
    var d = id.parentElement.parentElement.className.replace(' ', '.');
    var displayDurum = $("." + d + "Akt").css('display');
    if (displayDurum == "none") {
        $("." + d + "Akt").css("display", "block");

    }
    else {
        $("." + d + "Akt").css("display", "none");
    }
}


function detaylandir2(gID, gID2, direction, ucusYon) {
    _variables.gFlightID = gID;
    _variables.dFlightID = gID2;
    satisaGit(direction);
}
function detaylandir(gID, direction, ucusYon) {


    if (direction == "OW") {
        _variables.gFlightID = gID;
        satisaGit(direction);
        //$("#" + "ucusListesi >" + " div").each(function (index) {
        //    var productid = $(this).data("guidid");
        //    if (productid != gID) {
        //        $(this).hide();
        //    } else {
        //        $(this).show(); 
        //    }
        //});
    }

    if (direction == "RT") {
        if (ucusYon == "GIDIS") {
            _variables.gFlightID = gID;
            $("#" + "ucusListesi >" + " div").each(function (index) {

                var productid = $(this).data("guidid");
                if (productid != gID) {
                    $(this).hide();
                } else {
                    seciliVaris = moment($(this).data("arrivaldatetime"));
                    $(this).show();
                }
            });
            if (_variables.dFlightID == null) {
                $("#" + "donusUcusListesi >" + " div").each(function (index) {

                    var donusKalkis = moment($(this).data("datetime"));
                    var sonuc = (donusKalkis.diff(seciliVaris, 'hours'))
                    if (sonuc < 1) {
                        $(this).hide();
                    } else {
                        $(this).show();
                    }
                });
            }
            $(".sefer-degistir-gidis").css("display", "block");
            window.location.href = '#ucusListesiTumu';
        }

        if (ucusYon == "DONUS") {
            _variables.dFlightID = gID;
            $("#" + "donusUcusListesi >" + " div").each(function (index) {

                var productid = $(this).data("guidid");
                if (productid != gID) {
                    $(this).hide();
                } else {
                    $(this).show();
                    seciliVaris = moment($(this).data("arrivaldatetime"));
                }
            });
            if (_variables.gFlightID == null) {
                $("#" + "ucusListesi >" + " div").each(function (index) {

                    var gidisKalkis = moment($(this).data("datetime"));
                    var sonuc = (gidisKalkis.diff(seciliVaris, 'hours'))
                    if (sonuc < 1) {
                        $(this).hide();
                    } else {
                        $(this).show();
                    }
                });
            }

            $(".sefer-degistir-donus").css("display", "block");
            window.location.href = '#ucusListesiTumu';
        }
        if (_variables.dFlightID != null && _variables.gFlightID != null) {
            satisaGit(direction);
        }

    }
}



function satisaGit(ucusTipi) {
    var _disHat = $("#inpDisHat").val();

    //var _gProductID = _variables.gProductID;
    //var _dProductID = _variables.dProductID;
    var _gFlightID = _variables.gFlightID;
    var _dFlightID = _variables.dFlightID;


    if (ucusTipi == "RT") {
        window.location = "/Ucus/Satis.aspx?ucusTipi=RT" + "&disHat=" + _disHat + "&gFlightID=" + _gFlightID + "&dFlightID=" + _dFlightID;
    } else if (ucusTipi == "OW") {
        window.location = "/Ucus/Satis.aspx?ucusTipi=OW" + "&disHat=" + _disHat + "&gFlightID=" + _gFlightID;
    }
}




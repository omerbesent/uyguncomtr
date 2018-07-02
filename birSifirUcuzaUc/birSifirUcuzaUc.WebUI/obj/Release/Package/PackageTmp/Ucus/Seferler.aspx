<%@ Page Title="" Language="C#" MasterPageFile="~/anaYapi.Master" AutoEventWireup="true" ClientIDMode="Static" CodeBehind="Seferler.aspx.cs" Inherits="birSifirUcuzaUc.WebUI.Ucus.Seferler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta content="text/html;charset=utf-8" http-equiv="content-type" />
    <meta content="utf-8" http-equiv="encoding" />

    <%--<script src="../pageScripts/SefelerAir.js"></script>--%>
    <%--<script src="/assets/js/jquery-ui.min.js"></script>--%>
    <script src="../assets/js/moment.js"></script>
    <script src="../pageScripts/searchCookie.js"></script>
    <script src="../pageScripts/flightSearch.js"></script>
    <script src="../pageScripts/seferPage.js"></script>
    <link href="../assets/css/seferCss.css" rel="stylesheet" />
    <link href="../assets/css/prepareCss.css" rel="stylesheet" />
    <%--<script src="/assets/js/datepicker-tr.js"></script>--%>
    <%--<script src="/assets/js/js.js"></script>--%>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <input type="hidden" id="inpDisHat" value="" clientidmode="Static" runat="server" />
    <!-- START: MODIFY SEARCH -->
    <div class="row modify-search modify-flight">
        <div class="container clear-padding">
            <form>
                <div class="col-md-10">
                    <div class="checkboxFive">
                        <input style="/* display: block; */" type="checkbox" name="name" id="orUcusTipiGidisDonus" class="isOneWaySelector" checked="" value="option1">
                        <span class="checkmark"></span>

                        <label id="gidisdonus" for="orUcusTipiGidisDonus">
                            <p id="gitgel">Gidiş - Dönüş </p>
                        </label>

                    </div>


                    <div class="checkboxFive">
                        <input style="display: block" type="checkbox" name="name" id="orUcusTipiTekYon" class="isOneWaySelector" value="option1">
                        <span class="checkmark"></span>

                        <label id="tekyon1" for="orUcusTipiTekYon">
                            <p id="tekyon">Tek Yön</p>
                        </label>

                    </div>
                    <div class="clear"></div>
                </div>
                <div class="col-md-12">
                </div>
                <div class="trnsprnt">

                    <div class="col-md-2 col-sm-6">
                        <div class="form-gp">
                            <%--<label>Leaving From</label>--%>
                            <div id="divAirPortSearch1" class="input-group margin-bottom-sm">
                                <input type="text" runat="server" id="inpNereden" autocomplete="off" clientidmode="Static" name="dep-city" class="form-control" required placeholder="Kalkış Yeri.." />
                                <input type="hidden" runat="server" id="inpNeredenAirportCode" clientidmode="Static" value="" />
                                <input type="hidden" runat="server" id="inpNeredenCountryCode" clientidmode="Static" value="" />
                                <input type="hidden" runat="server" id="inpNeredenCountryName" clientidmode="Static" value="" />
                                <input type="hidden" runat="server" id="inpNeredenCityName" clientidmode="Static" value="" />
                                <ul id="inpAirportOneri1" onmouseenter="mouseEnter(this)" onmouseleave="mouseLeave(this)" class="dropdown-menu" style="margin-left: 15px;"></ul>
                                <span class="input-group-addon"><i class="fa fa-map-marker fa-fw"></i></span>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-2 col-sm-6">
                        <div class="form-gp">
                            <%--<label>Leaving To</label>--%>
                            <div id="divAirPortSearch2" class="input-group margin-bottom-sm">
                                <input type="text" runat="server" id="inpNereye" autocomplete="off" clientidmode="Static" name="des-city" class="form-control" required placeholder="Gidiş Yeri.." />
                                <input type="hidden" runat="server" id="inpNereyeAirportCode" clientidmode="Static" value="" />
                                <input type="hidden" runat="server" id="inpNereyeCountryCode" clientidmode="Static" value="" />
                                <input type="hidden" runat="server" id="inpNereyeCityName" clientidmode="Static" value="" />
                                <ul id="inpAirportOneri2" onmouseenter="mouseEnter(this)" onmouseleave="mouseLeave(this)" class="dropdown-menu" style="margin-left: 15px;"></ul>
                                <span class="input-group-addon"><i class="fa fa-map-marker fa-fw"></i></span>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-2 col-sm-6 col-xs-6">
                        <div class="form-gp">
                            <%--<label>Departure</label>--%>
                            <div class="input-group margin-bottom-sm">
                                <input type="text" runat="server" clientidmode="Static" id="departure_date" name="departure_date" data-format="dd.MM.yyyy" class="form-control" placeholder="Gidiş Tarihi" required />
                                <span class="input-group-addon"><i class="fa fa-calendar fa-fw"></i></span>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-2 col-sm-6 col-xs-6">
                        <div class="form-gp">

                            <div class="input-group margin-bottom-sm">
                                <input type="text" runat="server" clientidmode="Static" id="return_date" name="return_date" data-format="dd.MM.yyyy" class="form-control" placeholder="Dönüş Tarihi" />
                                <span class="input-group-addon" id="return_span"><i class="fa fa-calendar fa-fw"></i></span>
                            </div>
                        </div>
                    </div>


                    <div class="col-md-2 col-sm-6 col-xs-6">
                        <div class="form-gp">
                            <%--<label>Yolcu</label>--%>
                            <%-- <select class="selectpicker">
                            <option>1</option>
                            <option>2</option>
                            <option>3</option>
                            <option>4</option>
                            <option>5</option>
                            <option>6</option>
                        </select>--%>
                            <%--YOLCU SAYISI BELİRLEME--%>
                            <div class="selectpicker">
                                <div class="guest-select">

                                    <%--<label>Yolcu </label>--%>
                                    <div class="popover-icon" data-container="body" data-toggle="popover" data-trigger="hover" data-placement="right" data-content="0 till 18 years" data-original-title="" title=""><%--<i class="fa fa-info-circle fa-lg"></i>--%></div>

                                    <%--   <button type="button" class="btn eu-flight-passenger-btn form-control" id="select-passenger-btn" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" onclick="show('flightpassengerbox');">
                                    <span class="totalPassenger" id="totalPassenger">1</span> Yolcu <i class="fa fa-caret-down"></i>
                                </button>--%>
                                    <div class="input-group margin-bottom-sm">
                                        <button type="button" class="eu-flight-passenger-btn form-control" id="select-passenger-btn" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" onclick="show('flightpassengerbox');">
                                            <span class="totalPassenger" id="totalPassenger">1</span> Yolcu</button>
                                        <span class="input-group-addon"><i class="fa fa-users fa-fw"></i></span>
                                    </div>

                                    <div role="menu" aria-labelledby="select-passenger-btn" class="dropdown-menu select-passenger sefer" id="flightpassengerbox">
                                        <div class="passenger-type adult passenger-box-left">
                                            <div class="age-info">Yetişkin</div>
                                            <i class="form-adult-icon eu-icon-adult-gray"></i>
                                            <div class="passenger-inc-dec">
                                                <button id="yetiskinAzalt" type="button" class="btn btn-inc-dec pull-left minus" data-passenger="adult">
                                                    <i class="fa fa-minus"></i>
                                                </button>
                                                <%--<span class="passenger-count adultCount">1</span>--%>
                                                <span id="slcYolcuYetiskin" class="passenger-count adultCount slcYolcuYetiskin">1</span>
                                                <button id="yetiskinArttir" type="button" class="btn btn-inc-dec pull-right plus" data-passenger="adult">
                                                    <i class="fa fa-plus"></i>
                                                </button>
                                            </div>
                                        </div>
                                        <div class="passenger-type children">
                                            <div class="age-info">Çocuk (2-12 yaş)</div>
                                            <i class="form-kids-icon eu-icon-kids-gray"></i>
                                            <div class="passenger-inc-dec">
                                                <button id="cocukAzalt" type="button" class="btn btn-inc-dec pull-left minus" data-passenger="child">
                                                    <i class="fa fa-minus"></i>
                                                </button>
                                                <%--<span class="passenger-count childCount">0</span>--%>
                                                <span id="slcYolcuCocuk" class="passenger-count childCount slcYolcuCocuk">0</span>
                                                <button id="cocukArttir" type="button" class="btn btn-inc-dec pull-right plus" data-passenger="child">
                                                    <i class="fa fa-plus"></i>
                                                </button>
                                            </div>
                                        </div>
                                        <div class="passenger-type infant passenger-box-left">
                                            <div class="age-info">Bebek (0-2 yaş)</div>
                                            <i class="form-baby-icon eu-icon-baby-gray"></i>
                                            <div class="passenger-inc-dec">
                                                <button id="bebekAzalt" type="button" class="btn btn-inc-dec pull-left minus" data-passenger="infant">
                                                    <i class="fa fa-minus"></i>
                                                </button>
                                                <%--<span class="passenger-count infantCount">0</span>--%>
                                                <span id="slcYolcuBebek" class="passenger-count infantCount slcYolcuBebek">0</span>
                                                <button id="bebekArttir" type="button" class="btn btn-inc-dec pull-right plus" data-passenger="infant">
                                                    <i class="fa fa-plus"></i>
                                                </button>
                                            </div>
                                        </div>

                                        <div class="passenger-type adult passenger-box-left">
                                            <select class="custom-select" id="flight-class-select">
                                                <option value="ekonomi">Ekonomi</option>
                                                <%--<option value="comfort" disabled="disabled">Premium Economy</option>--%>
                                                <option value="business">Business</option>
                                            </select>
                                        </div>
                                        <button type="button" class="btn btn-success passenger-select-btn" onclick="hide('flightpassengerbox')">Tamam</button>
                                        <div class="passenger-select-msg" data-container="" data-toggle="popover" data-placement="bottom" data-content=""></div>
                                    </div>
                                    <p id="pUyari"></p>
                                </div>


                            </div>

                        </div>
                    </div>
                </div>
                <%--<div class="col-md-1 col-sm-6 col-xs-3">
                    <div class="form-gp">
                        <label>Child</label>
                        <select class="selectpicker">
                            <option>1</option>
                            <option>2</option>
                            <option>3</option>
                            <option>4</option>
                            <option>5</option>
                            <option>6</option>
                        </select>
                    </div>
                </div>--%>
                <div class="col-md-2 col-sm-6 col-xs-6">
                    <div class="form-gp">
                        <%--<button type="submit" class="modify-search-button btn transition-effect">MODIFY SEARCH</button>--%>

                        <button type="button" class="modify-search-button btn transition-effect" id="btnAirSearch" onclick="searchAir();">..Uçuş Ara..</button>

                    </div>
                </div>
            </form>
        </div>
    </div>
    <!-- END: MODIFY SEARCH -->


    <!-- START: LISTING AREA-->
    <div class="row">
        <div class="container">
            <!-- START: FILTER AREA -->
            <div class="col-md-3 clear-padding">
                <div id="ucusSayisi" class="filter-head text-center">
                    <%--<h4>25 Result Found Matching Your Search.</h4>--%>
                </div>
                <div class="filter-area">
                    <div class="price-filter filter">
                        <h5><i class=""></i>Fiyat</h5>
                        <p>
                            <label></label>
                            <input type="text" id="amount" readonly>
                        </p>
                        <div id="price-range"></div>
                    </div>
                   
                    <div id="airLinelist" runat="server" clientidmode="static" class="airline-filter filter">
                        <%--  <h5><i class="fa fa-plane"></i>Hava Yollari</h5>
                        <ul>
                            <li>
                                <input type="checkbox"><img src="assets/images/airline/airline.jpg" alt="cruise">
                                Vistara</li>
                            <li>
                                <input type="checkbox"><img src="assets/images/airline/airline.jpg" alt="cruise">
                                Indigo</li>
                            <li>
                                <input type="checkbox"><img src="assets/images/airline/airline.jpg" alt="cruise">
                                Spicejet</li>
                            <li>
                                <input type="checkbox"><img src="assets/images/airline/airline.jpg" alt="cruise">
                                Jet</li>
                            <li>
                                <input type="checkbox"><img src="assets/images/airline/airline.jpg" alt="cruise">
                                Vistara</li>
                            <li>
                                <input type="checkbox"><img src="assets/images/airline/airline.jpg" alt="cruise">
                                Indigo</li>
                        </ul>--%>
                    </div>

                    <div class="stop-filter filter">
                        <h5><i class="fa fa-stop"></i>Stops</h5>
                        <div class="btn-group" data-toggle="buttons">
                            <label class="btn btn-primary" onclick="AktShowHide('ALL');">
                                <input type="radio" name="options" id="option4">
                                ALL
                                <br>
                                Flight
                            </label>
                            <label class="btn btn-primary" onclick="AktShowHide(0);">
                                <input type="radio" name="options" id="option1">
                                0
                                <br>
                                Stop
                            </label>
                            <label class="btn btn-primary" onclick="AktShowHide(1);">
                                <input type="radio" name="options" id="option2">
                                1
                                <br>
                                Stops
                            </label>
                            <label class="btn btn-primary" onclick="AktShowHide(2);">
                                <input type="radio" name="options" id="option3">
                                1+
                                <br>
                                Stops
                            </label>
                        </div>
                    </div>
                  <%--  <div class="filter">
                        <h5><i class="fa fa-list"></i>Class</h5>
                        <ul>
                            <li>
                                <input type="checkbox">
                                Economy</li>
                            <li>
                                <input type="checkbox">
                                Business</li>
                            <li>
                                <input type="checkbox">
                                All</li>
                        </ul>
                    </div>--%>
                    <%--<div class="facilities-filter filter">
                        <h5><i class="fa fa-list"></i>Airline Facilities</h5>
                        <ul>
                            <li>
                                <input type="checkbox">
                                <i class="fa fa-wifi"></i>Wifi</li>
                            <li>
                                <input type="checkbox">
                                <i class="fa fa-cab"></i>Taxi</li>
                            <li>
                                <input type="checkbox">
                                <i class="fa fa-cutlery"></i>Meal</li>
                            <li>
                                <input type="checkbox">
                                <i class="fa fa-coffee"></i>Coffee </li>
                            <li>
                                <input type="checkbox">
                                <i class="fa fa-cutlery"></i>Meal</li>
                            <li>
                                <input type="checkbox">
                                <i class="fa fa-coffee"></i>Coffee</li>
                        </ul>
                    </div>--%>
                </div>
            </div>
            <!-- END: FILTER AREA -->

            <!-- START: INDIVIDUAL LISTING AREA -->
            <div class="col-md-9 flight-listing">

                <!-- START: LOWEST FARE SLIDER -->
                <div class="lowest-fare-slider col-md-12">
                    <div class="owl-carousel" id="lowest-fare">
                        <div class="text-center">
                            <h5>22 Aug</h5>
                            <span>From $129</span>
                        </div>
                        <div class="text-center">
                            <h5>23 Aug</h5>
                            <span>From $119</span>
                        </div>
                        <div class="text-center">
                            <h5>24 Aug</h5>
                            <span>From $299</span>
                        </div>
                        <div class="text-center">
                            <h5>25 Aug</h5>
                            <span>From $200</span>
                        </div>
                        <div class="text-center">
                            <h5>26 Aug</h5>
                            <span>From $150</span>
                        </div>
                        <div class="text-center">
                            <h5>27 Aug</h5>
                            <span>From $300</span>
                        </div>
                        <div class="text-center">
                            <h5>28 Aug</h5>
                            <span>From $400</span>
                        </div>
                        <div class="text-center">
                            <h5>29 Aug</h5>
                            <span>From $500</span>
                        </div>
                    </div>
                </div>
                <!-- END: LOWEST FARE SLIDER -->

                <!-- START: SORT AREA -->
                <div class="sort-area col-md-12">
                    <div class="col-md-3 col-sm-3 col-xs-6 sort">
                        <select id="FiyatFiltre" class="selectpicker">
                            <option>Fiyat</option>
                            <option>Artan Fiyat</option>
                            <option>Azalan Fiyat</option>
                        </select>
                    </div>
                    <div class="col-md-3 col-sm-3 col-xs-6 sort">
                        <select class="selectpicker">
                            <option>Airline</option>
                            <option>Vistara</option>
                            <option>Indigo</option>
                            <option>Jet</option>
                            <option>Spicejet</option>
                        </select>
                    </div>
                    <div class="col-md-3 col-sm-3 col-xs-6 sort">
                        <select class="selectpicker">
                            <option>User Rating</option>
                            <option>Low to High</option>
                            <option>High to Low</option>
                        </select>
                    </div>
                    <div class="col-md-3 col-sm-3 col-xs-6 sort">
                        <select id="HavaYolunaGore" class="selectpicker">
                            <option>Havayolları</option>
                            <option>A dan Z ye</option>
                            <option>Z den A ya</option>
                        </select>
                    </div>
                </div>
                <!-- END: SORT AREA -->
                <div class="clearfix"></div>
                <!-- START: FLIGHT LIST VIEW -->
                <div id="ucusListesiTumu" runat="server" clientidmode="static">

                    <%--<div id="ucusListesi" runat="server" clientidmode="static">
                </div>--%>
                    <%--   <div id="donusUcusListesi" runat="server" clientidmode="static">
                </div>--%>
                </div>
                <div class="clearfix"></div>
                <!-- END: FLIGHT LIST VIEW -->

                <!-- START: PAGINATION -->
                <div class="bottom-pagination">
                    <nav class="pull-right">
                        <ul class="pagination pagination-lg">
                            <li><a href="#" aria-label="Previous"><span aria-hidden="true">&laquo;</span></a></li>
                            <li class="active"><a href="#">1 <span class="sr-only">(current)</span></a></li>
                            <li><a href="#">2 <span class="sr-only">(current)</span></a></li>
                            <li><a href="#">3 <span class="sr-only">(current)</span></a></li>
                            <li><a href="#">4 <span class="sr-only">(current)</span></a></li>
                            <li><a href="#">5 <span class="sr-only">(current)</span></a></li>
                            <li><a href="#">6 <span class="sr-only">(current)</span></a></li>
                            <li><a href="#" aria-label="Previous"><span aria-hidden="true">&#187;</span></a></li>
                        </ul>
                    </nav>
                </div>
                <!-- END: PAGINATION -->
            </div>
            <!-- END: INDIVIDUAL LISTING AREA -->
        </div>
    </div>
    <!-- END: LISTING AREA -->

    <%--<script src="/assets/js/respond.js"></script>--%>
    <%--<script src="/assets/js/jquery.js"></script>--%>
    <%--<script src="/assets/plugins/owl.carousel.min.js"></script>--%>
    <%--<script src="/assets/js/bootstrap.min.js"></script>--%>
    <%--<script src="/assets/js/jquery-ui.min.js"></script>--%>
    <%--<script src="/assets/js/bootstrap-select.min.js"></script>--%>
    <%--<script src="/assets/plugins/wow.min.js"></script>--%>
    <%--<script src="/assets/js/js.js"></script>--%>
    <%--<link href="/assets/css/jquery-ui.min.css" rel="stylesheet" />--%>


    <script type="text/javascript">
        var ucret = [];
        var ucret2 = [];
        var enKucuk = "";
        var enBuyuk = "";
        var enKucukTR = "";
        var enBuyukTR = "";

        try {
            $("#" + "ucusListesi >" + " div").each(function (index) {


                ucret.push($("#ucusListesi > div:eq(" + index + ")").data("price"));

                //ucret2.push($(this).data("value"));

                //ucret2 = ucret2.sort(function (a, b) { return a - b });

            });
            //alert(ucret2[0] + " - " + ucret2[ucret2.length - 1]);
            enKucuk = parseInt(Math.min.apply(Math, ucret)); // 1
            enBuyuk = parseInt(Math.max.apply(Math, ucret)); // 3

            //alert(enKucukTR + " - " + enBuyukTR);

        } catch (e) {
            //
        }

    </script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jqueryui-touch-punch/0.2.3/jquery.ui.touch-punch.min.js"></script>
    <script>
        /* Price Range Slider */

        $(function () {
            "use strict";
            $("#price-range").slider({
                range: true,
                min: enKucuk,
                max: enBuyuk,
                values: [enKucuk, enBuyuk],
                slide: function (event, ui) {
                    $("#amount").val(ui.values[0] + " TL" + " - " + ui.values[1] + " TL");

                    $("#" + "ucusListesi >" + " div").each(function (index) {

                        var priceCode = $(this).data("price");

                        if (priceCode < ui.values[0] || priceCode > ui.values[1]) {
                            $(this).hide();
                        }
                        else
                            $(this).show();
                    });
                    //$("#" + "ucusListesi >" + " div").each(function (index) {

                    //    var priceCode = $(this).data("value").toString();

                    //    if (priceCode < ui.values[0] || priceCode > ui.values[1]) {
                    //        $(this).hide();
                    //    }
                    //    else
                    //        $(this).show();
                    //});

                }
            });
            $("#amount").val($("#price-range").slider("values", 0) +
              " TL - " + $("#price-range").slider("values", 1) + " TL");
        });
    </script>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/anaYapi.Master" AutoEventWireup="true" CodeBehind="flightSearch.aspx.cs" Inherits="birSifirUcuzaUc.WebUI.flightSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="pageScripts/searchCookie.js"></script>
    <script src="pageScripts/flightSearch.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- BEGIN: SEARCH SECTION -->
    <section>
        <div class="row flight-search single-search">

            <div class="container clear-padding">
                <div class="col-md-12 clear-padding search-section">
                    <h2 class="text-center">Size Uygun Hava Yolunu Arayın</h2>

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

                    <!-- START: HOTEL SEARCH -->
                    <div role="tabpanel" class="tab-pane" id="hotel">

                        <div class="col-md-3 col-sm-3 search-col-padding">
                            <%--<label>Leaving From</label>--%>
                            <div id="divAirPortSearch1" class="input-group">
                                <input id="inpNereden" type="text" name="dep-city" class="form-control" autocomplete="off" required placeholder="Kalkış Yeri.." />
                                <input type="hidden" id="inpNeredenAirportCode" value="" />
                                <input type="hidden" id="inpNeredenCountryCode" value="" />
                                <input type="hidden" id="inpNeredenCountryName" value="" />
                                <input type="hidden" id="inpNeredenCityName" value="" />
                                <ul id="inpAirportOneri1" onmouseenter="mouseEnter(this)" onmouseleave="mouseLeave(this)" class="dropdown-menu" style="margin-left: 15px;"></ul>
                                <span class="input-group-addon"><i class="fa fa-map-marker fa-fw"></i></span>
                            </div>
                        </div>
                        <div class="col-md-3 col-sm-3 search-col-padding">
                            <%--<label>Leaving To</label>--%>
                            <div id="divAirPortSearch2" class="input-group">
                                <input id="inpNereye" type="text" name="des-city" class="form-control" autocomplete="off" required placeholder="Gidiş Yeri.." />
                                <input type="hidden" id="inpNereyeAirportCode" value="" />
                                <input type="hidden" id="inpNereyeCountryCode" value="" />
                                <input type="hidden" id="inpNereyeCityName" value="" />
                                <ul id="inpAirportOneri2" onmouseenter="mouseEnter(this)" onmouseleave="mouseLeave(this)" class="dropdown-menu" style="margin-left: 15px;"></ul>
                                <span class="input-group-addon"><i class="fa fa-map-marker fa-fw"></i></span>
                            </div>
                        </div>
                        <div class="col-md-2 col-sm-2 search-col-padding">
                            <%--<label>Departure</label>--%>
                            <%--Tarih ile ilgili tüm işlemler /js/jquery-ui.min.js yolunda yapılacaktır.--%>
                            <div class="input-group">
                                <input type="text" name="dep_date" id="departure_date" class="form-control" placeholder="Gidiş Tarihi" readonly />
                                <span class="input-group-addon"><i class="fa fa-calendar fa-fw"></i></span>
                            </div>
                        </div>
                        <div class="col-md-2 col-sm-2 search-col-padding">
                            <%--<label>Return</label>--%>
                            <div class="input-group">
                                <input type="text" name="return_date" data-format="dd/MM/yyyy" id="return_date" class="form-control" placeholder="Dönüş Tarihi" readonly />
                                <span class="input-group-addon" id="return_span"><i class="fa fa-calendar fa-fw"></i></span>
                            </div>
                        </div>
                        <%-- <div class="col-md-2 col-sm-2 search-col-padding">
                           
                            <select id="slcYolcuYetiskin" class="selectpicker" name="guests">
                                <option>1</option>
                                <option>2</option>
                                <option>3</option>
                                <option>4</option>
                                <option>5</option>
                                <option>6</option>
                            </select>
                        </div>--%>


                        <%--YOLCU SAYISI BELİRLEME--%>
                             <div class="col-md-2 col-sm-2 search-col-padding">
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


                        <div class="clearfix"></div>
                        <div class="col-md-12 text-center search-col-padding">
                            <button type="button" id="btnAirSearch" onclick="searchAir();" class="search-button btn transition-effect">..Uçuş Ara..</button>
                        </div>
                        <div class="clearfix"></div>

                    </div>
                    <!-- END: HOTEL SEARCH -->
                </div>
            </div>
        </div>
    </section>
    <!-- END: SEARCH SECTION -->
    <!-- STRAT: LAST MINUTE DEALS -->
    <section>
        <div class="row last-minute-deal">
            <div class="container">
                <div class="section-title text-center">
                    <h2>LAST MINUTE DEALS</h2>
                    <h4>SAVE MORE</h4>
                </div>
                <div class="owl-carousel" id="lastminute">
                    <div class="col-grid">
                        <div class="wrapper">
                             <img src="assets/images/location/tour1.jpg" alt="cruise">
                            <h5 class="location">TÜRKİYE</h5>
                        </div>
                        <div class="body text-center">
                            <h5>Roound Trip</h5>
                            <p><i class="fa fa-star"></i><i class="fa fa-star"></i><i class="fa fa-star"></i><i class="fa fa-star"></i></p>
                            <p class="back-line">Starting From</p>
                            <h3>$199</h3>
                            <p class="text-sm">Thu Aug 12 - Sun 14 Aug</p>
                        </div>
                        <div class="bottom">
                            <a href="#">VIEW DETAIL</a>
                        </div>
                    </div>
                    <div class="col-grid">
                        <div class="wrapper">
                            <img src="assets/images/location/tour1.jpg" alt="cruise">
                            <h5 class="location">BANGKOK</h5>
                        </div>
                        <div class="body text-center">
                            <h5>One Way Trip</h5>
                            <p><i class="fa fa-star"></i><i class="fa fa-star"></i><i class="fa fa-star"></i><i class="fa fa-star"></i></p>
                            <p class="back-line">Starting From</p>
                            <h3>$299</h3>
                            <p class="text-sm">Thu Aug 12 - Sun 14 Aug</p>
                        </div>
                        <div class="bottom">
                            <a href="#">VIEW DETAIL</a>
                        </div>
                    </div>
                    <div class="col-grid">
                        <div class="wrapper">
                            <img src="assets/images/location/tour1.jpg" alt="cruise">
                            <h5 class="location">DUBAI</h5>
                        </div>
                        <div class="body text-center">
                            <h5>One Way Trip</h5>
                            <p><i class="fa fa-star"></i><i class="fa fa-star"></i><i class="fa fa-star"></i><i class="fa fa-star"></i></p>
                            <p class="back-line">Starting From</p>
                            <h3>$399</h3>
                            <p class="text-sm">Thu Aug 12 - Sun 14 Aug</p>
                        </div>
                        <div class="bottom">
                            <a href="#">VIEW DETAIL</a>
                        </div>
                    </div>
                    <div class="col-grid">
                        <div class="wrapper">
                            <img src="assets/images/location/tour1.jpg" alt="cruise">
                            <h5 class="location">ITALY</h5>
                        </div>
                        <div class="body text-center">
                            <h5>Round Trip</h5>
                            <p><i class="fa fa-star"></i><i class="fa fa-star"></i><i class="fa fa-star"></i><i class="fa fa-star"></i></p>
                            <p class="back-line">Starting From</p>
                            <h3>$399</h3>
                            <p class="text-sm">Thu Aug 12 - Sun 14 Aug</p>
                        </div>
                        <div class="bottom">
                            <a href="#">VIEW DETAIL</a>
                        </div>
                    </div>
                    <div class="col-grid">
                        <div class="wrapper">
                            <img src="assets/images/location/tour1.jpg" alt="cruise">
                            <h5 class="location">PARIS</h5>
                        </div>
                        <div class="body text-center">
                            <h5>One Way Trip</h5>
                            <p><i class="fa fa-star"></i><i class="fa fa-star"></i><i class="fa fa-star"></i><i class="fa fa-star"></i></p>
                            <p class="back-line">Starting From</p>
                            <h3>$199</h3>
                            <p class="text-sm">Thu Aug 12 - Sun 14 Aug</p>
                        </div>
                        <div class="bottom">
                            <a href="#">VIEW DETAIL</a>
                        </div>
                    </div>
                    <div class="col-grid">
                        <div class="wrapper">
                            <img src="assets/images/location/tour1.jpg" alt="cruise">
                            <h5 class="location">BANGKOK</h5>
                        </div>
                        <div class="body text-center">
                            <h5>Round Trip</h5>
                            <p><i class="fa fa-star"></i><i class="fa fa-star"></i><i class="fa fa-star"></i><i class="fa fa-star"></i></p>
                            <p class="back-line">Starting From</p>
                            <h3>$299</h3>
                            <p class="text-sm">Thu Aug 12 - Sun 14 Aug</p>
                        </div>
                        <div class="bottom">
                            <a href="#">VIEW DETAIL</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- END: LAST MINUTE DEALS -->

    <!-- BEGIN: TOP DESTINATION SECTION -->
    <section id="top-flight-row">
        <div class="row top-flight">
            <div class="container">
                <div class="section-title text-center">
                    <h2>TOP DESTINATION</h2>
                    <h4>CHECK OUT FLIGHTS TO TOP DESTINATIONS</h4>
                </div>
                <div class="col-md-4 col-sm-6 tour-grid clear-padding">
                    <img src="assets/images/location/tour1.jpg" alt="cruise">
                    <div class="tour-brief">
                        <div class="pull-left">
                            <h4><i class="fa fa-map-marker"></i>FRANCE</h4>
                        </div>
                        <div class="pull-right">
                            <h4>$49/Person</h4>
                        </div>
                    </div>
                    <div class="tour-detail text-center">
                        <p><strong><i class="fa fa-plane"></i>25 Airline</strong></p>
                        <p><strong>Starting $49/Person</strong></p>
                        <p><a href="#">DETAIL</a></p>
                    </div>
                </div>
                <div class="col-md-4 col-sm-6 tour-grid clear-padding">
                    <img src="assets/images/location/tour1.jpg" alt="cruise">
                    <div class="tour-brief">
                        <div class="pull-left">
                            <h4><i class="fa fa-map-marker"></i>DUBAI</h4>
                        </div>
                        <div class="pull-right">
                            <h4>$99/Person</h4>
                        </div>
                    </div>
                    <div class="tour-detail text-center">
                        <p><strong><i class="fa fa-plane"></i>40 Airline</strong></p>
                        <p><strong>Starting $99/Person</strong></p>
                        <p><a href="#">DETAIL</a></p>
                    </div>
                </div>
                <div class="col-md-4 col-sm-6 tour-grid clear-padding">
                    <img src="assets/images/location/tour1.jpg" alt="cruise">
                    <div class="tour-brief">
                        <div class="pull-left">
                            <h4><i class="fa fa-map-marker"></i>BANGKOK</h4>
                        </div>
                        <div class="pull-right">
                            <h4>$69/Person</h4>
                        </div>
                    </div>
                    <div class="tour-detail text-center">
                        <p><strong><i class="fa fa-plane"></i>90 Airline</strong></p>
                        <p><strong>Starting $69/Person</strong></p>
                        <p><a href="#">DETAIL</a></p>
                    </div>
                </div>
                <div class="col-md-4 col-sm-6 tour-grid clear-padding">
                    <img src="assets/images/location/tour1.jpg" alt="cruise">
                    <div class="tour-brief">
                        <div class="pull-left">
                            <h4><i class="fa fa-map-marker"></i>AFRICA</h4>
                        </div>
                        <div class="pull-right">
                            <h4>$90/Person</h4>
                        </div>
                    </div>
                    <div class="tour-detail text-center">
                        <p><strong><i class="fa fa-plane"></i>6 Airline</strong></p>
                        <p><strong>Starting $90/Person</strong></p>
                        <p><a href="#">DETAIL</a></p>
                    </div>
                </div>
                <div class="col-md-4 col-sm-6 tour-grid clear-padding">
                    <img src="assets/images/location/tour1.jpg" alt="cruise">
                    <div class="tour-brief">
                        <div class="pull-left">
                            <h4><i class="fa fa-map-marker"></i>BELGIUM</h4>
                        </div>
                        <div class="pull-right">
                            <h4>$89/Person</h4>
                        </div>
                    </div>
                    <div class="tour-detail text-center">
                        <p><strong><i class="fa fa-plane"></i>8 Airline</strong></p>
                        <p><strong>Starting $89/Person</strong></p>
                        <p><a href="#">DETAIL</a></p>
                    </div>
                </div>
                <div class="col-md-4 col-sm-6 tour-grid clear-padding">
                    <img src="assets/images/location/tour1.jpg" alt="cruise">
                    <div class="tour-brief">
                        <div class="pull-left">
                            <h4><i class="fa fa-map-marker"></i>AUSTRIA</h4>
                        </div>
                        <div class="pull-right">
                            <h4>$199/Person</h4>
                        </div>
                    </div>
                    <div class="tour-detail text-center">
                        <p><strong><i class="fa fa-plane"></i>28 Airline</strong></p>
                        <p><strong>Starting $199/Person</strong></p>
                        <p><a href="#">DETAIL</a></p>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- END: TOP DESTINATION SECTION -->
    <!-- START: HOT  DEALS -->
    <section>
        <div class="row hot-deals">
            <div class="container clear-padding">
                <div class="section-title text-center">
                    <h2>HOT DEALS</h2>
                    <h4>SAVE MORE</h4>
                </div>
                <div role="tabpanel" class="text-center">
                    <!-- BEGIN: CATEGORY TAB -->
                    <ul class="nav nav-tabs" role="tablist" id="hotDeal">
                        <li role="presentation" class="active text-center">
                            <a href="#tab1" aria-controls="tab1" role="tab" data-toggle="tab">
                                <i class="fa fa-map-marker"></i>
                                <span>NEW YORK</span>
                            </a>
                        </li>
                        <li role="presentation" class="text-center">
                            <a href="#tab2" aria-controls="tab2" role="tab" data-toggle="tab">
                                <i class="fa fa-map-marker"></i>
                                <span>SEATLE</span>
                            </a>
                        </li>
                        <li role="presentation" class="text-center">
                            <a href="#tab3" aria-controls="tab3" role="tab" data-toggle="tab">
                                <i class="fa fa-map-marker"></i>
                                <span>CALIFORNIA</span>
                            </a>
                        </li>
                        <li role="presentation" class="text-center">
                            <a href="#tab4" aria-controls="tab4" role="tab" data-toggle="tab">
                                <i class="fa fa-map-marker"></i>
                                <span>LOS VAGAS</span>
                            </a>
                        </li>
                        <li role="presentation" class="text-center">
                            <a href="#tab5" aria-controls="tab5" role="tab" data-toggle="tab">
                                <i class="fa fa-map-marker"></i>
                                <span>LOS ANGELES</span>
                            </a>
                        </li>
                    </ul>
                    <!-- END: CATEGORY TAB -->
                    <div class="clearfix"></div>
                    <!-- BEGIN: TAB PANELS -->
                    <div class="tab-content">
                        <!-- BEGIN: FLIGHT SEARCH -->
                        <div role="tabpanel" class="tab-pane active fade in" id="tab1">
                            <div class="col-md-6 hot-deal-list">
                                <div class="item">
                                    <div class="col-xs-3">
                                        <img src="assets/images/location/tour1.jpg" />
                                    </div>
                                    <div class="col-md-7 col-xs-6">
                                        <h5>Round Trip To New York</h5>
                                        <p class="location">New York <i class="fa fa-long-arrow-right"></i>New Delhi</p>
                                        <p class="location">New Delhi <i class="fa fa-long-arrow-right"></i>New York</p>
                                    </div>
                                    <div class="col-md-2 col-xs-3">
                                        <h4>$499</h4>
                                        <h6>Per Person</h6>
                                        <a href="#">BOOK</a>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <div class="item">
                                    <div class="col-xs-3">
                                        <img src="assets/images/location/tour1.jpg" />
                                    </div>
                                    <div class="col-md-7 col-xs-6">
                                        <h5>One Way Trip To Paris</h5>
                                        <p class="location">New York <i class="fa fa-long-arrow-right"></i>Paris</p>
                                    </div>
                                    <div class="col-md-2 col-xs-3">
                                        <h4>$399</h4>
                                        <h6>Per Person</h6>
                                        <a href="#">BOOK</a>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <div class="item">
                                    <div class="col-xs-3">
                                        <img src="assets/images/location/tour1.jpg" />
                                    </div>
                                    <div class="col-md-7 col-xs-6">
                                        <h5>Round Trip To New York</h5>
                                        <p class="location">New York <i class="fa fa-long-arrow-right"></i>Dubai</p>
                                        <p class="location">Dubai <i class="fa fa-long-arrow-right"></i>New York</p>
                                    </div>
                                    <div class="col-md-2 col-xs-3">
                                        <h4>$499</h4>
                                        <h6>Per Person</h6>
                                        <a href="#">BOOK</a>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                            </div>
                            <div class="col-md-6 hot-deal-grid">
                                <div class="col-sm-6 item">
                                    <div class="wrapper">
                                         <img src="assets/images/location/tour1.jpg" />
                                        <h5>Paris Flights $599/Person</h5>
                                        <a href="#">DETAILS</a>
                                    </div>
                                </div>
                                <div class="col-sm-6 item">
                                    <div class="wrapper">
                                         <img src="assets/images/location/tour1.jpg" alt="cruise">
                                        <h5>Spain Flights $599/Person</h5>
                                        <a href="#">DETAILS</a>
                                    </div>
                                </div>
                                <div class="col-sm-6 item">
                                    <div class="wrapper">
                                         <img src="assets/images/location/tour1.jpg" alt="cruise">
                                        <h5>Dubai Flights $599/Person</h5>
                                        <a href="#">DETAILS</a>
                                    </div>
                                </div>
                                <div class="col-sm-6 item">
                                    <div class="wrapper">
                                         <img src="assets/images/location/tour1.jpg" alt="cruise">
                                        <h5>Italy Flights $599/Person</h5>
                                        <a href="#">DETAILS</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div role="tabpanel" class="tab-pane fade" id="tab2">
                            <div class="col-md-6 hot-deal-list">
                                <div class="item">
                                    <div class="col-xs-3">
                                         <img src="assets/images/location/tour1.jpg" alt="cruise">
                                    </div>
                                    <div class="col-md-7 col-xs-6">
                                        <h5>Round Trip To New York</h5>
                                        <p class="location">New York <i class="fa fa-long-arrow-right"></i>New Delhi</p>
                                        <p class="location">New Delhi <i class="fa fa-long-arrow-right"></i>New York</p>
                                    </div>
                                    <div class="col-md-2 col-xs-3">
                                        <h4>$499</h4>
                                        <h6>Per Person</h6>
                                        <a href="#">BOOK</a>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <div class="item">
                                    <div class="col-xs-3">
                                        <img src="assets/images/location/tour1.jpg" alt="cruise">
                                    </div>
                                    <div class="col-md-7 col-xs-6">
                                        <h5>One Way Trip To Paris</h5>
                                        <p class="location">New York <i class="fa fa-long-arrow-right"></i>Paris</p>
                                    </div>
                                    <div class="col-md-2 col-xs-3">
                                        <h4>$399</h4>
                                        <h6>Per Person</h6>
                                        <a href="#">BOOK</a>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <div class="item">
                                    <div class="col-xs-3">
                                        <img src="assets/images/location/tour1.jpg" alt="cruise">
                                    </div>
                                    <div class="col-md-7 col-xs-6">
                                        <h5>Round Trip To New York</h5>
                                        <p class="location">New York <i class="fa fa-long-arrow-right"></i>Dubai</p>
                                        <p class="location">Dubai <i class="fa fa-long-arrow-right"></i>New York</p>
                                    </div>
                                    <div class="col-md-2 col-xs-3">
                                        <h4>$499</h4>
                                        <h6>Per Person</h6>
                                        <a href="#">BOOK</a>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                            </div>
                            <div class="col-md-6 hot-deal-grid">
                                <div class="col-sm-6 item">
                                    <div class="wrapper">
                                         <img src="assets/images/location/tour1.jpg" alt="cruise">
                                        <h5>London Flights $599/Person</h5>
                                        <a href="#">DETAILS</a>
                                    </div>
                                </div>
                                <div class="col-sm-6 item">
                                    <div class="wrapper">
                                         <img src="assets/images/location/tour1.jpg" alt="cruise">
                                        <h5>France Flights $699/Person</h5>
                                        <a href="#">DETAILS</a>
                                    </div>
                                </div>
                                <div class="col-sm-6 item">
                                    <div class="wrapper">
                                         <img src="assets/images/location/tour1.jpg" alt="cruise">
                                        <h5>Dubai Flights $799/Person</h5>
                                        <a href="#">DETAILS</a>
                                    </div>
                                </div>
                                <div class="col-sm-6 item">
                                    <div class="wrapper">
                                         <img src="assets/images/location/tour1.jpg" alt="cruise">
                                        <h5>Italy Flights $599/Person</h5>
                                        <a href="#">DETAILS</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div role="tabpanel" class="tab-pane" id="tab3">
                            Lorem Lpsum 3
                        </div>
                        <div role="tabpanel" class="tab-pane" id="tab4">
                            Lorem Lpsum 4
                        </div>
                        <div role="tabpanel" class="tab-pane" id="tab5">
                            Lorem Lpsum 5
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- END: HOT DEALS -->
</asp:Content>

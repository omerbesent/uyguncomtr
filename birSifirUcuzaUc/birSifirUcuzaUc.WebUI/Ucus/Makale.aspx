<%@ Page Title="" Language="C#" MasterPageFile="~/anaYapi.Master" AutoEventWireup="true" CodeBehind="Makale.aspx.cs" Inherits="birSifirUcuzaUc.WebUI.Ucus.Makale" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../assets/js/moment.js"></script>
    <script src="../pageScripts/searchCookie.js"></script>
    <script src="../pageScripts/flightSearch.js"></script>
    <script src="../pageScripts/seferPage.js"></script>
    <link href="../assets/css/seferCss.css" rel="stylesheet" />
    <link href="../assets/css/prepareCss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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
    <div class="row">
        <div class="container clear-padding">
            <div class="col-md-12">
					<div class="single-post-wrapper" runat="server" clientidmode="static" id="makale">
					 
				 
					</div>
				</div>
        </div>
    </div>
   
</asp:Content>

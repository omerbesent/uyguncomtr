<%@ Page Title="" Language="C#" MasterPageFile="~/anaYapi.Master" AutoEventWireup="true" CodeBehind="Satis.aspx.cs" Inherits="birSifirUcuzaUc.WebUI.Ucus.Satis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../pageScripts/satinal.css" rel="stylesheet" />


    <%--<script src="pageScripts/satinAlKontrol.js"></script>--%>
    <%--  <script type="text/javascript">

        $(document).ready(function () {
            satinAlRezervalidate();
            $("#payment-panel").hide(); //sayfa yüklendiği anda div gizledik.

            $('#checkboxtcno0').click(function () {
                var birCheck = document.getElementById('checkboxtcno0').checked;
                if (birCheck == true) {
                    $('#inpBilgiTc0').attr("disabled", true);
                    $('#inpBilgiTc0').val('');
                }
                else {
                    $('#inpBilgiTc0').attr("disabled", false);
                    $('#inpBilgiTc0').val('');
                }
            });
            $('#checkboxtcno1').click(function () {
                var birCheck = document.getElementById('checkboxtcno1').checked;
                if (birCheck == true) {
                    $('#inpBilgiTc1').attr("disabled", true);
                    $('#inpBilgiTc1').val('');
                }
                else {
                    $('#inpBilgiTc1').attr("disabled", false);
                    $('#inpBilgiTc1').val('');
                }
            });
            $('#checkboxtcno2').click(function () {
                var birCheck = document.getElementById('checkboxtcno2').checked;
                if (birCheck == true) {
                    $('#inpBilgiTc2').attr("disabled", true);
                    $('#inpBilgiTc2').val('');
                }
                else {
                    $('#inpBilgiTc2').attr("disabled", false);
                    $('#inpBilgiTc2').val('');
                }
            });
            $('#checkboxtcno3').click(function () {
                var birCheck = document.getElementById('checkboxtcno4').checked;
                if (birCheck == true) {
                    $('#inpBilgiTc3').attr("disabled", true);
                    $('#inpBilgiTc3').val('');
                }
                else {
                    $('#inpBilgiTc3').attr("disabled", false);
                    $('#inpBilgiTc3').val('');
                }
            });
            $('#checkboxtcno4').click(function () {
                var birCheck = document.getElementById('checkboxtcno4').checked;
                if (birCheck == true) {
                    $('#inpBilgiTc4').attr("disabled", true);
                    $('#inpBilgiTc4').val('');
                }
                else {
                    $('#inpBilgiTc4').attr("disabled", false);
                    $('#inpBilgiTc4').val('');
                }
            });
            $('#checkboxtcno5').click(function () {
                var birCheck = document.getElementById('checkboxtcno5').checked;
                if (birCheck == true) {
                    $('#inpBilgiTc5').attr("disabled", true);
                    $('#inpBilgiTc5').val('');
                }
                else {
                    $('#inpBilgiTc5').attr("disabled", false);
                    $('#inpBilgiTc5').val('');
                }
            });
            $('#checkboxtcno6').click(function () {
                var birCheck = document.getElementById('checkboxtcno6').checked;
                if (birCheck == true) {
                    $('#inpBilgiTc6').attr("disabled", true);
                    $('#inpBilgiTc6').val('');
                }
                else {
                    $('#inpBilgiTc6').attr("disabled", false);
                    $('#inpBilgiTc6').val('');
                }
            });
            $('#checkboxtcno7').click(function () {
                var birCheck = document.getElementById('checkboxtcno7').checked;
                if (birCheck == true) {
                    $('#inpBilgiTc7').attr("disabled", true);
                    $('#inpBilgiTc7').val('');
                }
                else {
                    $('#inpBilgiTc7').attr("disabled", false);
                    $('#inpBilgiTc7').val('');
                }
            });

        });
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="Satis-Block">

        <!-- Flight Start -->
        <div class="row">
            <div class="panel panel-default reservation-panel v2 fastclick satinal-panel-container">
                <div class="panel-heading hidden-xs">
                    <h1><i class="fa fa-plane"></i>Uçuş Bilgileri</h1>
                </div>
                <div class="panel-body">
                    <div id="ContentPlaceHolder1_gidisBilgileri" runat="server" class="flight-info-content" style="display: block;">
                    </div>
                    <div class="flight-ticket-notice-container clearfix"></div>
                </div>
            </div>
        </div>
        <!-- Flight End -->

        <!-- Price Start-->
        <div class="panel panel-default reservation-panel clear-padding fastclick satinal-panel-container">
            <div class="panel-heading">
                <h1><i class="fa fa-money"></i>Ücret Detayları</h1>
            </div>
            <div class="panel-body">
                <div class="price-info-content" runat="server" id="kisiFiyatListesi">
                </div>
            </div>
        </div>
        <!-- Price End-->
        <!-- Pessenger Start-->

        <div class="panel panel-default reservation-panel satinal-panel-container">
            <div class="panel-heading fastclick">
                <h1><i class="fa fa-user"></i>Yolcu Bilgileri</h1>
            </div>
            <div class="panel-body">
                <div class="passenger-info-content">
                    <div class="passenger-form-inputs passenger clearfix passenger-last" data-passengertype="ADT">
                        <div class="col-md-12">
                            <div id="_PessengerItems" clientidmode="Static" runat="server" name="_PessengerItems">
                                <%--  <div style="clear: both;">
                                    <input type="hidden" id="inpPaxType1" onchange="this.setAttribute('value', this.value);" value="ADT"><div class="col-xs-12 col-md-12" style="line-height: 30px;">Yetişkin yolcu:</div>
                                    <div class="col-xs-12 col-md-1 yolcu-input-alani">
                                        <div class="gender-main-label eu-label"></div>
                                        <select id="slcBilgiCinsiyet1" class="form-control" onchange="this.setAttribute('value', this.value);" style="display: inline-block">
                                            <option selected="" value="X">Seçin</option>
                                            <option value="M">Bay</option>
                                            <option value="F">Bayan</option>
                                        </select>
                                    </div>
                                    <div class="col-xs-12  col-md-2 yolcu-input-alani">
                                        <input placeholder="Ad" maxlength="20" type="text" id="inpBilgiAd1" onchange="this.setAttribute('value', this.value);" class="form-control passengerFirstname required pattern-check storage-persist" data-pattern="^[a-zA-ZÇÖİŞÜĞığüşöç\.]*$" data-content="Lütfen yolcunun adını girin" data-placement="bottom" data-original-title="" title="Ad Alanı Boş Geçilemez.">
                                    </div>
                                    <div class="col-xs-12 col-md-2 yolcu-input-alani">
                                        <input placeholder="Soyad" maxlength="20" type="text" id="inpBilgiSoyad1" onchange="this.setAttribute('value', this.value);" class="passengerLastname form-control required pattern-check storage-persist" data-pattern="^[a-zA-ZÇÖİŞÜĞığüşöç\]*$" data-content="Lütfen yolcunun soyadını girin" data-placement="bottom" data-original-title="" title="Soyad Alanı Boş Geçilemez.">
                                    </div>
                                    <div class="col-xs-12 col-md-2 yolcu-input-alani" data-passenger-type="ADT" data-min-year="August 25, 1950" data-max-year="August 25, 2003" data-content="" data-placement="bottom" data-original-title="" title="">
                                        <input placeholder="Doğum Tarihi" class="form-control return-date-input" onchange="this.setAttribute('value', this.value);" data-date-format="mm.dd.yyyy" id="date1" type="text" data-dmy="18.08.2015" maxlength="10" autocomplete="off">
                                    </div>
                                    <div class="col-xs-12 col-md-2 yolcu-input-alani" style="">
                                        <input placeholder="TC Kimlik No" maxlength="11" type="text" id="inpBilgiTc1" onchange="this.setAttribute('value', this.value);" onkeypress="return event.charCode >= 48 &amp;&amp; event.charCode <= 57" class="form-control passengerFirstname required pattern-check storage-persist" data-placement="bottom" data-original-title="" title="TC Alanı Boş Geçilemez.">
                                    </div>

                                    <div style="" class="checkboxTcNo col-md-2 col-xs-12">
                                        <input type="checkbox" id="checkboxtcno1" name="optionsRadiosUcusTipi" class="tcVatandasiCheckBox" checked index="1" value="option1">
                                        <span class="checkmark" id="after"></span>
                                        <p>TC Vatandaşıyım</p>
                                        <p>(I'm Turkish)</p>
                                    </div>
                                </div>--%>
                            </div>
                        </div>
                        <div style="clear: both;"></div>
                        <div class="clearfix"></div>
                        <div class="mPhone">
                            <div class="col-md-4 col-xs-12" style="padding-right: 14px; margin-bottom: -16px;">
                                <%--onkeyup="myFunction(this)"--%>
                                <input name="inpIletisimEposta" type="text" id="inpIletisimEposta" data-inputmask-alias="email" placeholder="E-Mail" class="form-control email emailValidation storage-persist" data-content="Lütfen geçerli bir e-posta adresi girin" data-placement="bottom" style="display: inline-block;" required />
                                <span class="sms-message-notice"><i class="fa fa-envelope-o"></i>(Uçuş bilgileriniz mail olarak gönderilecektir)</span>

                                <label id="lblMailUyari"></label>
                                <label id="lblGenelUyari"></label>
                                <div style="text-align: center; display: none;" id="Div3">
                                    <img style="position: absolute; right: -17px; top: 30px; width: 20px; height: 20px" src="/../assets/img/load.gif">
                                </div>
                            </div>
                            <div style="width: 1px;"></div>
                            <div class="col-md-4 col-xs-12" style="padding-left: 3px; padding-right: 14px;">
                                <div class="btn-group country-codes dropdown" style="float: left; width: 24%;">
                                    <button id="Button1" type="button" class="btn dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" role="button" aria-expanded="false">
                                        <img src="/../assets/images/bayrak.png">+<span id="Span1">90</span>
                                    </button>
                                </div>
                                <input name="inpIletisimCepNo" type="text" id="inpIletisimCepNo" data-content="Lütfen geçerli bir cep telefonu girin" autocomplete="off" placeholder="Cep No" data-placement="bottom" maxlength="15" class="form-control masked_mobile phone-number-fixer tel-number storage-persist trmasked phone" style="width: 76%; float: right;" title="" data-original-title="" data-inputmask="'mask': '(999) 999-99-99'">
                                <span class="sms-message-notice"><i class="fa fa-mobile"></i>(Bilet bilgileriniz sms olarak gönderilecektir)</span>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="clearfix"></div>

            </div>
        </div>
        <!-- Pessenger End-->

        <div class="form-group" style="text-align: center;">
            <button id="_satisRez" class="btn btn-success btn-reservation" onclick="satisRez()">
                <span id="satinaldevam">SATIN AL</span> <i class="fa fa-angle-double-right"></i>

            </button>
        </div>
        <!-- Credit Start-->

        <div id="payment-panel" class="panel panel-default flight-panel reservation-panel payment-panel satinal-panel-container" style="position: relative; display: none;">
            <div class="panel-heading">
                <h1><i class="fa fa-credit-card"></i>Ödeme Bilgileri</h1>
            </div>


            <div class="panel-body">
                <div class="col-xs-12 col-md-6" style="border: 1px solid #63a1d5;">
                    <div class="payment-wrapper">
                        <div class="payment-container clearfix">
                            <div class="card-info">
                                <div class="form-group" style="margin-bottom: 3px;">
                                    <div class="card-taksim-secim-alani">
                                        <div class="col-md-12 col-xs-12" style="padding-left: 3px;" id="KartOzellik">
                                            <div class="text-info" style="padding-top: 7px">Kart Programı:</div>
                                            <div class="">
                                                <div class="input">
                                                    <div class="btn-group">
                                                        <span style="color: green; text-transform: capitalize; font-size: 15px; line-height: 29px; font-weight: bold;" id="spnKartOzellik"></span>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>


                                <div class="form-group card-number-input fastclick" style="margin-bottom: 5px;">
                                    <label for="cardnumber" class="eu-label">Kredi Kartı / ATM - Para Kart Numarası</label>
                                    <input type="text" id="inpOdemeKartNo" class="form-control creditcard krediKarti" autocomplete="off" style="padding-left: 5px;" data-content="Lütfen geçerli bir kredi kartı numarası girin" data-placement="bottom" maxlength="19" data-inputmask="'mask': '9999 9999 9999 9999'">
                                    <i class="card-icon-type eu-icon-flight-card-gray"></i><i class="card-icon-brand"></i>
                                </div>
                                <div class="form-group card-date-input">
                                    <label class="eu-label col-xs-12" id="SonKullanma" for="expiremonth">Son Kullanma Tarihi</label>
                                    <div class="eu-select month col-xs-4" id="ay" style="width: 20%; float: left; margin-right: 5px;">
                                        <select id="spnOdemeKartTarihAy" name="expireMonth" class="form-control">
                                            <option value="01">1</option>
                                            <option value="02">2</option>
                                            <option value="03">3</option>
                                            <option value="04">4</option>
                                            <option value="05">5</option>
                                            <option value="06">6</option>
                                            <option value="07">7</option>
                                            <option value="08">8</option>
                                            <option value="09">9</option>
                                            <option value="10">10</option>
                                            <option value="11">11</option>
                                            <option value="12">12</option>
                                        </select>
                                    </div>
                                    <div class="eu-select year col-xs-4" style="width: 35%; float: left; margin-right: 5px;">
                                        <select id="spnOdemeKartTarihYil" name="expireYear" class="form-control">
                                            <option value="18">2018</option>
                                            <option value="19">2019</option>
                                            <option value="20">2020</option>
                                            <option value="21">2021</option>
                                            <option value="22">2022</option>
                                            <option value="23">2023</option>
                                            <option value="24">2024</option>
                                            <option value="25">2025</option>
                                            <option value="26">2026</option>
                                            <option value="27">2027</option>
                                            <option value="28">2028</option>
                                            <option value="29">2029</option>
                                            <option value="30">2030</option>
                                        </select>
                                    </div>
                                </div>
                                <div class="fastclick">
                                    <div class="form-group card-cvv" style="margin-bottom: 0px;">
                                        <label for="cvc" id="guvenlik" class="eu-label col-xs-4 stilo">CVV</label>
                                        <input placeholder="_ _ _" type="text" id="inpOdemeKartCVC2" class="form-control cvv cvc2" autocomplete="off" data-content="Lütfen kredi kartınızın arkasındaki 3 haneli güvenlik numarasını girin" data-placement="bottom" maxlength="3">
                                        <i class="cvc-icon eu-icon-cwc-code"></i>
                                    </div>
                                    <div class="clearfix"></div>
                                    <div class="form-group card-name">
                                        <label for="cardholder" class="eu-label">Kart Sahibi İsim Soyisim</label>
                                        <input type="text" name="cardHolder" id="inpOdemeKartSahibi" class="form-control required" autocomplete="off" data-content="Lütfen kredi kartınızın üzerindeki ismi girin" data-placement="bottom">
                                    </div>
                                    <div class="form-group">
                                    </div>
                                    <div class="form-group" style="text-align: center;">
                                        <button id="ContentPlaceHolder1_btnSatinAl" class="btn btn-success btn-reservation" style="padding-right: 5px !important;" onclick="satisFinis();">
                                            <span id="spnSatinAl">İŞLEMİ TAMAMLA</span> <i class="fa fa-angle-double-right"></i>
                                            <i class="fa fa-spinner fa-spin" id="btnPreLoad" style="visibility: hidden;"></i>
                                        </button>
                                    </div>
                                    <div class="form-group" style="text-align: center;">
                                        <div class="2" id="_divUyari" style="margin-top: 15px; display: none;">
                                            <div class="alert alert-warning" role="alert"><strong>Hata!</strong> <span id="_spnUyari"></span></div>
                                        </div>
                                    </div>

                                    <div class="clearfix"></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-6 col-xs-12 fastclick" style="padding-left: 15px;">
                    <div class="row">
                        <div class="form-group">
                        </div>
                        <div id="tablo" class="row" style="display: none; margin: 0px; margin-left: 15px; margin-top: -15px;">
                            <table class="table table-bordered installment-table table-hover" id="tablostilo">
                                <thead>
                                    <tr>
                                        <th>Seçim</th>
                                        <th>Taksit Sayısı</th>
                                        <th>Toplam Tutar</th>
                                    </tr>
                                </thead>
                                <tbody id="taksitIcerik">
                                </tbody>
                            </table>
                        </div>
                    </div>


                    <div class="clearfix payment-icons" style="margin-left: 8px;">
                        <link href="../CSS/payment-stil.css" rel="stylesheet">

                        <div class="row">

                            <div class="col-xs-12 col-md-5 imgstilo">
                                <div class="bs-flipper thumbnail" ontouchstart="this.classList.toggle('hover');">
                                    <div class="flipper">
                                        <div class="front">
                                            <img data-src="holder.js/100x180" class="img1stilfront" alt="100x180" src="../images/1.jpg" data-holder-rendered="true">
                                        </div>
                                        <div class="back">
                                            <img data-src="holder.js/100x180" class="img1stilback" alt="100x180" src="../images/1.jpg" data-holder-rendered="true">
                                        </div>
                                    </div>
                                </div>
                            </div>







                            <!-- 4-->



                            <div class="col-xs-12 col-md-5 imgstilo">
                                <div class="bs-flipper thumbnail" ontouchstart="this.classList.toggle('hover');">
                                    <div class="flipper">
                                        <div class="front">
                                            <img data-src="holder.js/100x180" class="imgstilfront" alt="100%x180" src="../images/3.jpg" data-holder-rendered="true">
                                        </div>
                                        <div class="back">
                                            <img data-src="holder.js/100x180" class="imgstilback" alt="100%x180" src="../images/3.jpg" data-holder-rendered="true">
                                        </div>
                                    </div>
                                </div>
                            </div>


                        </div>



                    </div>



                </div>
                <div class="Box-Clean Box-Clean-Info" style="padding: 10px; display: none;">
                    <p>www.bilet11.com üzerinde yapacağınız işlemler, dünyanın önde gelen güvenlik sertifikası şirketi GlobalSign koruması altındadır..</p>
                    <p>
                        www.bilet11.com’dan alınan biletler ile ilgili rezervasyon, biletleme, iptal ve değişiklik işlemleri
                        Bilet11.com
                        tarafından yapılmaktadır.
                    </p>
                    <p>Bilet satın aldığınızda birkaç dakika içinde <b>e-biletiniz</b> eposta adresinize gönderilecektir </p>
                </div>
                <div id="divLoading" class="preload" style="visibility: hidden; z-index: 99999999;">
                    <img src="/../CSS/img/ajax-progress.gif">
                </div>

            </div>

        </div>

        <div class="clear"></div>
    </div>
    <!-- Credit End-->
    <%--<script src="../js/inputmask.extensions.js"></script>--%>
    <script src="../pageScripts/inputMask/js/inputmask.js"></script>
    <%--<script src="../pageScripts/inputMask/js/inputmask.numeric.extensions.js"></script>--%>
    <%--<script src="../pageScripts/inputMask/js/inputmask.phone.extensions.js"></script>--%>
    <%--<script src="../pageScripts/inputMask/js/jquery.inputmask.js"></script>--%>
    <%--<script src="../pageScripts/inputMask/js/dependencyLibs/inputmask.dependencyLib.js"></script>--%>
    <%--<script src="../pageScripts/inputMask/js/dependencyLibs/inputmask.dependencyLib.jquery.js"></script>--%>
    <%--<script src="../pageScripts/inputMask/js/dependencyLibs/inputmask.dependencyLib.jqlite.js"></script>--%>
    <%--<script src="../pageScripts/inputMask/js/dependencyLibs/inputmask.dependencyLib.jquery.js"></script>--%>
    <script src="../pageScripts/inputMask/js/inputmask.date.extensions.js"></script>
    <script src="../pageScripts/inputMask/js/bindings/inputmask.binding.js"></script>
    <script src="../pageScripts/inputMask/dist/jquery.inputmask.bundle.js"></script>
    <script src="../pageScripts/satinAlKontrol.js"></script>






    <script type="text/javascript">
        $(document).ready(function () {


            satinAlRezervalidate();




        });
    </script>

    <iframe name="theFrame" id="theFrame" style="width: 100%; height: 500px; display:none;"></iframe>

</asp:Content>

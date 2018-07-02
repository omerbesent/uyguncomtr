<%@ Page Title="" Language="C#" MasterPageFile="~/anaYapi.Master" AutoEventWireup="true" CodeBehind="Bilet.aspx.cs" Inherits="birSifirUcuzaUc.WebUI.Ucus.Bilet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../pageScripts/bilet.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="load" clientidmode="Static" runat="server">

    </div>
  <%--<div id="bilet-content">
            <div id="bilet-tab" class="ic">
                <ul>

                    <li><a href="/flightsearch.aspx"><span><b class="fa fa-plane"></b>Uçuş İşlemleri</span></a></li>
                    <li class="active"><a href="javascript:void(0)"><span><b class="fa fa-ticket"></b>Sonuç</span></a></li>
                </ul>
                <div class="clear"></div>
            </div>
            <div class="ic resultpage" id="bilet-in">

                <a href="/voucher.aspx?op=view&amp;pnr=2ab5248b-bfdf-426e-a81a-49ffcfd71ad3&amp;email=acikgozali@hotmail.com" onclick="window.open(this.href, '', 'resizable=yes,status=no,location=no,toolbar=no,menubar=no, fullscreen=no,scrollbars=yes,dependent=no,width=800,height=600'); return false;" style="float: right; font-size: 14px; margin-left: 5px" class="btn btn-info"><i class="fa fa-eye"></i>&nbsp;Görüntüle</a>
                <a href="/voucher.aspx?op=createdticket&amp;pnr=2ab5248b-bfdf-426e-a81a-49ffcfd71ad3&amp;email=acikgozali@hotmail.com" onclick="window.open(this.href, '', 'resizable=yes,status=no,location=no,toolbar=no,menubar=no, fullscreen=no,scrollbars=yes,dependent=no,width=800,height=600'); return false;" style="float: right; font-size: 14px;" class="btn btn-warning"><i class="fa fa-print"></i>&nbsp;Yazdır</a>
                <br/>
                Sayın <b>TEST TEST</b>,<br/>
                <br/>
                Bizi tercih ettiğiniz için teşekkür ederiz.<br/>
                Detayları aşağıda belirtilen uçuşunuz/uçuşlarınız için satın almış olduğunuz bilete/biletlere ait rezervasyon kayıt numaranız/numaralarınız <b style="color: #22B509;">A2DJ2A</b> ve <b style="color: #22B509;">K0LQJF</b> olarak düzenlenmiştir.<br/>
                <br/>
                <p style="color: #d30e0e; font-weight: bold;">
                    * Lütfen biletinizin isim, tarih , saat ve parkur bilgisini kontrol ediniz.<br/>
                    * Biletinizdeki isim bilgisi ile pasaport veya kimlikteki bilginizin aynı olması gerekmektedir.
                </p>
                <h3><i class="fa fa-plane"></i>&nbsp;Uçuş Bilgileri</h3>
                <h4 class="dir">Gidiş Uçuşları</h4>
                <table class="resulttable">
                    <thead>
                        <tr>
                            <th>PNR</th>
                            <th>Havayolu</th>
                            <th>Uçuş No</th>
                            <th>Tarih</th>
                            <th>Kalkış</th>
                            <th>Varış</th>
                            <th>Sınıf</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>K0LQJF</td>
                            <td>
                                <img src="http://88.250.178.229:4545/images/airlogo/b/8Q.gif" onerror="this.onerror=null;this.src=http://88.250.178.229:4545/css/no_image.png;" alt="8Q"></td>
                            <td>222</td>
                            <td>03.01.2017</td>
                            <td>Ataturk (IST) <b>10:00</b></td>
                            <td>Antalya (AYT) <b>11:15</b></td>
                            <td>W</td>
                        </tr>
                    </tbody>
                </table>
                <h4 class="dir">Dönüş Uçuşları</h4>
                <table class="resulttable">
                    <thead>
                        <tr>
                            <th>PNR</th>
                            <th>Havayolu</th>
                            <th>Uçuş No</th>
                            <th>Tarih</th>
                            <th>Kalkış</th>
                            <th>Varış</th>
                            <th>Sınıf</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr class="">
                            <td>A2DJ2A</td>
                            <td>
                                <img src="http://88.250.178.229:4545/images/airlogo/b/XQ.gif" onerror="this.onerror=null;this.src=http://88.250.178.229:4545/css/no_image.png;" alt="XQ"></td>
                            <td>7526</td>
                            <td>11.01.2017</td>
                            <td>Antalya (AYT) <b>07:00</b></td>
                            <td>Sabiha Gokcen (SAW) <b>08:20</b></td>
                            <td>I</td>
                        </tr>
                    </tbody>
                </table>
                <br/>
                <h3><i class="fa fa-group"></i>&nbsp;Yolcu Bilgileri</h3>
                <table class="resulttable">
                    <thead>
                        <tr>
                            <th>Yolcu Bilgileri</th>
                            <th>Firma</th>
                            <th>E-Bilet Numarası</th>
                            <th>Firma</th>
                            <th>E-Bilet Numarası</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>Yetişkin, Bay, TEST TEST</td>
                            <td>SunExpress</td>
                            <td>5648440003883&nbsp;<a href="http://88.250.178.229:4545/onlinecheckin.aspx?pnr=A2DJ2A&amp;name=TEST&amp;surname=TEST&amp;prov=3" target="_blank" style="float: right; font-size: 14px; margin-left: 10px;" class="btn btn-success"><i class="fa fa-check-square-o"></i>&nbsp;Check-in</a></td>
                            <td>OnurAir</td>
                            <td>662402003150&nbsp;<a href="http://88.250.178.229:4545/onlinecheckin.aspx?pnr=K0LQJF&amp;name=TEST&amp;surname=TEST&amp;prov=4" target="_blank" style="float: right; font-size: 14px; margin-left: 10px;" class="btn btn-success"><i class="fa fa-check-square-o"></i>&nbsp;Check-in</a></td>
                        </tr>
                    </tbody>
                </table>
                <br/>
                <h3><i class="fa fa-credit-card"></i>&nbsp;Ödeme Bilgileri</h3>
                <div>
                    <table class="resulttable">
                        <thead>
                            <tr>
                                <th">Sayı</th>
                                <th">Tip</th>
                                <th">Ücret</th>
                                <th">Vergi</th>
                                <th">Hizmet Bedeli</th>
                                <th">Genel Toplam</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>1</td>
                                <td>Yetişkin</td>
                                <td>298,99 TL</td>
                                <td>48,47 TL</td>
                                <td>20,00 TL</td>
                                <td>367,46 TL</td>
                            </tr>
                        </tbody>
                    </table>
                    <table style="float: right;">
                        <tbody>
                            <tr>
                                <td>Genel Toplam</td>
                                <td>367,46 TL</td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <br/>
                <br/>
                <p>Uçuş için yukarıda belirtilen rezervasyon kayıt numarası ve fotoğraflı kimliğiniz (yurtdışı uçuşlarında pasaport) yeterlidir. Lütfen uçuşunuzun kalkış saatinden en geç 2 saat önce havaalanında olunuz.</p>
                <br/>
            </div>
        </div>--%>

</asp:Content>

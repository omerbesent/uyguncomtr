<%@ Page Title="" Language="C#" MasterPageFile="~/Admin2/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AddArticle.aspx.cs" Inherits="birSifirUcuzaUc.WebUI.Admin2.AddArticle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/toastr.css" rel="stylesheet" />

    <script src="Scripts/jquery-1.9.1.js"></script> 
    <script src="Scripts/jquery-ui-1.10.4.min.js"></script>
    <script src="ckeditor/ckeditor.js"></script> 
    <script src="Scripts/jquery.fileupload.js"></script>
    <script src="Scripts/toastr.js"></script>
    <script src="CustomScript/AddArticle.js"></script>
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" cellpadding="2" cellspacing="2">
        <tr>
            <td class="pageTitle">Makale Ekle
                <hr />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div id="divResult">
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <table border="0" cellpadding="2" cellspacing="2">
                    <tr>
                        <td>Makale Başlık :
                        </td>
                        <td>
                            <input type="text" style="width: 150px;" id="txtMakaleBaslik" />
                        </td>
                    </tr>

                    <tr>
                        <td>Kısa İçerik :
                        </td>
                        <td>
                            <textarea rows="3" style="width: 300px;"></textarea>
                        </td>
                    </tr>
                    <tr>
                        <td>Makale İçerik:</td>
                        <td>
                            <textarea class="ckeditor" id="ckeditor" name="ckeditor"></textarea>
                        </td>
                    </tr>
                    <tr>
                        <td>Resim :</td>
                        <td>
                            <input type="file" id="fileup_image" />
                            <input type="file" id="fileup_image2" />
                        </td>
                    </tr>
                    <tr>
                        <td valign="top"></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <button type="button" style="width: 75px; height: 25px;" id="btn_save">1</button>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

</asp:Content>

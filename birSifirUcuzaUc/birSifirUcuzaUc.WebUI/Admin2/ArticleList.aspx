<%@ Page Title="" Language="C#" MasterPageFile="~/Admin2/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ArticleList.aspx.cs" Inherits="birSifirUcuzaUc.WebUI.Admin2.ArticleList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/toastr.css" rel="stylesheet" />
    <link href="Styles/table.css" rel="stylesheet" />

    <script src="Scripts/jquery-1.9.1.js"></script>
    <script src="Scripts/jquery-ui-1.10.4.min.js"></script> 
    <script src="Scripts/toastr.js"></script>
    <script src="CustomScript/ArticleList.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" cellpadding="2" cellspacing="2">
        <tr>
            <td colspan="2" class="pageTitle">Makale Yönetimi
                <hr />
            </td>
        </tr>
        <tr>
            <td colspan="2" class="warning">* Makale düzenleme veya silme işlemlerini buradan yapabilirsiniz.
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div id="divResult">
                    <asp:Label ID="lblResult" ForeColor="Green" runat="server" />
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="2">Makale tanımlamayı <a href="AddArticle.aspx">buradan</a> yapabilirsiniz.
                <br />
                <br />
                <table class="blueTable" id="tbl_makale">
                    <thead>
                        <tr>
                            <th>Kapak Resim</th>
                            <th>Başlık</th>
                            <th>Kısa İçerik</th>
                            <th>Nereden</th>
                            <th>Nereye</th>
                            <th>İşlemler</th>
                        </tr>
                    </thead>
                    <%--  <tfoot>
                        <tr>
                            <td colspan="4">
                                <div class="links"><a href="#">&laquo;</a> <a class="active" href="#">1</a> <a href="#">2</a> <a href="#">3</a> <a href="#">4</a> <a href="#">&raquo;</a></div>
                            </td>
                        </tr>
                    </tfoot>--%>
                    <tbody>
                        <tr>
                            <td>cell1_1</td>
                            <td>cell2_1</td>
                            <td>cell3_1</td>
                            <td>cell4_1</td>
                            <td>cell4_1</td>
                            <td>Sil | Güncelle</td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

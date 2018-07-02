<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="articleList.aspx.cs" Inherits="birSifirUcuzaUc.WebUI.Admin.articleList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="script/articleList.js"></script>
    <style>
        div.scrollable {
            width: 600px;
            height: 100px;
            margin: 0;
            padding: 0;
            overflow: auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">

        <div class="speedbar">
            <div class="speedbar-nav"><a href="#">Uygun Admin Panel</a> &rsaquo; <a href="#">Makale Listesi</a></div>

            <div class="search">
                <form>
                    <input type="text">
                </form>
            </div>
        </div>

        <!-- içeriği bu aralığa ekle start -->
        <div class="grid-1">
            <div class="title-grid">Makaleler</div>
            <div class="content-gird">
                <table class="display" id="tblMakaleler">
                    <thead>
                        <tr>
                            <th class="th_title">Başlık</th>
                            <th class="th_status">İçerik</th>
                            <th class="th_date">Tarih</th>
                            <th class="th_date" style="width:80px">İşlem</th>
                        </tr>
                    </thead>
                    <tbody>
                        <%--<tr class="item">
                        <td class="subject"><a href="#">Supercar with 1,250 horsepower</a></td>
                        <td><span class="published">Published</span></td>
                        <td>26th August 2011</td>
                        <td class="action"><a href="#"><img src="images/del.png" alt="delete" title="delete"></a> <a href="#"><img src="images/del.png" alt="edit" title="edit"></a></td>
                    </tr>--%>
                    </tbody>
                </table>

            </div>
        </div>
        <!--Table Styling end-->
        <!-- içeriği bu aralığa ekle end -->

    </div>
    <!-- #content-->
</asp:Content>

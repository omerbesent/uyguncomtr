<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="addArticle.aspx.cs" Inherits="birSifirUcuzaUc.WebUI.Admin.addArticle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="script/jquery.fileupload.js"></script>
    <%--<script src="../pageScripts/flightSearch.js"></script>--%>
    <script src="script/addArticle.js"></script>
    <style>
        ul#inpAirportOneri1 {
            background-color: lightblue;
        }

        ul#inpAirportOneri2 {
            background-color: lightblue;
        }

        .dropdown-menu {
            position: absolute;
            /*top: 100%;
            left: 0;*/
            z-index: 1000;
            display: none;
            float: left;
            min-width: 160px;
            padding: 5px 0;
            margin: 2px 0 0;
            font-size: 13px;
            text-align: left;
            list-style: none;
            background-color: #fff;
            -webkit-background-clip: padding-box;
            background-clip: padding-box;
            border: 1px solid #ccc;
            border: 1px solid rgba(0,0,0,.15);
            border-radius: 4px;
            -webkit-box-shadow: 0 6px 12px rgba(0,0,0,.175);
            box-shadow: 0 6px 12px rgba(0,0,0,.175);
        }

        .open > .dropdown-menu {
            display: block;
        }

        element.style {
            margin-left: 15px;
        }

        p, ul, ol, pre {
            color: #424242;
            font-size: 12px;
            font-family: Helvetica, Arial, sans-serif;
            line-height: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">

        <div class="speedbar">
            <div class="speedbar-nav"><a href="#">Uygun Admin Panel</a> &rsaquo; <a href="#">Makale Ekle</a></div>

        </div>


        <!--WYSIWYG Editor-->
        <div class="grid-1">
            <div class="title-grid">Makale</div>
            <div class="content-gird">
                <div class="elem">
                    <label>Makale Başlık : </label>
                    <div class="indent">
                        <input type="text" id="txtArticleHeader" name="name" class="medium" />
                    </div>
                </div>
                <textarea id="editor"></textarea>
                <br />
                <div>
                    <input type="file" class="upload" id="FileUpload1" />
                    <img id="myUploadedImg" alt="Photo" style="width: 180px;" />
                    <%--<lable for="fileUpload" class="upload-button-mask">Upload</lable>--%>
                </div>
                <br />
                <div>
                    <div id="divAirPortSearch1" class="input-group">
                        <label>Kalkış : </label>
                        <input id="inpNereden" type="text" name="dep-city" class="form-control" autocomplete="off" onchange="javascript:myFunction(this)" required placeholder="Kalkış Yeri.." />
                        <input type="hidden" id="inpNeredenAirportCode" value="" />
                        <input type="hidden" id="inpNeredenCountryCode" value="" />
                        <input type="hidden" id="inpNeredenCountryName" value="" />
                        <input type="hidden" id="inpNeredenCityName" value="" />
                        <ul id="inpAirportOneri1" onmouseenter="mouseEnter(this)" onmouseleave="mouseLeave(this)" class="dropdown-menu" style="margin-left: 15px;">
                            <li><a id="anchor_IST" onclick="selectNeredenEvent(this, 'ISTTR', 'TR', 'Istanbul');"><i class="fa fa-angle-right"></i>Istanbul - Türkiye (Ataturk-IST)</a></li>
                        </ul>
                        <span class="input-group-addon"><i class="fa fa-map-marker fa-fw"></i></span>
                    </div>
                    <%--   <label>Kalkış : </label>
                    <input type="text" id="inpNereden" name="name" class="small" />--%>
                    <%--<label>Varış : </label>
                    <input type="text" id="inpNereye" name="name" class="small" />--%>
                    <%--<label>Leaving To</label>--%>
                    <div id="divAirPortSearch2" class="input-group">
                        <label>Varış : </label>
                        <input id="inpNereye" type="text" name="des-city" class="form-control" autocomplete="off" required placeholder="Gidiş Yeri.." />
                        <input type="hidden" id="inpNereyeAirportCode" value="" />
                        <input type="hidden" id="inpNereyeCountryCode" value="" />
                        <input type="hidden" id="inpNereyeCityName" value="" />
                        <ul id="inpAirportOneri2" onmouseenter="mouseEnter(this)" onmouseleave="mouseLeave(this)" class="dropdown-menu" style="margin-left: 15px;"></ul>
                        <span class="input-group-addon"><i class="fa fa-map-marker fa-fw"></i></span>
                    </div>
                </div>
                <%--  <form id="form2" runat="server">

                    <div style="padding: 40px">

                        <asp:FileUpload ID="FileUpload1" runat="server" />

                    </div>

                </form>
                <script type="text/javascript">

                    $(window).load(

                        function () {

                            $("#<%=FileUpload1.ClientID %>").fileUpload({

                                'uploader': 'scripts/uploader.swf',

                                'cancelImg': 'images/cancel.png',

                                'buttonText': 'Browse Files',

                                'script': 'Upload.ashx',

                                'folder': 'uploads',

                                'fileDesc': 'Image Files',

                                'fileExt': '*.jpg;*.jpeg;*.gif;*.png',

                                'multi': true,

                                'auto': true

                            });

                        }
                                );
                </script>--%>
                <%-- <body>

                    <input type="file" id="myFile" multiple size="50" onchange="myFunction()">
                    <br>
                    <img src="" id="yourImgTag" width="200" style="display: none;" />
                    <br />
                    <div id="disp_tmp_path"></div>
                    <p id="demo"></p>

                    <script>

                        function myFunction() {
                            //$('#myFile').change(function (event) {
                            //    var tmppath = URL.createObjectURL(event.target.files[0]);
                            //    $("img").fadeIn("fast").attr('src', URL.createObjectURL(event.target.files[0]));

                            //    $("#disp_tmp_path").html("Temporary Path(Copy it and try pasting it in browser address bar) --> <strong>[" + tmppath + "]</strong>");
                            //});

                            //var input = document.getElementById("myFile");
                            //var fReader = new FileReader();
                            //fReader.readAsDataURL(input.files[0]);
                            //fReader.onloadend = function (event) {
                            //    var img = document.getElementById("yourImgTag");
                            //    img.src = event.target.result;
                            //}

                            //return false;
                            //alert($('input[type=file]').val());
                            var x = document.getElementById("myFile");
                            var txt = "";
                            if ('files' in x) {
                                if (x.files.length == 0) {
                                    txt = "Select one or more files.";
                                } else {
                                    for (var i = 0; i < x.files.length; i++) {
                                        var tmppath = URL.createObjectURL(event.target.files[0]);
                                        txt += "<br><strong>" + (i + 1) + ". file</strong><br>";
                                        var file = x.files[i];
                                        if ('name' in file) {
                                            txt += "name: " + file.name + "<br>";
                                        }
                                        if ('size' in file) {
                                            txt += "size: " + file.size + " bytes <br>";
                                        }
                                    }
                                }
                            }
                            else {
                                if (x.value == "") {
                                    txt += "Select one or more files.";
                                } else {
                                    txt += "The files property is not supported by your browser!";
                                    txt += "<br>The path of the selected file: " + x.value; // If the browser does not support the files property, it will return the path of the selected file instead.
                                }
                            }
                            document.getElementById("demo").innerHTML = txt;
                        }
                    </script>

                    <p><strong>Tip:</strong> Use the Control or the Shift key to select multiple files.</p>

                </body>--%>

                <br />
                <a class="button-a red" href="javascript:makaleKaydet()" id="btnSave"><span class="edits icon-white-text" id="lblSave">Save</span></a>
            </div>

        </div>
        <!--WYSIWYG Editor end-->



        <div class="clear"></div>
    </div>
    <!-- #content-->
</asp:Content>

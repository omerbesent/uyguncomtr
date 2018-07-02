<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="birSifirUcuzaUc.WebUI.Admin.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <title>Uygun Admin Panel | Login</title>
    <meta name="description" content="">
    <link rel="shortcut icon" href="images/favicon.ico" />

    <link rel="stylesheet" href="css/validationEngine.jquery.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="css/login.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Cuprum" />

    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.4.4/jquery.min.js"></script>

    <script src="lib/jquery.validationEngine.js" type="text/javascript" charset="utf-8"></script>
    <script src="lib/jquery.validationEngine-en.js" type="text/javascript" charset="utf-8"></script>
    <script src="script/loginScript.js"></script>
    <script>
        jQuery(document).ready(function () {
            // binds form submission and fields to the validation engine
            jQuery("#form-login").validationEngine();
        });


    </script>
    <!--[if lt IE 9]>
	<script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
	<![endif]-->
</head>
<body>
    <section id="form">
        <%--<form id="form-login" class="formular">--%>
        <div id="form-login" class="formular">
            <div id="content-header">

                <p id="logo">Admin Panel Login</p>
                <p>To log into the admin panel, type your password and log.</a></p>
            </div>

            <div id="content">

                <input type="text" name="username" id="req" class="validate[required] text-input" placeholder="Username"><br>
                <br>
                <input type="text" name="pass" id="pass" class="validate[required] text-input" placeholder="Password" autocomplete="off"><br>
                <br>

                <div class="buttons">
                    <input class="button-a gray" value="Forgot your password?">
                    <input class="button-a red" value="LOG IN" onclick="adminGiris();">
                    <%--onclick="adminGiris();"--%>
                </div>
            </div>
        </div>
        <%--</form>--%>
    </section>
</body>
</html>

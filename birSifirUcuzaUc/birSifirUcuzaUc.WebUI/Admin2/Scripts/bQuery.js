

/* bQuery - 2010
**************************************
* Javascript Library
* Burc AKBAS - www.burcakbas.com
**************************************
*/


function Redirect(url) {
    window.location = url;
}
function openWindow(url) {
    window.open(url, "");
}
function openPage(url, width, height) {
    window.open(url, "", "menubar=0,width=" + width + ",height=" + height + ",status=no,location=no,resizable=no,toolbar=no,left=200,top=150,directories=no,titlebar=no");
}

/* Tipsy */

$(function () {
    $('[alt=tipsy]').tipsy({ gravity: 'sw' });
})


/* JQuery UI Highlight */

/* Requires :

(function ($) {
$.fn.writeError = function (message) {
return this.each(function () {
var $this = $(this);

var errorHtml = "<div class=\"ui-widget\">";
errorHtml += "<div class=\"ui-state-error ui-corner-all\" style=\"padding: 0 .7em;\">";
errorHtml += "<p>";
errorHtml += "<span class=\"ui-icon ui-icon-alert\" style=\"float:left; margin-right: .3em;\"></span>";
errorHtml += message;
errorHtml += "</p>";
errorHtml += "</div>";
errorHtml += "</div>";

$this.html(errorHtml);
});
}
})(jQuery);
;

(function ($) {
$.fn.writeAlert = function (message) {
return this.each(function () {
var $this = $(this);

var alertHtml = "<div class=\"ui-widget\">";
alertHtml += "<div class=\"ui-state-highlight ui-corner-all\" style=\"padding: 0 .7em;\">";
alertHtml += "<p>";
alertHtml += "<span class=\"ui-icon ui-icon-info\" style=\"float:left; margin-right: .3em;\"></span>";
alertHtml += message;
alertHtml += "</p>";
alertHtml += "</div>";
alertHtml += "</div>";

$this.html(alertHtml);
});
}
})(jQuery);
 
*/

/* Information messages - appends a div */

function ShowUIHighlightInfo(id, message) {
    $(function () {
        $(id).writeAlert(message).fadeIn("slow").delay(10000).fadeOut("slow");
    });
}

function ShowUIHighlightError(id, message) {
    $(function () {
        $(id).writeError(message).fadeIn("slow").delay(10000).fadeOut("slow");
    });
}

/* UI Buttons */

$(function () {
    $(".uibutton").button();
});

/* Modal confirm dialog */

$().ready(function () {

    var $confirmDialog = $('<div id="uiConfirm"></div>').
		html("<br/>Lütfen devam etmek istediğinizi onaylayın.<br/><br/>Devam etmek istiyor musunuz ?").
			dialog({
			    autoOpen: false,
			    bgiframe: true,
			    title: "Dikkat !",
			    modal: true,
			    open: function (type, data) {
			        $(this).parent().appendTo("form:first");
			    }
			});

});

function uiConfirm(uniqueID) {

    $('#uiConfirm').dialog('option', 'buttons',
				{
				    "Evet": function () {
				        __doPostBack(uniqueID, '');
				        $(this).dialog("close");
				    },
				    "Hayır": function () {
				        $(this).dialog("close");
				    }
				});

    $('#uiConfirm').dialog('open');

    return false;
}

///* fancybox */

//$(document).ready(function () {
//    //$('.fancybox').fancybox();
//    $('a[rel=galleria]').fancybox({
//        openEffect: 'elastic',
//        closeEffect: 'elastic',
//        prevEffect: 'fade',
//        nextEffect: 'fade',
//        closeBtn: true,
//        helpers: {
//            title: {
//                type: 'outside'
//            },
//            buttons: {}
//        },

//        afterLoad: function () {
//            this.title = 'Image ' + (this.index + 1) + ' of ' + this.group.length + (this.title ? ' - ' + this.title : '');
//        }
//    });
//});

/* top arrow */

$(document).ready(function () {
    $('.toparrow').click(function () {
        $('html, body').animate({ scrollTop: 0 }, 'slow'); return false;
    });
});

/* blur on hover */

$(function () {
    $(".imgf").css("opacity", "1.0");
    $(".imgf").hover(function () {
        $(this).stop().animate({
            opacity: 0.5
        }, "slow");
    },
function () {
    $(this).stop().animate({
        opacity: 1.0
    }, "slow");
});
});

/* Swap Image */

function MM_swapImgRestore() { //v3.0
    var i, x, a = document.MM_sr; for (i = 0; a && i < a.length && (x = a[i]) && x.oSrc; i++) x.src = x.oSrc;
}

function MM_preloadImages() { //v3.0
    var d = document; if (d.images) {
        if (!d.MM_p) d.MM_p = new Array();
        var i, j = d.MM_p.length, a = MM_preloadImages.arguments; for (i = 0; i < a.length; i++)
            if (a[i].indexOf("#") != 0) { d.MM_p[j] = new Image; d.MM_p[j++].src = a[i]; }
    }
}

function MM_findObj(n, d) { //v4.01
    var p, i, x; if (!d) d = document; if ((p = n.indexOf("?")) > 0 && parent.frames.length) {
        d = parent.frames[n.substring(p + 1)].document; n = n.substring(0, p);
    }
    if (!(x = d[n]) && d.all) x = d.all[n]; for (i = 0; !x && i < d.forms.length; i++) x = d.forms[i][n];
    for (i = 0; !x && d.layers && i < d.layers.length; i++) x = MM_findObj(n, d.layers[i].document);
    if (!x && d.getElementById) x = d.getElementById(n); return x;
}

function MM_swapImage() { //v3.0
    var i, j = 0, x, a = MM_swapImage.arguments; document.MM_sr = new Array; for (i = 0; i < (a.length - 2); i += 3)
        if ((x = MM_findObj(a[i])) != null) { document.MM_sr[j++] = x; if (!x.oSrc) x.oSrc = x.src; x.src = a[i + 2]; }
}

//Usage

//<a href="#" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('urun_katalogu','','images/urun_katalogu_btnb.png',0)">
//    <img src="images/urun_katalogu_btna.png" name="urun_katalogu" width="139" height="58" border="0" id="urun_katalogu" />
//</a>

//<a href="#" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Kamupanya','','images/kamupanya_hakkinda_btnb.png',1)">
//    <img src="images/kamupanya_hakkinda_btna.png" name="Kamupanya" width="187" height="58" border="0" id="Kamupanya" />
//</a>

/*----------------------------------------*/


/*----- IE 6-7 z-index Bug ------*/

//        $(function () {
//            var zIndexNumber = 1000;
//            $('div').each(function () {
//                $(this).css('zIndex', zIndexNumber);
//                zIndexNumber -= 10;
//            });
//        });


/* Browser PopUp */

function popUp(URL) {
    day = new Date();
    id = day.getTime();
    eval("page" + id + " = window.open(URL, '" + id + "', 'toolbar=0,scrollbars=1,location=0,statusbar=0,menubar=0,resizable=0,width=600,height=450,left = 440,top = 212');");
}
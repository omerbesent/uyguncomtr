
var makaleId = null;

$(document).ready(function () {


    makaleId = getParameterByName('MakaleID');//url den queryString değeri getirir.
    if (makaleId != null) {
        $('#btn_save').text('Güncelle')
        var query = JSON.stringify({ id: makaleId });
        $.ajax({
            type: "POST",
            url: "addArticle.aspx/makaleGetir",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: query,
            success: function (data) {
                var d = JSON.parse(data.d);
                if (d.status == 500) {
                    alert(d.message);
                }
                else if (d.status == 200) {
                    $('#txtMakaleBaslik').val(d.data.illerBaslik);
                    CKEDITOR.instances['ckeditor'].setData(d.data.illerMakale);
                }
            },
            error: function (xhr, err) {
                alert(err);
            }
        });

    } else
        $('#btn_save').text('Kaydet')




    $('#fileup_image').fileupload({
        dataType: 'json',
        url: 'ImageUpload.ashx',
        type: 'POST',
        contentType: false,
        cache: false,
        processData: false,
        add: function (e, data) {
            $('#btn_save').off('click').on('click', function () {

                //var jsondata = JSON.stringify({ pageCode: _functionName, primaryCode: primaryCode, lineType: lineType, lineID: lineID, documentType: documentType, fileName: '', user: _user, organization: _organization }); 
                //$('#fileup_image').data().blueimpFileupload.options.url = 'ImageUpload.ashx?jsondata=' + jsondata;

                $('#fileup_image').data().blueimpFileupload.options.url = 'ImageUpload.ashx';

                var jqXHR = data.submit();

                $("#fileup_image").html(data.files[0].name);
            });
            $("#fileup_image").html(data.files[0].name);
        },
        complete: function (data) {
            var d = JSON.parse(data.responseText);
            if (d.status == 200) {
                makaleKaydet(d.savePath)
            } else if (d.status == 500) {
                toastr["error"](d.msg);
            }
        },
    });

    $('#btn_save').on('click', function () {
        if ($("#fileup_image")[0].files.length == 0)
            toastr['error']('resim seç');
    });

});


function makaleKaydet(kapakResmi) {

    var baslik = $('#txtMakaleBaslik').val();
    var icerik = CKEDITOR.instances['ckeditor'].getData();

    var query = JSON.stringify({ baslik: baslik, icerik: icerik, makaleId: makaleId, makaleKapakResmi: kapakResmi });
    $.ajax({
        type: "POST",
        url: "AddArticle.aspx/makaleKaydet",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: query,
        success: function (data) {
            var d = JSON.parse(data.d);
            if (d.status == 500) {
                alert(d.message);
            }
            else if (d.status == 200) {
                alert('başarılı')
            }
        },
        error: function (xhr, err) {
            alert(err);
        }
    });
}

//url den queryString değeri getirir.
function getParameterByName(name, url) {
    if (!url) url = window.location.href;
    name = name.replace(/[\[\]]/g, "\\$&");
    var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, " "));
}


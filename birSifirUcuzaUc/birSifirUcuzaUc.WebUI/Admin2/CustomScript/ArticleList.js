
$(document).ready(function () {

    makaleListele();
})



function makaleListele() {
    $.ajax({
        type: "POST",
        url: "ArticleList.aspx/makaleListesi",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        //data: query,
        success: function (data) {
            var d = JSON.parse(data.d);
            if (d.status == 500) {
                alert(d.message);
            }
            else if (d.status == 200) {
                $('#tbl_makale tbody').empty();

                if (d.data != null) {
                    var tableRows = '';
                    for (i = 0; i < d.data.length; i++) {
                        tableRows += '<tr>' + 
                            '<td><img src="' + (d.data[i].illerKapakResim == null ? '' : d.data[i].illerKapakResim.replace('~','..')) + '" style="height:100px" /></td>' +
                            '<td>' + (d.data[i].illerBaslik == null ? '' : d.data[i].illerBaslik) + '</td>' +
                            '<td></td>' +
                            '<td></td>' +
                            '<td></td>' +
                            '<td><a href="javascript:makaleSil(' + d.data[i].illerID + ')" >Sil</a> | <a href="AddArticle.aspx?MakaleID=' + d.data[i].illerID + '">Güncelle</a></td>' +
                            '</tr>';

                    }
                    $('#tbl_makale tbody').append(tableRows);
                }
            }
        },
        error: function (xhr, err) {
            alert(err);
        }
    });
}

function makaleSil(makaleId) {

    if (!UserDeleteConfirmation())
        return false;

    var query = JSON.stringify({ makaleId: makaleId });
    $.ajax({
        type: "POST",
        url: "ArticleList.aspx/makaleSil",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: query,
        success: function (data) {
            var d = JSON.parse(data.d);
            if (d.status == 500) {
                alert(d.message);
            }
            else if (d.status == 200) {
                makaleListele();
                alert('silindi')
            }
        },
        error: function (xhr, err) {
            alert(err);
        }
    });
}

function UserDeleteConfirmation() {
    return confirm("Makaleyi silmek istediğinizden emin misiniz?");
}
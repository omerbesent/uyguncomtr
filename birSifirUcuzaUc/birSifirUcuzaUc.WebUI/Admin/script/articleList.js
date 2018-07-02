makaleListele();

function makaleListele() {
    $.ajax({
        type: "POST",
        url: "articleList.aspx/makaleListesi",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        //data: query,
        success: function (data) {
            var d = JSON.parse(data.d);
            if (d.status == 500) {
                alert(d.message);
            }
            else if (d.status == 200) {
                $('#tblMakaleler tbody').empty();

                if (d.data != null) {
                    var tableRows = '';
                    for (i = 0; i < d.data.length; i++) {
                        tableRows += '  <tr class="item"> ' +
                            '<td class="subject"><a href="#">' + d.data[i].illerBaslik + '</a></td>' +
                            '<td><div class="scrollable">' + d.data[i].illerMakale + '</div></td>' +
                            '<td>' + d.data[i].illerTarih + '</td>' +
                            '<td class="action"><a href="#"><img style="width: 17px;" src="images/del.png" alt="delete" title="delete" onclick="makaleSil(' + d.data[i].illerID + ')"></a> &nbsp;&nbsp;&nbsp; <a href="addArticle.aspx?MakaleID=' + d.data[i].illerID + '"><img style="width: 20px;" src="images/update.png" alt="edit" title="edit"></a></td>' +
                        '</tr>';
                    }
                    $('#tblMakaleler tbody').append(tableRows);
                }
            }
        },
        error: function (xhr, err) {
            alert(err);
        }
    });
}

function makaleSil(makaleId) {

    var query = JSON.stringify({ makaleId: makaleId });
    $.ajax({
        type: "POST",
        url: "articleList.aspx/makaleSil",
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
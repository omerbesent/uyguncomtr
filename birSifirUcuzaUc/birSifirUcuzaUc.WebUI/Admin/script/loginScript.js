$(window).load(function () {
    // run code

});

function adminGiris() {

    var kulAdi = $('#req').val();
    var pass = $('#pass').val();

    if (kulAdi.length <= 0) {
        alert('Kullanıcı adını doldurun..');
        return false;
    }
    if (pass <= 0) {
        alert('Parolanızı yazın..');
        return false;
    }

    var query = JSON.stringify({ kulAdi: kulAdi, pass: pass });
    $.ajax({
        type: "POST",
        url: "login.aspx/adminGiris",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: query,
        success: function (data) {
            var d = JSON.parse(data.d);
            if (d.status == 500) {
                alert(d.message);
            }
            else if (d.status == 200) {
                //alert('başarılı')
                window.location = 'dashboard.aspx';
            }
        },
        error: function (xhr, err) {
            alert(err);
        }
    });

}
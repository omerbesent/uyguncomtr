function ShowLoading(element) {
    element.showLoading();
}

function HideLoading(element) {
    element.hideLoading();
}

$(document).ajaxStart(function () {
    ShowLoading($('.container'));
});

$(document).ajaxSuccess(function () {
    HideLoading($('.container'));
});

$(document).ajaxError(function () {
    HideLoading($('.container'));
});

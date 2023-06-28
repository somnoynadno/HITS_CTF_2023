// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(init);

function init() {
    $.ajaxSetup({
        contentType: 'application/json'
    });
    setGlobalListeners();
}

function setGlobalListeners() {
    $("[return]").on("click", (e) => {
        window.history.back();
    })
    $(document).on("keyup", (e) => {
        if (e.key === "Escape") {
            $(".modal").modal('hide');
        }

    })
}
function baseUrl() {
    return window.location.protocol + "//" + window.location.host;
}
// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function loadingBegin(divName) {
    var body = document.querySelector("." + divName);
    var loaderDiv = document.createElement("div");
    loaderDiv.className = "loader";

    var loadDiv = document.createElement("div");
    loadDiv.className = "load";
    loadDiv.appendChild(document.createElement("hr"));
    loadDiv.appendChild(document.createElement("hr"));
    loadDiv.appendChild(document.createElement("hr"));
    loadDiv.appendChild(document.createElement("hr"));

    loaderDiv.appendChild(loadDiv);

    body.appendChild(loaderDiv);
    $("." + divName).addClass("load-block");
}

//yükleniyor efektini sonlandırma
function loadingEnd(divName) {
    $(".loader").remove();
    $("." + divName).removeClass("load-block");
}
//Uyarı mesajlarının gösterilmesi
function toastMessage(type, message, possition) {

    var timeOut = "5000";
    if (type == "") {
        type = "success";
    }
    if (possition == "") {
        possition = "toast-top-right";
    }

    if (type != "success") {
        timeOut = "10000";
    }
    toastr.options = {
        "closeButton": false,
        "debug": false,
        "newestOnTop": false,
        "progressBar": true,
        "positionClass": possition,
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }
    Command: toastr[type](message);
}

function setCookie(cname, cvalue, exdays) {
    const d = new Date();
    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
    let expires = "expires=" + d.toUTCString();
    document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
}
function getCookie(cname) {
    let name = cname + "=";
    let decodedCookie = decodeURIComponent(document.cookie);
    let ca = decodedCookie.split(';');
    for (let i = 0; i < ca.length; i++) {
        let c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}
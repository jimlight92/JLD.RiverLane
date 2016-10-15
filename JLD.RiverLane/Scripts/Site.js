$(function () {
    'use strict';

    setInterval(function () {
        $("#body-content").css("top", ((0.38 * window.innerWidth) ) + "px");
    }, 1000);

    for (var i = 1; i <= numberOfImages; i++) {
        $("#slideshow").append("<div class='jumbotronContainer' style='background-image: " + GetImageUrl(i) + "'></div>")
    }

    setInterval(function () {
        $('#slideshow > div:first')
          .insertAfter($("#slideshow").children().last())
    }, 4000);

    $("input.date-picker").datepicker({
        format: 'dd/mm/yyyy',
        forceParse: false,
        autoclose: true
    });

})

function GetImageUrl(count) {
    return "url(" + rootUrl + "Content/Images/" + bannerFolder + "/" + count + ".jpg)";
}
$(function () {
    "use strict";
    
    setInterval(function () {
        $("#slideshow > img:first")
            .insertAfter($("#slideshow").children().last());
    }, 4000);

    $("input.date-picker").datepicker({
        format: 'dd/mm/yyyy',
        forceParse: false,
        autoclose: true
    });

})
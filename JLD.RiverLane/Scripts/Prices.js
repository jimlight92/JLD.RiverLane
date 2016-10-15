$(function () {

    $(".price-more-info").on('click', function () {

        if ($(this).html().indexOf('More') > -1) {
            $(this).html('Less Info <span class="caret"></span>');
            $(this).parent().addClass('dropup');
        } else {
            $(this).html('More Info <span class="caret"></span>');
            $(this).parent().removeClass('dropup');
        }

    })

})
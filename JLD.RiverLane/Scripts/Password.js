

$(function () {

    $(".newPassword").on("keyup", function () {

        var regex = /(^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8}.*$)/;
        var match = regex.exec($(this).val());
        var success = match != null && match.length > 0;

        UpdateOnChange($(this), success);
        UpdateOnChange($(".confirmPassword"), success && $(this).val() == $(".confirmPassword").val());

    });

    $(".confirmPassword").on("keyup", function () {
        UpdateOnChange($(this), $(this).val() == $(".newPassword").val());
    });

})

function UpdateOnChange(input, success) {
    if (success) {
        $(input).parent().addClass("has-success").removeClass("has-error").find(".glyphicon").
            addClass("glyphicon-ok text-success").
            removeClass("glyphicon-remove text-danger")
    } else {
        $(input).parent().removeClass("has-success").addClass("has-error").find(".glyphicon").
            addClass("glyphicon-remove text-danger").
            removeClass("glyphicon-ok text-success")
    }
}

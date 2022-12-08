 src="https://code.jquery.com/jquery-3.6.1.min.js"



    $("#gonder").click(function () {

        let result = {
            names: $("#names").val(),
            konu: $("#konu").val(),
            yorum: $("#yorum").val()
        };
        $.ajax({
            type: "post",
            url: "/Comment/PartialAddComment/",
            data: result,
            success: function (func) {
                let sonuc = jQuery.parseJSON(func);
            }
        });
    });
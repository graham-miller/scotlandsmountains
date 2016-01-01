var ScotlandsMountains = (function (sm, $) {

    sm.showInDialog = function (title, view) {

        $("#dialog").html('<i class="fa fa-spinner fa-spin"></i>');

        $.ajax({
            url: "/Home/" + view,
            success: function (data) { $("#dialog").html(data); },
            });

        var height = $("#map").height() - 10;
        var width = $("#map").width() - 20;

        height = (height > 600 ? 600 : height);
        width = (width > 800 ? 800 : width);

        $("#dialog").dialog({
            height: height,
            width: width,
            modal: true,
            title: title,
            resizable: false,
            draggable: false,
            buttons: [{
                text: "Close",
                click: function() { $(this).dialog("close").html(""); }
            }],
        });

    };

    return sm;

})(ScotlandsMountains || {}, jQuery);
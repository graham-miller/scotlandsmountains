var ScotlandsMountains = (function (sm, $) {

    sm.initializeSearch = function () {

        $("#search").autocomplete({
            minLength: 2,
            source: function(request, response) {
                var url = "/api/mountains/search?term=" + request.term;
                try {
                    $.ajax(
                        url,
                        {
                            success: function(results) {
                                response(results.Data);
                            },
                            error: function() {
                                response([]);
                            }
                        });
                } catch(e) {
                    response([]);
                }
            },
            focus: function(event, ui) {
                event.preventDefault();
            },
            select: function(event, ui) {
                event.preventDefault();
                window.location.href = "#/mountains/" + ui.item.id + "/" + ui.item.name;
            },
            close: function(event, ui) {
                $("#search").val("");
            }
        })
        .data("ui-autocomplete")._renderItem = function (ul, item) {
            return $('<li class="search-result">')
               .append(
                   '<a>' +
                       '<div title="' + item.name + '">' + item.name + '</div>' +
                       '<div title="' + item.description + '">' + item.description + '</div>' +
                   '</a>')
               .appendTo(ul);
        };
    };

    return sm;

})(ScotlandsMountains || {}, jQuery);
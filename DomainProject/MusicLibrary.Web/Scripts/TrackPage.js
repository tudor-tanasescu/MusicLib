$(document).ready(function() {
    $(".likeButton").click(function() {
        var url;
        var id = $(".likeButton").parent().parent().attr("trackId");

        var $btn = $(this);

        if ($($btn.children("span")[0]).attr("title") === "Like") {
            url = "/Track/Like/";
        } else {
            url = "/Track/Unlike/";
        }

        $.ajax({
            url: url,
            data: { trackId: id },
            type: "POST"
        }).done(function(data, textStatus, jqXhr) {
            if (textStatus === "success") {
                if ($($btn.children("span")[0]).attr("title") === "Like") {
                    $btn.html('<span class="glyphicon glyphicon-heart" title="Unlike"></span>');
                } else {
                    $btn.html('<span class="glyphicon glyphicon-heart-empty" title="Like"></span>');
                }
            }
        });
    });
});


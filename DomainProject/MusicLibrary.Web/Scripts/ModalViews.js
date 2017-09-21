$(document).ready(function () {

    $(document).on("submit", ".post-using-ajax", function (e) {
        e.preventDefault();

        var $frm = $(this);

        $.ajax({
            type: $frm.attr("method"),
            url: $frm.attr("action"),
            data: $frm.serialize(),
            success: function (msg) {

                if ($frm.hasClass("addToForm")) {
                    var $btn = $($frm.children(".addToPlaylistButton")[0]);

                    if ($btn.text().trim() === "Remove") {
                        $btn.text("Add");
                        $frm.attr("action", "/Playlist/AddToExistingPlaylist/");
                    }
                    else if ($btn.text().trim() === "Add") {
                        $btn.text("Remove");
                        $frm.attr("action", "/Playlist/RemoveFromPlaylist/");
                    }
                }

                $frm.trigger("submitOk", { msg:"ok" });
            }
        });
    });

    $(document).on("click", ".addToButton", function () {

        var id = $(this).parent().parent().attr("trackId");

        var url = "/Playlist/AddToPlaylists/";

        $("#existing").load(url+"?trackId="+id, function (responseTxt, statusTxt, xhr) {
            if (statusTxt === "success") {
                $(".trackIdContainer").attr("value", id);
                //console.log(responseTxt);
            }
            if (statusTxt === "error")
                alert("Error: " + xhr.status + ": " + xhr.statusText);
        });

        $("#NewPlaylistName").val("");
        $(".nav-tabs a[href='#existing']").tab("show");
    });
});
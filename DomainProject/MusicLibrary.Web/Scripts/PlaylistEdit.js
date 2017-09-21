$(document).ready(function () {
    $("#playlist-rename-form").on("submitOk", function () {
        $(".playlist-name-header").text($("#playlist-name-editor").val());
        $("#renameModal").modal("toggle");
    });
});
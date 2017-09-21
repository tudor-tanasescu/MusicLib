var loading;

var page = 1;
var totalPages = 1;
var pageSize = 20;
var trackCount = 0;

var getElementsUrl;
var getElementsCountUrl;
var containerId;

$(document).ready(function () {
    
    var username = document.location.pathname.replace(/^\//g, "").split("/")[0];

    var category = document.location.pathname.replace(/^\//g, "").split("/")[1];

    switch (category) {
    case "Tracks":
        getElementsUrl = "/Track/GetUploadedTracksThumbnails/";
        getElementsCountUrl = "/Track/GetUploadedTracksCount/";
        containerId = "#trackContainer";
        break;
    case "Likes":
        getElementsUrl = "/Track/GetLikedTracksThumbnails/";
        getElementsCountUrl = "/Track/GetLikedTracksCount/";
        containerId = "#trackContainer";
        break;
    case "Playlists":
        getElementsUrl = "/Playlist/GetCreatedPlaylistsThumbnails/";
        getElementsCountUrl = "/Playlist/GetCreatedPlaylistsCount/";
        containerId = "#playlistContainer";
        break;
    case "Saved":
        getElementsUrl = "/Playlist/GetSavedPlaylistThumbnails/";
        getElementsCountUrl = "/Playlist/GetSavedPlaylistsCount/";
        containerId = "#playlistContainer";
        break;
    }

    $.get(getElementsCountUrl,
        { username: username },
        function (responseTxt, statusTxt, xhr) {
            if (statusTxt === "success") {
                trackCount = parseInt(responseTxt) || 0;
                console.log(responseTxt);
            }
            if (statusTxt === "error")
                alert("Error: " + xhr.status + ": " + xhr.statusText);
        }).done(function() {
            totalPages = Math.floor((trackCount + pageSize - 1) / pageSize);
            appendElements(getElementsUrl, containerId);
    });
    

    $(document).scroll(function() {
        if (loading)
            return false;

        if ($(window).scrollTop() >= ($(document).height() - $(window).height()) * 0.9) {
            loading = true;
            appendElements(getElementsUrl, containerId);
        }
        return false;
    });
});


var appendElements = function(url, containerId) {
    if (page > totalPages) {
        return;
    }
    var spiner = $(containerId).find(".spinner");
    spiner.show();

    var username = document.location.pathname.replace(/^\//g, "").split("/")[0];

    $.get(url,
        { username: username, page: page++, pageSize: pageSize },
        function(responseTxt, statusTxt, xhr) {
            if (statusTxt === "success") {
                $(responseTxt).insertBefore(spiner);
                loading = false;
                console.log(responseTxt);
            }
            if (statusTxt === "error")
                alert("Error: " + xhr.status + ": " + xhr.statusText);
        }).done(function(){spiner.hide()});
};
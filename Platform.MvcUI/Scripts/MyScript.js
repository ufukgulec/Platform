$(function () {
    /*TagSelectList*/
    $.get("/Home/TagSelectList", function (data) {
        console.log(data);
        $("#TagSelectList").html(data);
    });

    $("#loading-tag").show(300);
    $.get("/Home/MostPopularTags", function (data) {
        console.log(data);
        $("#MostPopularTags").html(data);
        $("#loading-tag").hide(300);
    });
    $("#loading-entry").show(300);
    $.get("/Home/MostPopularEntries", function (data) {
        console.log(data);
        $("#MostPopularEntries").html(data);
        $("#loading-entry").hide(300);
    });
});

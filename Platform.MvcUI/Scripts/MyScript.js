$(function () {
    /*TagSelectList*/
    TagSelectList();
    /*Popular Tags*/
    MostPopularTags();
    /*Popular Entries*/
    MostPopularEntries();
    /*Home Entries*/
    TodayEntryGetAll();
});
function LoadingOpen(name) {
    $("#loading-" + name).show(300);
}
function LoadingClose(name) {
    $("#loading-" + name).hide(300);
}
function Login() {
    $.ajax({
        method: 'POST',
        url: '../Person/Login',
        data: $("#login-form").serialize()
    }).fail(function () {
        console.log("Giriş hatalı");
    });
}
function Register() {
    $.ajax({
        method: 'POST',
        url: '../Person/Register',
        data: $("#register-form").serialize()
    }).fail(function () {
        console.log("Giriş hatalı");
    });
}
function TodayEntryGetAll() {
    $.get("/Entry/TodayEntryGetAll", function (data) {
        console.log(data);
        $("#TodayEntryGetAll").html(data);
    });
}
function TagSelectList() {
    $.get("/Tag/TagSelectList", function (data) {
        console.log(data);
        $("#TagSelectList").html(data);
    });
}
function MostPopularTags() {
    LoadingOpen("tag");
    $.get("/Tag/MostPopularTags", function (data) {
        console.log(data);
        $("#MostPopularTags").html(data);
        LoadingClose("tag");
    });
}
function MostPopularEntries() {
    LoadingOpen("entry");
    $.get("/Entry/MostPopularEntries", function (data) {
        console.log(data);
        $("#MostPopularEntries").html(data);
        LoadingClose("entry");
    });
}
$(function () {
    /*Navbar Button*/
    $('[data-toggle=offcanvas]').click(function () {

        $(this).toggleClass('visible-xs text-center ');
        $(this).find('i').toggleClass('bx-flip-horizontal');
        $('.row-offcanvas').toggleClass('active');
        $('#lg-menu').toggleClass('hidden-xs').toggleClass('visible-xs');
        $('#xs-menu').toggleClass('visible-xs').toggleClass('hidden-xs');
        $('#btnShow').toggle();
    });
    /*Popular Tags*/
    MostPopularTags();
    /*Popular Entries*/
    MostPopularEntries();
    /*Home Entries*/
    TodayEntries();
    /*New Post*/
    NewPostArea();
});
/*Loader*/
function LoadingOpen(name) {
    $("#loading-" + name).show(300);
}
function LoadingClose(name) {
    $("#loading-" + name).hide(300);
}
function TagSelectList() {
    $.get("/Tag/TagSelectList", function (data) {
        console.log("tag select list çekildi...");
        $("#tag-select-list").html(data);
        $("#tag-select-list-modal").html(data);
    });
}
function MostPopularTags() {
    LoadingOpen("tag");
    $.get("/Tag/MostPopularTags", function (data) {
        console.log("popüler tagler çekildi...");
        $("#popular-tags").html(data);
        LoadingClose("tag");
    });
}
function MostPopularEntries() {
    LoadingOpen("entry");
    $.get("/Entry/MostPopularEntries", function (data) {
        console.log("popüler entryler çekildi...");
        $("#popular-entries").html(data);
        LoadingClose("entry");
    });
}
function NewPostArea() {
    $.get("/Entry/Post", function (data) {
        console.log("yeni post alanı oluşturuldu...");
        $("#new-post-area").html(data);
        /*TagSelectList*/
        TagSelectList();
    });
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
function TodayEntries() {
    $.get("/Entry/TodayEntryGetAll", function (data) {
        console.log("Home/Index için bugünkü entry'ler");
        $("#today-entries").html(data);
    });
}
/*Sadece yeni tag için ve yeni entry için alanlar*/
function NewTag() {
    var x = document.getElementById("new-tag-area");
    var button = document.getElementById("new-tag-button");
    if (x.style.display === "none") {
        x.style.display = "block";
        button.className = "btn btn-danger";
        button.innerHTML = "Kapat";
    } else {
        x.style.display = "none";
        button.className = "btn btn-success";
        button.innerHTML = "Yeni";
    }
}
function NewEntry() {
    var x = document.getElementById("new-post-area");
    var button = document.getElementById("new-entry-button");
    if (x.style.display === "none") {
        x.style.display = "block";
        button.className = "btn btn-danger";
        button.innerHTML = "Kapat";
    } else {
        x.style.display = "none";
        button.className = "btn btn-success";
        button.innerHTML = "Yeni";
    }
}
/*Entry Post*/
function ModalEntryPost() {
    $.ajax({
        method: 'POST',
        url: '../Entry/Post',
        data: $("#modal-post-form").serialize()
    }).done(function () {
        console.log("Başarılı gönderim");
        TodayEntries();
    }).fail(function () {
        console.log("----HATA----");
    });
}
function EntryPost() {
    $.ajax({
        method: 'POST',
        url: '../Entry/Post',
        data: $("#post-form").serialize()
    }).done(function () {
        console.log("Başarılı gönderim");
        TodayEntries();
        NewPostArea();
    }).fail(function () {
        console.log("----HATA----");
    });
}
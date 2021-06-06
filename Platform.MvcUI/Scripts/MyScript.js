$(function () {
    /*Sayfa yüklendikten sonra çalışacak komutlar*/
    HomePage();
});
function HomePage() {
    PostArea();
    MostPopularTags();
    MostPopularEntries();
    EntryList();
}
/*Loading Anim Methods*/
function LoadingAnimOpen(name) {
    $("#loading-" + name).show(300);
}
function LoadingAnimClose(name) {
    $("#loading-" + name).hide(300);
}
/*Data Extractions*/
function EntryList() {
    $.get("/Entry/GetEntries", function (data) {
        console.log("Gönderiler çekildi...");
        $("#entry-list-area").html(data);
    });
}
function PostArea() {
    $.get("/Entry/Post", function (data) {
        console.log("yeni post alanı oluşturuldu...");
        $("#new-post-area").html(data);
        /*TagSelectList*/
        TagSelectList();
    });
}
function TagSelectList() {
    $.get("/Tag/TagSelectList", function (data) {
        console.log("tag select list çekildi...");
        $("#tag-select-list").html(data);
        $("#tag-select-list-modal").html(data);
    });
}
function MostPopularTags() {
    /*LoadingOpen("tag");*/
    $.get("/Tag/MostPopularTags", function (data) {
        console.log("popüler tagler çekildi...");
        $("#popular-tags-area").html(data);
        /*LoadingClose("tag");*/
    });
}
function MostPopularEntries() {
    /*LoadingOpen("entry");*/
    $.get("/Entry/MostPopularEntries", function (data) {
        console.log("popüler entryler çekildi...");
        $("#popular-entries-area").html(data);
        /*LoadingClose("entry");*/
    });
}
function TodayEntries() {
    $.get("/Entry/TodayEntryGetAll", function (data) {
        console.log("Home/Index için bugünkü entry'ler");
        $("#today-entries").html(data);
    });
}
/*Entry Post And New Tag Methods*/
function ModalEntryPost() {
    $.ajax({
        method: 'POST',
        url: '../Entry/Post',
        data: $("#modal-post-form").serialize()
    }).done(function () {
        console.log("Başarılı gönderim");
        EntryList();
        $('#PostModal').modal('hide');
        $('#PostModal').on('hidden.bs.modal', function (e) {
            $('#entry-title').val('');
            $('#entry-article').val('');
            $('#tag-select').val('Tags');
        })
    }).fail(function () {
        console.log("----HATA----");
    });
}
function EntryPost() {
    $.ajax({
        method: 'POST',
        url: '../Entry/Post',
        data: $("#entry-post").serialize()
    }).done(function () {
        console.log("Başarılı gönderim");
        PostArea();
        EntryList();
    }).fail(function () {
        console.log("----HATA----");
    });
}
function PostLike(id) {
    $.get("/Entry/Like/" + id, function (data) {
        EntryList();
    });
}
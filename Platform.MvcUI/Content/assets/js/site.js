function darkmode() {
    var body = document.body;
    body.classList.toggle("dark-mode");
    document.cookie = "theme='dark-mode'";

    var iconbar = document.getElementById("icon-bar");
    iconbar.classList.toggle("dark-mode");

    var themeicon = document.getElementById("theme");
    themeicon.classList.toggle("bxs-sun");

    var popular = document.getElementsByClassName("list");
    var postArea = document.getElementsByClassName("post");
    var entries = document.getElementsByClassName("entry");

    if (themeicon.classList.contains("bxs-sun")) {
        if (popular.length === 0) {
            console.log("list yok");
        } else {
            for (var i = 0; i < popular.length; i++) {
                popular[i].classList.add("dark-bordered");
                popular[i].classList.remove("light-bordered");
            }
        }
        if (postArea.length !== 0) {
            postArea[0].classList.add("dark-bordered");
            postArea[0].classList.remove("light-bordered");
        }

        for (var i = 0; i < entries.length; i++) {
            entries[i].classList.add("dark-bordered");
            entries[i].classList.remove("light-bordered");
        }
    } else {
        if (popular.length === 0) {
        } else {
            for (var i = 0; i < popular.length; i++) {
                popular[i].classList.remove("dark-bordered");
                popular[i].classList.add("light-bordered");
            }
        }
        if (postArea.length !== 0) {
            postArea[0].classList.remove("dark-bordered");
            postArea[0].classList.add("light-bordered");
        }

        for (var i = 0; i < entries.length; i++) {
            entries[i].classList.remove("dark-bordered");
            entries[i].classList.add("light-bordered");
        }
    }
}
function topnavbaropen() {
    var x = document.getElementById("myLinks");
    if (x.style.display === "block") {
        x.style.display = "none";
    } else {
        x.style.display = "block";
    }
    var menuswitcher = document.getElementById("menu-switcher");
    menuswitcher.classList.toggle("bxs-left-arrow");
}
function ReadMore() {
    var dots = document.getElementById("dots");
    var moreText = document.getElementById("more");
    var btnText = document.getElementById("myBtn");

    if (dots.style.display === "none") {
        dots.style.display = "inline";
        btnText.innerHTML = "Read more";
        moreText.style.display = "none";
    } else {
        dots.style.display = "none";
        btnText.innerHTML = "Read less";
        moreText.style.display = "inline";
    }
}


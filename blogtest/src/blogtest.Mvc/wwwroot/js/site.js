//$(document).ready(function () {
//    var url = window.location.href.substr(window.location.href.lastIndexOf('/') + 1);
//    $('.navbar-nav a').each(function () {
//        if ($(this).attr('href') === url || $(this).attr('href') === '') {
//            $(this).parent('li').addClass('active');
//        }
//    });
//});

$(document).ready(function () {
    var url = window.location;
    $('ul.nav li a').each(function () {
        if (this.href == url) {
            $("ul.nav li").each(function () {
                if ($(this).hasClass("active")) {
                    $(this).removeClass("active");
                }
            });
            $(this).parent().addClass('active');
        }
    });
});
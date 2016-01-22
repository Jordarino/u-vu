$.extend($.expr[":"], {
    "containsIN": function (elem, i, match, array) {
        return (elem.textContent || elem.innerText || "").toLowerCase().indexOf((match[3] || "").toLowerCase()) == 0;
    }
});

(function () {
    var zindex = 1011;
    $.fn.showPopup = function (options) {

        var settings = $.extend({}, {}, options);

        var itm = $(this);
        itm.css('z-index', zindex++)
        itm.show();
        itm.click(function () {
            if ($(this).zIndex() + 1 != zindex) $(this).css('z-index', zindex++);
        })

        var setHeight = function () {
            var popWidth = itm.outerHeight(); //.find('.popup-title').outerHeight() + itm.find('.popup-buttons').outerHeight() + itm.find('.popup-content')[0].scrollHeight + 10;
            var docWidth = $(window).width();
            var docHeight = $(window).height() - 100;

            var windowWidth = docWidth > 1200 ? 1100 : docWidth - 100;
            var windowHeight = docHeight > 900 ? 800 : docHeight - 100;

            itm.css({ 'width': windowWidth, 'height': windowHeight, 'left': (docWidth - windowWidth) / 2, 'top': (docHeight - windowHeight) / 2 });
        }

        itm.find('.cancelPopup').click(function (e) {
            e.preventDefault();
            if (settings.onCancel) {
                if (settings.onCancel()) itm.remove();
            } else {
                itm.remove();
            }
            return false;
        });

        $(window).resize(function () { setHeight(); });

        setHeight();
    }
})();

$(function () {

    $('#nav')
    .on('click', '.drop-menu-button', function (e) {
        e.stopPropagation();
        var sub = $(this).next('div');
        if (sub.is(':visible')) sub.hide();
        else {
            $('div.drop-menu').hide();
            sub.show();
        }
    })
    $(document).click(function (e) {
        //console.log($(e.target).closest('.drop-menu'));
        if ($(e.target).closest('.drop-menu').length == 0) $('div.drop-menu').hide();
    });
})
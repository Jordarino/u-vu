(function ($) {

    var settings = {};

    var methods = {
        init: function (options) {

            settings = $.extend({
                enablePan: true,
                enableZoom: true,
                onDragging: null,
                onDragEnd: null,
                onZoom : null,
                initialZoom: 1,
                min: 0.2,
                max: 20
            }, options);

            return this.each(function (i, e) {
                var root = $(e);
                var state = 'none';
                var viewPort, fixedPort, stateTarget, stateOrigin, stateTf, controlBox;

                var wireEvents = function () {
                    root
                        .on('mouseup', mouseUp)
                        .on('mousedown', mouseDown)
                        .on('mousemove', mouseMove)
                        //.on('mouseout', mouseUp)
                        .on('mousewheel', mouseWheel)
                    //.on('touchstart', mouseDown)
                    //.on('touchmove', mouseMove)
                    //.on('touchend', mouseUp)

                    root.find('.btnZoomIn')
                        .on('click', function () { zoom(1); })
                        .on('touchend', function () { zoom(1); });

                    root.find('.btnZoomOut')
                        .on('click', function () { zoom(-1); })
                        .on('touchend', function () { zoom(-1); });

                    controlBox = root.find('#controls');

                    fixedPort = root.find('#fixedPort')[0];
                    viewPort = root.find('#viewport')[0];
                    setCTM(viewPort.getCTM());
                }

                var mouseDown = function (e) {
                    //e.preventDefault();
                    var g = viewPort;

                    stateTf = g.getCTM().inverse();
                    stateOrigin = getEventPoint(e);
                    stateOrigin = stateOrigin.matrixTransform(stateTf);
                    //if (e.which == 1 && settings.onClick) settings.onClick(stateOrigin, e);
                    //if (e.which != 3) return false;
                    state = 'pan';
                    return false;
                }

                var mouseMove = function (e) {
                    e.preventDefault();
                    var g = viewPort;
                    if (state == 'pan' && settings.enablePan) {
                        var p = getEventPoint(e).matrixTransform(stateTf);
                        setCTM(stateTf.inverse().translate(p.x - stateOrigin.x, p.y - stateOrigin.y));
                        if (settings.onDragging) settings.onDragging();
                    }
                }

                var mouseUp = function (e) {
                    e.preventDefault();
                    state = '';
                    if (settings.onDragEnd) settings.onDragEnd();
                    return false;
                }

                var mouseWheel = function (e) {
                    if (!settings.enableZoom) return;
                    e.preventDefault();
                    zoom(e.deltaY, e);
                }

                var zoom = function (delta, e) {
                    delta = delta / 10
                    var z = 1 + delta;
                    var g = viewPort;

                    if (!e) e = { clientX: root.parent().width() / 2, clientY: root.parent().height() / 2 };

                    p = getEventPoint(e);
                    p = p.matrixTransform(g.getCTM().inverse());

                    var currentZoom = g.getCTM().a;

                    if ((currentZoom > settings.max && delta>0) || (currentZoom < settings.min && delta<0)) return;


                    var k = root[0].createSVGMatrix().translate(p.x, p.y).scale(z).translate(-p.x, -p.y);
                    setCTM(g.getCTM().multiply(k));
                    if (typeof (stateTf) == "undefined") stateTf = g.getCTM().inverse();
                    stateTf = stateTf.multiply(k.inverse());

                    if (settings.onZoom) settings.onZoom(g.getCTM().a);
                }

                var setCTM = function (matrix) {
                    viewPort.setAttribute("transform", "matrix(" + matrix.a + "," + matrix.b + "," + matrix.c + "," + matrix.d + "," + matrix.e + "," + matrix.f + ")");
                    fixedPort.setAttribute("transform", "translate(" + matrix.e + "," + matrix.f + ")")
                    $(fixedPort).find('.noscale').each(function (i, e) {
                        var point = $(e).data('data').point;
                        e.setAttribute('transform', 'translate(' + (point.x * matrix.a) + "," + (point.y * matrix.a) + ")")
                    })
                }

                var getEventPoint = function (e) {
                    var p = root[0].createSVGPoint();
                    if (e.clientX) {
                        p.x = e.clientX;
                        p.y = e.clientY - root.offset().top; // - 68 correction for container position top;
                    } else if (e.originalEvent.targetTouches) {
                        p.x = e.originalEvent.targetTouches[0].pageX;
                        p.y = e.originalEvent.targetTouches[0].pageY - root.offset().top;
                    }

                    return p;
                }

                wireEvents();


            });
        },
        zoomTo: function (options) {
            var root = $(this);
            var z = options.zoom;
            root.find('#viewport')[0].setAttributeNS(null, "transform", "matrix(" + z + ",0,0," + z + "," + options.offset.x + "," + options.offset.y + ")");
            if (settings.onZoom) settings.onZoom(z);
        }

    }


    $.fn.pxSVGPanZoom = function () {
        var method = arguments[0];
        if (methods[method]) {
            method = methods[method];
            arguments = Array.prototype.slice.call(arguments, 1);
        } else if (typeof (method) == 'object' || !method) {
            method = methods.init;
        } else {
            $.error('Method ' + method + ' does not exist on the wizard');
            return this;
        }
        return method.apply(this, arguments);
    }

})(jQuery);
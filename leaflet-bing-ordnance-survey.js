var BingLayer = L.TileLayer.extend({
    getTileUrl: function (tilePoint) {
        this._adjustTilePoint(tilePoint);
        return L.Util.template(this._url, {
            s: this._getSubdomain(tilePoint),
            q: this._quadKey(tilePoint.x, tilePoint.y, this._getZoomForUrl())
        });
    },
    _quadKey: function (x, y, z) {
        var quadKey = [];
        for (var i = z; i > 0; i--) {
            var digit = '0';
            var mask = 1 << (i - 1);
            if ((x & mask) != 0) {
                digit++;
            }
            if ((y & mask) != 0) {
                digit++;
                digit++;
            }
            quadKey.push(digit);
        }
        return quadKey.join('');
    }
});

var layer = new BingLayer('http://ecn.t{s}.tiles.virtualearth.net/tiles/r{q}?g=1567&lbl=l1&productSet=mmOS', {
    subdomains: ['0', '1', '2', '3', '4', '5', '6', '7'],
    attribution: '&copy; <a href="http://bing.com/maps">Bing Maps</a>',
    detectRetina: true
});

var map = new L.Map(document.querySelector('#map'), {
    layers: [layer],
    center: new L.LatLng(51.7617353,-1.2427226),
    zoom: 12
});
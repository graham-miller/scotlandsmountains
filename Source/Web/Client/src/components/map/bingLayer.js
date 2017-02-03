import L from "leaflet";

const BingLayer = L.TileLayer.extend({

    getTileUrl: function (coords) {
        var x = coords.x;
        var y = coords.y;
        var z = this._getZoomForUrl();
        var subdomains = this.options.subdomains;
        var quadDigits = new Array(z);
        var mask = 1 << (z - 1);
        for (var i = 0; i < z; ++i) {
            var charCode = 48;
            if (x & mask) {
                charCode += 1;
            }
            if (y & mask) {
                charCode += 2;
            }
            quadDigits[i] = String.fromCharCode(charCode);
            mask >>= 1;
        }

        return L.Util.template(this._url, L.Util.extend({
            subdomain: subdomains[(x + y) % subdomains.length],
            quadkey: quadDigits.join("")
        }, this.options));
    }
});

export default BingLayer;
'use strict';

import L from 'leaflet';

class BingLayer extends L.TileLayer {

    constructor(bingMapsKey, url) {

        super(url, {
            subdomains: ['0', '1', '2', '3'],
            attribution: '&copy; <a href="http://bing.com/maps">Bing Maps</a>',
            detectRetina: true
        });

        this._bingMapsKey = bingMapsKey;
    }

    getTileUrl (tilePoint) {
        this._adjustTilePoint(tilePoint);
        return L.Util.template(this._url, {
            s: this._getSubdomain(tilePoint),
            q: this._quadKey(tilePoint.x, tilePoint.y, this._getZoomForUrl()),
            k: this._bingMapsKey
        });
    }

    _quadKey (x, y, z) {
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
}

class RoadLayer extends BingLayer {
    constructor(bingMapsKey) {
        super(bingMapsKey, 'https://ecn.t{s}.tiles.virtualearth.net/tiles/r{q}.jpeg?g=5142&mkt=en-GB&shading=hill');
    }
}

class MapLayer extends BingLayer {
    constructor(bingMapsKey) {
        super(bingMapsKey, 'https://ecn.t{s}.tiles.virtualearth.net/tiles/r{q}?g=5142&lbl=l1&productSet=mmOS&key={k}');
    }
}

class AerialLayer extends BingLayer {
    constructor(bingMapsKey) {
        super(bingMapsKey, 'https://ecn.t{s}.tiles.virtualearth.net/tiles/a{q}.jpeg?g=5142');
    }
}

export { RoadLayer };
export { MapLayer };
export { AerialLayer };
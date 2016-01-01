var bingLayer = require("./bingLayer.js");
var thunderforestLayer = require("./thunderforestLayer.js");
var openStreetMapLayer = require("./openStreetMapLayer.js");
var openWeatherMapLayer = require("./openWeatherMapLayer.js");
var mountainLayer = require("./mountainLayer.js");

module.exports = function () {

    var bingAttribution = "Map data &copy; <a href=\"http://bing.com/maps\">Bing Maps</a>";

    //var os = L.tileLayer("http://ondemandapi.ordnancesurvey.co.uk/osmapapi/tile/1579A00CEC942653E0530C6CA40AFD63/{z}/{x}/{y}.png?URL=scotlandsmountains.net"),

    var street = openStreetMapLayer(),
        outdoors = thunderforestLayer("outdoors"),
        landscape = thunderforestLayer("landscape"),
        cycle = thunderforestLayer("cycle"),
        transport = thunderforestLayer("transport"),
        bing = bingLayer('http://ecn.t{s}.tiles.virtualearth.net/tiles/a{q}?g=3625', { subdomains: ['0', '1', '2', '3', '4', '5', '6', '7'], attribution: bingAttribution });
    //bing = new BingLayer("http://t{s}.ssl.ak.tiles.virtualearth.net/tiles/r{q}?g=3649&productSet=mmOS&key=Al1D9ABtWD8Gl_YBH0ameyeUPYchC7iTCEiVHo89IReCew-Y5nf72gqg5qS3yOGD", { subdomains: ['0', '1', '2', '3', '4', '5', '6', '7'], attribution: bingAttribution });

    var map = L.map("map", {
        center: [56.559406, -4.011214],
        attributionControl: false,
        zoom: 7,
        minZoom: 6,
        maxZoom: 18,
        maxBounds: [[49.247907, -10.653977], [60.854594, 1.738363]],
        layers: [outdoors, mountainLayer]
    });

    //https://msdn.microsoft.com/en-us/library/ff701716.aspx
    //http://dev.virtualearth.net/REST/V1/Imagery/Metadata/Aerial?key=AtpjQPLgDNxkSUWxAwtDKaJNRE6oRj1bw6kxYpvAy-NCvNGFQdJxveEZ_CQOBEVU
    //var response = {
    //    "authenticationResultCode": "ValidCredentials",
    //    "brandLogoUri": "http:\/\/dev.virtualearth.net\/Branding\/logo_powered_by.png",
    //    "copyright": "Copyright © 2015 Microsoft and its suppliers. All rights reserved. This API cannot be accessed and the content and any results may not be used, reproduced or transmitted in any manner without express written permission from Microsoft Corporation.",
    //    "resourceSets": [{ "estimatedTotal": 1, "resources": [{ "__type": "ImageryMetadata:http:\/\/schemas.microsoft.com\/search\/local\/ws\/rest\/v1", "imageHeight": 256, "imageUrl": "http:\/\/ecn.{subdomain}.tiles.virtualearth.net\/tiles\/a{quadkey}.jpeg?g=3625", "imageUrlSubdomains": ["t0", "t1", "t2", "t3"], "imageWidth": 256, "imageryProviders": null, "vintageEnd": null, "vintageStart": null, "zoomMax": 21, "zoomMin": 1 }] }], "statusCode": 200, "statusDescription": "OK", "traceId": "4dc1918cf6e54ace925c7a9120f6445b|DB40060332|02.00.185.700|"
    //};

    var attribution = "Mountain data &copy; <a href=\"http://www.hills-database.co.uk\">Database of British and Irish Hills v14.3</a>";

    L.control.attribution({
        position: "bottomright",
        prefix: attribution,
    }).addTo(map);

    L.control.scale({
        position: "bottomright",
        maxWidth: 200,
        imperial: false
    }).addTo(map);

    var baseMaps = {
        //"OS": os,
        "Street": street,
        "Outdoors": outdoors,
        "Landscape": landscape,
        "Cycle": cycle,
        "Transport": transport,
        "Aerial": bing
    };

    var rain = openWeatherMapLayer("rain_cls");
    var pressure = openWeatherMapLayer("pressure_cntr");

    var overlayMaps = {
        "Mountains": mountainLayer,
        "Rain": rain,
        "Pressure": pressure
    };

    L.control.layers(baseMaps, overlayMaps).addTo(map);

    //-------------------------------------------------------------------------

    var logMapState = function () {
        var zoom = map.getZoom();
        var centre = map.getCenter();
        console.log(zoom + "/" + centre.lat + "/" + centre.lng);
    }

    map.on('viewreset', function (e) {
        logMapState();
    });

    map.on('dragend', function (e) {
        logMapState();
    });

    map.on('baselayerchange', function (e) {
        logMapState();
    });

    //-------------------------------------------------------------------------

    return map;
}
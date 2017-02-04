import React from "react";

import L from "leaflet";

import Satellite from "material-ui/svg-icons/maps/satellite";
import Map from "material-ui/svg-icons/maps/map";

export default function createBaseLayers() {

    //import BingLayer from "./bingLayer";

    const mapboxAttribution = "&copy; <a href=\"https://www.mapbox.com/about/maps/\" target=\"_blank\">Mapbox</a>";
    const mapboxToken = "pk.eyJ1IjoiZ3JhaGFtbSIsImEiOiJkNDg0MTMwMjAwZjIxMjNlOTExMzk4YTMxZmM0MWIwMSJ9.9xj78sGiHCxyWzdnAg-jEA";

    const mapLayer = L.tileLayer(
        "https://api.mapbox.com/styles/v1/mapbox/outdoors-v9/tiles/256/{z}/{x}/{y}?access_token=" + mapboxToken, {
            attribution: mapboxAttribution + " &copy; <a href=\"http://www.openstreetmap.org/copyright\" target=\"_blank\">OpenStreetMap</a>",
            maxZoom: 18,
            minZoom: 2
        });
    mapLayer.name = "Map";
    mapLayer.label = <Map/>;

    const aerialLayer = L.tileLayer(
        "https://api.mapbox.com/styles/v1/mapbox/satellite-v9/tiles/256/{z}/{x}/{y}?access_token=" + mapboxToken, {
            attribution: mapboxAttribution + " &copy; <a href=\"https://www.digitalglobe.com/ target=\"_blank\"\">DigitalGlobe</a>",
            maxZoom: 18,
            minZoom: 2
        });
    aerialLayer.name = "Aerial";
    aerialLayer.label = <Satellite/>;

    // const osLayer = new BingLayer(
    //     "https://t{subdomain}.ssl.ak.dynamic.tiles.virtualearth.net/comp/ch/{quadkey}?mkt=en-GB&it=G,OS,BX,RL&shading=hill&n=z&og=144&key=AuKhsbA70Bov12p8tCtQr_p04VmODhYMeHBpHAByMzzOK2gbPtrBRQ-YT_U2SfIW&c4w=1", {
    //         subdomains: ["0", "1", "2", "3", "4", "5", "6", "7"],
    //         attribution: "&copy; 2017 Microsoft Corporation image courtesy of Ordnance Survey",
    //         maxZoom: 18,
    //         minZoom: 2
    //     });
    // osLayer.name = "OS";
    // osLayer.label = "OS";

    return [mapLayer, aerialLayer];
}

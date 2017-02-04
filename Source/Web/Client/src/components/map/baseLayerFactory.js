import React from "react";
import L from "leaflet";
import Satellite from "material-ui/svg-icons/maps/satellite";
import Map from "material-ui/svg-icons/maps/map";

import BingLayer from "./bingLayer";

export default function createBaseLayers(options) {

    const mapboxAttribution = "&copy; <a href=\"https://www.mapbox.com/about/maps/\" target=\"_blank\">Mapbox</a>";

    const mapLayer = L.tileLayer(
        "https://api.mapbox.com/styles/v1/mapbox/outdoors-v9/tiles/256/{z}/{x}/{y}?access_token=" + options.mapBoxApiKey, {
            attribution: mapboxAttribution + " &copy; <a href=\"http://www.openstreetmap.org/copyright\" target=\"_blank\">OpenStreetMap</a>",
            maxZoom: 18,
            minZoom: 2
        });
    mapLayer.name = "Map";
    mapLayer.label = <Map/>;

    const aerialLayer = L.tileLayer(
        "https://api.mapbox.com/styles/v1/mapbox/satellite-v9/tiles/256/{z}/{x}/{y}?access_token=" + options.mapBoxApiKey, {
            attribution: mapboxAttribution + " &copy; <a href=\"https://www.digitalglobe.com/ target=\"_blank\"\">DigitalGlobe</a>",
            maxZoom: 18,
            minZoom: 2
        });
    aerialLayer.name = "Aerial";
    aerialLayer.label = <Satellite/>;

    const osLayer = new BingLayer(
        "https://t{subdomain}.ssl.ak.dynamic.tiles.virtualearth.net/comp/ch/{quadkey}?mkt=en-GB&it=G,OS,BX,RL&shading=hill&n=z&og=144&key=" + options.bingMapsApiKey, {
            subdomains: ["0", "1", "2", "3", "4", "5", "6", "7"],
            attribution: "&copy; 2017 Microsoft Corporation image courtesy of Ordnance Survey",
            maxZoom: 18,
            minZoom: 2
        });
    osLayer.name = "OS";
    osLayer.label = <span style={{fontWeight:"bold"}}>OS</span>;

    return [mapLayer, aerialLayer, osLayer];
}

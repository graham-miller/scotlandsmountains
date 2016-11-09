import L from "leaflet";

const mapboxAttribution = "&copy; <a href=\"https://www.mapbox.com/about/maps/\" target=\"_blank\">Mapbox</a>";
const mapboxToken = "pk.eyJ1IjoiZ3JhaGFtbSIsImEiOiJkNDg0MTMwMjAwZjIxMjNlOTExMzk4YTMxZmM0MWIwMSJ9.9xj78sGiHCxyWzdnAg-jEA";

const mapLayer = L.tileLayer(
    "https://api.mapbox.com/styles/v1/mapbox/outdoors-v9/tiles/256/{z}/{x}/{y}?access_token=" + mapboxToken, {
        attribution: mapboxAttribution + " &copy; <a href=\"http://www.openstreetmap.org/copyright\" target=\"_blank\">OpenStreetMap</a>",
        maxZoom: 18,
        minZoom: 2
    });
mapLayer.name = "Map";

const aerialLayer = L.tileLayer(
    "https://api.mapbox.com/styles/v1/mapbox/satellite-v9/tiles/256/{z}/{x}/{y}?access_token=" + mapboxToken, {
        attribution: mapboxAttribution + " &copy; <a href=\"https://www.digitalglobe.com/ target=\"_blank\"\">DigitalGlobe</a>",
        maxZoom: 18,
        minZoom: 2
    });
mapLayer.name = "Aerial";

const MapLayers = [mapLayer, aerialLayer];

export default MapLayers;
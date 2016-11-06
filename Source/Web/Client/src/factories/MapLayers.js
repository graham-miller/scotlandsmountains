import L from 'leaflet';

const mapboxAttribution = '&copy; <a href="https://www.mapbox.com/about/maps/" target="_blank">Mapbox</a>';
const mapboxToken = 'pk.eyJ1IjoiZ3JhaGFtbSIsImEiOiJkNDg0MTMwMjAwZjIxMjNlOTExMzk4YTMxZmM0MWIwMSJ9.9xj78sGiHCxyWzdnAg-jEA';

const MapLayers = {
    Map: L.tileLayer('https://api.mapbox.com/styles/v1/mapbox/outdoors-v9/tiles/256/{z}/{x}/{y}?access_token=' + mapboxToken, {
        attribution: mapboxAttribution + ' &copy; <a href="http://www.openstreetmap.org/copyright" target="_blank">OpenStreetMap</a>',
        maxZoom: 18,
        minZoom: 2
    }),
    Aerial: L.tileLayer('https://api.mapbox.com/styles/v1/mapbox/satellite-v9/tiles/256/{z}/{x}/{y}?access_token=' + mapboxToken, {
        attribution: mapboxAttribution + ' &copy; <a href="https://www.digitalglobe.com/ target="_blank"">DigitalGlobe</a>',
        maxZoom: 18,
        minZoom: 2
    })
};

MapLayers.Map.Name = 'Map';
MapLayers.Aerial.Name = 'Aerial';

export default MapLayers;
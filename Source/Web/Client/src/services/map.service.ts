import { Injectable } from '@angular/core';

var L = require('leaflet');

@Injectable()
export class MapService {

    private map: any;

    getMap(): any {
        return this.map;
    }

    initializeMap() {
        var map = L.map('map').setView([56.816922, -4.18265], 13);

        L.tileLayer('https://api.mapbox.com/styles/v1/mapbox/outdoors-v9/tiles/256/{z}/{x}/{y}?access_token={accessToken}', {
            attribution: 'Map data &copy; <a href="http://openstreetmap.org">OpenStreetMap</a> contributors, <a href="http://creativecommons.org/licenses/by-sa/2.0/">CC-BY-SA</a>, Imagery © <a href="http://mapbox.com">Mapbox</a>',
            maxZoom: 18,
            accessToken: 'pk.eyJ1IjoiZ3JhaGFtbSIsImEiOiJkNDg0MTMwMjAwZjIxMjNlOTExMzk4YTMxZmM0MWIwMSJ9.9xj78sGiHCxyWzdnAg-jEA'
        }).addTo(map);

        map.invalidateSize(false);

        return map;
    }
}
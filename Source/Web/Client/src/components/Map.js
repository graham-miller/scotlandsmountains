import React, { Component } from 'react';
import L from 'leaflet';

class Map extends Component {

    componentDidMount() {

        this.map = L.map('map').setView([56.816922, -4.18265], 7);

        this.map.attributionControl.setPrefix('');

        L.tileLayer('https://api.mapbox.com/styles/v1/mapbox/outdoors-v9/tiles/256/{z}/{x}/{y}?access_token=pk.eyJ1IjoiZ3JhaGFtbSIsImEiOiJkNDg0MTMwMjAwZjIxMjNlOTExMzk4YTMxZmM0MWIwMSJ9.9xj78sGiHCxyWzdnAg-jEA', {
            attribution: 'Map data &copy; <a href="http://openstreetmap.org">OpenStreetMap</a> contributors, <a href="http://creativecommons.org/licenses/by-sa/2.0/">CC-BY-SA</a>, Imagery &copy; <a href="http://mapbox.com">Mapbox</a>',
            maxZoom: 18,
            minZoom: 2,
        }).addTo(this.map);
    }

    componentWillUnmount() {
        this.map = null;
    }

    render() {
        return (
            <div className='full-height'>
                <div id='map' className='full-height'></div>
            </div>
        );
    }
}

export default Map;

import React, { Component } from 'react';
import L from 'leaflet';

import Toolbar from './Toolbar';
import './Map.scss';
import MountainStore from '../../state/stores/MountainStore';

class Map extends Component {

    constructor(props) {
        super(props);
        this.state = MountainStore.getState();
        this.onChange = this.onChange.bind(this);
    }

    onChange(state) {

        if (this.layer) {
            this.layer.removeFrom(this.map);
            this.layer = null;
        }

        this.layer = L.layerGroup().addTo(this.map);

        var icon = L.divIcon({className: 'marker munro'});

        state.mountains.forEach((mountain) => {
            var marker = L.marker([mountain.latitude, mountain.longitude], {icon: icon}).addTo(this.layer);

            marker.bindPopup('<p style="padding:0;margin:0;">' + mountain.name + '</p><p style="padding:0;margin:0;">' + mountain.height + '</p>', {closeButton: false});
            marker.on('mouseover', function (e) {
                this.openPopup();
            });
            marker.on('mouseout', function (e) {
                this.closePopup();
            });
            
        });
    }
    
    shouldComponentUpdate(nextProps, nextState) {
        return false;
    }

    componentDidMount() {

        MountainStore.listen(this.onChange);

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
        MountainStore.unlisten(this.onChange);
    }

    render() {
        return (
            <div className='full-height'>
                <Toolbar />
                <div id='map' className='full-height'></div>
            </div>
        );
    }
}

export default Map;

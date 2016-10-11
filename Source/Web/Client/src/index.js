import React from 'react';
import ReactDOM from 'react-dom';
import App from './components/App';
import './index.scss';

require('jquery');
require('tether');

import './boostrap-theme.scss';
import 'bootstrap/scss/bootstrap.scss';
import 'bootstrap/dist/js/bootstrap.js';

import 'leaflet/dist/leaflet.css';
import 'leaflet/dist/images/layers.png';
import 'leaflet/dist/images/layers-2x.png';
import 'leaflet/dist/images/marker-icon.png';
import 'leaflet/dist/images/marker-icon-2x.png';
import 'leaflet/dist/images/marker-shadow.png';

ReactDOM.render(<App />, document.getElementById('sm-app'));

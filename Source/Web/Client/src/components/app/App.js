import React, { Component } from 'react';

import Title from './Title';
import MapContainer from '../map/MapContainer';
import Routes from './Routes';
import Footer from '../footer/Footer';

import './App.scss'

class App extends Component {
    render() {
        return (
            <div>
                <Title />
                <div className='container-fluid' style={{paddingTop: '70px', marginBottom: '40px'}}>
                    <div className='row'>
                        <div className='col-md-4'><Routes /></div>
                        <div className='col-md-8'><MapContainer /></div>
                    </div>
                </div>
                <Footer />
            </div>
        );
    }
}

export default App;

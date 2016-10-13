import React, { Component } from 'react';

import Title from './Title';
import MapModule from '../map/MapModule';
import Content from '../content/Content';
import Footer from '../footer/Footer';

import './App.scss'

class App extends Component {
    render() {
        return (
            <div>
                <Title />
                <div className='container-fluid' style={{paddingTop: '70px', marginBottom: '40px'}}>
                    <div className='row'>
                        <div className='col-md-4'><Content /></div>
                        <div className='col-md-8'><MapModule /></div>
                    </div>
                </div>
                <Footer />
            </div>
        );
    }
}

export default App;

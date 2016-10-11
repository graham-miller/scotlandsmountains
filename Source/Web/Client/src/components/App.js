import React, { Component } from 'react';

import Title from './Title';
import Map from './map/Map';
import Content from './Content';
import Footer from './Footer';

class App extends Component {
    render() {
        return (
            <div className='full-height'>
                <Title />
                <div className='container-fluid full-height' style={{paddingTop: '70px'}}>
                    <div className='row full-height'>
                        <div className='col-md-4 full-height'><Content /></div>
                        <div className='col-md-8 full-height'><Map /></div>
                    </div>
                </div>
                <Footer />
            </div>
        );
    }
}

export default App;

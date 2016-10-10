import React, { Component } from 'react';
import { Grid, Row, Col } from 'react-bootstrap';

import Title from './Title';
import Map from './map/Map';
import Content from './Content';
import Footer from './Footer';

class App extends Component {
    render() {
        return (
            <div className='full-height' style={{paddingTop: '50px'}}>
                <Title />
                <Grid fluid className='full-height'>
                    <Row className='full-height'>
                        <Col md={4} className='full-height'><Content /></Col>
                        <Col md={8} className='full-height'><Map /></Col>
                    </Row>
                </Grid>
                <Footer />
            </div>
        );
    }
}

export default App;

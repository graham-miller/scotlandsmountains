import React, { Component } from 'react';
import { Grid, Row, Col } from 'react-bootstrap';

import Title from './Title';
import Map from './Map';
import Content from './Content';
import Footer from './Footer';

class App extends Component {
    render() {
        return (
            <div className='full-height' style={{paddingTop: '50px'}}>
                <Title />
                <Grid fluid className='full-height'>
                    <Row className='full-height'>
                        <Col md={6} style={{padding: '0'}}><Content /></Col>
                        <Col md={6} style={{padding: '0'}} className='full-height'><Map /></Col>
                    </Row>
                </Grid>
                <Footer />
            </div>
        );
                }
}

export default App;

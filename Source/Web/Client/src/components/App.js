import React, { Component } from 'react';
import { Grid, Row, Col } from 'react-bootstrap';

import TitleBar from './TitleBar';
import Map from './Map';

class App extends Component {
    render() {
        return (
            <div className='full-height'>
                <TitleBar />
                <Grid fluid style={{paddingTop:'50px'}} className='full-height'>
                    <Row className='full-height'>
                        <Col md={6} style={{paddingTop: '15px'}}>Content</Col>
                        <Col md={6} className='full-height' style={{padding: 0}}><Map /></Col>
                    </Row>
                </Grid>
                <Grid fluid>
                    <Row>
                        <Col md={4}>Footer left</Col>
                        <Col md={4}>Footer centre</Col>
                        <Col md={4}>Footer right</Col>
                    </Row>
                </Grid>
            </div>
        );
    }
}

export default App;

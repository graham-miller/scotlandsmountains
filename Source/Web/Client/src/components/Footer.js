import React, { Component } from 'react';
import { Grid, Row, Col } from 'react-bootstrap';

class Footer extends Component {
    render() {
        return (
            <Grid fluid style={{paddingTop: '15px'}}>
                <Row>
                    <Col md={4} style={{padding: '0'}}>Footer left</Col>
                    <Col md={4} style={{padding: '0'}}>Footer centre</Col>
                    <Col md={4} style={{padding: '0'}}>Footer right</Col>
                </Row>
            </Grid>
        );
                }
}

export default Footer;

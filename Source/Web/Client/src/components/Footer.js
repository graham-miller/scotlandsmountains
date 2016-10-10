import React, { Component } from 'react';
import { Grid, Row, Col } from 'react-bootstrap';

class Footer extends Component {
    render() {
        return (
            <Grid fluid>
                <Row>
                    <Col md={4}>
                        <p>
                            Site design / logo &copy; {new Date().getFullYear()} Graham Miller.
                        </p>
                        <p>
                            Site} developed and operated by Graham Miller.
                        </p>
                        <p>
                            Mountain data &copy;
                            &nbsp;<a href='http://www.hills-database.co.uk/'>The Database of British and Irish Hills</a>&nbsp;
                            licensed under a
                            &nbsp;<a href='http://creativecommons.org/licenses/by/3.0/deed.en_GB'>Creative Commons Attribution 3.0 Unported License</a>.
                        </p>
                    </Col>
                    <Col md={4}>Footer centre</Col>
                    <Col md={4}>Footer right</Col>
                </Row>
            </Grid>
        );
    }
}

export default Footer;

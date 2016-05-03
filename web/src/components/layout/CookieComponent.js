'use strict';

import React from 'react';
import {Card, CardActions, CardTitle, CardText} from 'material-ui/Card';
import FlatButton from 'material-ui/FlatButton';
import { Link } from 'react-router'
import cookie from 'cookie_js/cookie.js';

class CookieComponent extends React.Component {
    
    constructor(props) {
        super(props);

        this.KEY = "cookiesAccepted"
        this.VALUE = "accepted"

        cookie.defaults.expires = 365;
        cookie.defaults.secure = true;

        this.state = {cookiesAccepted: cookie.get(this.KEY) === this.VALUE};

        this.handleAccept = this.handleAccept.bind(this);
    }

    setCookieFromState () {
        if(this.state.cookiesAccepted) {
        } else {
            cookie.remove(this.KEY);
        }
    }

    handleAccept() {
        this.setState({cookiesAccepted: true});
        cookie.set(this.KEY, this.VALUE);
    }
    
    render() {
                
        if (this.state.cookiesAccepted) { return null; }
            
        return (
            <div className="cookie-control container">
                <div className="cookie-control content clearfix">
                    <h3>Cookies</h3>
                    <p>
                        Scotland's Mountains uses cookies to improve functionality and performance. By 
                        using this site, you agree to this use. See our&nbsp;
                        <Link to="/legal/privacy">Privacy Policy</Link> for details.
                    </p>
                    <p>
                        <button onClick={this.handleAccept}>Dismiss</button>
                    </p>
                </div>
            </div>
        );
    }
}

export default CookieComponent;
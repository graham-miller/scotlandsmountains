import React, { Component } from "react";

import Attribution from "./Attribution";
import Legal from "./Legal";

import "./Footer.scss";

class Footer extends Component {
    render() {
        return (
            <div className='footer container-fluid'>
                <div className='row'>
                    <div className='col-md-4'>
                        <Attribution />
                    </div>
                    <div className='col-md-4'>
                        <Legal />
                    </div>
                    <div className='col-md-4'>Footer right</div>
                </div>
            </div>
        );
    }
}

export default Footer;

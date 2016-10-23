import React, { Component } from 'react';

import './Footer.scss'

class Footer extends Component {
    render() {
        return (
            <div className='footer container-fluid'>
                <div className='row'>
                    <div className='col-md-4'>
                        <p>
                            Site design / logo &copy; {new Date().getFullYear()} Graham Miller.
                        </p>
                        <p>
                            Site developed and operated by Graham Miller.
                        </p>
                        <p>
                            Mountain data &copy;
                            &nbsp;<a href='http://www.hills-database.co.uk/' target='_blank'>The Database of British and Irish Hills</a>&nbsp;
                            licensed under a
                            &nbsp;<a href='http://creativecommons.org/licenses/by/3.0/deed.en_GB' target='_blank'>Creative Commons Attribution 3.0 Unported License</a>.
                        </p>
                    </div>
                    <div className='col-md-4'>Footer centre</div>
                    <div className='col-md-4'>Footer right</div>
                </div>
            </div>
        );
    }
}

export default Footer;

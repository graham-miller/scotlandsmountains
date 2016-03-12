'use strict';

import React from 'react';

class FooterComponent extends React.Component {

    render() {

        return (
            <div id="footer-component">
                <h2>Scotland's Mountains</h2>
                &copy; 2016 Graham Miller
                <div>
                    <a href="#">Terms and conditions</a>&nbsp;&middot;&nbsp;
                    <a href="#">Copyright</a>&nbsp;&middot;&nbsp;
                    <a href="#">Privacy policy</a>&nbsp;&middot;&nbsp;
                    <a href="#">Disclaimer</a>
                </div>
            </div>
        );
    }
}

export default FooterComponent;
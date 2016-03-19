'use strict';

import React from 'react';

import NavigationExpandMore from 'material-ui/lib/svg-icons/navigation/expand-more';


class FooterComponent extends React.Component {

    scrollToFooter() {
        window.scrollTo(0, document.body.scrollHeight || document.documentElement.scrollHeight);
    }

    render() {
        return (
            <div id="footer-component">
                <div className="handle" onClick={this.scrollToFooter}>
                    <NavigationExpandMore color={'#e8e8e8'} />
                </div>
                <div className="content">
                    <h2>Scotland's Mountains</h2>
                    <div className="legal">
                        <p>
                            Website design / logo &copy; 2016 Graham Miller
                        </p>
                        <p>
                            <a href="#">Terms and conditions</a>&nbsp;&middot;&nbsp;
                            <a href="#">Copyright</a>&nbsp;&middot;&nbsp;
                            <a href="#">Privacy policy</a>&nbsp;&middot;&nbsp;
                            <a href="#">Disclaimer</a>
                        </p>
                    </div>  
                </div>
            </div>
        );
    }
}

export default FooterComponent;
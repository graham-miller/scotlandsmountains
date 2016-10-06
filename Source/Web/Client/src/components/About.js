import React, { Component } from 'react';

class About extends Component {

    render() {
        return (
            <div style={{padding: '15px'}}>
                <p>
                    Site developed and operated by Graham Miller.
                </p>
                <p>
                    Mountain data &copy;
                    &nbsp;<a href='http://www.hills-database.co.uk/'>The Database of British and Irish Hills</a>&nbsp;
                    licensed under a
                    &nbsp;<a href='http://creativecommons.org/licenses/by/3.0/deed.en_GB'>Creative Commons Attribution 3.0 Unported License</a>.
                </p>
            </div>
        );
    }
}

export default About;

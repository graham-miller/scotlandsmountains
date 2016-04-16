'use strict';

import React from 'react';
import GettyComponent from './GettyComponent';

class AboutComponent extends React.Component {

    render() {
        return (
            <div>
                <h2>About</h2>
                <p>
                    Scotland's Mountains is developed and operated by Graham Miller.
                </p>
                <GettyComponent width={535} height={320} href="http://www.gettyimages.com/detail/179656322"
                    src="//embed.gettyimages.com/embed/179656322?et=qaW6RQo2Q9Bd6Mj4fYP3Ww&viewMoreLink=off&sig=BqDO26d3XUlCgiUezjj9dKHBAjJTlNA38fDFfkyQadI=" />
            </div>
        );
    }
}

export default AboutComponent;
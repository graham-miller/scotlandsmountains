'use strict';

import React from 'react';
import GettyComponent from './GettyComponent';

class AttributionsComponent extends React.Component {

    render() {
        return (
            <div className="padded">
                <h2>Attributions</h2>
                <p>
                    Mountain data is licensed by&nbsp;
                    <a href="http://www.hills-database.co.uk" target="_blank">The Database of british and Irish Hills</a>&nbsp;
                    under a&nbsp;
                    <a href="http://creativecommons.org/licenses/by/3.0/deed.en_GB" target="_blank">Creative Commons Attribution 3.0 Unported License</a>.
                </p>
                <GettyComponent width={615} height={281} href="http://www.gettyimages.com/detail/573624773"
                    src="//embed.gettyimages.com/embed/573624773?et=YXhvzVNuRt9DPcV-_xjn_w&viewMoreLink=on&sig=KKpa7LWym0-7vZ2s3Fcus6Kh0FYCW268jYTLqfxJNUQ=" />
            </div>
        );
    }
}

export default AttributionsComponent;

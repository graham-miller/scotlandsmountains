'use strict';

import React from 'react';

class ContainerComponent extends React.Component {

    render() {

        return (
            <div className={'container-outer ' + this.props.outerClassName}>
                { this.props.header }
                <div className={'container-inner ' + this.props.innerClassName}>
                { this.props.content }
                </div>
                { this.props.footer }
            </div>
        );
    }
}

ContainerComponent.defaultProps = {
    header: null,
    content: null,
    footer: null
};

export default ContainerComponent;



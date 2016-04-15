'use strict';

import React from 'react';

class ContainerComponent extends React.Component {

    render() {

        const baseOuterStyle = {
            boxSizing: 'border-box',
            position: 'absolute',
            width: '100%',
            top: '0px'
        }
        
        const baseInnerStyle = {
            boxSizing: 'border-box',
            position: 'relative',
            width: '100%'
        }
        
        return (
            <div style={Object.assign(baseOuterStyle, this.props.outerStyle)}>
                { this.props.header }
                <div style={Object.assign(baseInnerStyle, this.props.innerStyle)}>
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



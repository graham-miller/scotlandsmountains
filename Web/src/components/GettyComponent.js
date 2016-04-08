'use strict';

import React from 'react';

class GettyComponent extends React.Component {

    render() {

        var padding = this.props.height / this.props.width * 100;

        var style1 = {
            //backgroundColor: '#fff',
            display: 'inline-block',
            //fontFamily: '\'Helvetica Neue\',Helvetica,Arial,sans-serif',
            //color: '#a7a7a7',
            fontSize: '11px',
            width: '100%',
            maxWidth: this.props.width + 'px'
        };

        var style2 = {
            padding: '0',
            margin: '0',
            textAlign: 'left'
        };

        var style3 = {
            color: '#a7a7a7',
            textDecoration: 'none',
            fontWeight: 'normal !important',
            border: 'none',
            display: 'none'//'inline-block'
        };

        var style4 = {
            overflow: 'hidden',
            position: 'relative',
            height: '0',
            padding: padding + '% 0 0 0',
            width: '100%',
        };

        var style5 = {
            display: 'inline-block',
            position: 'absolute',
            top: '0',
            left: '0',
            width: '100%',
            height: '100%',
            margin: '0',
            border: 'none'
        };

        var style6 = {
            margin: '0'
        };

        return (
            <div className="getty embed image" style={style1}>
                <div style={style2}>
                    <a href={this.props.href} target="_blank" style={style3}>Embed from Getty Images</a>
                </div>
                <div style={style4}>
                    <iframe src={this.props.src} width={this.props.width} height={this.props.height} scrolling="no" frameBorder="0" style={style5}>
                    </iframe>
                </div>
                <p style={style6}></p>
            </div>
        );
    }
}

GettyComponent.propTypes = {
    width: React.PropTypes.number.isRequired,
    height: React.PropTypes.number.isRequired,
    href: React.PropTypes.string.isRequired,
    src: React.PropTypes.string.isRequired
}

export default GettyComponent;
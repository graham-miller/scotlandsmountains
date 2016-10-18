import React, { Component } from 'react';
import $ from 'jquery';

class FullHeightContainer extends Component {

    constructor(props) {
        super(props);

        this.handleResize = this.handleResize.bind(this);
        this.calculateHeight = this.calculateHeight.bind(this);
    }

    handleResize() {
        this.setState = { height: this.calculateHeight() };
        debugger;
    }
    
    componentDidMount() {
        window.addEventListener('resize', this.handleResize);
    }

    componentWillUnmount() {
        window.removeEventListener('resize', this.handleResize);
    }

    calculateHeight() {
        const allowance = 85; 
        const minimum = 200; 
        const windowHeight = $(window).height();

        var height = windowHeight - allowance;
        height = height < minimum ? minimum : height;

        return height;
    }

    render() {

        const style = { height: this.calculateHeight() };

        return (
            <div style={style}>
                {this.props.children}
            </div>
        );
    }
}

export default FullHeightContainer;

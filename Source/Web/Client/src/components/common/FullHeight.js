import React, { Component } from "react";
import $ from "jquery";

class FullHeight extends Component {

    constructor(props) {
        super(props);

        this.handleResize = this.handleResize.bind(this);
        this.updateHeight = this.updateHeight.bind(this);
    }
    
    componentDidMount() {
        this.handleResize();
        window.addEventListener("resize", this.handleResize);
    }
    
    componentDidUpdate() {
        this.handleResize();
    }
    
    componentWillUnmount() {
        window.removeEventListener("resize", this.handleResize);
    }

    handleResize() {
        this.updateHeight();
        if (this.props.handleResize) {
            this.props.handleResize();
        }
    }

    updateHeight() {
        const minimum = 200; 
        const windowHeight = $(window).height();

        var height = windowHeight - this.props.allowance;
        height = height < minimum ? minimum : height;

        this.element.style.height = height + "px";
    }

    render() {

        return (
            <div
                ref={(div) => {this.element = div;}}
                className={this.props.className}
                style={this.props.style}>
                {this.props.children}
            </div>
        );
    }
}

export default FullHeight;

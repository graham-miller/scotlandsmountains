'use strict';

import React from 'react';
import $ from 'jquery';
import NavigationExpandMore from 'material-ui/svg-icons/navigation/expand-more';
import NavigationExpandLess from 'material-ui/svg-icons/navigation/expand-less';

class FooterComponent extends React.Component {
    
    constructor(props) {
        super(props);
        this.state = {isVisible: false};
        this.updateHandle = this.updateHandle.bind(this);
    }

    componentWillMount() {
        $(window).on('DOMContentLoaded load resize scroll', this.updateHandle);
    }

    componentWillUnmount() {
        $(window).off('DOMContentLoaded load resize scroll', this.updateHandle);
    }

    componentDidMount() {
        this.updateHandle();
    }
        
    updateHandle() {
        this.setState({isVisible: this.isVisible()});
    }
    
    isVisible() {
        var el = $('#footer-component .content')[0];
        var rect = el.getBoundingClientRect();
        return (
            rect.top >= 0 && rect.left >= 0 &&
            rect.bottom <= (window.innerHeight || document.documentElement.clientHeight) &&
            rect.right <= (window.innerWidth || document.documentElement.clientWidth)
        );
    }

    scrollToFooter() {
        $("html, body").animate({scrollTop: $(document).height()});
    }

    scrollFromFooter() {
        $("html, body").animate({scrollTop: 0});
    }

    render() {
        
        const onClick = this.state.isVisible ? this.scrollFromFooter : this.scrollToFooter;
        const icon = this.state.isVisible ? (<NavigationExpandMore color={'#e8e8e8'} />) : (<NavigationExpandLess color={'#e8e8e8'} />);
         
        return (
            <div id="footer-component">
                {this.props.showHandle ? <div className="handle" onClick={onClick}>{icon}</div> : null}
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
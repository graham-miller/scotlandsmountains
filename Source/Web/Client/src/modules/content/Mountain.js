import React, { Component } from 'react';

import $ from 'jquery';

class Mountain extends Component {

    constructor(props) {
        super(props);

        this.onMouseOver = this.onMouseOver.bind(this);
        this.onMouseOut = this.onMouseOut.bind(this);
    }

    onMouseOver() {
        $(this.props.mountain.marker._icon).addClass('highlighted');
    }

    onMouseOut() {
        $(this.props.mountain.marker._icon).removeClass('highlighted');
    }
    
    render() {



        return (
            <tr
                onMouseOver={this.onMouseOver}
                onMouseOut={this.onMouseOut} >
                <td>{this.props.index + 1}</td>
                <td>
                    {this.props.mountain.name}<br />
                    <span style={{fontSize:'80%'}}>{this.props.mountain.height}</span>
                </td>
            </tr>
        );
    }
}

export default Mountain;

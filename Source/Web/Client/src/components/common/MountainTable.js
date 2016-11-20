import React, { Component } from "react";
import { browserHistory } from "react-router";
import $ from "jquery";

import "./MountainTable.scss";

class MountainTable extends Component {
    
    constructor(props){
        super(props);

        this.onMouseOver = this.onMouseOver.bind(this);
        this.onMouseOut = this.onMouseOut.bind(this);
        this.onClick = this.onClick.bind(this);
    }

    getRowNumberTh() {
        if (this.props.showRowNumbers) {
            return (<th className="right">Number</th>);
        }
        return null;
    }

    getRowNumberTd(index) {
        if (this.props.showRowNumbers) {
            return (<td className="right">{index+1}</td>);
        }
        return null;
    }

    onMouseOver(mountain) {
        if (mountain.marker) {
            $(mountain.marker._icon).addClass("highlighted");
        }
    }

    onMouseOut(mountain) {
        if (mountain.marker) {
            $(mountain.marker._icon).removeClass("highlighted");
        }
    }

    onClick(mountain) {
        var name = mountain.name.replace(/\s/gmi, "_").replace(/[^a-z0-9_]/gmi, "");
        browserHistory.push("/mountain/" + mountain.id + "/" + name);
    }

    render() {

        return (
            <div>
                <table className="mountain">
                <thead>
                    <tr>
                        { this.getRowNumberTh() }
                        <th>
                            Name
                            <span className="small indented">height</span>
                        </th>
                    </tr>
                </thead>
                <tbody>
                    {
                        this.props.mountains.map((mountain, index) =>
                            <tr
                                key={mountain.id}
                                onMouseOver={() => this.onMouseOver(mountain)}
                                onMouseOut={() => this.onMouseOut(mountain)}
                                onClick={() => this.onClick(mountain)}>
                                { this.getRowNumberTd(index) }
                                <td>
                                    {mountain.name}
                                    <div className="small indented">{mountain.height}</div>
                                </td>
                            </tr>
                        )
                    }
                </tbody>
                </table>
            </div>
        );
    }
}

MountainTable.defaultProps = {
    showRowNumbers: false,
    mountains: []
};

export default MountainTable;

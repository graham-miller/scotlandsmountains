import React, { Component } from "react";
import { connect } from "react-redux";
import { browserHistory } from "react-router";
import $ from "jquery";

import { fetchClassification } from "../../actions/mountains";

import Loading from "../common/Loading";
import NetworkError from "../common/NetworkError";

import "./Table.scss";

class TableComponent extends Component {

    constructor(props) {
        super(props);

        this.onMouseOver = this.onMouseOver.bind(this);
        this.onMouseOut = this.onMouseOut.bind(this);
        this.onClick = this.onClick.bind(this);
    }

    componentDidMount() {
        this.props.dispatch(fetchClassification(this.props.routeParams.table));
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

        if (this.props.status.error) { return (<NetworkError />); }

        if (this.props.status.loading) { return (<Loading />); }

        if (!this.props.mountains) { return (<Loading />); }

        return (
            <div>
                <table style={{width:"100%"}}>
                    <thead>
                        <tr>
                            <th className="right">Number</th>
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
                                    onClick={() => this.onClick(mountain)}
                                    style={{cursor:"pointer"}}>
                                    <td className="right">{index+1}</td>
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

const mapStateToProps = (state) => {
    return {
        mountains: state.mountains.items,
        status: state.mountains.status
    };
};

const Table = connect(mapStateToProps)(TableComponent);

export default Table;

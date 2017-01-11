import React, { Component } from "react";
import { connect } from "react-redux";

import { fetchMountain } from "../../actions/mountains";

import Loading from "../common/Loading";
import NetworkError from "../common/NetworkError";

class MountainComponent extends Component {

    componentWillMount() {
        this.props.dispatch(fetchMountain(this.props.params.id));
    }

    render() {

        if (this.props.status.error) { return (<NetworkError />); }

        if (this.props.status.loading) { return (<Loading />); }

        if (!this.props.mountain) { return (<Loading />); }

        let mountain = this.props.mountain;

        return (
            <dl>
                <dt>Height</dt>
                <dd>{mountain.height}</dd>

                <dt>Prominence</dt>
                <dd>{mountain.prominence}</dd>

                <dt>Grid ref.</dt>
                <dd><span title={mountain.tenFigureGridRef}>{mountain.sixFigureGridRef}</span></dd>

                <dt>Section</dt>
                <dd>{mountain.section.name}</dd>

                <dt>Country</dt>
                <dd>{mountain.country.name}</dd>

                <dt>Summit</dt>
                <dd>{mountain.feature}</dd>

                <dt>Observations</dt>
                <dd>{mountain.observations}</dd>

                <dt>Lists</dt>
                <dd><ul>{
                    mountain.lists.map((list) => <li key={list.id}>{list.name}</li>)
                }</ul></dd>

                <dt>Maps</dt>
                <dd><ul>{
                    mountain.maps.map((map) => <li key={map.id}>{map.name}</li>)
                }</ul></dd>
            </dl>
        );
    }
}

const mapStateToProps = (state) => {
    return {
        mountain: state.mountains.items.length === 1 ? state.mountains.items[0] : null,
        status: state.mountains.status
    };
};

const Mountain = connect(mapStateToProps)(MountainComponent);

export default Mountain;

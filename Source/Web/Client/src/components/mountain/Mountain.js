import React, { Component } from "react";
import { connect } from "react-redux";
import { fetchMountain } from "./actions";

class MountainComponent extends Component {

    componentWillMount() {
        this.props.dispatch(fetchMountain(this.props.params.id));
    }

    render() {

        let mountain = this.props.mountain;

        if (!mountain) { return null; }

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
        mountain: state.mountain.value
    };
};

const Mountain = connect(mapStateToProps)(MountainComponent);

export default Mountain;

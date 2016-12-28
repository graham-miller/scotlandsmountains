import React, { Component } from "react";
import { connect } from "react-redux";

import { fetchMountain } from "../../actions/mountains";

import Loading from "../common/Loading";
import NetworkError from "../common/NetworkError";

import {List, ListItem} from "material-ui/List";
import Chip from "material-ui/Chip";

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
            <List>
                <ListItem
                    leftIcon={null}
                    primaryText="Height"
                    secondaryText={mountain.height} />
                <ListItem
                    leftIcon={null}
                    primaryText="Prominence"
                    secondaryText={mountain.prominence} />
                <ListItem
                    leftIcon={null}
                    primaryText="Grid ref."
                    secondaryText={<span title={mountain.tenFigureGridRef}>{mountain.sixFigureGridRef}</span>} />
                <ListItem
                    leftIcon={null}
                    primaryText="Section"
                    secondaryText={mountain.section.name} />
                <ListItem
                    leftIcon={null}
                    primaryText="Country"
                    secondaryText={mountain.country.name} />
                <ListItem
                    leftIcon={null}
                    primaryText="Summit"
                    secondaryText={mountain.feature} />
                <ListItem
                    leftIcon={null}
                    primaryText="Observations"
                    secondaryText={mountain.observations} />
                <ListItem
                    leftIcon={null}
                    primaryText="Classifications"
                    secondaryText={
                        <ul> {
                            mountain.classifications.map((classification) =>
                                <li><a href="" key={classification.id}>{classification.name}</a></li>
                        )}
                        </ul>} />
                <ListItem
                    leftIcon={null}
                    primaryText="Maps"
                    secondaryText={
                        <ul> {
                            mountain.maps.map((map) =>
                                <li><a href="" key={map.id}>{map.name}</a></li>
                        )}
                        </ul>} />
            </List>
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

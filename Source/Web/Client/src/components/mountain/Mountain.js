import React, { Component } from 'react';
import { connect } from 'react-redux';

import { fetchMountain } from '../../actions/mountains';

import FullHeight from '../common/FullHeight';
import Loading from '../common/Loading';
import NetworkError from '../common/NetworkError';

import './Mountain.scss';

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
            <div>
                <h2>{mountain.name}</h2>
                <FullHeight className='scrollable mountain' allowance='128'>
                    <dl>
                        <dt>Height</dt>
                        <dd>{mountain.height}</dd>
                    </dl>
                    <dl>
                        <dt>Prominence</dt>
                        <dd>{mountain.prominence}</dd>
                    </dl>
                    <dl>
                        <dt>Grid ref.</dt>
                        <dd title={mountain.tenFigureGridRef} >{mountain.sixFigureGridRef}</dd>
                    </dl>
                    <dl>
                        <dt>Section</dt>
                        <dd>{mountain.section.name}</dd>
                    </dl>
                    <dl>
                        <dt>Country</dt>
                        <dd>{mountain.country.name}</dd>
                    </dl>
                    <dl>
                        <dt>Summit feature</dt>
                        <dd>{mountain.feature}</dd>
                    </dl>
                    <dl>
                        <dt>Summit observations</dt>
                        <dd>{mountain.observations}</dd>
                    </dl>
                    <dl>
                        <dt>Classifications</dt>
                        <dd>
                            <ul>{
                                mountain.classifications.map((classification) =>
                                    <li key={classification.id}>{classification.name}</li>
                            )}</ul>
                        </dd>
                    </dl>
                    <dl>
                        <dt>Maps</dt>
                        <dd>
                            <ul>{
                                mountain.maps.map((map) =>
                                    <li key={map.id}>{map.name}</li>
                            )}</ul>
                        </dd>
                    </dl>
                </FullHeight>
            </div>
        );
    }
}

const mapStateToProps = (state) => {
    return {
        mountain: state.mountains.items.length === 1 ? state.mountains.items[0] : null,
        status: state.mountains.status
    };
}

const Mountain = connect(mapStateToProps)(MountainComponent);

export default Mountain;

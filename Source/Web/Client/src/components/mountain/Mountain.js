import React, { Component } from 'react';

import { fetchMountain } from '../../actions/mountains';

import FullHeightContainer from '../common/FullHeightContainer';
import Loading from '../common/Loading';

import './Mountain.scss';

class Mountain extends Component {

    componentWillMount() {
        this.props.dispatch(fetchMountain(this.props.params.id));
    }

    render() {

        if (this.props.mountains.status.error) {
            return (<div>Network error</div>);
        }

        if (this.props.mountains.status.loading) {
            return (<Loading />);
        }

        var mountain = this.props.mountains.list[0];

        if (mountain) {
            return (
            <div>
                <h2>{mountain.name}</h2>
                <FullHeightContainer className='scrollable mountain' allowance='128'>
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
                </FullHeightContainer>
            </div>);
        }

        return (<div>Not found</div>);
    }
}

export default Mountain;

import React, { Component } from 'react';
import { connect } from 'react-redux';
import { browserHistory } from 'react-router';
import $ from 'jquery';

import { fetchClassification } from '../../actions/mountains';

import Loading from '../common/Loading';
import NetworkError from '../common/NetworkError';
import FullHeight from '../common/FullHeight'

import './Classification.scss'

class ClassificationComponent extends Component {

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
            $(mountain.marker._icon).addClass('highlighted');
        }
    }

    onMouseOut(mountain) {
        if (mountain.marker) {
            $(mountain.marker._icon).removeClass('highlighted');
        }
    }

    onClick(mountain) {
        var name = mountain.name.replace(/\s/gmi, '_').replace(/[^a-z0-9_]/gmi, '')
        browserHistory.push('/mountain/' + mountain.id + '/' + name);
    }

    render() {

        if (this.props.status.error) { return (<NetworkError />); }

        if (this.props.status.loading) { return (<Loading />); }

        if (!this.props.mountains) { return (<Loading />); }

        return (
            <div>
                <h2 style={{textTransform: 'capitalize'}}>{this.props.routeParams.table}</h2>
                <FullHeight className='scrollable' allowance='128'>
                    <ol className='classification-table'>
                        {
                            this.props.mountains.map((mountain, index) =>
                                <li
                                    key={mountain.id}
                                    onMouseOver={() => this.onMouseOver(mountain)}
                                    onMouseOut={() => this.onMouseOut(mountain)}
                                    onClick={() => this.onClick(mountain)}>
                                    <span className='number'>{index+1}</span>
                                    <span className='name'>{mountain.name}</span>
                                    <span className='height'>{mountain.height}</span>
                                </li>
                            )
                        }                
                    </ol>
                </FullHeight>
            </div>
        );
    }
}

const mapStateToProps = (state) => {
    return {
        mountains: state.mountains.items,
        status: state.mountains.status
    };
}

const Classification = connect(mapStateToProps)(ClassificationComponent);

export default Classification;

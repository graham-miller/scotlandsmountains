import React, { Component } from 'react';

import { fetchTable } from '../../actions/mountains';

import Mountain from './Mountain';
import './Mountains.scss';
import Loading from './Loading';

import getHeight from '../../util/getHeight';

class Mountains extends Component {

    componentDidMount() {
        this.props.dispatch(fetchTable('munro'));
    }

    render() {

        if (this.props.error) {
            return (<div>Network error</div>);
        }

        if (this.props.loading) {
            return (<Loading />);
        }

        return (
            <div>
                <div>
                    <h2>Munros</h2>
                </div>
                <div className="scrollable" style={{height: getHeight()-43}}>
                    <table className="table table-hover table-sm">
                        <tbody>
                            {
                                this.props.mountains.map((mountain, index) =>
                                    <Mountain key={mountain.id} mountain={mountain} index={index} />
                                )
                            }                
                        </tbody>
                    </table>
                </div>
            </div>
        );
    }
}

export default Mountains;

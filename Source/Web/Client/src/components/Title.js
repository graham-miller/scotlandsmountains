import React, { Component } from 'react';
import { browserHistory } from 'react-router'

class Title extends Component {

    constructor() {
        super();
        this.goToUrl = this.goToUrl.bind(this);
    }

    goToUrl(url, event) {
        browserHistory.push(url);   
        event.preventDefault();
    }

    render() {
        return (
            <nav className="navbar navbar-fixed-top navbar-dark bg-inverse bg-faded">
                <a className="navbar-brand" href="/" onClick={(e) => this.goToUrl('/', e)}>Scotland&apos;s Mountains</a>
                <div className="pull-xs-right">
                    <button
                        className="navbar-toggler hidden-sm-up" type="button"
                        data-toggle="collapse" data-target="#exCollapsingNavbar2"
                        aria-controls="exCollapsingNavbar2" aria-expanded="false" aria-label="Toggle navigation">
                        &#9776;
                    </button>
                    <div className="collapse navbar-toggleable-xs" id="exCollapsingNavbar2">
                        <ul className="nav navbar-nav">
                            <li className="nav-item">
                                <a className="nav-link" href="/search" onClick={(e) => this.goToUrl('/search', e)}>Search</a>
                            </li>
                        </ul>
                    </div>
                </div>
            </nav>
        );
    }
}

export default Title;

import React, { Component } from 'react';

class Content extends Component {

    componentDidMount() {
        fetch('api/mountains/search/ben nevis')
            .then(function(response) {
                return response.text();
            }).then(function(text) {
                console.log(text);
            });
    }

    componentWillUnmount() {
    }

    render() {
        return (
            <div>Content</div>
        );
    }
}

export default Content;

import React from 'react';
import ReactDOM from 'react-dom';
import { createStore } from 'redux'
import { Provider } from 'react-redux'

import Title from './Title';

it('renders without crashing', () => {
    const div = document.createElement('div');
    ReactDOM.render((<Title />), div);
});

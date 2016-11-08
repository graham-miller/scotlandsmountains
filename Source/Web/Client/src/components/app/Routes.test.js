import React from 'react';
import ReactDOM from 'react-dom';
import { createStore } from 'redux'
import { Provider } from 'react-redux'

import Routes from './Routes';
import { app } from '../../reducers/index'

let store = createStore(app);

it('renders without crashing', () => {
    const div = document.createElement('div');
    ReactDOM.render((
        <Provider store={store}>
            <Routes />
        </Provider>
    ), div);
});

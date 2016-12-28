import React from "react";
import { render } from "react-dom";
import { Provider } from "react-redux";
import { createStore, applyMiddleware } from "redux";
import thunkMiddleware from "redux-thunk";
import MuiThemeProvider from "material-ui/styles/MuiThemeProvider";

import { app } from "./reducers/index";
import App from "./components/app/App";

import "normalize.css/normalize.css";
import "leaflet/dist/leaflet.css";
import "./index.scss";

import injectTapEventPlugin from "react-tap-event-plugin";
injectTapEventPlugin();

let store = createStore(app, applyMiddleware(thunkMiddleware));

const element = (
    <Provider store={store}>
        <MuiThemeProvider>
            <App/>
        </MuiThemeProvider>
    </Provider>
);

render(element, document.getElementById("root"));

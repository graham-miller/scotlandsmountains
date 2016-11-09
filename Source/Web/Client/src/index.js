import React from "react";
import { render } from "react-dom";
import { Provider } from "react-redux";
import { createStore, applyMiddleware } from "redux";
import thunkMiddleware from "redux-thunk";

import { app } from "./reducers/index";
import App from "./components/app/App";

import "./index.scss";

require("jquery");
require("tether");

import "bootstrap/dist/js/bootstrap.js";

let store = createStore(app, applyMiddleware(thunkMiddleware));

render(
    <Provider store={store}>
        <App />
    </Provider>,
    document.getElementById("sm-app"));

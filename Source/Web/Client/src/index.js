import React from "react";
import { render } from "react-dom";
import { Provider } from "react-redux";
import { createStore, applyMiddleware } from "redux";
import thunkMiddleware from "redux-thunk";

import { app } from "./reducers/index";
import App from "./components/app/App";

import "normalize.css/normalize.css";
import "leaflet/dist/leaflet.css";
import "./index.scss";

let store = createStore(app, applyMiddleware(thunkMiddleware));

render(<Provider store={store}><App/></Provider>,document.getElementById("root"));

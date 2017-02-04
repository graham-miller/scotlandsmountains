import React from "react";
import { render } from "react-dom";
import { Provider } from "react-redux";
import MuiThemeProvider from "material-ui/styles/MuiThemeProvider";
import getMuiTheme from "material-ui/styles/getMuiTheme";
import store from "./state/store";
import Routes from "./components/app/Routes";

import "normalize.css/normalize.css";
import "leaflet/dist/leaflet.css";
import "./index.scss";

import injectTapEventPlugin from "react-tap-event-plugin";
injectTapEventPlugin();

const muiTheme = getMuiTheme({
    palette: {
        primary1Color: "#909740",
    }
});

const element = (
    <Provider store={store}>
        <MuiThemeProvider muiTheme={muiTheme}>
            <Routes />
        </MuiThemeProvider>
    </Provider>
);

render(element, document.getElementById("root"));

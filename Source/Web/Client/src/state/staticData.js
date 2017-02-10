import { get } from "../api";
import defaultState from "./defaultState";

const StaticDataActions = {
    Request: "STATICDATA_REQUEST",
    Receive: "STATICDATA_RECEIVE",
    Error: "STATICDATA_ERROR"
};

function request() {
    return {
        type: StaticDataActions.Request
    };
}

function receive(json) {
    return {
        type: StaticDataActions.Receive,
        json
    };
}

function error() {
    return {
        type: StaticDataActions.Error
    };
}

export function fetchStaticData() {
    return get("staticdata", request, receive, error);
}

export function reducer(state = defaultState.staticData, action) {

    switch (action.type) {

    case StaticDataActions.Request:
        return {
            status: { loading: true, error: false },
            value: null
        };

    case StaticDataActions.Receive:
        return {
            status: { loading: false, error: false },
            value: action.json,
            lastUpdated: + new Date()            
        };

    case StaticDataActions.Error:
        return {
            status: { loading: false, error: true },
            value: null
        };

    default:
        return state;
    }
};

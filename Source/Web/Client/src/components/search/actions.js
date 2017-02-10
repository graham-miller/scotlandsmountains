import { get } from "../../api";

export const SearchActions = {
    Request: "SEARCH_REQUEST",
    Receive: "SEARCH_RECEIVE",
    Clear: "SEARCH_CLEAR",
    Error: "SEARCH_ERROR",
};

function request() {
    return {
        type: SearchActions.Request
    };
}

function receive(json) {
    return {
        type: SearchActions.Receive,
        json
    };
}

function clear() {
    return {
        type: SearchActions.Clear
    };
}

function error() {
    return {
        type: SearchActions.Error
    };
}

export function search(term) {
    if (term && term.length > 2) {
        return get("search/" + term, request, receive, error);
    } else {
        return (dispatch) => dispatch(clear());
    }
}

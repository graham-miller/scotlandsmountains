import callApi from "../../state/callApi";

export const SearchActions = {
    Request: "SEARCH_REQUEST",
    Receive: "SEARCH_RECEIVE",
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

function error() {
    return {
        type: SearchActions.Error
    };
}

export function search(term) {
    return callApi("/api/search/" + term, request, receive, error);
}

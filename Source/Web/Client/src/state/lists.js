import callApi from "./callApi";

const ListsActions = {
    Request: "LISTS_REQUEST",
    Receive: "LISTS_RECEIVE",
    Error: "LISTS_ERROR"
};

function request() {
    return {
        type: ListsActions.Request
    };
}

function receive(json) {
    return {
        type: ListsActions.Receive,
        json
    };
}

function error() {
    return {
        type: ListsActions.Error
    };
}

export function fetchLists() {
    return callApi("/api/lists/", request, receive, error);
}

export function reducer(state = [], action) {

    switch (action.type) {

    case ListsActions.Request:
        return [];

    case ListsActions.Receive:
        return action.json;

    case ListsActions.Error:
        return [];

    default:
        return state;
    }
};

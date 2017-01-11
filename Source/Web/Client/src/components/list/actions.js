import callApi from "../../state/callApi";

export const Actions = {
    RequestList: "REQUEST_LIST",
    ReceiveList: "RECEIVE_LIST",
    ListError: "LIST_ERROR",
};

function requestList() {
    return {
        type: Actions.RequestList
    };
}

function receiveList(json) {
    return {
        type: Actions.ReceiveList,
        json
    };
}

function listError() {
    return {
        type: Actions.ListError
    };
}

export function fetchList(list) {
    return callApi("/api/lists/" + list, requestList, receiveList, listError);
}

export const Actions = {
    RequestStart: "REQUEST_START",
    ReceiveMountain: "RECEIVE_MOUNTAIN",
    ReceiveList: "RECEIVE_LIST",
    ReceiveSearch: "RECEIVE_SEARCH",
    RequestError: "REQUEST_ERROR",
    Clear: "CLEAR"
};

function requestStart() {
    return {
        type: Actions.RequestStart
    };
}

function receiveMountain(json) {
    return {
        type: Actions.ReceiveMountain,
        json
    };
}

function receiveList(json) {
    return {
        type: Actions.ReceiveList,
        json
    };
}

function receiveSearch(json) {
    return {
        type: Actions.ReceiveSearch,
        json
    };
}

function requestError() {
    return {
        type: Actions.RequestError
    };
}

export function fetchMountain(id) {
    return callApi("/api/mountains/" + id, receiveMountain);
}

export function fetchList(list) {
    return callApi("/api/lists/" + list, receiveList);
}

export function search(term) {
    return callApi("/api/search/" + term, receiveSearch);
}

export function clear() {
    return {
        type: Actions.Clear
    };
}

function callApi(url, onSuccess) {
    return dispatch => {
        dispatch(requestStart());
        return fetch(url, {redirect: "follow", mode: "cors"})
            .then(response => {
                if (!response.ok) {
                    throw new Error();
                }
                return response.json();
            })
            .then(json => {
                dispatch(onSuccess(json));
            })
            .catch(function(error) {
                dispatch(requestError());
            });
    };
}
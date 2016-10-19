function requestMountain(id) {
    return {
        type: 'REQUEST_MOUNTAIN',
        id
    }
}

function receiveMountain(json) {
    return {
        type: 'RECEIVE_MOUNTAIN',
        mountain: json
    }
}

function requestTable() {
    return {
        type: 'REQUEST_TABLE',
    }
}

function receiveTable(json) {
    return {
        type: 'RECEIVE_TABLE',
        mountains: json
    }
}

export function clearList() {
    return {
        type: 'CLEAR_LIST'
    }
}

function requestSearch(term) {
    return {
        type: 'REQUEST_SEARCH',
        term
    }
}

function receiveSearch(json) {
    return {
        type: 'RECEIVE_SEARCH',
        searchResult: json
    }
}

function didntSearch(term) {
    return {
        type: 'DIDNT_SEARCH',
        term
    }
}

function networkError() {
    return {
        type: 'NETWORK_ERROR'
    }
}

export function fetchMountain(id) {
    return dispatch => {
        dispatch(requestMountain())
        return fetch('/api/mountains/' + id, {
            redirect: 'follow',
            mode: 'cors'
        })
        .then(response => {
            if (!response.ok) {
                throw new Error();
            }
            return response.json();
        })
        .then(json => {
            dispatch(receiveMountain(json));
        })
        .catch(function(error) {
            dispatch(networkError());
        });
    }
}

export function fetchTable(table) {
    return dispatch => {
        dispatch(requestTable())
        return fetch('/api/mountains/' + table, {
            redirect: 'follow',
            mode: 'cors'
        })
        .then(response => {
            if (!response.ok) {
                throw new Error();
            }
            return response.json();
        })
        .then(json => {
            dispatch(receiveTable(json));
        })
        .catch(function(error) {
            dispatch(networkError());
        });
    }
}

export function search(term) {

    if (!term || term.length < 3) {
        return dispatch => dispatch(didntSearch(term));
    }

    return dispatch => {
        dispatch(requestSearch(term))
        return fetch('/api/mountains/search/' + term, {
            redirect: 'follow',
            mode: 'cors'
        })
        .then(response => {
            if (!response.ok) {
                throw new Error();
            }
            return response.json();
        })
        .then(json => {
            dispatch(receiveSearch(json));
        })
        .catch(function(error) {
            dispatch(networkError());
        });
    }
}
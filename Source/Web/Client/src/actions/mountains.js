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

function networkError() {
    return {
        type: 'NETWORK_ERROR'
    }
}

export function fetchTable(table) {
    return dispatch => {
        dispatch(requestTable())
        return fetch('/api/mountains/' + table, {
            redirect: 'follow',
            mode: 'cors'
        })
        .then(response => response.json())
        .then(json => dispatch(receiveTable(json)))
    }
}
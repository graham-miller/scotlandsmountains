const defaultState = {
    loading: false,
    error: false,
    mountains: []
};

const mountains = (state = defaultState, action) => {
    switch (action.type) {
        
        case 'REQUEST_TABLE':
            return Object.assign({}, {
                loading: true,
                error: false,
                mountains: []
            });

        case 'RECEIVE_TABLE':
            return Object.assign({}, {
                loading: false,
                error: false,
                mountains: action.mountains
            });

        case 'NETWORK_ERROR':
            return Object.assign({}, {
                loading: false,
                error: true,
                mountains: []
            });

        default:
            return Object.assign({}, state);

    }
};

export default mountains;
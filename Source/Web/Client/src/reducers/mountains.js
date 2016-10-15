const defaultState = {
    error: false,
    mountains: []
};

const mountains = (state = defaultState, action) => {
    switch (action.type) {
        
        case 'REQUEST_TABLE':
            return defaultState;

        case 'RECEIVE_TABLE':
            return Object.assign({}, defaultState, {
                mountains: action.mountains
            });
        
        case 'NETWORK_ERROR':
            return Object.assign({}, defaultState, {
                error: true
            });
        
        default:
            return state
    }
};

export default mountains;
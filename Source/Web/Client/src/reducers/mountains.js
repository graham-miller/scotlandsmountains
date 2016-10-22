import { Actions } from '../actions/mountains';

const defaultStatus = {
    loading: false,
    error: false
};

const loadingStatus = {
    loading: true,
    error: false
};

const errorStatus = {
    loading: false,
    error: true
};

const defaultState = {
    status: defaultStatus,
    searchResult: null,
    classification: null,
    mountain: null
};

const mountains = (state = defaultState, action) => {
    switch (action.type) {
        
        case Actions.RequestStart:
            return Object.assign({}, state, {
                status: loadingStatus,
                searchResult: null,
                classification: null,
                mountain: null
            });

        case Actions.ReceiveMountain:
            return Object.assign({}, state, {
                status: defaultStatus,
                searchResult: null,
                classification: null,
                mountain: action.json
        });

        case Actions.ReceiveClassification:
            return Object.assign({}, state, {
                status: defaultStatus,
                searchResult: null,
                classification: action.json,
                mountain: null
            });
        
        case Actions.RequestIgnored:
            return Object.assign({}, state, {
                status: defaultStatus,
                searchResult: null,
                classification: null,
                mountain: null
            });

        case Actions.ReceiveSearch:
            return Object.assign({}, state, {
                status: defaultStatus,
                searchResult: action.json,
                classification: null,
                mountain: null
            });

        case Actions.RequestError:
            return Object.assign({}, state, {
                status: errorStatus,
                searchResult: null,
                classification: null,
                mountain: null
            });

        default:
            return Object.assign({}, state);
    }
};

export default mountains;
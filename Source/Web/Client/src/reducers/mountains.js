import { Actions } from '../actions/mountains';

const defaultStatus = { loading: false, error: false };

const defaultState = {
    status: defaultStatus,
    items: []
};

const mountains = (state = defaultState, action) => {
    switch (action.type) {
        
        case Actions.RequestStart:
            return Object.assign({}, state, {
                status: { loading: true, error: false },
                items: []
            });

        case Actions.ReceiveMountain:
            return Object.assign({}, state, {
                status: defaultStatus,
                items: [action.json]
        });

        case Actions.ReceiveClassification:
            return Object.assign({}, state, {
                status: defaultStatus,
                items: action.json
            });
        
        case Actions.ReceiveSearch:
            return Object.assign({}, state, {
                status: defaultStatus,
                items: action.json.results
            });

        case Actions.RequestError:
            return Object.assign({}, state, {
                status: { loading: false, error: true },
                items: []
            });

        default:
            return Object.assign({}, state);
    }
};

export default mountains;
import { SearchActions } from "./actions";
import defaultState from "../../state/defaultState";
import requestStatus from "../../state/requestStatus";

const reducer = (state = defaultState.search, action) => {
    
    switch (action.type) {

    case SearchActions.Start:
        return Object.assign({}, state, {
            status: requestStatus.loading,
            value: null,
            lastUpdated: null
        });

    case SearchActions.Receive:
        return Object.assign({}, state, {
            status: requestStatus.success,
            value: action.json,
            lastUpdated: + new Date()
        });

    case SearchActions.Clear:
        return defaultState.search;

    case SearchActions.Error:
        return Object.assign({}, state, {
            status: requestStatus.error,
            value: null,
            lastUpdated: null
        });

    default:
        return Object.assign({}, state);
    }
};

export default reducer;
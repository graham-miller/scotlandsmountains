import { Actions } from "../../state/actions";
import { ListActions } from "./actions";
import defaultState from "../../state/defaultState";
import requestStatus from "../../state/requestStatus";

const reducer = (state = defaultState.list, action) => {
    
    switch (action.type) {

    case ListActions.Request:
        return Object.assign({}, state, {
            status: requestStatus.loading,
            value: null,
            lastUpdated: null
        });

    case ListActions.Receive:
        return Object.assign({}, state, {
            status: requestStatus.success,
            value: action.json,
            lastUpdated: + new Date()
        });

    case ListActions.Error:
        return Object.assign({}, state, {
            status: requestStatus.error,
            value: null,
            lastUpdated: null
        });

    case Actions.ClearMountains:
        return defaultState.list;

    default:
        return Object.assign({}, state);
    }
};

export default reducer;
import { Actions } from "../../state/actions";
import { MountainActions } from "./actions";
import defaultState from "../../state/defaultState";
import requestStatus from "../../state/requestStatus";

const reducer = (state = defaultState.mountain, action) => {
    
    switch (action.type) {

    case MountainActions.Request:
        return Object.assign({}, state, {
            status: requestStatus.loading,
            value: null,
            lastUpdated: null
        });

    case MountainActions.Receive:
        return Object.assign({}, state, {
            status: requestStatus.success,
            value: action.json,
            lastUpdated: + new Date()
        });

    case MountainActions.Error:
        return Object.assign({}, state, {
            status: requestStatus.error,
            value: null,
            lastUpdated: null
        });

    case Actions.ClearMountains:
        return defaultState.mountain;

    default:
        return Object.assign({}, state);
    }
};

export default reducer;
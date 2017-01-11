import { Actions } from "./actions";
import defaultState from "../../state/defaultState";
import requestStatus from "../../state/requestStatus";

const reducer = (state = defaultState.mountain, action) => {
    
    switch (action.type) {

    case Actions.RequestMountain:
        return Object.assign({}, state, {
            status: requestStatus.loading,
            value: null,
            lastUpdated: null
        });

    case Actions.ReceiveMountain:
        return Object.assign({}, state, {
            status: requestStatus.success,
            value: action.json,
            lastUpdated: + new Date()
        });

    case Actions.MountainError:
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
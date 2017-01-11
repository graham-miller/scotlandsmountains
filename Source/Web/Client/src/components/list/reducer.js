import { Actions } from "./actions";
import defaultState from "../../state/defaultState";
import requestStatus from "../../state/requestStatus";

const reducer = (state = defaultState.list, action) => {
    
    switch (action.type) {

    case Actions.RequestList:
        return Object.assign({}, state, {
            status: requestStatus.loading,
            value: null,
            lastUpdated: null
        });

    case Actions.ReceiveList:
        return Object.assign({}, state, {
            status: requestStatus.success,
            value: action.json,
            lastUpdated: + new Date()
        });

    case Actions.ListError:
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
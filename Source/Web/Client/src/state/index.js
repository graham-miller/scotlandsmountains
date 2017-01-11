import { combineReducers } from "redux";
import map from "../components/map/reducers";

import list from "../components/list/reducer";
import mountain from "../components/mountain/reducer";

export const app = combineReducers({
    list,
    mountain,
    map
});

export default app;
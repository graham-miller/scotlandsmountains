import { combineReducers } from "redux";
import map from "../components/map/reducers";

import { reducer as lists }  from "./lists";
import list from "../components/list/reducer";
import mountain from "../components/mountain/reducer";
import search from "../components/search/reducer";

export const app = combineReducers({
    lists,
    list,
    mountain,
    search,
    map
});

export default app;
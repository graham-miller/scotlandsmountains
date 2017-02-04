import { combineReducers } from "redux";

import { reducer as staticData }  from "./staticData";
import map from "../components/map/reducers";
import list from "../components/list/reducer";
import mountain from "../components/mountain/reducer";
import search from "../components/search/reducer";

export default combineReducers({
    staticData,
    list,
    mountain,
    search,
    map
});

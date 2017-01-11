import { combineReducers } from "redux";
import mountains from "../reducers/mountains";
import map from "../components/map/reducers";

import list from "../components/list/reducer";

export const app = combineReducers({
    list,
    mountains,
    map
});

export default app;
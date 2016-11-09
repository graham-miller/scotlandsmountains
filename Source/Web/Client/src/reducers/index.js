import { combineReducers } from "redux";
import mountains from "./mountains";
import map from "./map";

export const app = combineReducers({
    mountains,
    map
});

export default app;
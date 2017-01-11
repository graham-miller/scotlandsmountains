import { combineReducers } from "redux";
import mountains from "./mountains";
import map from "../components/map/reducers";

export const app = combineReducers({
    mountains,
    map
});

export default app;
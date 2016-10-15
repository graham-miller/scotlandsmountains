import { combineReducers } from 'redux';
import map from './map';
import mountains from './mountains';

const app = combineReducers({
    map,
    mountains
});

export default app;
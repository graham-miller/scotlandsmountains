import { combineReducers } from 'redux';
import mountains from './mountains';
import map from './map';

const app = combineReducers({
    mountains,
    map
});

export default app;
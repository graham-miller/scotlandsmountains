import { Actions } from '../actions/map';
import mapFactory from '../factories/mapFactory';

const defaultState = {
    object: null,
    canZoomIn: true,
    canZoomOut: true,
    baseLayer: null
};

const map = (state = defaultState, action) => {
    switch (action.type) {
        
        case Actions.Create:
            return Object.assign({}, state, {
                object: mapFactory(action.elementId)
            });

        case Actions.ZoomIn:
            state.map.zoomIn();
            return Object.assign({}, state, {
                canZoomIn: state.map.getZoom() < state.map.getMaxZoom(),
                canZoomOut: state.map.getZoom() > state.map.getMinZoom()
            });

        case Actions.ZoomOut:
            state.map.zoomOut();
            return Object.assign({}, state, {
                canZoomIn: state.map.getZoom() < state.map.getMaxZoom(),
                canZoomOut: state.map.getZoom() > state.map.getMinZoom()
            });

        case Actions.Reset:
            state.map.reset();
            return Object.assign({}, state, {
                canZoomIn: state.map.getZoom() < state.map.getMaxZoom(),
                canZoomOut: state.map.getZoom() > state.map.getMinZoom(),
                baseLayerName: null
            });

        case Actions.SetBaseLayer:
            state.map.setBaseLayer(action.baseLayer);
            return Object.assign({}, state, {
                baseLayerName: action.baseLayer
            });

        case Actions.Destroy:
            state.map.setBaseLayer(action.baseLayer);
            return Object.assign({}, state, {
                baseLayerName: action.baseLayer
            });

        default:
            return Object.assign({}, state);
    }
};

export default map;
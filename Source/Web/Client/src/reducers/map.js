import { MapActions } from '../actions/map';
import mapFactory from '../factories/mapFactory';

const defaultState = {
    object: null,
    canZoomIn: true,
    canZoomOut: true,
    baseLayer: null
};

const map = (state = defaultState, action) => {
    switch (action.type) {
        
        case MapActions.Create:
            return Object.assign({}, state, {
                object: mapFactory(action.elementId)
            });

        case MapActions.ZoomIn:
            state.object.zoomIn();
            return Object.assign({}, state, {
                canZoomIn: state.object.getZoom() < state.object.getMaxZoom(),
                canZoomOut: state.object.getZoom() > state.object.getMinZoom()
            });

        case MapActions.ZoomOut:
            state.object.zoomOut();
            return Object.assign({}, state, {
                canZoomIn: state.object.getZoom() < state.object.getMaxZoom(),
                canZoomOut: state.object.getZoom() > state.object.getMinZoom()
            });

        case MapActions.Reset:
            state.object.reset();
            return Object.assign({}, state, {
                canZoomIn: state.object.getZoom() < state.object.getMaxZoom(),
                canZoomOut: state.object.getZoom() > state.object.getMinZoom(),
                baseLayerName: null
            });

        case MapActions.SetBaseLayer:
            state.object.setBaseLayer(action.baseLayer);
            return Object.assign({}, state, {
                baseLayerName: action.baseLayer
            });

        case MapActions.Destroy:
            return defaultState;

        default:
            return Object.assign({}, state);
    }
};

export default map;
import alt from '../alt';
import MapActions from './MapActions';
import buildMap from './MapFactory';

class MapStore {
    constructor() {
        this.map = null;

        this.bindListeners({
            handleCreateMap: MapActions.CREATE_MAP,
            handleZoomIn: MapActions.ZOOM_IN,
            handleZoomOut: MapActions.ZOOM_OUT,
            handleReset: MapActions.RESET,
            handleDestroyMap: MapActions.DESTROY_MAP
        });
    }

    handleCreateMap(htmlElement) {
        this.map = buildMap(htmlElement); 
    }

    handleZoomIn() {
        this.map.zoomIn(); 
    }

    handleZoomOut() {
        this.map.zoomOut(); 
    }
    
    handleReset() {
        this.map.reset(); 
    }

    handleDestroyMap() {
        this.map = null; 
    }
}

export default alt.createStore(MapStore, 'MapStore');
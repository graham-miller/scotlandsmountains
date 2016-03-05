import alt from '../alt';
import MapActions from './MapActions';
import buildMap from './MapFactory';

//const center = [56.659406, -4.011214];
const center = [56.964957, -4.659999];
const zoom = 2;

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
        this.map = buildMap(htmlElement, center, zoom); 
    }

    handleZoomIn() {
        this.map.zoomIn(); 
    }

    handleZoomOut() {
        this.map.zoomOut(); 
    }
    
    handleReset() {
        this.map.setView(center, zoom); 
    }

    handleDestroyMap() {
        this.map = null; 
    }
}

export default alt.createStore(MapStore, 'MapStore');
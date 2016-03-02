import alt from '../alt';
import MapActions from '../actions/MapActions';
import buildMap from '../components/map/MapFactory';

class MapStore {
    constructor() {
        this.map = null;

        this.bindListeners({
            handleCreateMap: MapActions.CREATE_MAP,
            handleZoomIn: MapActions.ZOOM_IN,
            handleZoomOut: MapActions.ZOOM_OUT,
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

    handleDestroyMap() {
        this.map = null; 
    }
}

export default alt.createStore(MapStore, 'MapStore');
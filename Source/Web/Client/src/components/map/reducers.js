import { Actions } from "../../state/actions";
import { MapActions } from "./actions";
import factory from "./factory";

const map = (mapObject = null, action) => {
    switch (action.type) {
        
    case MapActions.Create:
        return factory(action.elementId);

    case MapActions.ZoomIn:
        mapObject.zoomIn();
        break;

    case MapActions.ZoomOut:
        mapObject.zoomOut();
        break;

    case MapActions.Reset:
        if (mapObject) {
            mapObject.reset();
        }
        break;

    case MapActions.SetBaseLayer:
        mapObject.setBaseLayer(action.baseLayer);
        break;

    case Actions.ClearMountains:
        mapObject.clearMountains();
        break;

    case MapActions.Destroy:
        mapObject.setBaseLayer(null);
        return null;

    default:
        break;
    }

    return mapObject;
};

export default map;
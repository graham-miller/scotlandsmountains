import { Actions } from "../../state/actions";
import { MapActions } from "./actions";
import factory from "./factory";

const map = (mapObject = null, action) => {
    switch (action.type) {
        
    case MapActions.Create:
        return factory(action.elementId, action.baseLayer);

    case MapActions.ZoomIn:
        mapObject.zoomIn();
        break;

    case MapActions.ZoomOut:
        mapObject.zoomOut();
        break;

    case MapActions.SetBaseLayer:
        mapObject.setBaseLayer(action.baseLayer);
        break;

    case Actions.ClearMountains:
        mapObject.clearMountains();
        break;

    case MapActions.Destroy:
        if (mapObject) { mapObject.setBaseLayer(null); }
        return null;

    default:
        break;
    }

    return mapObject;
};

export default map;
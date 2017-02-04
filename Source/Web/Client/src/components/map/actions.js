export const MapActions = {
    Create: "CREATE",
    ZoomIn: "ZOOM_IN",
    ZoomOut: "ZOOM_OUT",
    SetBaseLayer: "SET_BASE_LAYER",
    Destroy: "DESTROY"
};

export function create(elementId, baseLayer) {
    return {
        type: MapActions.Create,
        elementId,
        baseLayer
    };
}

export function zoomIn() {
    return {
        type: MapActions.ZoomIn
    };
}

export function zoomOut() {
    return {
        type: MapActions.ZoomOut
    };
}

export function setBaseLayer(baseLayer) {
    return {
        type: MapActions.SetBaseLayer,
        baseLayer
    };
}

export function destroy() {
    return {
        type: MapActions.Destroy
    };
}

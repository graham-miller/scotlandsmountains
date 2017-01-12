export const MapActions = {
    Create: "CREATE",
    ZoomIn: "ZOOM_IN",
    ZoomOut: "ZOOM_OUT",
    Reset: "RESET",
    SetBaseLayer: "SET_BASE_LAYER",
    Destroy: "DESTROY"
};

export function create(elementId) {
    return {
        type: MapActions.Create,
        elementId
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

export function reset() {
    return {
        type: MapActions.Reset
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

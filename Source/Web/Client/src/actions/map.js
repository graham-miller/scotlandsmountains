export const Actions = {
    Create: 'CREATE',
    ZoomIn: 'ZOOM_IN',
    ZoomOut: 'ZOOM_OUT',
    Reset: 'RESET',
    SetBaseLayer: 'SET_BASE_LAYER',
    Destroy: 'DESTROY'
};

function create(elementId) {
    return {
        type: Actions.Create,
        elementId
    }
}

function zoomIn() {
    return {
        type: Actions.zoomIn
    }
}

function zoomOut() {
    return {
        type: Actions.zoomOut
    }
}

function reset() {
    return {
        type: Actions.reset
    }
}

function setBaseLayer(baseLayer) {
    return {
        type: Actions.SetBaseLayer,
        baseLayer
    }
}

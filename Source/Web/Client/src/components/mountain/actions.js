import callApi from "../../state/callApi";

export const Actions = {
    RequestMountain: "REQUEST_MOUNTAIN",
    ReceiveMountain: "RECEIVE_MOUNTAIN",
    MountainError: "MOUNTAIN_ERROR",
};

function requestMountain() {
    return {
        type: Actions.RequestMountain
    };
}

function receiveMountain(json) {
    return {
        type: Actions.ReceiveMountain,
        json
    };
}

function mountainError() {
    return {
        type: Actions.MountainError
    };
}

export function fetchMountain(id) {
    return callApi("/api/mountains/" + id, requestMountain, receiveMountain, mountainError);
}

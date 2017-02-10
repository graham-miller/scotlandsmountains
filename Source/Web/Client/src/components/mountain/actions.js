import { get } from "../../api";

export const MountainActions = {
    Request: "MOUNTAIN_REQUEST",
    Receive: "MOUNTAIN_RECEIVE",
    Error: "MOUNTAIN_ERROR",
};

function request() {
    return {
        type: MountainActions.Request
    };
}

function receive(json) {
    return {
        type: MountainActions.Receive,
        json
    };
}

function error() {
    return {
        type: MountainActions.Error
    };
}

export function fetchMountain(id) {
    return get("mountains/" + id, request, receive, error);
}

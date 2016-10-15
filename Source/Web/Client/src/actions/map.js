export const createMap = (map) => {
    return {
        type: 'CREATE_MAP',
        map
    }
};

export const destroyMap = () => {
    return {
        type: 'DESTROY_MAP'
    }
};

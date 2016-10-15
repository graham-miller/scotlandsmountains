const map = (state = null, action) => {
    switch (action.type) {
        case 'CREATE_MAP':
            return action.map;
        case 'DESTROY_MAP':
            return null;
        default:
            return state
    }
};

export default map;
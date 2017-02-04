const defaultStatus = { loading: false, error: false };

const defaultState = {
    staticData: {
        status: defaultStatus,
        value: null
    },
    lists: [],
    list: {
        status: defaultStatus,
        value: null,
        lastUpdated: null
    },
    mountain: {
        status: defaultStatus,
        value: null,
        lastUpdated: null
    },
    search: {
        status: defaultStatus,
        value: null,
        lastUpdated: null
    }
};

export default defaultState;
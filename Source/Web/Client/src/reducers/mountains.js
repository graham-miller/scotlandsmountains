const defaultState = {
    status: {
        loading: false,
        error: false,
    },
    info: {
        page: 0,
        pageSize: 0,
        pages: 0,
        count: 0,
    },
    list: [],
    searchTerm: ''
};

const mountains = (state = defaultState, action) => {
    switch (action.type) {
        
        case 'REQUEST_TABLE':
            return Object.assign({}, state, {
                status: {
                    loading: true,
                    error: false,
                },
                list: []
            });

        case 'RECEIVE_TABLE':
            return Object.assign({}, state, {
                status: {
                    loading: false,
                    error: false,
                },
                info: {
                    page: 1,
                    pageSize: 1,
                    pages: 1,
                    count: action.mountains.length,
                },
                list: action.mountains
            });

        
        case 'REQUEST_SEARCH':
            return Object.assign({}, state, {
                status: {
                    loading: true,
                    error: false,
                },
                list: [],
                searchTerm: action.term
            });

        case 'RECEIVE_SEARCH':
            return Object.assign({}, state, {
                status: {
                    loading: false,
                    error: false,
                },
                info: {
                    page: action.searchResult.page,
                    pageSize: action.searchResult.pageSize,
                    pages: action.searchResult.pages,
                    count: action.searchResult.results.length,
                },
                list: action.searchResult.results,
                searchTerm: action.searchResult.term
            });

        case 'NETWORK_ERROR':
            return Object.assign({}, defaultState);

        default:
            return Object.assign({}, state);

    }
};

export default mountains;
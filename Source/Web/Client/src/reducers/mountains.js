import { REQUEST_START, RECEIVE_MOUNTAIN, RECEIVE_CLASSIFICATION, RECEIVE_SEARCH, REQUEST_IGNORED, REQUEST_ERROR } from '../actions/mountains';

const defaultStatus = {
    loading: false,
    error: false
};

const loadingStatus = {
    loading: true,
    error: false
};

const errorStatus = {
    loading: false,
    error: true
};

const defaultInfo = {
    page: 0,
    pageSize: 0,
    pages: 0,
    count: 0
};

const defaultState = {
    status: defaultStatus,
    info: defaultInfo,
    list: []
};

const mountains = (state = defaultState, action) => {
    switch (action.type) {
        
        case REQUEST_START:
            return Object.assign({}, state, {
                status: loadingStatus,
                info: defaultInfo,
                list: []
            });

        case RECEIVE_MOUNTAIN:
            return Object.assign({}, state, {
                status: defaultStatus,
                info: defaultInfo,
                list: [action.mountains]
            });

        case RECEIVE_CLASSIFICATION:
            return Object.assign({}, state, {
                status: defaultStatus,
                info: defaultInfo,
                list: action.mountains
            });
        
        case REQUEST_IGNORED:
            return Object.assign({}, state, {
                status: defaultStatus,
                info: defaultInfo,
                list: []
            });

        case RECEIVE_SEARCH:
            return Object.assign({}, state, {
                status: defaultStatus,
                info: {
                    page: action.searchResult.page,
                    pageSize: action.searchResult.pageSize,
                    pages: action.searchResult.pages,
                    count: action.searchResult.results.length
                },
                list: action.searchResult.results
            });

        case REQUEST_ERROR:
            return Object.assign({}, state, {
                status: errorStatus,
                info: defaultInfo,
                list: []
            });

        default:
            return Object.assign({}, state);
    }
};

export default mountains;
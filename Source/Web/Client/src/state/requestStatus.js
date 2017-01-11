const requestStatus = {
    default: { loading: false, error: false },
    loading: { loading: true, error: false },
    success: { loading: false, error: false },
    error: { loading: false, error: true }
};

export default requestStatus;
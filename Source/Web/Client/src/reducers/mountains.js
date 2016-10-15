const mountains = (state = [], action) => {
    switch (action.type) {
        case 'SEARCH':
            return [
                {
                    "name": "Ben Nevis",
                    "height": "1345m",
                    "latitude": 56.796849,
                    "longitude": -5.003525,
                    "id": "kN37JDEn"
                },
                {
                    "name": "Ben na Cro [Beinn na Cro]",
                    "height": "572m",
                    "latitude": 57.243635,
                    "longitude": -6.030529,
                    "id": "5J3aljEW"
                },
                {
                    "name": "Ben Newe",
                    "height": "565.0m",
                    "latitude": 57.215344,
                    "longitude": -3.025284,
                    "id": "Jv3q0LEQ"
                }
            ]
        default:
            return state
    }
};

export default mountains;
import { connect } from 'react-redux'
import Map from './Map'

const mapStateToProps = (state) => {

    if (state.mountains.classification) {
        return {
            mountains: state.mountains.classification
        };
    }

    if (state.mountains.searchResult) {
        return {
            mountains: state.mountains.searchResult.results
        };
    }

    if (state.mountains.mountain) {
        return {
            mountains: [state.mountains.mountain]
        };
    }

    return {
        mountains: []
    };
}

const MapContainer = connect(mapStateToProps)(Map)

export default MapContainer
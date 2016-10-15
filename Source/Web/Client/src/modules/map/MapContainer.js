import { connect } from 'react-redux'
//import { toggleTodo } from '../actions'
import Map from './Map'

const mapStateToProps = (state) => {
    return {
        map: state.map
    }
}

const MapContainer = connect(mapStateToProps)(Map)

export default MapContainer
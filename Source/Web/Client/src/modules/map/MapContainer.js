import { connect } from 'react-redux'
//import { toggleTodo } from '../actions'
import Map from './Map'

const mapStateToProps = (state) => {
    return {
        mountains: state.mountains
    }
}

const MapContainer = connect(mapStateToProps)(Map)

export default MapContainer
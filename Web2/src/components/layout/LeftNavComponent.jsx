import React from 'react';
import LayoutStore from '../../stores/LayoutStore';
import LeftNav from 'material-ui/lib/left-nav';
import MenuItem from 'material-ui/lib/menus/menu-item';

class LeftNavComponent extends React.Component {
     
    constructor(props) {
        super(props);
        this.state = LayoutStore.getState();
        
        // React components using ES6 classes no longer autobind `this` to non React methods
        this.onChange = this.onChange.bind(this)
    }

    componentDidMount() {
        LayoutStore.listen(this.onChange);
    }

    componentWillUnmount() {
        LayoutStore.unlisten(this.onChange);
    }
    
    onChange(state) {
        this.setState(state);
    }
      
    render() {
        return (
            <div>
                <LeftNav
                    open={this.state.leftNavOpen}
                    style={{paddingTop:'64px'}}>
                    <MenuItem>Menu Item</MenuItem>
                    <MenuItem>Menu Item 2</MenuItem>
                </LeftNav>
            </div>
            );
    }
}

export default LeftNavComponent;
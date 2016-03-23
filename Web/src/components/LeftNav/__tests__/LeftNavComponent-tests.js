'use strict';

jest.unmock('../LeftNavComponent');

import React from 'react';
import ReactDOM from 'react-dom';
import TestUtils from 'react-addons-test-utils';
import LeftNavComponent from '../LeftNavComponent';
import MenuItem from 'material-ui/lib/menus/menu-item';
import injectTapEventPlugin from 'react-tap-event-plugin';

describe('LeftNavComponent', () => {

    injectTapEventPlugin()

    it('validates props', () => {
        
        const error = console.error;
        console.error = jest.genMockFunction();
        
        const shallowRenderer = TestUtils.createRenderer();
        shallowRenderer.render(React.createElement(LeftNavComponent, {open: ""}));
        const sut = shallowRenderer.getRenderOutput();
        
        expect(console.error).toBeCalledWith('Warning: Failed propType: Invalid prop `open` of type `string` supplied to `LeftNavComponent`, expected `boolean`.');
        expect(console.error).toBeCalledWith('Warning: Failed propType: Required prop `onClose` was not specified in `LeftNavComponent`.');
        
        console.error = error;
    });

    describe('sets open from props', () => {
        
        it('open is true if {open: true} passed in props', () => {
            
            const shallowRenderer = TestUtils.createRenderer();
            shallowRenderer.render(React.createElement(LeftNavComponent, {open: true}));
            const sut = shallowRenderer.getRenderOutput();
            expect(sut.props.open).toBeTruthy();
        })
        
        it('sets open=false from props', () => {
            
            const shallowRenderer = TestUtils.createRenderer();
            shallowRenderer.render(React.createElement(LeftNavComponent, {open: false}));
            const sut = shallowRenderer.getRenderOutput();
            expect(sut.props.open).toBeFalsy();
        })
        
    });
    
    it('it calls props.onClose when first menu item clicked', () => {
        
        const onClose = jest.genMockFunction();
        const leftNavComponent = TestUtils.renderIntoDocument(<LeftNavComponent open={true} onClose={onClose} />);
        
        TestUtils.Simulate.touchTap(ReactDOM.findDOMNode(leftNavComponent).firstChild.firstChild);
        expect(onClose).toBeCalled();
    })
     
});
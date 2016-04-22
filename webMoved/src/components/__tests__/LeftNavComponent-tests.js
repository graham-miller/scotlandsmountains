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
        shallowRenderer.render(React.createElement(LeftNavComponent));
        const sut = shallowRenderer.getRenderOutput();
        
        expect(console.error).toBeCalledWith('Warning: Failed propType: Required prop `isOpen` was not specified in `LeftNavComponent`.');
        expect(console.error).toBeCalledWith('Warning: Failed propType: Required prop `close` was not specified in `LeftNavComponent`.');
        
        console.error = error;
    });

    describe('sets open from props', () => {
        
        it('open is true if {open: true} passed in props', () => {
            
            const shallowRenderer = TestUtils.createRenderer();
            shallowRenderer.render(React.createElement(LeftNavComponent, {isOpen: true}));
            const sut = shallowRenderer.getRenderOutput();
            
            expect(sut.props.open).toBeTruthy();
        })
        
        it('sets open=false from props', () => {
         
            const shallowRenderer = TestUtils.createRenderer();
            shallowRenderer.render(React.createElement(LeftNavComponent, {isOpen: false}));
            const sut = shallowRenderer.getRenderOutput();
            
            expect(sut.props.open).toBeFalsy();
        })
        
    });
    
    it('it calls close() when first menu item clicked', () => {

        const close = jest.genMockFunction();
        const shallowRenderer = TestUtils.createRenderer();
        shallowRenderer.render(React.createElement(LeftNavComponent, {isOpen: true, close: close}));
        const sut = shallowRenderer.getRenderOutput();

        sut.props.children[0].props.onTouchTap();

        expect(close).toBeCalled();
    })
     
});
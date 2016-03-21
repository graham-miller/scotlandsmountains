'use strict';

jest.unmock('../LeftNavComponent');

import React from 'react';
import ReactDOM from 'react-dom';
import TestUtils from 'react-addons-test-utils';
import LeftNavComponent from '../LeftNavComponent';

describe('LeftNavComponent', () => {

    it('validates props', () => {
        
        const error = console.error;
        console.error = jest.fn();
        
        const shallowRenderer = TestUtils.createRenderer();
        shallowRenderer.render(React.createElement(LeftNavComponent));
        const sut = shallowRenderer.getRenderOutput();
        
        expect(console.error.mock.calls.length).toBe(9)
        expect(console.error).toBeCalledWith('Warning: Failed propType: LeftNav: prop type `header` is invalid; it must be a function, usually from React.PropTypes.');
        expect(console.error).toBeCalledWith('Warning: Failed propType: LeftNav: prop type `header` is invalid; it must be a function, usually from React.PropTypes.');
        expect(console.error).toBeCalledWith('Warning: Failed propType: LeftNav: prop type `menuItemClassName` is invalid; it must be a function, usually from React.PropTypes.');
        expect(console.error).toBeCalledWith('Warning: Failed propType: LeftNav: prop type `menuItemClassNameLink` is invalid; it must be a function, usually from React.PropTypes.');
        expect(console.error).toBeCalledWith('Warning: Failed propType: LeftNav: prop type `menuItemClassNameSubheader` is invalid; it must be a function, usually from React.PropTypes.');
        expect(console.error).toBeCalledWith('Warning: Failed propType: LeftNav: prop type `menuItems` is invalid; it must be a function, usually from React.PropTypes.');
        expect(console.error).toBeCalledWith('Warning: Failed propType: LeftNav: prop type `onChange` is invalid; it must be a function, usually from React.PropTypes.');
        expect(console.error).toBeCalledWith('Warning: Failed propType: LeftNav: prop type `onNavClose` is invalid; it must be a function, usually from React.PropTypes.');
        expect(console.error).toBeCalledWith('Warning: Failed propType: LeftNav: prop type `onNavOpen` is invalid; it must be a function, usually from React.PropTypes.');
        expect(console.error).toBeCalledWith('Warning: Failed propType: LeftNav: prop type `selectedIndex` is invalid; it must be a function, usually from React.PropTypes.');
        
        console.error = error;
    });    


});
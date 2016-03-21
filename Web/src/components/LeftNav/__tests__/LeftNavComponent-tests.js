'use strict';

jest.unmock('../LeftNavComponent');

import React from 'react';
import ReactDOM from 'react-dom';
import TestUtils from 'react-addons-test-utils';
import LeftNavComponent from '../LeftNavComponent';

describe('LeftNavComponent', () => {

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
});
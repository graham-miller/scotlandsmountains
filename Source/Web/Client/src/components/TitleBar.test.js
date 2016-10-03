import React from 'react';
import ReactDOM from 'react-dom';
import Titlebar from './Titlebar';

it('renders without crashing', () => {
  const div = document.createElement('div');
  ReactDOM.render(<Titlebar />, div);
});

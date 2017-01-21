import React, { Component } from 'react';

class App extends Component {

  render() {
    return (
      <div id="app">

        <div id="header">
          <h1>Header</h1>
        </div>

        <div id="map-section">
          <div id="map-title">
            Map title
          </div>
          <div id="map-wrapper">
            <div id="map">
            </div>
          </div>
        </div>

        <div id="content-section">
          <div id="content-wrapper">
          </div>
        </div>

        <div id="footer">Footer</div>

      </div>
    );
  }
}

export default App;

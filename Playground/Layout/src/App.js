import React, { Component } from 'react';
import $ from "jquery";

class App extends Component {

  constructor(props) {
    super(props);

    this.onWindowResize = this.onWindowResize.bind(this);
    this.resizeMap = this.resizeMap.bind(this);
  }

  onWindowResize () {

    if(this.onWindowResizeDelay) {
      clearTimeout(this.onWindowResizeDelay);
    }

    this.onWindowResizeDelay = setTimeout(this.resizeMap, 100);
  }

  resizeMap() {
    // TODO
  }

  componentDidMount() {
    $(window).on("resize", this.onWindowResize);
  }

  componentWillUnmunt() {
    $(window).on("resize", this.onWindowResize);
  }

  render() {
    return (
      <div id="app-component">
        <header>
          <h1>Application Name</h1>
          <nav>
            <div className="nav-item">Lists</div>
            <div className="nav-item">Search</div>
            <div className="nav-item">Item 3</div>
            <div className="nav-item">Item 4</div>
            <div className="nav-item">Item 5</div>
            <div className="nav-item">Item 6</div>
            <div className="nav-item">Item 7</div>
            <div className="nav-item">Item 8</div>
            <div className="nav-item">Item 9</div>
            <div className="nav-item">Item 10</div>
          </nav>
        </header>
        <main>
          <div id="map-section">
            <div id="page-actions">Page Actions</div>
            <div id="map-container">
              <div id="map">Map</div>
            </div>
          </div>
          <div id="content-section">
            Content start
            <br />&middot;<br />&middot;<br />&middot;<br />&middot;<br />&middot;<br />&middot;<br />&middot;<br />&middot;<br />&middot;<br />&middot;<br />&middot;<br />&middot;<br />&middot;<br />&middot;<br />&middot;<br />&middot;<br />&middot;<br />&middot;<br />&middot;<br />&middot;<br />&middot;<br />&middot;<br />&middot;<br />&middot;<br />&middot;<br />&middot;<br />&middot;<br />&middot;<br />&middot;<br />&middot;<br />&middot;<br />&middot;<br />&middot;<br />
            Content end
          </div>
          <footer>
            <div className="footer-section legal">Footer 1</div>
            <div className="footer-section">Footer 2</div>
          </footer>
        </main>
      </div>
    );
  }
}

export default App;

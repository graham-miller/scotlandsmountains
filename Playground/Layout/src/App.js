import React, { Component } from 'react';

class App extends Component {
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
          <div id="map-container">
            <div id="page-actions">Heading<br/>Sub-heading</div>
            <div id="map">Map</div>
          </div>
          <div id="content-container">
            Content start
            <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
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

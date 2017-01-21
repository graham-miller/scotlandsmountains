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
              <button onClick={() => alert('clicked')}>Clickable?</button>
            </div>
          </div>
        </div>

        <div id="content-section">
          <div id="content-wrapper">
            <p>
              Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam a sodales felis. Sed porta diam sed feugiat vehicula. Nullam massa nisl, bibendum sed magna et, rhoncus feugiat est. Mauris id purus nec justo vehicula dictum. Maecenas non scelerisque magna, nec fermentum orci. Pellentesque volutpat blandit magna. Cras metus neque, cursus quis suscipit eget, finibus id ante.
            </p>
            <p>
              Praesent dignissim, turpis in tincidunt fringilla, libero lorem hendrerit est, ac consectetur nisi urna ut turpis. Maecenas eu convallis risus. Suspendisse gravida non lacus in pellentesque. Donec ornare nisi eu ipsum interdum, et molestie dolor tincidunt. Maecenas sapien tellus, hendrerit et tortor ac, luctus finibus magna. Pellentesque non felis nec libero scelerisque suscipit eu vitae purus. Quisque sit amet diam fringilla, egestas mauris finibus, venenatis dolor. Mauris et ligula sed tortor vestibulum convallis.
            </p>
            <p>
              Sed quis turpis venenatis, ornare nisl sed, lobortis lorem. Cras mi nunc, finibus eu blandit sed, porta sed magna. Aliquam eu ligula dolor. Etiam ut sapien sit amet turpis pretium molestie nec quis orci. Fusce pharetra elit tellus, ac porttitor diam scelerisque eget. In vitae nisi maximus, luctus dolor iaculis, ultrices orci. In hendrerit, quam vitae accumsan semper, nibh ipsum sodales augue, sed laoreet tellus nibh non risus. Sed metus dolor, scelerisque sit amet dui non, elementum egestas ante. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc quis nisl quam. Curabitur venenatis sem orci, eu mollis purus viverra sed. Phasellus ut rutrum eros.
            </p>
            <p>
              Mauris quis turpis quis erat porttitor tempor. In vestibulum non leo nec placerat. Aliquam erat volutpat. Cras aliquam lobortis mattis. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla ipsum magna, laoreet vel lobortis eu, feugiat egestas magna. Praesent in odio et nunc blandit ultricies. Proin cursus mollis venenatis. Aenean quam elit, ultricies elementum cursus et, suscipit sed erat. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nullam sed blandit est, ac convallis elit.
            </p>
            <p>
              Curabitur nisl ante, ultrices a orci sit amet, tristique ultrices felis. Etiam accumsan, urna a elementum sagittis, lectus dolor convallis nibh, nec placerat ex enim nec magna. Ut metus ante, tristique vitae aliquam at, mattis tempor ex. Etiam eget luctus tortor. Vivamus pretium faucibus velit, a varius nunc ornare id. Aliquam vitae venenatis risus. Vestibulum sit amet tempor nibh, sed elementum sem. Maecenas orci enim, varius vel sodales ut, porta vitae lorem. Nunc elit nulla, volutpat vel laoreet sit amet, eleifend ac ipsum. Mauris in hendrerit turpis, eget volutpat sapien. Proin quis ultricies erat. Nam viverra sodales porta. Aenean dolor ante, tristique et purus in, posuere euismod urna. Nullam efficitur dapibus felis vel molestie. Duis enim mi, tempor nec cursus vitae, volutpat nec odio. Suspendisse eget diam vel diam eleifend ultricies vel in mauris.          
            </p>
          </div>
        </div>

        <div id="footer">Footer</div>

      </div>
    );
  }
}

export default App;

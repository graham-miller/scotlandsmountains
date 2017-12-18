// @flow

import React, { Component } from 'react';
import fire from './fire';

class Data extends Component {
  constructor(props) {
    super(props);
    this.state = {mountains: []};
  }

  componentDidMount(){
    let that = this;
    fire.database().ref('mountains')
      .orderByChild('HeightMetres')
      .limitToLast(100)
      .once('value', function (snapshot){
        var array = [];
        snapshot.forEach(function(item) {
          array.push(item.val());
        });
        that.setState({ mountains: array });
      }) 
  }

  render() {
    return (
      <ul>
        { /* Render the list of messages */
          this.state.mountains.map((m,i) => {
            return <li key={i}>{m.Name}</li>
        })
        }
      </ul>
    );
  }
}

export default Data;

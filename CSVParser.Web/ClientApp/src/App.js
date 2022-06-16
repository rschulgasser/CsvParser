import React, { Component } from 'react';
import { Route } from 'react-router';
import  Layout from './Layout';
import  Home  from './Home';

import FileUpload from './FileUpload';
import Generate from './Generate';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/FileUpload' component={FileUpload} />
        <Route path='/Generate' component={Generate} />
       
       
      </Layout>
    );
  }
}

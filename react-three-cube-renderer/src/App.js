import React from 'react';
import {Component} from 'react';
import { BrowserRouter as Router, Route } from 'react-router-dom';
import './App.css';
import Input from './components/input';
// import Cubelist from './Cubelist';


function App() {
  return (
    <Router>
      <Route exact path="/" component={Input} />
      {/* <Route exact path="/cubelist" component={<Cubelist/>} /> */}

    </Router>
  );
}

export default App;

import React, { Component } from 'react';
import { Routes, Route, Link } from 'react-router-dom';
import 'bootstrap/dist/css/bootstrap.min.css';
import './App.css';

//import Tutorial from './components/tutorial.component';
import TutorialsList from './components/tutorials-list.component';

class App extends Component {
  render() {
    return (
      <div>
        <nav className="navbar navbar-expand navbar-dark bg-dark">
          <Link to={'/'} className="navbar-brand">
            Craig's Forecast App
          </Link>
        </nav>

        <div className="container mt-3">
          <Routes>
            <Route path="/" element={<TutorialsList />} />
          </Routes>
        </div>
      </div>
    );
  }
}

export default App;

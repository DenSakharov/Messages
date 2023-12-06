import React from 'react';
import logo from './logo.svg';
import './App.css';
import Main from './Main/Main'
import ReactDOM from 'react-dom';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import LoginPage from './LoginPage/LoginPage'; // Путь к компоненту LoginPage

function App() {
  return (
    <div className="App">
      <header className="App-header">
              <Router>
                  <Routes>
                      <Route path="/" element={<Main />} />
                      <Route path="/login" element={<LoginPage />} />
                  </Routes>
              </Router>
      </header>
    </div>
  );
}

ReactDOM.render(<App />, document.getElementById('root'));

export default App;

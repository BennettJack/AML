import React from 'react';
import './App.css';
import {
  HashRouter,
  BrowserRouter,
  Routes,
  Route,
  NavLink,
} from "react-router-dom";
import Home from './Pages/Home.js';

function App() {
  return (
    <div id="appWrapper">
      <BrowserRouter>
        <Routes>
          <Route index element={<Home />} />
        </Routes>
      </BrowserRouter>
    </div>
  )
}

export default App;
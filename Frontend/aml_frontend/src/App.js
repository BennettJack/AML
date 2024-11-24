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
import LibraryList from './Pages/LibraryList.js';
import Browse from './Pages/Browse.js';
import MediaResult from './Pages/MediaResult.js';
import LibraryList from './Components/LibraryList.js';
import MemberProfile from "./Components/MemberProfile";

function App() {
  return (
    <div id="appWrapper">
      <BrowserRouter>
        <Routes>
          <Route index element={<Home />} />
          <Route path={"/LibraryList"} element={<LibraryList/>} />
          <Route path={"/Browse"} element={<Browse/>} />
          <Route path={"/MediaResult"} element={<MediaResult/>} />
          <Route path="/profile" element={<MemberProfile />} />
        </Routes>
      </BrowserRouter>
    </div>
  )
}

export default App;
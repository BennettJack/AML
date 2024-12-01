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
import LibraryList from './Components/LibraryList.js';
import MemberProfile from "./Components/MemberProfile";
import Browse from './Pages/Browse.js';
import MediaResult from './Pages/MediaResult.js';
import Register from "./Components/Register";
import Login from "./Components/Login";

function App() {
  return (
    <div id="appWrapper">
      <BrowserRouter>
        <Routes>
          <Route index element={<Home />} />
          <Route path={"/LibraryList"} element={<LibraryList/>} />
          <Route path="/profile" element={<MemberProfile />} />
          <Route path={"/Browse"} element={<Browse/>} />
          <Route path={"/MediaResult"} element={<MediaResult/>} />
          <Route path={"/MemberProfile"} element={<MemberProfile/>} />
          <Route path="/register" element={<Register />} />
          <Route path="/login" element={<Login />} />
        </Routes>
      </BrowserRouter>
    </div>
  )
}

export default App;
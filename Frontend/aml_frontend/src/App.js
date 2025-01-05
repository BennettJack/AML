import React from 'react';
import './App.css';
import {
  HashRouter,
  BrowserRouter,
  Routes,
  Route,
  NavLink,
    useParams
} from "react-router-dom";
import Home from './Pages/Home.js';
import LibraryList from './Pages/LibraryList.js';
import MemberProfile from "./Components/MemberProfile";
import Browse from './Pages/Browse.js';
import MediaResult from './Pages/MediaResult.js';
import Register from "./Components/Register";
import Login from "./Components/Login";
import NewMediaSubmission from "./Pages/NewMediaSubmission/NewMediaSubmission";
import StockControlMainPage from "./Pages/StockControl/StockControlMainPage";
import StockControlMediaView from "./Pages/StockControl/StockControlMediaView";
import Reports from "./Pages/Reports/Reports";
import MediaReports from "./Pages/Reports/MediaReports";
import BranchDashboard from "./Pages/BranchDashboard";
import BranchQueries from "./Pages/BranchQueries";

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
          <Route path={"/NewMediaSubmission"} element={<NewMediaSubmission/>} />
          <Route path={"/StockControl"} element={<StockControlMainPage/>} />
          <Route path={"/StockControl/StockControlMediaView/:id"} element={<StockControlMediaView/>} />
          <Route path={"/Reports"} element={<Reports/>}/>
          <Route path={"/Reports/MediaReports"} element={<MediaReports/>}/>
          <Route path={"/BranchDashboard"} element={<BranchDashboard/>} />
          <Route path={"/BranchQueries"} element={<BranchQueries/>} />
        </Routes>
      </BrowserRouter>
    </div>
  )
}

export default App;
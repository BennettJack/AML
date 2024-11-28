import React from "react";
import { Link } from "react-router-dom";
import "../CSS/HomeButtons.css";
import LibraryImage from "./images/LibraryImage1.jpg";

const HomeButtons = () => {
    return (
        <>
            <div className="buttonWrapper">
                <Link to="/register" className="button">Become A Member</Link>
                <Link to="/LibraryList" className="button">Find A Branch</Link>
                <Link to="/login" className="button">Member Login</Link>
                <Link to="/browse" className="button">Search Catalogue</Link>
            </div>
            <div className="libraryImage">
                <img src={LibraryImage} alt="Library Image" width="700" height="500" />
            </div>
        </>
    );
};

export default HomeButtons;

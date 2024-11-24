import React from "react";
import { Link } from "react-router-dom";
import "../CSS/Header.css";

const Header = () => {
    return (
        <header className="customHeader">
            <div className="logoContainer">
                <Link to="/" className="logoLink">
                    <span className="logoPart1">A</span>
                    <span className="logoPart2">M</span>
                    <span className="logoPart3">L</span>
                </Link>
            </div>
            <nav className="navigationMenu">
                <ul className="navList">
                    <li><Link to="/" className="navItem"><i className="fas fa-home"></i> Home</Link></li>
                    <li><Link to="/browse" className="navItem"><i className="fas fa-folder"></i> Browse</Link></li>
                    <li><Link to="/branches" className="navItem"><i className="fas fa-user"></i> Find A Branch</Link></li>
                    <li><Link to="/membership" className="navItem"><i className="fas fa-user-plus"></i> Become a Member</Link></li>
                </ul>
            </nav>
        </header>
    );
};

export default Header;

import { useState, useEffect } from "react";
import { link } from "react-router-dom"
import '../CSS/Header.css';

const Header = () => {
    return (
        <header className="headerWrapper">
            <div>
                <div className="logoContainer">

                </div>
                <nav className="header">
                    <ul>
                        <li>Home</li>
                        <li>Browse</li>
                        <li>Find A Branch</li>
                        <li>Become A Member</li>
                    </ul>
                </nav>
            </div>
        </header>
    )
}
export default Header;
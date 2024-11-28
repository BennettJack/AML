import React from "react";
import Header from "./Header";
import Footer from "./Footer";
import "../CSS/Login.css";

const Login = () => {
    return (
        <div className="pageWrapper">
            <Header />
            <main className="loginContainer">
                <h1>Member Login</h1>
                <form className="loginForm">
                    <label>
                        Email Address:
                        <input type="email" name="email" />
                    </label>
                    <label>
                        Password:
                        <input type="password" name="password" />
                    </label>
                    <button type="submit">Submit</button>
                </form>
            </main>
            <Footer />
        </div>
    );
};

export default Login;

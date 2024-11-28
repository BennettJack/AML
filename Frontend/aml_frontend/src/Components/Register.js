import React from "react";
import Header from "./Header";
import Footer from "./Footer";
import "../CSS/Register.css";

const Register = () => {
    return (
        <div className="pageWrapper">
            <Header />
            <main className="registerContainer">
                <h1>Member Registration</h1>
                <form className="registerForm">
                    <label>
                        First Name:
                        <input type="text" name="firstName" />
                    </label>
                    <label>
                        Last Name:
                        <input type="text" name="lastName" />
                    </label>
                    <label>
                        Email Address:
                        <input type="email" name="email" />
                    </label>
                    <label>
                        Location:
                        <input type="text" name="location" />
                    </label>
                    <label>
                        Password:
                        <input type="password" name="password" />
                    </label>
                    <label>
                        Confirm Password:
                        <input type="password" name="confirmPassword" />
                    </label>
                    <button type="submit">Submit</button>
                </form>
            </main>
            <Footer />
        </div>
    );
};

export default Register;

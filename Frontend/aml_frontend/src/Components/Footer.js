// src/components/Footer.js
import React from 'react';

const Footer = () => {
    return (
        <footer style={styles.footer}>
            <div style={styles.container}>
                <p>&copy; {new Date().getFullYear()} AML Library System. All rights reserved.</p>
                <nav style={styles.nav}>
                    <a href="/about" style={styles.link}>About</a>
                    <a href="/privacy" style={styles.link}>Privacy Policy</a>
                    <a href="/contact" style={styles.link}>Contact</a>
                </nav>
            </div>
        </footer>
    );
};

const styles = {
    footer: {
        backgroundColor: '#333',
        color: '#fff',
        padding: '20px 0',
        textAlign: 'center',
    },
    container: {
        maxWidth: '1200px',
        margin: '0 auto',
        padding: '0 15px',
    },
    nav: {
        marginTop: '10px',
    },
    link: {
        color: '#61dafb',
        textDecoration: 'none',
        margin: '0 10px',
    },
};

export default Footer;

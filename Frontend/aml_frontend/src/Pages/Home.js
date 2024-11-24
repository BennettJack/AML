import Header from '../Components/Header.js';
import Main from '../Components/Main.js'
import AboutUs from '../Components/AboutUs.js';
import HomeButtons from '../Components/HomeButtons.js';
import Footer from '../Components/Footer.js';
import '../CSS/Home.css';

const Home = () => {
    return (
        <div>
            <Header />
            <h1>AML Home</h1>
            <Main />
            <AboutUs />
            <HomeButtons />
            <Footer />
        </div>
    )
}
export default Home;
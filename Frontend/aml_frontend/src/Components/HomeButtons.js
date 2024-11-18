import '../CSS/HomeButtons.css';
import LibraryImage from './images/LibraryImage1.jpg';

const HomeButtons = () => {
    return (
        <>
            <div className = "buttonWrapper">
                <form>
                    <button>Become A Member</button>
                    <button>Find A Branch</button>
                    <button>Member Login</button>
                    <button>Seach Catalogue</button>
                </form>
            </div>
            <div>
                <img src ={LibraryImage} alt="Library Image"></img>;
            </div>
        </>
    )
}
export default HomeButtons;
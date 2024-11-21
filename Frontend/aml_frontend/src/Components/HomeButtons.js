import '../CSS/HomeButtons.css';
import LibraryImage from './images/LibraryImage1.jpg';

const HomeButtons = () => {
    return (
        <>
            <div className = "buttonWrapper">
                <form>
                    <button type="button">Become A Member</button>
                    <button type="button">Find A Branch</button>
                    <button type="button">Member Login</button>
                    <button type="button">Seach Catalogue</button>
                </form>
            </div>
            <div>
                <img src ={LibraryImage} alt="Library Image"></img>;
            </div>
        </>
    )
}
export default HomeButtons;
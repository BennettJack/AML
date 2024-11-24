import '../CSS/HomeButtons.css';
import LibraryImage from './images/LibraryImage1.jpg';

const HomeButtons = () => {
    return (
        <>
            <div className = "buttonWrapper">
                <form>
                    <button type="button">Become A Member</button>
                    <a href="/LibraryList" class="button">Find A Branch</a>
                    <button type="button">Member Login</button>
                    <button type="button">Seach Catalogue</button>
                </form>
            </div>
            <div className = "libraryImage">;
                <img src ={LibraryImage} alt="Library Image" width="700" height="500"></img>;
            </div>
        </>
    )
}
export default HomeButtons;
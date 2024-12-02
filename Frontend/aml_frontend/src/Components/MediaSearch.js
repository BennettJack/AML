import '../CSS/MediaSearch.css';
import lotrBookSmall from './images/lotrBookSmall.jpg';

const formToJSON = (elements) =>
[].reduce.call(
    elements,
    (data, element) => {
        data[element.name] = element.value;
        return data;
    },
    {}
);

const handleFormSubmit = (event) => {
    event.preventDefault();

    const data = formToJSON(form.elements);

    const dataContainer = document.getElementsByClassName('results_display')[0];

    dataContainer.textContent = JSON.stringify(data, null, ' ');
}

const reducerFuntion = (data, element) => {
    data[element.name] = element.value;
    console.Log(JSON.stringify(data));
    return data;
};

const form = document.getElementsByClassName('searchAndFilter')[0];
form.addEventListener('submit', handleFormSubmit);

const MediaSearch = () => {
    return (
        <>
            <div className="searchAndFilter"> 
                <form id="searchForm">
                    <div className="search">
                        <p>Search the catalogue: </p>
                        <label for="search" id="search" name="search"></label>
                        <input type="text" id="search" name="search"></input>
                    </div>
                    <div className="filter">
                        <p>Filter by: </p>
                        <div className="filters">
                            <input type="radio" id="books" name="mediaFilter" value="books"></input>
                            <label for="books">books</label><br></br>
                            <input type="radio" id="journals" name="mediaFilter" value="journals"></input>
                            <label for="journals">journals</label><br></br>
                            <input type="radio" id="periodicals" name="mediaFilter" value="periodicals"></input>
                            <label for="periodicals">periodicals</label><br></br>
                            <input type="radio" id="disks" name="mediaFilter" value="disks"></input>
                            <label for="disks">CD/DVDs</label><br></br>
                            <input type="radio" id="games" name="mediaFilter" value="games"></input>
                            <label for="games">Multimedia Games</label><br></br>
                            <input type="submit" value="Search"></input>
                        </div>
                    </div>
                </form>
            </div>
            <div className ="resultsContainer">
                <div className ="resultHeading">
                    <h2>Results:</h2>
                </div>
                <div className="mediaResult">
                    <section>
                        <article className="mediaResultArticle">
                            <div>
                                <img src={lotrBookSmall} id="mediaResultImage" alt="lotr book" width="113" height="171"></img>
                            </div>
                            <div>
                                <p>Media Name</p>
                                <p>Author</p>
                                <p>Publish Date</p>
                            </div>
                        </article>
                    </section>
                    <section>
                        <article className="mediaResultArticle">
                            <div>
                            <img src={lotrBookSmall} id="mediaResultImage" alt="lotr book" width="113" height="171"></img>
                            </div>
                            <div>
                            <p>Media Name</p>
                            <p>Author</p>
                            <p>Publish Date</p>
                            </div>
                        </article>
                    </section>
                    <section>
                        <article className="mediaResultArticle">
                            <div>
                            <img src={lotrBookSmall} id="mediaResultImage" alt="lotr book" width="113" height="171"></img>
                            </div>
                            <div>
                            <p>Media Name</p>
                            <p>Author</p>
                            <p>Publish Date</p>
                            </div>
                        </article>
                    </section>
                </div>
            </div>

            <div class="results">
            <h2 class="results__heading">Form Data</h2>
            
            </div>
        </>
    )
}
export default MediaSearch;
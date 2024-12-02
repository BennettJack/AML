import '../CSS/MediaInfo.css';
import lotrBookSmall from './images/lotrBookSmall.jpg';

const MediaInfo = () => {
    return (
        <>
            <div className="MediaInfo">
                <div className="MediaImage">
                    <img src={lotrBookSmall} id="mediaResultImage" alt="lotr book" width="113" height="171"></img>
                </div>
                <div className ="Info">
                    <div className ="InfoLine1">
                        <p>Media Name</p>
                        <p>Type</p>
                        <p>Genre</p>
                        <p>Author</p>
                    </div>
                    <div className ="InfoLine2">
                        <p>Publisher</p>
                        <p>Publish Date</p>
                        <p>Page Count</p>
                        <p>Available</p>
                    </div>
                </div>
            </div>
            <div className ="MediaDescription">
                <p>Description</p>
                <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec non condimentum dolor, volutpat cursus dolor. Nulla et mi eget justo feugiat commodo vitae sit amet nulla. Duis interdum, diam nec eleifend maximus, sapien neque imperdiet ligula, eu mattis leo nunc id quam. Aenean efficitur euismod tortor quis  aliquam. Nunc maximus viverra augue, et mattis orci maximus ut. Integer fermentum molestie tortor. Suspendisse potenti. Aenean lectus orci, egestas sit amet venenatis sit amet, congue non lorem. Aenean quis leo quis eros vehicula posuere. Pellentesque libero arcu, suscipit ac est quis, ultrices mollis erat. </p>
            </div>
            <div className="bookButton">
            <button>Book</button>
            </div>
        </>
    )
}
export default MediaInfo;
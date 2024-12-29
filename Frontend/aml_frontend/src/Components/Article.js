import { Link} from 'react-router-dom';

const Article = ({ media }) => {
    return (
        <section>
            <article className="mediaResultArticle">
                <Link to={`/mediaresult/${media.id}`}>
                    <div>
                        <img src={media.image} id="mediaResultImage" alt={media.image} width="113" height="171"></img>
                    </div>
                    <div>
                        <p>{media.name}</p>
                        <p>{media.author}</p>
                        <p>{media.publishDate}</p>
                    </div>
                </Link>
            </article>
        </section>
    );
};

export default Article;
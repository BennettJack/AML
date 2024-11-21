import '../CSS/Queries.css';

const Queries = () => {
    return (
        <>
            <form>
                <div ClassName = "QueryButtons">
                    <button type="button">Query</button>
                    <button type="button">Query</button>
                    <button type="button">Query</button>
                    <button type="button">Query</button>
                </div>
                <div ClassName = "QueryView">
                    <h2>Query</h2>
                    <h3>Member Query: </h3>
                    <textarea name="QueryMessage" rows="10" cols="30">Query Message Here</textarea>
                    <h3>Response: </h3>
                    <textarea name="QueryResponse" rows="10" cols="30">Type Query Response Here...</textarea>
                    <button type="submit">Confirm</button>
                </div>
            </form>
        </>
    )
}
export default Queries;
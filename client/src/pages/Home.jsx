import { useEffect, useState } from 'react';

// dependecies
import axios from 'axios';

// components
import Article from '../components/Article';

export default function Home() {
    const [articles, setArticles] = useState([]);

    const FetchArticles = async () => {
        return await (await axios.get('https:localhost:5001/api/articles')).data;
    }

    useEffect(() => {
        const abortController = new AbortController();
        let ignored = false;

        if(!ignored) {
        (async function(){
            setArticles(await FetchArticles())
        } ())
        };

        return () => {
        ignored = true;
        abortController.abort();
        }
    }, [])

    return (
        <div className="container-fluid">
            <div class="row">
                {
                    articles.length !== 0?
                        articles.map(x => <Article data={x} className={"col-12 mb-3"} />)
                    :
                        "No Articles found"
                }
            </div>
      </div>
    )
}

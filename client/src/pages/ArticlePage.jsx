import { useEffect, useState } from 'react';
import { Link, useParams } from 'react-router-dom';
import { LoremIpsum } from "lorem-ipsum";

import '../components/Article.css';

// dependecies
import axios from 'axios';

export default function ArticlePage(props) {
    let { id } = useParams();

    const [articleData, setArticleData] = useState({title: '', content: '', user: {name: ''}, createdAt: new Date()});

    const lorem = new LoremIpsum({
        sentencesPerParagraph: {
          max: 8,
          min: 4
        },
        wordsPerSentence: {
          max: 16,
          min: 4
        }
      });

    const FetchArticle = async () => {
        return await (await axios.get(`https:localhost:5001/api/articles/${id}`)).data;
    }

    useEffect(() => {
        const abortController = new AbortController();
        let ignored = false;

        if(!ignored) {
        (async function(){
            setArticleData(await FetchArticle())
        } ())
        };

        return () => {
        ignored = true;
        abortController.abort();
        }
    }, [])

  
    console.log(articleData)

    return (
        <div className={`${props.className} card bg-gradient-default`}>
            <div className="card-body">
                <h3 className="card-title text-info text-gradient">{articleData.title}</h3>
                <img src={process.env.PUBLIC_URL + `/cozy-workspace.jpeg`} class="img-fluid border-radius-lg" alt="Responsive image"></img>
                <blockquote className="blockquote text-white mb-0">
                <p className="text-dark ms-3">{articleData.content + '. ' + lorem.generateParagraphs(5)}</p>
                <footer className="blockquote-footer text-gradient text-info text-sm ms-3">{articleData?.user?.name || 'name'} <cite title="Source Title">{`@ ${new Date(articleData.createdAt).toLocaleDateString()} ${new Date(articleData.createdAt).toLocaleTimeString()}`}</cite></footer>
                </blockquote>
            </div>
        </div>
    )
}

import React from 'react'
import { useNavigate } from 'react-router-dom';
import './Article.css';

export default function Article(props) {
    let navigate = useNavigate();
    
    return (
        <a className={`${props.className} card bg-gradient-default enlarge`} onClick={() => navigate(`/articles/${props.data.id}`)}>
            <div className="card-body">
                <h3 className="card-title text-info text-gradient">{props.data.title}</h3>
                <p className="text-dark ms-3">{'Tags: ' + props.data.keywords.join(', ')}</p>
                <blockquote className="blockquote text-white mb-0">
                <p className="text-dark ms-3 text-truncate">{props.data.content}</p>
                <footer className="blockquote-footer text-gradient text-info text-sm ms-3">{props.data.user.name + ' ' + props.data.id} <cite title="Source Title">{`@ ${new Date(props.data.createdAt).toLocaleDateString()} ${new Date(props.data.createdAt).toLocaleTimeString()}`}</cite> </footer>
                </blockquote>
            </div>
        </a>
    )
}

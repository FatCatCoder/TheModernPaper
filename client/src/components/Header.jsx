import React from 'react'

export default function Header() {
    return (
        <>
        <header className="container-fluid">
            <div className="row">
                <a href="/" className="col-10">
                    <h1 className="display-1 m-0 p-0">The Modern Paper</h1>
                    <h4 className="lead ms-3 fst-italic">The best content for you</h4>
                </a>
                <div className="col-2 my-auto">
                    <a type="button" href="/login" class="btn bg-gradient-info">Login</a>
                </div>
            </div>
        </header>

        <hr />
        </>
    )
}

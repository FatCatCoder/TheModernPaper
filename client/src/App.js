import { useEffect, useState } from 'react';
import {
  BrowserRouter,
  Routes,
  Route
} from "react-router-dom";

// dependecies
import axios from 'axios';

// pages
import Home from './pages/Home';
import ArticlePage from './pages/ArticlePage';
import Login from './pages/Login';

// componenets
import logo from './logo.svg';
import Header from './components/Header';
import Footer from './components/Footer';


function App() {
  

  return (
    <div className="App">
      <Header />
      
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/login" element={<Login />} />
          <Route path="/articles/:id" element={<ArticlePage />} />
        </Routes>
      </BrowserRouter>

      <Footer />
    </div>
  );
}

export default App;

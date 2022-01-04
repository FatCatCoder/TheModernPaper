import React from 'react';
import ReactDOM from 'react-dom';
import 'soft-ui-design-system/assets/css/soft-design-system.min.css';
import 'soft-ui-design-system/assets/js/soft-design-system.min.js';
import 'soft-ui-design-system/assets/css/nucleo-icons.css';
import App from './App';
import reportWebVitals from './reportWebVitals';

ReactDOM.render(
  <React.StrictMode>
    <App />
  </React.StrictMode>,
  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();

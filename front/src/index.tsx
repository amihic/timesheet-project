import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import reportWebVitals from './reportWebVitals';
import { RouterProvider, createBrowserRouter } from 'react-router-dom';
import App from './components/App/App';
import ClientsPage from './pages/ClientsPage/ClientsPage';
import CategoriesPage from './pages/CategoriesPage/CategoriesPage';

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);

const router = createBrowserRouter([
  {
    path: "/app",
    element: <App />,
    children: [
      {
        path: "clients",
        element: <ClientsPage/>,
      },
      {
        path: "categories",
        element: <CategoriesPage/>,
      }
    ],
  },
  {
    path: "/login",
    element: <div>Login</div>,
  },
]);

root.render(
  <React.StrictMode>
     <RouterProvider router={router} />
  </React.StrictMode>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();

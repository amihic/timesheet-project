import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import './scss/style.scss';
import reportWebVitals from './reportWebVitals';
import { RouterProvider, createBrowserRouter } from 'react-router-dom';
import App from './components/App/App';
import ClientsPage from './pages/ClientsPage/ClientsPage';
import CategoriesPage from './pages/CategoriesPage/CategoriesPage';
import LoginPage from './pages/LoginPage/LoginPage';
import ProjectsPage from './pages/ProjectsPage/ProjectsPage';
import TeamMembersPage from './pages/TeamMembersPage/TeamMembersPage';
import ReportsPage from './pages/ReportsPage/ReportsPage';
import TimeSheet from './components/TimeSheet/TimeSheet';

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);

const router = createBrowserRouter([
  {
    path: "/app",
    element: <App />,
    children: [
      {
        path: "timeSheet",
        element: <TimeSheet/>,
      },
      {
        path: "clients",
        element: <ClientsPage/>,
      },
      {
        path: "categories",
        element: <CategoriesPage/>,
      },
      {
        path: "projects",
        element: <ProjectsPage/>,
      },
      {
        path: "teamMembers",
        element: <TeamMembersPage/>,
      },
      {
        path: "reports",
        element: <ReportsPage/>,
      }
    ],
  },
  {
    path: "/login",
    element: <LoginPage/>,
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

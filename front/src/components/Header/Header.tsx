import {jwtDecode} from 'jwt-decode';
import { useEffect, useState } from 'react';

function Header() {

  const [userEmail, setUserEmail] = useState<string | null>(null);

  useEffect(() => {
    async function getEmailFromToken() {
      const tokenString = localStorage.getItem('token');

      if (tokenString !== null) {
        try {
          const decodedToken: { sub?: string } = jwtDecode(tokenString);
          const userEmail = decodedToken?.sub || null;
          setUserEmail(userEmail);
          console.log('User email:', userEmail);
        } catch (error) {
          console.error('Error decoding token:', error);
        }
      }
    }

    getEmailFromToken();
  }, []);

  return (
    <div >
      <header className="header">
			<div className="top-bar"></div>
      <div style={{ marginLeft: '50px', color: '#ed6732' }}>{userEmail !== null ? userEmail : 'Loading...'}</div>
			<div className="wrapper">
          <a href="app" className="logo">
            <img src="src\assets\img\logo.png" alt="VegaITSourcing Timesheet" />
          </a>
          <ul className="user right">
            <li>
              <a>Sladjana Miljanovic</a>
              <div className="invisible"></div>
              <div className="user-menu">
                <ul>
                  <li>
                    <a>Change password</a>
                  </li>
                  <li>
                    <a>Settings</a>
                  </li>
                  <li>
                    <a>Export all data</a>
                  </li>
                </ul>
              </div>
            </li>
            <li className="last">
              <a>Logout</a>
            </li>
          </ul>
          <nav>
            <ul className="menu">
              <li>
                <a href="/app/timeSheet" className="btn nav active">
                  TimeSheet
                </a>
              </li>
              <li>
                <a href="/app/clients" className="btn nav">
                  Clients
                </a>
              </li>
              <li>
                <a href="/app/projects" className="btn nav">
                  Projects
                </a>
              </li>
              <li>
                <a href="/app/categories" className="btn nav">
                  Categories
                </a>
              </li>
              <li>
                <a href="/app/teamMembers" className="btn nav">
                  Team members
                </a>
              </li>
              <li className="last">
                <a href="/app/reports" className="btn nav">
                  Reports
                </a>
              </li>
            </ul>
            
            <span className="line"></span>
          </nav>
        </div>
      </header>
    </div>
  );
}

export default Header;

import { Outlet } from "react-router-dom";
import styles from './App.module.scss'

function App() {
  return (
    <div className={styles.container}>
      <header className={styles.header}>
        <div className={styles["top-bar"]}></div>
        <div className="wrapper">
          <a href="index.html" className="logo">
            <img src="assets/img/logo.png" alt="VegaITSourcing Timesheet" />
          </a>
          <ul className="user right">
            <li>
              <a href="javascript:;">Sladjana Miljanovic</a>
              <div className="invisible"></div>
              <div className="user-menu">
                <ul>
                  <li>
                    <a href="javascript:;" className="link">
                      Change password
                    </a>
                  </li>
                  <li>
                    <a href="javascript:;" className="link">
                      Settings
                    </a>
                  </li>
                  <li>
                    <a href="javascript:;" className="link">
                      Export all data
                    </a>
                  </li>
                </ul>
              </div>
            </li>
            <li className="last">
              <a href="javascript:;">Logout</a>
            </li>
          </ul>
          <nav>
            <ul className="menu">
              <li>
                <a href="index.html" className="btn nav active">
                  TimeSheet
                </a>
              </li>
              <li>
                <a href="clients.html" className="btn nav">
                  Clients
                </a>
              </li>
              <li>
                <a href="projects.html" className="btn nav">
                  Projects
                </a>
              </li>
              <li>
                <a href="categories.html" className="btn nav">
                  Categories
                </a>
              </li>
              <li>
                <a href="team-members.html" className="btn nav">
                  Team members
                </a>
              </li>
              <li className="last">
                <a href="reports.html" className="btn nav">
                  Reports
                </a>
              </li>
            </ul>
            <div className="mobile-menu">
              <a href="javascript:;" className="menu-btn">
                <i className="zmdi zmdi-menu"></i>
              </a>
              <ul>
                <li>
                  <a href="javascript:;">TimeSheet</a>
                </li>
                <li>
                  <a href="javascript:;">Clients</a>
                </li>
                <li>
                  <a href="javascript:;">Projects</a>
                </li>
                <li>
                  <a href="javascript:;">Categories</a>
                </li>
                <li>
                  <a href="javascript:;">Team members</a>
                </li>
                <li className="last">
                  <a href="javascript:;">Reports</a>
                </li>
              </ul>
            </div>
            <span className="line"></span>
          </nav>
        </div>
      </header>
      <Outlet />
      <footer className="footer">
			<div className="wrapper">
				<ul>
					<li>
						<span>Copyright. VegaITSourcing All rights reserved</span>
					</li>
				</ul>
				<ul className="right">
					<li>
						<a href="javascript:;">Terms of service</a>
					</li>
					<li>
						<a href="javascript:;" className="last">Privacy policy</a>
					</li>
				</ul>
			</div>
		</footer>
    </div>
  );
}

export default App;

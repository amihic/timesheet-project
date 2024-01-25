
function Header() {
  return (
    <div >
      <header className="header">
			<div className="top-bar"></div>
			<div className="wrapper">
          <a href="app" className="logo">
            <img src="assets/img/logo.png" alt="VegaITSourcing Timesheet" />
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
                <a href="/app" className="btn nav active">
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

type ProjectsProps = {
    projects: Project[];
  };
  
  function Projects({ projects }: ProjectsProps) {
    return (
      <div className="wrapper">
        <section className="content">
          <h2>
            <i className="ico projects"></i>Projects
          </h2>
          <div className="grey-box-wrap reports">
            <a href="#new-member" className="link new-member-popup">
              Create new category
            </a>
            <div className="search-page">
              <input type="search" name="search-clients" className="in-search" />
            </div>
          </div>
          <div className="new-member-wrap">
            <div id="new-member" className="new-member-inner">
              <h2>Create new project</h2>
              <ul className="form">
                <li>
                  <label>Project name:</label>
                  <input type="text" className="in-text" />
                </li>
                <li>
                  <label>Description:</label>
                  <input type="text" className="in-text" />
                </li>
                <li>
                  <label>Customer:</label>
                  <select>
                    <option>Select customer</option>
                    <option>Adam Software NV</option>
                    <option>Clockwork</option>
                    <option>Emperor Design</option>
                  </select>
                </li>
                <li>
                  <label>Lead:</label>
                  <select>
                    <option>Select lead</option>
                    <option>Sasa Popovic</option>
                    <option>Sladjana Miljanovic</option>
                  </select>
                </li>
              </ul>
              <div className="buttons">
                <div className="inner">
                  <a>
                    Save
                  </a>
                </div>
              </div>
            </div>
          </div>
          <div className="alpha">
            <ul>
              <li>
                <a>a</a>
              </li>
              <li>
                <a>b</a>
              </li>
              <li>
                <a>c</a>
              </li>
              <li>
                <a>d</a>
              </li>
              <li>
                <a>e</a>
              </li>
              <li className="active">
                <a>f</a>
              </li>
              <li>
                <a>g</a>
              </li>
              <li>
                <a>h</a>
              </li>
              <li>
                <a>i</a>
              </li>
              <li>
                <a>j</a>
              </li>
              <li>
                <a>k</a>
              </li>
              <li>
                <a>l</a>
              </li>
              <li className="disabled">
                <a>m</a>
              </li>
              <li>
                <a>n</a>
              </li>
              <li>
                <a>o</a>
              </li>
              <li>
                <a>p</a>
              </li>
              <li>
                <a>q</a>
              </li>
              <li>
                <a>r</a>
              </li>
              <li>
                <a>s</a>
              </li>
              <li>
                <a>t</a>
              </li>
              <li>
                <a>u</a>
              </li>
              <li>
                <a>v</a>
              </li>
              <li>
                <a>w</a>
              </li>
              <li>
                <a>x</a>
              </li>
              <li>
                <a>y</a>
              </li>
              <li className="last">
                <a>z</a>
              </li>
            </ul>
          </div>
          <div className="accordion-wrap projects" >
            {projects && projects.length && projects.map((project) => (
              <div className="item" key={project.id}>
                <div className="heading">
                  <span>{project.name}</span>
                  <i>+</i>
                </div>
                <div className="details">
                  <ul className="form">
                    <li>
                      <label>Project name:</label>
                      <input type="text" className="in-text" />
                    </li>
                    <li>
                      <label>Lead:</label>
                      <select>
                        <option>Select lead</option>
                        <option>Sasa Popovic</option>
                        <option>Sladjana Miljanovic</option>
                      </select>
                    </li>
                  </ul>
                  <ul className="form">
                    <li>
                      <label>Description:</label>
                      <input type="text" className="in-text" />
                    </li>
                  </ul>
                  <ul className="form last">
                    <li>
                      <label>Customer:</label>
                      <select>
                        <option>Select customer</option>
                        <option>Adam Software NV</option>
                        <option>Clockwork</option>
                        <option>Emperor Design</option>
                      </select>
                    </li>
                    <li className="inline">
                      <label>Status:</label>
                      <span className="radio">
                        <label htmlFor="inactive">Active:</label>
                        <input
                          type="radio"
                          value="1"
                          name="status"
                          id="inactive"
                        />
                      </span>
                      <span className="radio">
                        <label htmlFor="active">Inactive:</label>
                        <input type="radio" value="2" name="status" id="active" />
                      </span>
                      <span className="radio">
                        <label htmlFor="active">Archive:</label>
                        <input type="radio" value="3" name="status" id="active" />
                      </span>
                    </li>
                  </ul>
                  <div className="buttons">
                    <div className="inner">
                      <a>
                        Save
                      </a>
                      <a >
                        Delete
                      </a>
                    </div>
                  </div>
                </div>
              </div>
            ))}
          </div>
          <div className="pagination">
            <ul>
              <li>
                <a>1</a>
              </li>
              <li>
                <a>2</a>
              </li>
              <li>
                <a>3</a>
              </li>
              <li className="last">
                <a>Next</a>
              </li>
            </ul>
          </div>
        </section>
      </div>
    );
  }
  
  export default Projects;
  
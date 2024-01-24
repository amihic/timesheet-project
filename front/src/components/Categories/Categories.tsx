type CategoriesProps = {
  categories: Category[];
};

function Categories({ categories }: CategoriesProps) {
  return (
    <div className="wrapper">
      <section className="content">
        <h2>
          <i className="ico projects"></i>Projects
        </h2>
        <div className="grey-box-wrap reports">
          <a href="#new-member" className="link new-member-popup">
            Create new project
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
                <a href="javascript:;" className="btn green">
                  Save
                </a>
              </div>
            </div>
          </div>
        </div>
        <div className="alpha">
          <ul>
            <li>
              <a href="javascript:;">a</a>
            </li>
            <li>
              <a href="javascript:;">b</a>
            </li>
            <li>
              <a href="javascript:;">c</a>
            </li>
            <li>
              <a href="javascript:;">d</a>
            </li>
            <li>
              <a href="javascript:;">e</a>
            </li>
            <li className="active">
              <a href="javascript:;">f</a>
            </li>
            <li>
              <a href="javascript:;">g</a>
            </li>
            <li>
              <a href="javascript:;">h</a>
            </li>
            <li>
              <a href="javascript:;">i</a>
            </li>
            <li>
              <a href="javascript:;">j</a>
            </li>
            <li>
              <a href="javascript:;">k</a>
            </li>
            <li>
              <a href="javascript:;">l</a>
            </li>
            <li className="disabled">
              <a href="javascript:;">m</a>
            </li>
            <li>
              <a href="javascript:;">n</a>
            </li>
            <li>
              <a href="javascript:;">o</a>
            </li>
            <li>
              <a href="javascript:;">p</a>
            </li>
            <li>
              <a href="javascript:;">q</a>
            </li>
            <li>
              <a href="javascript:;">r</a>
            </li>
            <li>
              <a href="javascript:;">s</a>
            </li>
            <li>
              <a href="javascript:;">t</a>
            </li>
            <li>
              <a href="javascript:;">u</a>
            </li>
            <li>
              <a href="javascript:;">v</a>
            </li>
            <li>
              <a href="javascript:;">w</a>
            </li>
            <li>
              <a href="javascript:;">x</a>
            </li>
            <li>
              <a href="javascript:;">y</a>
            </li>
            <li className="last">
              <a href="javascript:;">z</a>
            </li>
          </ul>
        </div>
        <div className="accordion-wrap projects">
          {categories.map((category) => (
            <div className="item">
              <div className="heading">
                <span>{category.name}</span>{" "}
                <span>
                  <em>{category.id}</em>
                </span>
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
                    <a href="javascript:;" className="btn green">
                      Save
                    </a>
                    <a href="javascript:;" className="btn red">
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
              <a href="javascript:;">1</a>
            </li>
            <li>
              <a href="javascript:;">2</a>
            </li>
            <li>
              <a href="javascript:;">3</a>
            </li>
            <li className="last">
              <a href="javascript:;">Next</a>
            </li>
          </ul>
        </div>
      </section>
    </div>
  );
}

export default Categories;

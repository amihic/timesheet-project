import { useState } from "react"
import AuthService from "../../services/AuthService";

function LoginPage()
{
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");

    const handleLogin = async () => {
        try {
        await AuthService.login(email, password);
        // baci na neku stranicu
        } catch (error) {
        console.error("Login error:", error);
        }
    };

    return (
        <div className="wrapper centered">
          <div className="logo-wrap">
            <a href="index.html" className="inner">
              {/* <img src="assets/img/logo-large.png"> */}
            </a>
          </div>
          <div className="centered-content-wrap">
            <div className="centered-block">
              <h1>Login</h1>
              <ul>
                <li>
                  <input
                    type="text"
                    placeholder="Email"
                    className="in-text large"
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                  />
                </li>
                <li>
                  <input
                    type="password"
                    placeholder="Password"
                    className="in-pass large"
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                  />
                </li>
                <li className="last">
                  <input type="checkbox" className="in-checkbox" id="remember" />
                  <label className="in-label" htmlFor="remember">
                    Remember me
                  </label>
                  <span className="right">
                    <a>
                      Forgot password?
                    </a>
                    <button onClick={handleLogin} className="btn orange">
                      Login
                    </button>
                  </span>
                </li>
              </ul>
            </div>
          </div>
        </div>
      );
    }

export default LoginPage
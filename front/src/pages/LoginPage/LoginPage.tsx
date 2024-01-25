function LoginPage()
{
    return <div className="wrapper centered">
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
                    <input type="text" placeholder="Email" className="in-text large"/>
                </li>
                <li>
                    <input type="password" placeholder="Password" className="in-pass large"/>
                </li>
                <li className="last">
                    <input type="checkbox" className="in-checkbox" id="remember"/>
                    <label className="in-label" htmlFor="remember">Remember me</label>
                    <span className="right">
                        <a href="javascript:;" className="link">Forgot password?</a>
                        <a href="javascript:;" className="btn orange">Login</a>
                    </span>
                </li>
            </ul>
        </div>
    </div>
</div>

}

export default LoginPage
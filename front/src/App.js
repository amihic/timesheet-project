//import logo from "./logo.svg";
import "./App.css";

function App() {

  // return (
  //   <div className="App">
  //     <header className="App-header">
  //       <img src={logo} className="App-logo" alt="logo" />
  //       <p>
  //         Edit <code>src/App.js</code> and save to reload.
  //       </p>
  //       <a
  //         className="App-link"
  //         href="https://reactjs.org"
  //         target="_blank"
  //         rel="noopener noreferrer"
  //       >
  //         Learn React
  //       </a>
  //     </header>
  //   </div>
  // );
  return(
    

	<div class="wrapper centered">
		<div class="logo-wrap">
			<a href="index.html" class="inner">
				
			</a>
		</div>
		<div class="centered-content-wrap">
			<div class="centered-block">
				<h1>Login</h1>
				<ul>
					<li>
						<input type="text" placeholder="Email" class="in-text large" />
					</li>
					<li>
						<input type="password" placeholder="Password" class="in-pass large" />
					</li>
					<li class="last">
						<input type="checkbox" class="in-checkbox" id="remember"></input>
						<label class="in-label" for="remember">Remember me</label>
						<span class="right">
							
						</span>
					</li>
				</ul>
			</div>
		</div>
	</div>




  );
}

export default App;

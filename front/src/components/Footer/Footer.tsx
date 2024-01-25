import styles from "./Footer.module.scss";

function Footer() {
  return (
    <div className={styles.container}>
      <footer className="footer">
			<div className="wrapper">
          <ul>
            <li>
              <span>Copyright. VegaITSourcing All rights reserved</span>
            </li>
          </ul>
          <ul className="right">
            <li>
              <a>Terms of service</a>
            </li>
            <li>
              <a className="last">Privacy policy</a>
            </li>
          </ul>
        </div>
      </footer>
    </div>
  );
}

export default Footer;

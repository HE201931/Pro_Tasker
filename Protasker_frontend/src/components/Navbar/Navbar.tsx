import "./Navbar.scss"
import {Link, useLocation} from "react-router-dom"

function Navbar(){
    
    const location = useLocation();

    const { pathname } = location;

    const splitLocation:string[] = pathname.split("/");

    return(
        <div className="c-navbar">
            <div className="c-navbar-title">
                <h1>ProTasker</h1>
            </div>  
            <div className="c-navbar-links">
                <Link to="/" className={splitLocation[1] === '' ? "active-link" : "link"}>Table de bord</Link>
                <Link to="/graph" className={splitLocation[1] === 'graph' ? "active-link" : "link"}>Graphique</Link>
            </div>
        </div>
    )
}

export default Navbar;
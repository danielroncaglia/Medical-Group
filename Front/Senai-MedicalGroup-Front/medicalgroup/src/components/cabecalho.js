import React, { Component } from "react";
import NavBar from '../components/NavBar';

import {Link, withRouter} from 'react-router-dom';

import {usuarioAutenticado} from '../services/auth';

import logo from "../assets/img/icon-login.png";

class Cabecalho extends Component {

    logout(){
        localStorage.removeItem("medicalgroup");
        this.props.history.push('/');
    }
  render() {
    return (
      <header className="cabecalhoPrincipal">
        <div className="container">
          <img src={logo} alt="Medicalgroup" />

          <nav className="cabecalhoPrincipal-nav">
            <div>
                <Link to="/">Home</Link>
            </div>
            <NavBar />
          </nav>
        </div>
      </header>
    );
  }
}

export default withRouter(Cabecalho);
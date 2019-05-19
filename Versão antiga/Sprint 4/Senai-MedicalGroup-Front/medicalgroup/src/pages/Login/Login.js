import React, { Component } from "react";
import {parseJwt} from '../../services/auth';
//import logo from '../../assets/img/icon-login.png'
import Axios from "axios";
//import {Link} from 'react-router-dom';

export default class Login extends Component {
    constructor(){
        super();

        this.state ={
            email : '',
            senha : ''
        }
    }

    atualizaEstadoEmail(event){
        this.setState({email : event.target.value});
    }

    atualizaEstadoSenha(event){
        this.setState({senha : event.target.value});
    }

    efetuaLogin(event){
        event.preventDefault();
        
        alert(this.state.email + " logado");

        Axios.post('https://localhost:5001/api/login', {
          email : this.state.email,
          senha: this.state.senha
       })
       .then(data => {

           if(data.status === 200){
               console.log(data);
               localStorage.setItem("medicalgroup", data.data.token);
               console.log(parseJwt().Role);

               if(parseJwt().Role === "Administrador"){
                 this.props.history.push("/cadastrarconsulta");
               }
               
               else if (parseJwt().Role === "Médico"){
                  this.props.history.push("/listarmedico");
               }
               
               else if (parseJwt().Role === "Paciente"){
                this.props.history.push("/listarpaciente");
               }
                else {
                 this.props.history.push("/login");
               }
               
           } 
       })
       .catch(erro => {
           this.setState({ erroMensagem : 'Email ou senha inválido'});
       })
   }

  render() {
    return (
      <section className="container flex">
        <div className="img__login">
          <div className="img__overlay" />
        </div>

        <div className="item__login">
          <div className="row">
            <div className="item">
            </div>
            <div className="item" id="item__title">
              <p className="text__login" id="item__description">
                Faça o login.
              </p>
            </div>
            <form onSubmit={this.efetuaLogin.bind(this)}>
              <div className="item">
                <input
                  className="input__login"
                  placeholder="email"
                  type="text"
                  value={this.state.email}
                  onChange={this.atualizaEstadoEmail.bind(this)}
                  name="email"
                  id="login__email"
                />
              </div>
              <div className="item">
                <input
                  className="input__login"
                  placeholder="password"
                  value={this.state.senha}
                  onChange={this.atualizaEstadoSenha.bind(this)}
                  type="password"
                  name="password"
                  id="login__password"
                />
              </div>
              <div className="item">
                <button type="submit" className="btn btn__login" id="btn__login">
                  Login
                </button>
              </div>
            </form>
          </div>
        </div>
      </section>
    );
  }
}
import React, { Component } from "react";
import axios from "axios";
import {Link} from 'react-router-dom';
import "../../assets/css/flexbox.css";
import "../../assets/css/reset.css";
import "../../assets/css/style.css";
import logo from '../../assets/img/icon-login.png'


export default class CadastrarConsulta extends Component {

  constructor() {
    super();

    this.state = {

      IdPaciente: "",
      IdMedico: "",
      DataHorario: "",
      DescricaoConsulta: "",
      SituacaoConsulta: "",
      listaconsultas: [],

    };

  }

    componentDidMount() {

        
    }

  atualizaEstadoIdPaciente(event) {
    this.setState({ IdPaciente: event.target.value });
  }

  atualizaEstadoIdMedico(event) {
    this.setState({ IdMedico: event.target.value });
  }

  atualizaEstadoDataHorario(event) {
    this.setState({ DataHorario: event.target.value });
  }

  atualizaEstadoDescricaoConsulta(event) {
    this.setState({ DescricaoConsulta: event.target.value });
  }

  atualizaEstadoSituacaoConsulta(event) {
    this.setState({ SituacaoConsulta: event.target.value });
  }

  atualizaEstadolistaconsultas(event) {
    this.setState({ listaconsultas: event.target.value });
  }

  CadastrarConsulta(event) {
    event.preventDefault();

    let consulta = {
      idPaciente: this.state.IdPaciente,
      idMedico: this.state.IdMedico,
      dataHorario: this.state.DataHorario,
      descricaoConsulta: this.state.DescricaoConsulta,
      situacaoConsulta: this.state.SituacaoConsulta,
    };

    axios.post('http://192.168.6.3:5000/api/consultas/cadastrar', consulta,{
      headers: {
          "Authorization": "Bearer " + localStorage.getItem('medicalgroup'),
          "Content-Type": "application/json"
      }

  })
  .then( res => {
    alert("Cadastrar consulta")
  })
  }

  render() {
    return (
      <div>

        <main className="conteudoPrincipal">

          <section className="conteudoPrincipal-cadastro">

            <h1 className="conteudoPrincipal-cadastro-titulo">Cadastrar Consultas</h1>
            <h1 className="conteudoPrincipal-cadastro-titulo">Medical Group</h1>

            <Link to="/">
                <img src={logo} className="icone__login" alt="Medical" />
        </Link>

            <div className="container" id="conteudoPrincipal-cadastro">

              <form onSubmit={this.CadastrarConsulta.bind(this)}>

                <div className="container">

                  <input
                    type="text"
                    value={this.state.IdPaciente}
                    onChange={this.atualizaEstadoIdPaciente.bind(this)}
                    id="IdPaciente"
                    placeholder="Digite o ID do paciente"
                  />

                  <input
                    type="text"
                    value={this.state.IdMedico}
                    onChange={this.atualizaEstadoIdMedico.bind(this)}
                    id="IdMedico"
                    placeholder="Digite o ID do médico"
                  />

                    <input
                    type="date"
                    value={this.state.DataHorario}
                    onChange={this.atualizaEstadoDataHorario.bind(this)}
                    id="DataHorario"
                  />

                    <textarea
                    rows="3"


                    cols="50"
                    value={this.state.DescricaoConsulta}
                    onChange={this.atualizaEstadoDescricaoConsulta.bind(this)}
                    placeholder="descricao da consulta"
                    id="DescricaoConsulta"
                  />

                    <select
                    id="option__acessolivre"
                    value={this.state.SituacaoConsulta}
                    onChange={this.atualizaEstadoSituacaoConsulta.bind(this)}
                  >
                    <option value="Agendada">Agendada</option>
                    <option value="Realizada">Realizada</option>
                    <option value="Cancelada">Cancelada</option>
                  </select>

                  
                </div>

                <button className="conteudoPrincipal-btn conteudoPrincipal-btn-cadastro">
                  Cadastrar                
                </button>              
              </form>
            </div>
          </section>
        </main>

      </div>
    );
  }
}
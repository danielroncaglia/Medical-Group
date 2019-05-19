import React, { Component } from "react";
import axios from "axios";

export default class CadastrarConsulta extends Component {

  constructor() {
    super();

    this.state = {

      IdPaciente: "",
      IdMedico: "",
      DataHorario: "",
      DescricaoConsulta: "",
      SituacaoConsulta: "",
      Outros: "",
      listaconsultas: [],

    };

  }

    componentDidMount() {
        // apiService
        //     .call("consultas/cadastrar")
        //     .getAll()
        //     .then(data => {
        //         this.setState({ listaconsultas: data.data });
        //     });
        
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

  atualizaEstadoOutros(event) {
    this.setState({ Outros: event.target.value });
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
      situacaoConsulta: this.state.SituacaoConsulta,
    };

    axios.post('http://localhost:5000/api/consultas/cadastrar', consulta,{
      headers: {
          "Authorization": "Bearer " + localStorage.getItem('medicalgroup'),
          "Content-Type": "application/json"
      }

  })
  .then( res => {
    this.CadastrarConsulta()
  })
  }

  render() {
    return (
      <div>

        <main className="conteudoPrincipal">

          <section className="conteudoPrincipal-cadastro">

            <h1 className="conteudoPrincipal-cadastro-titulo">Cadastrar Consultas</h1>

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

                    <textarea
                    rows="3"
                    cols="50"
                    value={this.state.Outros}
                    onChange={this.atualizaEstadoOutros.bind(this)}
                    placeholder="outras informações"
                    id="outros"
                  />

                  
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
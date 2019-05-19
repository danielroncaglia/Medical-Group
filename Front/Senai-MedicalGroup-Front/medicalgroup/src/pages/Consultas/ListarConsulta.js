import React, { Component } from "react";
import axios from "axios";

export default class ListarConsulta extends Component {

    constructor() {
        super();
        this.state = {
            listarconsulta: [],
            idPaciente: '',
            idMedico:  '',
            dataHorario: '',
            situacaoConsulta:  '',
        }
    }


    componentDidMount() {
        this.listarConsulta();
    }

    listarConsultas() {
        fetch('http://localhost:5000/api/consulta/listar', {
            headers: {
                "Content-Type": "application/json",
                "Authorization": "Bearer " + localStorage.getItem("medgroup")
            }
        })
            .then(resposta => resposta.json())
            .then(data => this.setState({ listarconsulta: data }))
            .catch((erro) => console.log(erro))
    }


    render() {
        return (
            <div className="centralizar1">
                        <h1>SPMedGroup</h1>
                        <div className="lista-consultas">    

                                {this.state.listarConsulta.map((consulta) => {
                                 {  return (
                                            <h2>
                                            {consulta.idPaciente}
                                            {consulta.idMedico}
                                            {consulta.dataHorario}
                                            {consulta.situacaoConsulta}
                                            </h2>
                                 )}}
        )}
                        </div>
                        </div>
        )}}
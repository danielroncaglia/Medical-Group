import React, { Component } from "react";
//import axios from "axios";

import apiService from "../../services/apiServices"

import "../../assets/css/flexbox.css";
import "../../assets/css/reset.css";
import "../../assets/css/style.css";

class ListarConsulta extends Component {

    constructor() {
        super();
        this.state = {
            listarConsultas: [],
            idPaciente: '',
            idMedico: '',
            dataHorario: '',
            descricaoConsulta:"",
            situacaoConsulta: '',
        }
    }


    listarConsultas() {
        apiService
            .call("consultas/listar")
            .getAll()
            .then(res => {
                const consultas = res.data;
                console.log(consultas);
                this.setState({ listarConsultas: consultas })
            })
    }

    componentDidMount() {
        this.listarConsultas();
    }


    render() {
        return (
            <div className="centralizar1">
                <h1>Medical Group</h1>
                <div className="lista-consultas">
                    {this.state.listarConsultas.map((consultas) => {
                        return (
                            <tr key={consultas.id}>
                                <li>{consultas.idPaciente}</li>
                                <li>{consultas.idMedico}</li>
                                <li>{consultas.dataHorario}</li>
                                <li>{consultas.descricaoConsulta}</li>
                                <li>{consultas.situacaoConsulta}</li>
                            </tr>
                        )
                    })}
                </div>
            </div>
        )
    }
}

export default ListarConsulta;
import React, { Component } from "react";
import {Link} from 'react-router-dom';
import "../../assets/css/listar.css";
import "../../assets/css/flexbox.css";
import "../../assets/css/reset.css";
import logo from '../../assets/img/icon-login.png'
import apiService from "../../services/apiServices"

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

            <main class="conteudoPrincipal">

                <div class="container">

                    <h1 className="conteudoPrincipal-cadastro-titulo">Lista de Consultas</h1>
                    <h1 className="conteudoPrincipal-cadastro-titulo">Medical Group</h1>

                <Link to="/">
                    <img src={logo} className="icone__login" alt="MedicalGroup" />
                </Link>

                </div>

                <nav>
                    <ul class="conteudoPrincipal-dados" id="ul-dados">      

                        {this.state.listarConsultas.map((consultas) => {
                            return (
                                <li key={consultas.id} class="conteudoPrincipal-dados-link">
                                    <h2 class="conteudoPrincipal-dados-titulo titulo-azul" >{consultas.idPaciente}</h2>
                                    <p className="titulo-tipo-evento">{consultas.idMedico}</p>
                                    <p className="titulo-tipo-evento">{consultas.dataHorario}</p>
                                    <p className="titulo-tipo-evento">{consultas.descricaoConsulta}</p>
                                    <p className="titulo-tipo-evento">{consultas.situacaoConsulta}</p>
                                </li>
                        )

                    })}
                    </ul>
                </nav>
            </main>

    );
  }
}

export default ListarConsulta;
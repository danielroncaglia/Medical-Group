import React, { Component } from "react";
import "../../assets/css/listar.css";
import "../../assets/css/flexbox.css";
import "../../assets/css/reset.css";
import apiService from "../../services/apiServices"

class ListarPaciente extends Component {

    constructor() {
        super();
        this.state = {
            listarPaciente: [],
            idPaciente: "",
            idMedico: "",
            dataHorario: "",
            descricaoConsulta:"",
            situacaoConsulta: "",
            nomePaciente:"",
            nascimentoPaciente:"",
            rgPaciente:"",
            cpfPaciente:"",
            telefonePaciente:"",
            enderecoPaciente: "",
            informacoesPaciente:"",
        }
    }

    listarPaciente() {
        apiService
            .call("consultas/paciente")
            .getAll()
            .then(res => {
                const paciente = res.data;
                console.log(paciente);
                this.setState({ listarPaciente: paciente })
            })
    }

    componentDidMount() {
        this.listarPaciente();
    }


    render() {
        return (
            <div className="centralizar1">
                <h1>Medical Group</h1>
                <div className="lista-consultas">
                    {this.state.listarPaciente.map((paciente) => {
                        return (
                            <tr key={paciente.id}>
                                <li>{paciente.idPaciente}</li>
                                <li>{paciente.idMedico}</li>
                                <li>{paciente.dataHorario}</li>
                                <li>{paciente.descricaoConsulta}</li>
                                <li>{paciente.situacaoConsulta}</li>
                                <li>{paciente.nomePaciente}</li>
                                <li>{paciente.nascimentoPaciente}</li>
                                <li>{paciente.rgPaciente}</li>
                                <li>{paciente.telefonePaciente}</li>
                                <li>{paciente.enderecoPaciente}</li>                                                               
                                <li>{paciente.informacoesPaciente}</li>            
                            </tr>
                        )
                    })}
                </div>
            </div>
        )
    }
}

export default ListarPaciente;
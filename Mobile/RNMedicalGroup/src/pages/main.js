import React, { Component } from "react";
import { Text, View, Image, StyleSheet, FlatList } from "react-native";
import axios from "axios";
import api from "../services/api";
import {AsyncStorage} from 'react-native';

class Main extends Component {

    static navigationOptions = {
        tabBarIcon: ({ tintColor }) => (
            <Image
                source={require("../assets/icon-login.png")}
                style={styles.iconeNavegacaoConsultas}
            />
        )
    };

    constructor(props) {
        super(props);
        this.state = {
            Consultas: []
        };
    }

    componentDidMount() {
        this.carregarConsultas();
    }

    carregarConsultas = async () => {
        let token = await AsyncStorage.getItem('userToken');

        const resposta = await api.get("/consultas/listar",  {
            headers: {
              "Content-Type": "application/json",
              'Authorization': "Bearer " + token
            }
          });
        const dadosDaApi = resposta.data;
        this.setState({ Consultas: dadosDaApi });
    };

    render() {
        return (

            <View style={styles.telaConsultas}>

                <Image
                    source={require('../assets/icon-login.png')}
                    style={styles.imagemConsultas}
                />
                <Text style={styles.textoConsultas}>{"Consultas"}</Text>

                <View >
                    <FlatList
                        data={this.state.Consultas}
                        keyExtractor={item => item.idConsulta}
                        renderItem={this.renderizaItem}
                    />
                </View>
            </View>
        );
    }

    renderizaItem = ({ item }) => (
        <View >
            
            <Text style={styles.textoListaConsultas}>Paciente:</Text>
            <Text style={styles.textoListaConsultas}>{item.idPaciente}</Text>
            
            <Text style={styles.textoListaConsultas}>Data da Consulta:</Text>           
            <Text style={styles.textoListaConsultas}>{item.dataHorario}</Text>

            <Text style={styles.textoListaConsultas}>Descrição:</Text>           
            <Text style={styles.textoListaConsultas}>{item.descricaoConsulta}</Text>

            <Text style={styles.textoListaConsultas}>Situação:</Text>           
            <Text style={styles.textoListaConsultas}>{item.situacaoConsulta}</Text>

            <Text style={styles.textoListaConsultas}>Nome do Medico:</Text>
            <Text style={styles.textoListaConsultas}>{item.idMedico}</Text>

        </View>
    );
}

const styles = StyleSheet.create({

    iconeNavegacaoConsultas:{
        width: 25,
        height: 25,
        tintColor: "white"
    },

    telaConsultas: {
        display: "flex",
        flexDirection: "column",
        alignItems: "center",
        alignContent: "space-around",
        padding: 40
    },

    textoConsultas: {
        fontSize: 40,
        fontFamily: "OpenSans",
        color: "#2699FB",
        letterSpacing: 4
    },

    imagemConsultas: {
        height: 140,
        width: 132,
        margin: 40
    },

    textoListaConsultas: {
        fontSize: 20,
        fontFamily: "OpenSans",
        color: "#2699FB",
        letterSpacing: 4
    },

});

export default Main;
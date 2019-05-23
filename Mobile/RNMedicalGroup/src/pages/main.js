import React, {Component } from "react";
import {Text, View, Image, StyleSheet, FlatList} from "react-native";

import api from "../services/api";

class Main extends Component {

    static navigationOptions = {
        tabBarIcon: ({tintColor}) => (
            <Image
                source={require("../assets/icon-login.png")}
                style={styles.tabNavigatorIconHome}
            />
        )
    };

    constructor(props){
        super(props);
        this.state = {
            Consultas: []
        };
    }

    componentDidMount(){
        this.carregarConsultas();
    }

    carregarConsultas = async () => {
        const resposta = await api.get("/consultas/listar");
        const dadosDaApi = resposta.data;
        this.setState({Consultas: dadosDaApi});
    };

    render(){
        return (
            <View style={styles.main}>
                <View style={styles.mainHeader}>
                    <View style={styles.mainHeaderRow}>
                        <Image
                            source={require('../assets/icon-login.png')}
                            style={styles.mainHeaderImg}
                        />
                        <Text style={styles.mainHeaderText}>{"Lista de consultas"}</Text>
                    </View>

                </View>
                <View >
                    <FlatList
                    contentContainerStyle={styles.mainBodyConteudo}
                    data={this.state.Consultas}
                    keyExtractor={item => item.idConsulta}
                    renderItem={this.renderizaItem}
                    />
                </View>
            </View>
        );
    }

    renderizaItem = ({item}) => (
            <View style={styles.flatItemContainer}>
            <Text>{item.idPaciente}</Text>
            <Text>{item.dataHorario}</Text>
            <Text>{item.descricaoConsulta}</Text>
            <Text>{item.situacaoConsulta}</Text>
            </View>
    );
}



const styles = StyleSheet.create({
    tabNavigatorIconHome:{
        width: 25,
        height: 25,
        tintColor: "white"
    },

    main:{
        flex: 1,
        backgroundColor: "white",
        alignItems: "center",
    },

    mainHeaderRow:{
        flexDirection: "column",
        alignItems: "center",
    },

    mainHeaderImg: {
        width:99,
        height: 106,
        marginTop: -50,
        marginRight: -50,
        justifyContent: "center",
    },

    mainHeaderText:{
        fontSize: 35,
        letterSpacing: 20,
        color: "#2699FB",
        fontFamily: "Calibri"
    },

    mainHeaderLine:{
        width: 170,
        paddingTop: 10,
        borderBottomColor: "#999999",
        borderBottomWidth: 0.9
    },

    mainBody:{
        flex:4
    },

    mainBodyConteudo: {
        paddingTop: 30,
        paddingRight: 50,
        paddingLeft: 50
      },

      flatItemContainer: {
        flexDirection: "row",
        borderBottomWidth: 0.9,
        borderBottomColor: "gray",
        flex: 7,
        marginTop: 5
      },

      flatItemTitulo: {
        fontSize: 14,
        color: "#333",
        fontFamily: "OpenSans-Light"
      },

    });


export default Main
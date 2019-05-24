  import React, { Component } from "react";

  import { Text, Image, StyleSheet, View, AsyncStorage } from "react-native";
  
  import jwt from "jwt-decode";
  
  class Profile extends Component {
    static navigationOptions = {
      tabBarIcon: ({ tintColor }) => (
        <Image
          source={require("../assets/profile.png")}
          style={styles.iconeNavegacaoPerfil}
        />
      )
    };
  
    constructor(props) {
      super(props);
      this.state = { token: "", nome: "" };
    }
  
    _buscarDadosDoStorage = async () => {
      try {
        const value = await AsyncStorage.getItem("userToken");
        if (value !== null) {
          this.setState({ nome: jwt(value).Nome });
          this.setState({ token: value });
        }
      } catch (error) {}
    };
  
    componentDidMount() {
      this._buscarDadosDoStorage();
    }
  
  
      render(){
          return(
          <View style={styles.telaPerfil}>
                  <Image
                      source={require('../assets/profile.png')}
                      style={styles.imagemPerfil}
                  />
                  <Text style={styles.textoPerfil}>{"Perfil do parceiro"}</Text>

            <View>
              <Text style={styles.textoPerfildetalhes}>{this.state.token}</Text>
              <Text style={styles.textoPerfildetalhes}>{this.state.nome}</Text>
            </View>
            </View>
      );
    }
  }
  
  const styles = StyleSheet.create({
    iconeNavegacaoPerfil:{
          width: 25,
          height: 25,
          tintColor: "white"
      },
  
      telaPerfil: {
        display: "flex",
        flexDirection: "column",
        alignItems: "center",
        alignContent: "space-around",
        padding: 40
    },

    textoPerfil: {
        fontSize: 40,
        fontFamily: "OpenSans",
        color: "#2699FB",
        letterSpacing: 4
    },

    imagemPerfil: {
        height: 140,
        width: 132,
        margin: 40,
        tintColor: "#2699FB"
    },

    textoPerfildetalhes: {
        fontSize: 18,
        fontFamily: "OpenSans",
        color: "#2699FB",
        letterSpacing: 4
    },
  
  });
  
  export default Profile;
import React, { Component } from "react";
import {
  StyleSheet,
  View,
  Text,
  Image,
  ImageBackground,
  TextInput,
  TouchableOpacity,
} from "react-native";

import {AsyncStorage} from 'react-native';

import api from "../services/api";

class SignIn extends Component {
  static navigationOptions = {
    header: null
  };

  constructor(props) {
    super(props);
    this.state = { email: "", senha: "" };
  }

  _realizarLogin = async () => {

    const resposta = await api.post("/login", {
      email: this.state.email,
      senha: this.state.senha
    });

    const token = resposta.data.token;
    await AsyncStorage.setItem("userToken", token);
    this.props.navigation.navigate("MainNavigator");
  };

  render() {
    return (

      <View style={styles.telaLogin}>

        <Image
          source={require('../assets/icon-login.png')}
          style={styles.imagemLogin}
        />
        <Text style={styles.textoLogin}>{"Medical Group"}</Text>

        <TextInput
          style={styles.inputLogin}
          placeholder="parceiro@med.com"
          onChangeText={email => this.setState({ email })}
        />

        <TextInput
          style={styles.inputLogin}
          placeholder="******"
          secureTextEntry={true}
          onChangeText={senha => this.setState({ senha })}
          
        />

        <TouchableOpacity style={styles.botaoLogin}
          onPress={this._realizarLogin}>
          <Text style={styles.botaoLoginTexto}>Entrar</Text>
        </TouchableOpacity>

      </View>
    );
  }
}

const styles = StyleSheet.create({

  telaLogin: {
    display: "flex",
    flexDirection: "column",
    alignItems: "center",
    alignContent: "space-around",
    margin: 20,
    padding: 40
  },

  textoLogin: {
    fontSize: 40,
    fontFamily: "OpenSans",
    color: "#2699FB",
    letterSpacing: 4
  },

  imagemLogin: {
    height: 140,
    width: 132,
    margin: 40
  },

  botaoLogin: {
    height: 50,
    elevation: 3,
    width: 300,
    borderWidth: 1,
    borderColor: "#2699FB",
    backgroundColor: "#2699FB",
    justifyContent: "center",
    alignItems: "center",
    borderRadius: 10,
    margin: 20
  },

  botaoLoginTexto: {
    fontSize: 25,
    fontFamily: "OpenSans",
    color: "white",
  },

  inputLogin: {
    borderWidth: 2,
    borderColor: "#2699FB",
    width: 300,
    height: 50,
    fontSize: 25,
    fontFamily: "OpenSans",
    color: "#2699FB",
    borderRadius: 10,
    margin: 20,
  }
});

export default SignIn;
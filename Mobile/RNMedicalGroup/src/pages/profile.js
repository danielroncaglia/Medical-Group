import React, {Component} from "react";
import {Text, Image, View, StyleSheet} from "react-native";

class Profile extends Component {

    static navigationOptions = {
        tabBarIcon: ({tintColor}) => (
            <Image
                source={require("../assets/profile.png")}
                style={styles.tabNavigatorIconHome}
            />
        )
    };

    render(){
        return(
        <View style={styles.main}>
        <View style={styles.mainHeader}>
            <View style={styles.mainHeaderRow}>
                <Image
                    source={require('../assets/profile.png')}
                    style={styles.mainHeaderImg}
                />
                <Text style={styles.mainHeaderText}>{"Perfil do parceiro"}</Text>
            </View>
            </View>
            </View>
            );
    }
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
        justifyContent: "center"
    },

    mainHeaderRow:{
        flexDirection: "column",
        alignItems: "center",
    },

    mainHeaderImg: {
        width:99,
        height: 106,
        marginTop: 20,
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
});

export default Profile;


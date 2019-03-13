import React, {Component} from 'react';
import{
    StyleSheet,
    Text,
    View,
    StatusBar,
    Image,
    TextInput,
    TouchableOpacity
} from 'react-native';
import {Actions} from 'react-native-router-flux';
import firebase from 'firebase';
import ForgotPage from './ForgotPage';
import Search from './Search';
import RegisterPage from './RegisterPage';


class LoginPage extends Component{
       constructor(props){
           super(props);
           this.state={
             email:'',
             password:''
           };
      }
    
  submit() {
    firebase.auth().signInWithEmailAndPassword(this.state.email,this.state.password).then(function(user){
    Actions.search();
    }).catch(function(e){
    alert(e);
  })
  }

    render () {
         console.disableYellowBox=true; 
    return (
        <View style={styles.container}>

           <View style={styles.logoContainer}>
             <Image 
             style={styles.logo}
             source={{uri: 'http://aracpiyasa.com/r/g/arac-incele.png'}}/>
            </View>

          <TextInput style={styles.input}
             onChangeText={(email)=> this.setState({email})}
             placeholder="email"
             placeholderTextColor="#008ae6"
             returnKeyType="next"/>

          <TextInput style={styles.input}
             onChangeText={(password)=> this.setState({password})}
             placeholder="password"
             placeholderTextColor="#008ae6"
             returnKeyType="go"
             secureTextEntry={true}/>

          <Text
             style={styles.forgotpassword}
             onPress={()=>Actions.forgot()}>
             Forgot Password?
          </Text>

          <TouchableOpacity style={styles.buttonContainer}>
            <Text
              style={styles.buttonText}
              onPress={this.submit.bind(this)}>
              Log In
            </Text>
          </TouchableOpacity>

          <TouchableOpacity style={styles.buttonContainer}>
             <Text
              style={styles.buttonText}
              onPress={()=>Actions.register()}>
              Sign In
            </Text>
          </TouchableOpacity>  

        </View>
    );
};
}

const styles = StyleSheet.create({
    container: {
        flex:1,
        justifyContent: 'center',
        alignItems: 'center',
        backgroundColor: '#ffffff', 
    },

    logoContainer: {
       alignItems: 'center',
       flexGrow: 1,
       justifyContent: 'center'
    },
    
    logo: {
       width: 300,
       height: 300,
    },

    buttonContainer: {
      backgroundColor:'#3385ff',
      paddingVertical: 15,
      height: 10,
      width: 350,
      marginBottom:10,
      justifyContent: 'center'
  },

    buttonText: {
      textAlign: 'center',
      color: '#FFFFFF',
      fontWeight: '800'
  },
  
    forgotpassword: {
      justifyContent: 'center',
      color: '#666666',
      textDecorationLine:'underline',
      marginLeft:240,
      marginBottom:10,
  },

    input: {
       height: 40,
       width: 350,
       backgroundColor:'#e0e0eb',
       marginBottom:10,
       color: '#000000',
       paddingHorizontal: 10,
       textAlign: 'center',
  },

});

export default LoginPage;
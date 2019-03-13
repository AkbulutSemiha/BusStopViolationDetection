import React, {Component} from 'react';
import{
    StyleSheet,
    Text,
    View,
    Image,
    StatusBar,
    TextInput,
    TouchableOpacity,
    KeyboardAvoidingView
} from 'react-native';
import {Actions} from 'react-native-router-flux';
import firebase from 'firebase';

class ForgotPage extends Component{
       constructor(props){
          super(props);
          this.state={
             email:'',
             
       };
  }

  submit() {
    firebase.auth().sendPasswordResetEmail(this.state.email).then(function(user){
    alert("Check your e-mail!");
    }).catch(function(e){
    alert(e);
  })
  }
    render() {
           console.disableYellowBox=true; 
    return (
        <View style={styles.container}>
            <KeyboardAvoidingView style={styles.container} behavior="padding" enabled>
            <View style={styles.logoContainer}>            
             <Image 
             style={styles.logo}
             source={{uri: 'https://storage.googleapis.com/gs-images/gs-sell/lock-icon2.png'}}/>
            </View>

            <Text
               style={styles.textt} 
               onPress={this.submit.bind(this)}>
               Forgot Your Password?
             </Text>

             <Text
               style={styles.textt2} 
               onPress={this.submit.bind(this)}>
               Enter the e-mail address 
             </Text>
            <Text
               style={styles.textt2} 
               onPress={this.submit.bind(this)}>
               associated with your account
             </Text>
             <Text
               style={styles.textt2} 
               onPress={this.submit.bind(this)}>
               to reset your password.
             </Text>

            <TextInput 
               placeholder="Type Your E-mail"
               onChangeText={(email)=> this.setState({email})}
               placeholderTextColor="#666666"
               returnKeyType="next"
               style={styles.input}/>

            <TouchableOpacity style={styles.buttonContainer}>
             <Text
               style={styles.buttonText} 
               onPress={this.submit.bind(this)}>
               Send
             </Text>
            </TouchableOpacity>
            </KeyboardAvoidingView>
        </View>
    );
 };
}

const styles = StyleSheet.create({
    container: {
        flex:1,
        alignItems: 'center',
        backgroundColor: '#008ae6', 
        justifyContent: 'center',
    },

    textt: {
        textAlign: 'center',
        color: '#FFFFFF',
        fontWeight: '900',
        marginTop:15,
        fontStyle:'normal',
        fontSize:24 
    },

    textt2: {
        textAlign: 'center',
        color: '#FFFFFF',
        fontWeight: '900',
        marginTop:10,
        fontStyle:'italic',
        fontSize:15 
    },

    logoContainer: {
       alignItems: 'center',
       justifyContent: 'center',
       marginTop:60,
    },
    
    logo: {
       width: 80,
       height: 80,
    },

     buttonContainer: {
        backgroundColor:'#77b300',
        paddingVertical: 15,
        height: 50,
        width: 100,
        justifyContent: 'center',
        marginTop:80,
        borderRadius:50
    },

     buttonText: {
        textAlign: 'center',
        color: '#FFFFFF',
        fontWeight: '800'
    },

    input: {
        height:50,
        width: 350,
        backgroundColor:'#FFFFFF',
        color: '#000000',
        paddingHorizontal: 10,
        textAlign: 'center',
        marginTop: 120,
        borderTopLeftRadius:10,
        borderTopRightRadius:10,
        borderBottomLeftRadius:10,
        borderBottomRightRadius:10
    },
});

export default ForgotPage;
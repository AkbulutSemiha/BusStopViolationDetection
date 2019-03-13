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

class RegisterPage extends Component{
   constructor(props){
    super(props);
       this.state={
         email:'',
         password:''
       };
  }

  submit() {
    firebase.auth().createUserWithEmailAndPassword(this.state.email,this.state.password).then(function(user){
    user.sendEmailVerification();
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
               source={{uri: 'https://www.volunteersrus.org/wp-content/uploads/2016/11/kpi-icons-05-320x320.png'}}/>
              </View>

            <Text
               style={styles.textt} 
               onPress={this.submit.bind(this)}>
               Register Now!
             </Text>

             <Text
               style={styles.textt2} 
               onPress={this.submit.bind(this)}>
               Register Now to see your traffic fines online!
             </Text>

             <TextInput 
               placeholder="E-Mail"
               onChangeText={(email)=> this.setState({email})}
               placeholderTextColor="#666666"
               returnKeyType="next"
               style={styles.inputmail}/>

             <TextInput 
               placeholder="Password"
               onChangeText={(password)=> this.setState({password})}
               placeholderTextColor="#666666"
               returnKeyType="go"
               secureTextEntry={true}
               style={styles.inputpassword}/>

            <TouchableOpacity style={styles.buttonContainer}>
              <Text
               style={styles.buttonText}
               onPress={this.submit.bind(this)}>
               Register
              </Text>
            </TouchableOpacity>
          </KeyboardAvoidingView>
            </View>
    );
};
  }

const styles = StyleSheet.create({
     container: {
        justifyContent: 'center',
        alignItems: 'center',
        backgroundColor: '#77b300',
        justifyContent: 'center', 
    },

    textt: {
        textAlign: 'center',
        color: '#FFFFFF',
        fontWeight: '900',
        marginTop:20,
        fontStyle:'normal',
        fontSize:24 
    },

     textt2: {
        textAlign: 'center',
        color: '#FFFFFF',
        fontWeight: '900',
        marginTop:15,
        fontStyle:'italic',
        fontSize:15 
    },

     logoContainer: {
       alignItems: 'center',
       justifyContent: 'center',
       marginTop:80,
    },
    
    logo: {
       width: 80,
       height: 80,
    },

     buttonContainer: {
       backgroundColor:'#008ae6',
       paddingVertical: 15,
       height: 50,
       width: 100,
       marginTop:105,
       marginBottom: 50,
       justifyContent: 'center',
       borderRadius:50
    },

    buttonText: {
       textAlign: 'center',
       color: '#FFFFFF',
       fontWeight: '800'
    },

    inputmail: {
       height: 50,
       width: 350,
       backgroundColor:'#FFFFFF',
       marginTop:110,
       color: '#000000',
       paddingHorizontal: 10,
       textAlign: 'center',
       borderTopLeftRadius:10,
       borderTopRightRadius:10,
    },

    inputpassword: {
       height: 50,
       width: 350,
       backgroundColor:'#FFFFFF',
       color: '#000000',
       paddingHorizontal: 10,
       textAlign: 'center',
       borderBottomLeftRadius:10,
       borderBottomRightRadius:10
    },
});

export default RegisterPage;
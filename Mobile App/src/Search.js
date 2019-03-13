import React, { Component } from 'react';
import {
  AppRegistry,
  StyleSheet,
  Text,
  TextInput,
  View,
  ListView,
  Image,
  TouchableOpacity,
  ScrollView,
  KeyboardAvoidingView,
} from 'react-native';
import {Actions} from 'react-native-router-flux';
import ActionButton from 'react-native-circular-action-menu';
import firebase from 'firebase';
import Icon from 'react-native-vector-icons/MaterialIcons'

class Search extends Component {
  constructor(props){
        super(props)
        this.state={
         text_plate:'',
        }
    }
 
    searchData(){

           const {text_plate}=this.state;
           console.disableYellowBox = true;
      const ref=firebase.database().ref('tablocezali').child('-LCFiJ0HruUzdCA0Jn_B')

        ref.orderByChild('Plaka').equalTo(text_plate).on("value",function(snapshot){
          var plaka = snapshot.val();
          snapshot.forEach(function(data) {
          console.log(data.key);
        });
         if(snapshot.exists()){
              alert('There is a traffic fine for '+text_plate)}
            else{
              alert('There is NO traffic fine for '+text_plate)
            }
  });              
};

  render() { 
   
    return (
        
      <View style={{flex:1, backgroundColor: '#ffffff'}}>
        <KeyboardAvoidingView style={styles.container} behavior="padding" enabled>
            <View style={styles.logoContainer}>
              <Image 
               style={styles.logo}
               source={{uri: 'http://www.theonestopcarshop.co.uk/wp-content/uploads/2016/02/car-search.png'}}/>
              </View>
            <Text
               style={styles.textt}>
               Search Your Traffic Fines
             </Text>
             
            <TextInput 
               placeholder="Type Your Licence Plate"
               placeholderTextColor="#666666"
               returnKeyType="next"
               style={styles.input}
               onChangeText={(text_plate) => this.setState({text_plate})}
               returnKeyType="go"
               />

        <TouchableOpacity style={styles.buttonContainer}>
           <Text
             style={styles.buttonText}
             onPress={ ()=> this.searchData() }>
             SEARCH
           </Text>
        </TouchableOpacity>

    <ScrollView>
        <Image style={{width:350,height:350,margin:5}} source={{uri:this.state.dp}}/>
    </ScrollView>

    <ActionButton buttonColor='#77b300'>
          <ActionButton.Item buttonColor='#9b59b6' title="Profile" onPress={()=>{}}>
             <Icon name="person" style={styles.actionButtonIcon} />
          </ActionButton.Item>
          <ActionButton.Item buttonColor='#3498db' title="Settings" onPress={()=>{}}>
              <Icon name="build" style={styles.actionButtonIcon} />
          </ActionButton.Item>
          <ActionButton.Item buttonColor='#1abc9c' title="Log Out" onPress={()=>{}}>
              <Icon name="forward" style={styles.actionButtonIcon} />
          </ActionButton.Item>
        </ActionButton>
    </KeyboardAvoidingView>
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

    textt: {
        textAlign: 'center',
        color: '#ff8c1a',
        fontWeight: '900',
        marginTop:60,
        fontStyle:'normal',
        fontSize:24 
    },

     logoContainer: {
       alignItems: 'center',
       justifyContent: 'center',
       marginTop:40,
    },
    
    logo: {
       width: 100,
       height: 100,
    },
 
     buttonContainer: {
       backgroundColor:'#008ae6',
       paddingVertical: 15,
       height: 50,
       width: 420,
       marginTop:20,
       marginBottom: 50,
       justifyContent: 'center',
    },

    buttonText: {
       textAlign: 'center',
       color: '#FFFFFF',
       fontWeight: '800'
    },
       input: {
        height:50,
        width: 420,
        backgroundColor:'#FFFFFF',
        color: '#000000',
        paddingHorizontal: 10,
        textAlign: 'center',
        marginTop: 40,
    },

    actionButtonIcon: {
        fontSize: 20,
        height: 20,
        color: 'white',
  },

});

export default Search;

import { AppRegistry } from 'react-native';
import App from './src/App';

import firebase from 'firebase';
 var config = {
    //your firebase connection
  };
  firebase.initializeApp(config);

AppRegistry.registerComponent('tasarim', () =>App);

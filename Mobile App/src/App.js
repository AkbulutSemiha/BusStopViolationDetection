import React, {Component} from 'react';
import {
    StyleSheet,
    Text,
    View
} from 'react-native';
import {Router,Scene} from 'react-native-router-flux';

import Search from './Search';
import ForgotPage from './ForgotPage';
import LoginPage from './LoginPage';
import RegisterPage from './RegisterPage';

class App extends Component {
    render () {
        return (

         <Router>
             <Scene key="root">

                   <Scene 
                  key="forgot"
                  component={ForgotPage}
                 />

                 <Scene 
                 key="login"
                 component={LoginPage}
                 initial
                 />
                  
                  <Scene 
                  key="register"
                  component={RegisterPage}
                  />

                  <Scene 
                  key="search"
                  component={Search}
                 />

             </Scene>
         </Router>
        );
    }
};

export default App;
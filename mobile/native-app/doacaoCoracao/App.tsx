import 'react-native-gesture-handler';

import React from 'react';
import SwitchLogin from './src/pages/SwitchLogin';
import { NavigationContainer } from '@react-navigation/native';
import { createStackNavigator } from '@react-navigation/stack';
import { Header } from 'react-native/Libraries/NewAppScreen';
import LoginUser from './src/pages/LoginUser';

const Stack = createStackNavigator();
const App = () => {
  return (
    <NavigationContainer>
      <Stack.Navigator>
        <Stack.Screen name="SwitchLogin" component={SwitchLogin} options={{ headerShown: false }} />
        <Stack.Screen name="LoginUser" component={LoginUser}
          options={{
            title: "",
            headerTintColor: '#C4284D',
            headerStyle: { backgroundColor: '#fff', elevation:0 }
          }} />
      </Stack.Navigator>
    </NavigationContainer>
  );
};

export default App;

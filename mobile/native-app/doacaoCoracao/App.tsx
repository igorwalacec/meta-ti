import 'react-native-gesture-handler';

import React from 'react';
import { View, StatusBar } from 'react-native';
import { NavigationContainer } from '@react-navigation/native';
import AppProvider from './src/hooks';
import Routes from './src/routes';


const App: React.FC = () => (
  <NavigationContainer>
    <AppProvider>
      <View style={{ flex: 1, backgroundColor: '#FFF' }}>
        <Routes />
      </View>
    </AppProvider>
  </NavigationContainer>
);

export default App;

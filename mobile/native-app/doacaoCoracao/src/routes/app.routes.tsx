import React from 'react';
import { createStackNavigator } from '@react-navigation/stack';
import Home from '../pages/_Doador/Home';

const App = createStackNavigator();

const AuthRoutes: React.FC = () => (
    <App.Navigator
        screenOptions={{
            // headerShown: false,            
        }}
    >
        <App.Screen name="Home" component={Home} />
    </App.Navigator>
);

export default AuthRoutes;

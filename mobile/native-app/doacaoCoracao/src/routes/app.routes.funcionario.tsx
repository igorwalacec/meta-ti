import React from 'react';
import { createStackNavigator } from '@react-navigation/stack'; 
import HomeFuncionario from '../pages/_Funcionario/HomeFuncionario';

const App = createStackNavigator();

const AuthRoutes: React.FC = () => (
    <App.Navigator
        screenOptions={{
            // headerShown: false,            
        }}
    >
        <App.Screen name="Home" component={HomeFuncionario} />
    </App.Navigator>
);

export default AuthRoutes;

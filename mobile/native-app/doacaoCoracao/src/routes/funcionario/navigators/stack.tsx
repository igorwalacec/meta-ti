import React from 'react';
import { createStackNavigator } from '@react-navigation/stack';
import Hemocentro from '../../../pages/_Funcionario/Hemocentro';
import EstoqueSanguineo from '../../../pages/_Funcionario/AtualizarEstoqueSanguineo';

const App = createStackNavigator();

export const MainStackNavigator: React.FC = () => (
    <App.Navigator
        screenOptions={{
            headerTintColor: '#C4284D',
            headerStyle: { backgroundColor: '#fff', elevation: 0 }
        }}
    >
        <App.Screen name="Perfil" component={Hemocentro} />
        <App.Screen name="EstoqueSanguineo" options={{ title: "Estoque Sanguíneo" }} component={EstoqueSanguineo} />
    </App.Navigator>
);
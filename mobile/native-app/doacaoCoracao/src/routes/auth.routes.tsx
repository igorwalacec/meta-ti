import React from 'react';
import { createStackNavigator } from '@react-navigation/stack';
import SwitchLogin from '../pages/SwitchLogin';
import LoginUser from '../pages/LoginUser';
import CadastroUsuario from '../pages/CadastroUsuario';
import CadastroFuncionario from '../pages/CadastroFuncionario';
import LoginFuncionario from '../pages/LoginFuncionario';
import CadastroHemocentro from '../pages/CadastroHemocentro/ParteUm';

const Auth = createStackNavigator();

const AuthRoutes: React.FC = () => (
    <Auth.Navigator>
        <Auth.Screen name="SwitchLogin" component={SwitchLogin} options={{ headerShown: false }} />
        <Auth.Screen name="CadastroUsuario" component={CadastroUsuario} options={{
            title: "Cadastro Doador",
            headerTintColor: '#C4284D',
            headerStyle: { backgroundColor: '#fff', elevation: 0 }
        }} />
        <Auth.Screen name="CadastroFuncionario" component={CadastroFuncionario} options={{
            title: "Cadastro Funcionário",
            headerTintColor: '#C4284D',
            headerStyle: { backgroundColor: '#fff', elevation: 0 }
        }} />
        <Auth.Screen name="CadastroHemocentro" component={CadastroHemocentro} options={{
            title: "Cadastro Hemocentro",
            headerTintColor: '#C4284D',
            headerStyle: { backgroundColor: '#fff', elevation: 0 }
        }} />
        <Auth.Screen name="LoginUser" component={LoginUser}
            options={{
                title: "",
                headerTintColor: '#C4284D',
                headerStyle: { backgroundColor: '#fff', elevation: 0 }
            }} />
        <Auth.Screen name="LoginFuncionario" component={LoginFuncionario}
            options={{
                title: "",
                headerTintColor: '#C4284D',
                headerStyle: { backgroundColor: '#fff', elevation: 0 }
            }} />
    </Auth.Navigator>
);

export default AuthRoutes;

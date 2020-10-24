import React from 'react';
import { createStackNavigator } from '@react-navigation/stack';
import SwitchLogin from '../pages/SwitchLogin';
import LoginUser from '../pages/LoginUser';
import CadastroUsuario from '../pages/CadastroUsuario';

const Auth = createStackNavigator();

const AuthRoutes: React.FC = () => (
    <Auth.Navigator>
        <Auth.Screen name="SwitchLogin" component={SwitchLogin} options={{ headerShown: false }} />
        <Auth.Screen name="CadastroUsuario" component={CadastroUsuario} options={{
            title: "",
            headerTintColor: '#C4284D',
            headerStyle: { backgroundColor: '#fff', elevation: 0 }
        }} />
        <Auth.Screen name="LoginUser" component={LoginUser}
            options={{
                title: "",
                headerTintColor: '#C4284D',
                headerStyle: { backgroundColor: '#fff', elevation: 0 }
            }} />
    </Auth.Navigator>
);

export default AuthRoutes;

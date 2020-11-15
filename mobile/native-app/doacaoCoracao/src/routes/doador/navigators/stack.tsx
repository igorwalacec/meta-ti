import React from 'react';
import { createStackNavigator } from '@react-navigation/stack';
import Feed from '../../../pages/_Doador/Feed';
import Hemocentro from '../../../pages/_Doador/Hemocentros';
import MapaHemocentros from '../../../pages/_Doador/MapaHemocentros';
import Notificacoes from '../../../pages/_Doador/Notificacoes';
import Perfil from '../../../pages/_Doador/Perfil';

const App = createStackNavigator();

export const MainStackNavigator: React.FC = () => (
    <App.Navigator
        screenOptions={{
            // headerShown: false,            
        }}
    >
        <App.Screen name="Feed" component={Feed} />
        <App.Screen name="HemocentroDetalhes" component={Hemocentro} />
    </App.Navigator>
);

export const HemocentroMapaNavigator: React.FC = () => (
    <App.Navigator
        screenOptions={{
            // headerShown: false,            
        }}
    >
        <App.Screen name="Mapa" component={MapaHemocentros} />
    </App.Navigator>
);

export const NotificacoesNavigator: React.FC = () => (
    <App.Navigator
        screenOptions={{
            // headerShown: false,            
        }}
    >
        <App.Screen name="Notificacoes" component={Notificacoes} />
    </App.Navigator>
);


export const PerfilNavigator: React.FC = () => (
    <App.Navigator
        screenOptions={{
            // headerShown: false,            
        }}
    >
        <App.Screen name="Perfil" component={Perfil} />
    </App.Navigator>
);

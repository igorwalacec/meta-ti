
import React from 'react';
import { createBottomTabNavigator } from "@react-navigation/bottom-tabs";
import { MainStackNavigator, HemocentroMapaNavigator, NotificacoesNavigator, PerfilNavigator } from './stack';
import TabBarCustom from './custom/tab/tabContent';

const Tab = createBottomTabNavigator();

const BottomTabNavigator = () => {
    return (
        <Tab.Navigator tabBar={props => <TabBarCustom {...props} />}>
            <Tab.Screen name="Feed" component={MainStackNavigator} />
            <Tab.Screen name="MapaHemocentros" component={HemocentroMapaNavigator} />
            <Tab.Screen name="Notificacoes" component={NotificacoesNavigator} />
            <Tab.Screen name="Perfil" component={PerfilNavigator} />
        </Tab.Navigator>
    );
};

export default BottomTabNavigator;
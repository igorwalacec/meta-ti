import React from 'react';
import { createStackNavigator } from '@react-navigation/stack';
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';
import DrawerNavigator from './navigators/drawer';

const App = createStackNavigator();
const Tab = createBottomTabNavigator();

const AuthRoutes: React.FC = () => (
    <DrawerNavigator />
);

export default AuthRoutes;

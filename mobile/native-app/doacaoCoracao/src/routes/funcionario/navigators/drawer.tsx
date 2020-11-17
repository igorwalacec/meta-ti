import React from "react";

import { createDrawerNavigator } from '@react-navigation/drawer';

import DrawerContent from "./custom/drawerContent";
import { MainStackNavigator } from "./stack";
const Drawer = createDrawerNavigator();

const DrawerNavigator = () => {
  return (
    <Drawer.Navigator drawerContent={props => <DrawerContent {...props} />}>
      <Drawer.Screen name="Home" component={MainStackNavigator} />
    </Drawer.Navigator>
  );
}

export default DrawerNavigator;
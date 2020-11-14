import React from "react";

import { createDrawerNavigator } from '@react-navigation/drawer';
import { HemocentroMapaNavigator } from "./stack";
import TabNavigator from './tab';
import DrawerContent from "./custom/drawerContent";
const Drawer = createDrawerNavigator();

const DrawerNavigator = () => {
  return (
    <Drawer.Navigator drawerContent={props => <DrawerContent {...props} />}>
      <Drawer.Screen name="Feed" component={TabNavigator} />
      <Drawer.Screen name="Mapa" component={HemocentroMapaNavigator} />
    </Drawer.Navigator>
  );
}

export default DrawerNavigator;
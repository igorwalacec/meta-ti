import React from "react";

import { NavigationContainer } from "@react-navigation/native";
import { createStackNavigator } from "@react-navigation/stack";
import Login from "./pages/Login";
import Hospital from "./pages/Hospital";

const AppStack = createStackNavigator();

export default function Routes() {
  return (
    <NavigationContainer>
      <AppStack.Navigator>
        <AppStack.Screen name="Login" component={Login} />
        <AppStack.Screen name="Hospital" component={Hospital} />
      </AppStack.Navigator>
    </NavigationContainer>
  );
}

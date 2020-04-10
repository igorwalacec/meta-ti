import React, { useState } from "react";
import { StyleSheet, Text, View, TextInput, Button } from "react-native";
import { useNavigation } from "@react-navigation/native";

import api from "../../services/api";

export default function Login() {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const navigation = useNavigation();

  async function SignIn() {
    try {
      const response = await api.post(
        `user/gettoken?email=${encodeURI(email)}&password=${password}`
      );
      const { token } = response.data;

      navigation.navigate("Hospital", token);
    } catch (error) {
      alert("Usuário não encontrado");
    }
  }

  return (
    <View style={styles.container}>
      <Text>Email:</Text>
      <TextInput
        style={{
          height: 40,
          width: "80%",
          borderColor: "gray",
          borderWidth: 1,
        }}
        onChangeText={(text) => setEmail(text)}
        value={email}
      />
      <Text>Senha:</Text>
      <TextInput
        style={{
          height: 40,
          width: "80%",
          borderColor: "gray",
          borderWidth: 1,
        }}
        secureTextEntry={true}
        onChangeText={(text) => setPassword(text)}
        value={password}
      />
      <Button title="Logar" onPress={SignIn} />
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: "#fff",
    alignItems: "center",
    justifyContent: "center",
  },
});

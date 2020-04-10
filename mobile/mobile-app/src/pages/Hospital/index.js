import React, { useEffect, useState } from "react";
import { useNavigation, useRoute } from "@react-navigation/native";
import { View, FlatList, Text } from "react-native";

import api from "../../services/api";

export default function Hospital() {
  const [hospitals, setHospitals] = useState([]);
  const [loading, setLoading] = useState(false);
  const navigation = useNavigation();
  const route = useRoute();

  const token = route.params.token;

  async function loadHospitals() {
    if (loading) {
      return;
    }

    setLoading(true);
    const response = await api.get("hospital");

    setHospitals([...hospitals, ...response.data]);
    setLoading(false);
  }

  useEffect(() => {
    loadHospitals();
  }, []);

  return (
    <View>
      <FlatList
        data={hospitals}
        keyExtractor={(hospital) => String(hospital.id)}
        showsVerticalScrollIndicator={false}
        onEndReached={loadHospitals}
        onEndReachedThreshold={0.2}
        renderItem={({ item: hospital }) => (
          <View>
            <Text>Nome Hospital:</Text>
            <Text>{hospital.name}</Text>
          </View>
        )}
      />
    </View>
  );
}

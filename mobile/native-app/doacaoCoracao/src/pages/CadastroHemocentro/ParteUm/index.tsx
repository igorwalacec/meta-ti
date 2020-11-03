import React, { useCallback, useEffect, useRef, useState } from 'react';
import { ActivityIndicator, Alert, StyleSheet, Text, View } from 'react-native';
import { Container } from './styles';

import MapView, { Marker } from 'react-native-maps';
import Geolocation from '@react-native-community/geolocation';
import { Form } from '@unform/mobile';
import { FormHandles } from '@unform/core';
import Input from '../../../components/Input';
import geoApi from '../../../services/geoapi';
import { KEY_GEO_API } from '@env';
import { ResponseGeoApi } from '../../../@types/ResponseGeoApi';
import FloatButton from '../../../components/FloatButton';
import { useNavigation } from '@react-navigation/native';

interface SubmitForm {
    endereco: string;
}
interface MapProps {
    latitude: number,
    longitude: number,
    latitudeDelta: number,
    longitudeDelta: number,
}

interface EnderecoProps {
    endereco: string;
    numero: string;
    latitude: number;
    longitude: number;
}


const CadastroHemocentroParteUm: React.FC = () => {
    const formRef = useRef<FormHandles>(null);
    const [position, setPosition] = useState<MapProps>({
        latitude: 0,
        longitude: 0,
        latitudeDelta: 0.04,
        longitudeDelta: 0.04,
    });

    const [enderecoProp, setEnderecoProp] = useState<EnderecoProps>({} as EnderecoProps);
    const [loading, setLoading] = useState(true);

    const navigation = useNavigation();
    const IrParteDois = useCallback(() => {
        Alert.alert("Aviso",
            "Essa será sua posição no mapa",
            [
                {
                    text: "Cancelar"
                }, {
                    text: "OK",
                    onPress: () => {
                        navigation.navigate("CadastroHemocentroParteDois", enderecoProp);
                    }
                }
            ]);
    }, [navigation, enderecoProp]);

    const buscarEndereco = useCallback(async (data: SubmitForm) => {
        setLoading(true);
        const { endereco } = data;
        const enderecoEncode = encodeURIComponent(endereco);

        geoApi.get<ResponseGeoApi>(`search?text=${enderecoEncode}&apikey=${KEY_GEO_API}`)
            .then((response) => {
                const longitudeResponse = response.data.features[0].geometry.coordinates[0];
                const latitudeResponse = response.data.features[0].geometry.coordinates[1];

                setEnderecoProp({
                    endereco: response.data.features[0].properties.street,
                    numero: response.data.features[0].properties.housenumber,
                    latitude: latitudeResponse,
                    longitude: longitudeResponse
                });
                setPosition({
                    latitudeDelta: 0.0922,
                    longitudeDelta: 0.0421,
                    latitude: latitudeResponse,
                    longitude: longitudeResponse,
                });
                setLoading(false);
            })
            .catch((error) => {
                Alert.alert("Digite seu endereço com mais detalhes");
                setLoading(false);
            });
    }, []);

    useEffect(() => {
        async function getLocationUser() {
            await Geolocation.getCurrentPosition(
                position => {
                    const { latitude, longitude } = position.coords;
                    setPosition({
                        latitudeDelta: 0.0922,
                        longitudeDelta: 0.0421,
                        latitude: latitude,
                        longitude: longitude
                    });
                    setLoading(false);
                },
                error => {
                    setPosition({
                        latitudeDelta: 0.0922,
                        longitudeDelta: 0.0421,
                        latitude: 0,
                        longitude: 0
                    });
                    setLoading(true);
                },
            );
        };
        getLocationUser();
    }, [])

    if (loading) {
        return (<View style={{ flex: 1, justifyContent: 'center', alignItems: 'center' }}>
            <ActivityIndicator size="large" color="#999" />
        </View>);
    } else {
        return (
            <>
                <Container>
                    <MapView
                        style={styles.mapStyle}
                        initialRegion={position}
                        region={position}
                        showsUserLocation={true}
                        followsUserLocation={true}
                    >
                        <Marker
                            draggable
                            onDragEnd={(e) => {
                                setPosition({
                                    ...position,
                                    latitude: e.nativeEvent.coordinate.latitude,
                                    longitude: e.nativeEvent.coordinate.longitude,
                                })
                            }}
                            coordinate={position}
                            title={`${enderecoProp.endereco},${enderecoProp.numero}`}
                            description={'Este será o local do seu hemocentro!'}
                        />
                    </MapView>
                </Container>
                <Form ref={formRef} onSubmit={buscarEndereco}>
                    <Input
                        name="endereco"
                        icon="map-pin"
                        returnKeyType="send"
                        onSubmitEditing={() => {
                            formRef.current?.submitForm();
                        }}
                    />
                </Form>
                <FloatButton position={{
                    bottom: 80,
                    right: 10,
                    top: 0,
                    left: 0
                }} icon="arrow-right"
                    onPress={IrParteDois} />
            </>
        );
    }

}
export default CadastroHemocentroParteUm;

const styles = StyleSheet.create({
    mapStyle: {
        position: 'absolute',
        top: 0,
        left: 0,
        right: 0,
        bottom: 0,
    },
});
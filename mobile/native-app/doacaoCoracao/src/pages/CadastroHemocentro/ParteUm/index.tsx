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

interface SubmitForm {
    endereco: string;
}
interface MapProps {
    latitude: number,
    longitude: number,
    latitudeDelta: 0.04,
    longitudeDelta: 0.05,
}
const CadastroHemocentro: React.FC = () => {
    const formRef = useRef<FormHandles>(null);
    const [position, setPosition] = useState({
        latitude: 0,
        longitude: 0,
        latitudeDelta: 0.0922,
        longitudeDelta: 0.0421,
    });
    const [loading, setLoading] = useState(true);

    const buscarEndereco = useCallback(async (data: SubmitForm) => {
        const { endereco } = data;
        const enderecoEncode = encodeURIComponent(endereco);
        const response = await geoApi.get<ResponseGeoApi>(`search?text=${enderecoEncode}&apikey=${KEY_GEO_API}`);

        const longitudeResponse = response.data.features[0].geometry.coordinates[0];
        const latitudeResponse = response.data.features[0].geometry.coordinates[1];

        setPosition({
            latitudeDelta: 0.0922,
            longitudeDelta: 0.0421,
            latitude: latitudeResponse,
            longitude: longitudeResponse,
        });

    }, [position, setPosition]);
    // "nome": "string",
    // "cnpj": "string",
    // "aprovado": true,
    // "ativo": true,
    // "dataCriacao": "2020-10-28T03:30:56.314Z",
    // "dataAlteracao": "2020-10-28T03:30:56.314Z",
    // "logradouro": "string",
    // "complemento": "string",
    // "numero": "string",
    // "cep": "string",
    // "latitude": "string",
    // "longitude": "string",
    // "idCidade": 0
    useEffect(() => {
        Geolocation.getCurrentPosition(info => {
            const { coords } = info;
            setPosition({
                latitudeDelta: 0.0922,
                longitudeDelta: 0.0421,
                latitude: coords.latitude,
                longitude: coords.longitude
            })
            setLoading(false);
        });
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
                        customMapStyle={mapStyle}>
                        <Marker
                            draggable
                            coordinate={position}
                            onDragEnd={
                                (e) => Alert.alert(JSON.stringify(e.nativeEvent.coordinate))
                            }
                            title={'Test Marker'}
                            description={'This is a description of the marker'}
                        />
                    </MapView>
                </Container>
                <Form ref={formRef} onSubmit={buscarEndereco}>
                    <Input
                        name="endereco"
                        icon="mail"
                        returnKeyType="send"
                        onSubmitEditing={() => {
                            formRef.current?.submitForm();
                        }}
                    />
                </Form>
            </>
        );
    }

}
export default CadastroHemocentro;

const mapStyle = [
    { elementType: 'geometry', stylers: [{ color: '#242f3e' }] },
    { elementType: 'labels.text.fill', stylers: [{ color: '#746855' }] },
    { elementType: 'labels.text.stroke', stylers: [{ color: '#242f3e' }] },
    {
        featureType: 'administrative.locality',
        elementType: 'labels.text.fill',
        stylers: [{ color: '#d59563' }],
    },
    {
        featureType: 'poi',
        elementType: 'labels.text.fill',
        stylers: [{ color: '#d59563' }],
    },
    {
        featureType: 'poi.park',
        elementType: 'geometry',
        stylers: [{ color: '#263c3f' }],
    },
    {
        featureType: 'poi.park',
        elementType: 'labels.text.fill',
        stylers: [{ color: '#6b9a76' }],
    },
    {
        featureType: 'road',
        elementType: 'geometry',
        stylers: [{ color: '#38414e' }],
    },
    {
        featureType: 'road',
        elementType: 'geometry.stroke',
        stylers: [{ color: '#212a37' }],
    },
    {
        featureType: 'road',
        elementType: 'labels.text.fill',
        stylers: [{ color: '#9ca5b3' }],
    },
    {
        featureType: 'road.highway',
        elementType: 'geometry',
        stylers: [{ color: '#746855' }],
    },
    {
        featureType: 'road.highway',
        elementType: 'geometry.stroke',
        stylers: [{ color: '#1f2835' }],
    },
    {
        featureType: 'road.highway',
        elementType: 'labels.text.fill',
        stylers: [{ color: '#f3d19c' }],
    },
    {
        featureType: 'transit',
        elementType: 'geometry',
        stylers: [{ color: '#2f3948' }],
    },
    {
        featureType: 'transit.station',
        elementType: 'labels.text.fill',
        stylers: [{ color: '#d59563' }],
    },
    {
        featureType: 'water',
        elementType: 'geometry',
        stylers: [{ color: '#17263c' }],
    },
    {
        featureType: 'water',
        elementType: 'labels.text.fill',
        stylers: [{ color: '#515c6d' }],
    },
    {
        featureType: 'water',
        elementType: 'labels.text.stroke',
        stylers: [{ color: '#17263c' }],
    },
];
const styles = StyleSheet.create({
    mapStyle: {
        position: 'absolute',
        top: 0,
        left: 0,
        right: 0,
        bottom: 0,
    },
});
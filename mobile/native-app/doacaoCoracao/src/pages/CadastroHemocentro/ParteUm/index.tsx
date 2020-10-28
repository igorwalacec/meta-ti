import React, { useEffect, useState } from 'react';
import { Alert, StyleSheet, Text } from 'react-native';
import { Container } from './styles';

import MapView, { Marker } from 'react-native-maps';
import Geolocation from '@react-native-community/geolocation';

const CadastroHemocentro: React.FC = () => {
    const [minhaLocalizacao, setMinhaLocalizacao] = useState({})
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

            console.log(coords);

            setMinhaLocalizacao({
                latitude: coords.latitude,
                longitude: coords.longitude,
                latitudeDelta: 0.04,
                longitudeDelta: 0.05,
            })
        });
    }, [])

    return (
        <Container>
            <MapView
                style={styles.mapStyle}
                initialRegion={minhaLocalizacao}
                customMapStyle={mapStyle}>
                <Marker
                    draggable
                    coordinate={{
                        latitude: -23.489636,
                        longitude: -46.598482,
                    }}
                    onDragEnd={
                        (e) => Alert.alert(JSON.stringify(e.nativeEvent.coordinate))
                    }
                    title={'Test Marker'}
                    description={'This is a description of the marker'}
                />
            </MapView>
        </Container>
    );
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
    container: {
        position: 'absolute',
        top: 0,
        left: 0,
        right: 0,
        bottom: 0,
        alignItems: 'center',
        justifyContent: 'flex-end',
    },
    mapStyle: {
        position: 'absolute',
        top: 0,
        left: 0,
        right: 0,
        bottom: 0,
    },
});
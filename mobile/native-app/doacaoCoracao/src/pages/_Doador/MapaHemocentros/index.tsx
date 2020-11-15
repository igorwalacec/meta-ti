import React, { useCallback, useEffect, useRef, useState } from 'react';
import { ActivityIndicator, Alert, StyleSheet, Text, View } from 'react-native';
import { Container, HemocentroBody, HemocentroContainer, HemocentroDetalhes, HemocentroEndereco, HemocentroHeader, HemocentroTitulo } from './styles';

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
import api from '../../../services/api';
import { GenericCommandResult } from '../../../@types/GenericCommandResult';
import Hemocentro from '../Hemocentros';
import Icon from 'react-native-vector-icons/Feather';
import { useIsFocused } from "@react-navigation/native";

interface MapProps {
    latitude: number,
    longitude: number,
    latitudeDelta: number,
    longitudeDelta: number,
}

interface HemocentroResponse {
    id: string;
    nome: string;
    endereco: {
        id: number;
        logradouro: string;
        numero: string;
        latitude: string;
        longitude: string;
    }
}


const MapaHemocentros: React.FC = () => {
    const [position, setPosition] = useState<MapProps>({
        latitude: 0,
        longitude: 0,
        latitudeDelta: 0.04,
        longitudeDelta: 0.04,
    });

    const [hemocentros, setHemocentros] = useState<HemocentroResponse[]>([] as HemocentroResponse[]);

    const [loading, setLoading] = useState(true);

    const [hemocentro, setHemocentro] = useState({} as HemocentroResponse);

    const navigation = useNavigation();

    const isFocused = useIsFocused();


    const ObterHemocentros = async () => {
        const response = await api.get<GenericCommandResult<HemocentroResponse[]>>("/hemocentro/obter-todos");

        setHemocentros([...response.data.data]);
    }

    const getLocationUser = async () => {
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
    useEffect(() => {
        if (isFocused) {
            getLocationUser();
            ObterHemocentros();
        }
    }, [isFocused])

    const selecionarHemocentro = useCallback(async (event) => {
        const idHemocentro = event.nativeEvent.id;

        const response = await api.get<GenericCommandResult<HemocentroResponse[]>>("/hemocentro/obter-todos");
        const hemocentroSelecionado = response.data.data.find(x => x.id == idHemocentro);
        if (hemocentroSelecionado) {
            setHemocentro(hemocentroSelecionado);
        }
    }, [hemocentro])

    const detalheHemocentro = () => {
        if (hemocentro.id) {
            return (
                <HemocentroContainer>
                    <HemocentroHeader>
                        <HemocentroTitulo>{hemocentro.nome}</HemocentroTitulo>
                    </HemocentroHeader>
                    <HemocentroBody>
                        <HemocentroEndereco>
                            {`${hemocentro.endereco.logradouro}, ${hemocentro.endereco.numero}`}
                        </HemocentroEndereco>
                        <HemocentroDetalhes onPress={() => {
                            navigation.navigate("HemocentroDetalhes", {
                                id: hemocentro.id
                            })
                        }}>
                            <Icon name="arrow-right" size={30} color='#C4284D' />
                        </HemocentroDetalhes>
                    </HemocentroBody>
                </HemocentroContainer>
            );
        }
    }

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
                        {
                            hemocentros.map((hemocentro) => {
                                const hemocentroPosition = {
                                    latitude: parseFloat(hemocentro.endereco.latitude),
                                    longitude: parseFloat(hemocentro.endereco.longitude)
                                };
                                return (
                                    <Marker
                                        key={hemocentro.id}
                                        identifier={hemocentro.id}
                                        coordinate={hemocentroPosition}
                                        onPress={selecionarHemocentro}
                                    >
                                    </Marker>);
                            })
                        }
                    </MapView>
                </Container>
                {
                    detalheHemocentro()
                }
            </>
        );
    }

}
export default MapaHemocentros;

const styles = StyleSheet.create({
    mapStyle: {
        position: 'absolute',
        top: 0,
        left: 0,
        right: 0,
        bottom: 0,
    },
});

import AsyncStorage from '@react-native-community/async-storage';
import React, { useEffect, useState } from 'react';
import { Text, View } from 'react-native';
import { FlatList } from 'react-native-gesture-handler';
import { GenericCommandResult } from '../../../@types/GenericCommandResult';
import { Collapse, CollapseHeader, CollapseBody } from 'accordion-collapse-react-native';
import api from '../../../services/api';
import {
    ContainerNotificacaoSemHemocentro,
    Container,
    ContainerNotificacao,
    TituloNotificacao,
    DescricaoNotificacao,
    BotaoDetalheHemocentro,
    TituloSemNotificacao,
    DescricaoSemNotificacao
} from './styles';
import Icon from 'react-native-vector-icons/Feather';
import { useIsFocused, useNavigation } from '@react-navigation/native';
import FloatButton from '../../../components/FloatButton';

interface CampanhasResponse {
    id: number,
    titulo: string,
    descricao: string,
    hemocentro: {
        id: string,
        nome: string,
        endereco: {
            logradouro: string,
            numero: string
        }
    }
}
const Campanha: React.FC = () => {
    const [loading, setLoading] = useState(false);
    const [campanhas, setCampanhas] = useState([] as CampanhasResponse[]);

    const navigation = useNavigation();

    const isFocused = useIsFocused();

    async function ObterCampanhas() {
        setLoading(true);

        const token = await AsyncStorage.getItem('@MetaTi:token');

        const response = await api.get<GenericCommandResult<CampanhasResponse[]>>("/campanha/obter-campanha-por-hemocentro", {
            headers: {
                'Authorization': `Bearer ${token}`
            }
        });

        await setCampanhas([...response.data.data])

        setLoading(false);
    }

    useEffect(() => {
        if (isFocused) {
            ObterCampanhas();
        }
    }, [isFocused]);

    const renderNotification = ({ item: campanha }) => {
        return (
            <View key={campanha.id} >
                <ContainerNotificacaoSemHemocentro>
                    <CollapseHeader style={{ padding: 10 }}>
                        <TituloSemNotificacao>{campanha.titulo}</TituloSemNotificacao>
                    </CollapseHeader>
                    <CollapseBody style={{ flexDirection: 'row', alignItems: 'center', backgroundColor: '#FFEEEC', padding: 10 }}>
                        <DescricaoSemNotificacao>{campanha.descricao}</DescricaoSemNotificacao>
                    </CollapseBody>
                </ContainerNotificacaoSemHemocentro>
            </View>
        );
    }
    return (
        <>
            <Container>
                <FlatList
                    data={campanhas}
                    renderItem={renderNotification}
                    onRefresh={ObterCampanhas}
                    refreshing={loading}
                    keyExtractor={item => item.id.toString()}
                />
                <FloatButton
                    icon="plus"
                    position={{
                        top: 0,
                        bottom: 20,
                        left: 0,
                        right: 20
                    }}
                    onPress={() => {
                        navigation.navigate("CriarCampanha");
                    }}
                />
            </Container>
        </>
    );
}

export default Campanha;
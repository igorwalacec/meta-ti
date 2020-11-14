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

interface NotificacaoResponse {
    id: string;
    titulo: string;
    descricao: string;
    hemocentro: {
        id: string;
    }
}
const Notificacoes: React.FC = () => {
    const [loading, setLoading] = useState(false);
    const [notificacoes, setNotificacoes] = useState([] as NotificacaoResponse[]);

    async function ObterNotificacoes() {
        setLoading(true);

        const token = await AsyncStorage.getItem('@MetaTi:token');

        const response = await api.get<GenericCommandResult<NotificacaoResponse[]>>("/notificacoes/obter-por-usuario", {
            headers: {
                'Authorization': `Bearer ${token}`
            }
        });

        await setNotificacoes([...response.data.data])

        setLoading(false);
    }

    useEffect(() => {
        ObterNotificacoes();
    }, []);
    const renderNotification = ({ item: notificacao }) => {
        if (notificacao.hemocentro == null) {
            return (
                <View key={notificacao.id} >
                    <ContainerNotificacaoSemHemocentro>
                        <CollapseHeader style={{ padding: 10 }}>
                            <TituloSemNotificacao>{notificacao.titulo}</TituloSemNotificacao>
                        </CollapseHeader>
                        <CollapseBody style={{ flexDirection: 'row', alignItems: 'center', backgroundColor: '#FFEEEC', padding: 10 }}>
                            <DescricaoSemNotificacao>{notificacao.descricao}</DescricaoSemNotificacao>
                        </CollapseBody>
                    </ContainerNotificacaoSemHemocentro>
                </View>
            );
        } else {
            return (
                <View key={notificacao.id} >
                    <ContainerNotificacao>
                        <CollapseHeader style={{ padding: 10 }}>
                            <TituloNotificacao>{notificacao.titulo}</TituloNotificacao>
                        </CollapseHeader>
                        <CollapseBody style={{ flexDirection: 'row', alignItems: 'center', backgroundColor: '#C4284D', padding: 10 }}>
                            <DescricaoNotificacao>{notificacao.descricao}</DescricaoNotificacao>
                            <BotaoDetalheHemocentro onPress={() => { }}>
                                <Icon name="arrow-right" color="#C4284D" size={50} />
                            </BotaoDetalheHemocentro>
                        </CollapseBody>
                    </ContainerNotificacao>
                </View>
            );
        }
    }
    return (
        <>
            <Container>
                <FlatList
                    data={notificacoes}
                    renderItem={renderNotification}
                    onRefresh={ObterNotificacoes}
                    refreshing={loading}
                    keyExtractor={item => item.id.toString()}
                />
            </Container>
        </>
    );
}

export default Notificacoes;
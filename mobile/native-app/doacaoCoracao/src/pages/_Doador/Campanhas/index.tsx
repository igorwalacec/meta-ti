import AsyncStorage from '@react-native-community/async-storage';
import React, { useEffect, useState } from 'react';
import { Text, View } from 'react-native';
import { FlatList } from 'react-native-gesture-handler';
import { GenericCommandResult } from '../../../@types/GenericCommandResult';
import { CollapseHeader, CollapseBody } from 'accordion-collapse-react-native';
import api from '../../../services/api';
import {
    ContainerNotificacaoSemHemocentro,
    Container,
    TituloSemNotificacao,
    DescricaoSemNotificacao,
    HemocentroInfoWrapper,
    HemocentroWrapper,
    BotaoDetalheHemocentro,
    DescricaoWrapper,
    NomeHemocentro,
    EnderecoHemocentro
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
const Campanhas: React.FC = () => {
    const [loading, setLoading] = useState(false);
    const [campanhas, setCampanhas] = useState([] as CampanhasResponse[]);

    const navigation = useNavigation();

    const isFocused = useIsFocused();

    async function ObterCampanhas() {
        setLoading(true);


        const response = await api.get<GenericCommandResult<CampanhasResponse[]>>("/campanha");

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
                    <CollapseBody style={{ backgroundColor: '#FFEEEC', padding: 10 }}>
                        <DescricaoWrapper>
                            <DescricaoSemNotificacao>{campanha.descricao}</DescricaoSemNotificacao>
                        </DescricaoWrapper>
                        <HemocentroWrapper>
                            <HemocentroInfoWrapper>
                                <NomeHemocentro>
                                    {campanha.hemocentro.nome}
                                </NomeHemocentro>
                                <EnderecoHemocentro>
                                    {`${campanha.hemocentro.endereco.logradouro}, ${campanha.hemocentro.endereco.numero}`}
                                </EnderecoHemocentro>
                            </HemocentroInfoWrapper>
                            <BotaoDetalheHemocentro onPress={() => {
                                navigation.navigate("HemocentroDetalhes", {
                                    id: campanha.hemocentro.id
                                })
                            }}>
                                <Icon name="arrow-right" size={45} color={"#FFF"}></Icon>
                            </BotaoDetalheHemocentro>
                        </HemocentroWrapper>
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
            </Container>
        </>
    );
}

export default Campanhas;
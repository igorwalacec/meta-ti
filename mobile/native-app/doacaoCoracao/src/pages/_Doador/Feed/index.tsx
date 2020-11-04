import { useNavigation } from '@react-navigation/native';
import React, { useEffect, useState } from 'react';
import { FlatList } from 'react-native';
import Icon from 'react-native-vector-icons/Feather';
import { GenericCommandResult } from '../../../@types/GenericCommandResult';
import Button from '../../../components/Button';
import FloatButton from '../../../components/FloatButton';
import api from '../../../services/api';
import { AvatarUsuario, Container, DataPostagem, Detalhes, DetalhesHemocentro, FeedContainer, FeedInfomacoes, InformacaoUsuario, InformacoesHemocentro, NomeHemocentro, NomeUsuario, TipoSanguineoUsuario } from './styles'

interface FeedInformacoesResponse {
    id: number;
    descricao: String;
    dataCriacao: Date;
    hemocentro: {
        id: String;
        nome: String;
    }
    usuario: {
        id: String;
        nome: String;
        sobrenome: String;
    }
    tipoSanguineo: {
        id: Number;
        nome: String;
    }
}
interface FeedInformacoes {
    id: number;
    descricao: String;
    tempo: string;
    idHemocentro: String;
    nomeHemocentro: String;
    idUsuario: String;
    nomeUsuario: String;
    sobrenomeUsuario: String;
    idTipoSanguineo: Number;
    nomeTipoSanguineo: String;
}

const Feed: React.FC = () => {
    const [loading, setLoading] = useState(false);
    const [posts, setPosts] = useState([] as FeedInformacoes[]);

    async function ObterFeed() {
        setLoading(true);
        const response = await api.get<GenericCommandResult<FeedInformacoesResponse[]>>("/FeedSolicitacao");

        const postsResponse = response.data.data.map((item) => {
            const DataCriacao = new Date(item.dataCriacao);
            const DataAtual = new Date();

            let diferenca = DataAtual.getTime() - DataCriacao.getTime();

            const horas = Math.floor(diferenca / 1000 / 60 / 60);
            diferenca -= horas * 1000 * 60 * 60;
            const minutos = Math.floor(diferenca / 1000 / 60);

            return {
                id: item.id,
                descricao: item.descricao,
                tempo: horas > 0 ? `${horas.toString()} horas atrás` : `${minutos.toString()} minutos atrás`,
                idHemocentro: item.hemocentro.id,
                nomeHemocentro: item.hemocentro.nome,
                idUsuario: item.usuario.id,
                nomeUsuario: item.usuario.nome,
                sobrenomeUsuario: item.usuario.sobrenome,
                idTipoSanguineo: item.tipoSanguineo.id,
                nomeTipoSanguineo: item.tipoSanguineo.nome
            } as FeedInformacoes;
        });
        await setPosts([...postsResponse]);
        setLoading(false);
    }

    useEffect(() => {
        ObterFeed();
    }, []);

    const renderPost = ({ item: post }) => {
        return (
            <FeedContainer key={post.id}>
                <FeedInfomacoes>
                    <InformacaoUsuario>
                        <AvatarUsuario>
                            <Icon name="user" color="#FFF" size={30} />
                        </AvatarUsuario>
                        <NomeUsuario>
                            {post.nomeUsuario + ' ' + post.sobrenomeUsuario}
                        </NomeUsuario>
                        <TipoSanguineoUsuario>
                            {post.nomeTipoSanguineo}
                        </TipoSanguineoUsuario>
                        <DataPostagem>
                            {post.tempo}
                        </DataPostagem>
                    </InformacaoUsuario>
                </FeedInfomacoes>
                <Detalhes>
                    {post.descricao}
                </Detalhes>
                <InformacoesHemocentro>
                    <NomeHemocentro>
                        {post.nomeHemocentro}
                    </NomeHemocentro>
                    <DetalhesHemocentro>
                        <Icon name="arrow-right" color="#FFF" size={30} />
                    </DetalhesHemocentro>
                </InformacoesHemocentro>
            </FeedContainer>);
    }

    const navigation = useNavigation();
    return (
        <>
            <Container>
                <FlatList
                    data={posts}
                    renderItem={renderPost}
                    onRefresh={ObterFeed}
                    refreshing={loading}
                    keyExtractor={item => item.id}
                />
            </Container>
            <FloatButton
                icon="plus"
                position={{
                    bottom: 30,
                    right: 20,
                    top: 0,
                    left: 0
                }}
            />
        </>
    );
}

export default Feed;
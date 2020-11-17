import React, { useEffect, useState } from 'react';
import { Image, Text, View } from 'react-native';
import { FlatList } from 'react-native-gesture-handler';
import { GenericCommandResult } from '../../../@types/GenericCommandResult';
import critico from '../../../assets/estoqueSanguineo/critico/drawable-xxxhdpi/critico.png';
import alerta from '../../../assets/estoqueSanguineo/alerta/drawable-xxxhdpi/alerta.png';
import estavel from '../../../assets/estoqueSanguineo/estavel/drawable-xxxhdpi/estavel.png';

import IconMaterialCommunity from 'react-native-vector-icons/MaterialCommunityIcons';
import IconMaterial from 'react-native-vector-icons/MaterialIcons';
import IconFeather from 'react-native-vector-icons/Feather';

import api from '../../../services/api';

import { Container, ContainerDetalhes, ContainerEstoque, SubTituloDetalhe, TipoSanguineo, TituloHemocentro, ExpedienteDescricao, CNPJDescricao, TelefoneDescricao, EnderecoDescricao, SubTituloWrapper, UpdateDetalhe } from './styles';
import AsyncStorage from '@react-native-community/async-storage';
import { useAuthFuncionario } from '../../../hooks/funcionario/authFuncionario';
import { useIsFocused, useNavigation } from '@react-navigation/native';



interface HemocentroResponse {
    id: string;
    nome: string,
    cnpj: string;
    endereco: {
        logradouro: string;
        numero: string;
        cep: string;
    }
    estoquesSanguineos: [
        {
            id: number,
            idTipoSanguineo: number,
            quantidadeBolsas: number,
            quantidadeMinimaBolsas: number,
            tipoSanguineo: {
                id: number,
                nome: string
            }
        }
    ],
    expedientes: [
        {
            id: number;
            inicio: string;
            fim: string;
            diaSemana: {
                id: number;
                nome: string;
            }
        }
    ],
    telefones: [
        {
            id: number;
            numero: string;
        }
    ]
}
interface HemocentroState {
    id: string;
    nome: string,
    cnpj: string;
    endereco: {
        logradouro: string;
        numero: string;
        cep: string;
    }
    estoquesSanguineos: [
        {
            id: number,
            idTipoSanguineo: number,
            quantidadeBolsas: number,
            quantidadeMinimaBolsas: number,
            tipoSanguineo: {
                id: number,
                nome: string
            }
        }
    ],
    expedientes: [
        {
            id: number;
            inicio: string;
            fim: string;
            diaSemana: {
                id: number;
                nome: string;
            }
        }
    ], telefones: [
        {
            id: number;
            numero: string;
        }
    ]
}

const Hemocentro: React.FC = () => {
    const { funcionario } = useAuthFuncionario();
    const navigation = useNavigation();
    const [hemocentro, setHemocentro] = useState<HemocentroState>({} as HemocentroState);

    const focused = useIsFocused();
    const obterDetalhesHemocentro = async () => {
        console.log(funcionario);
        const response = await api.post<GenericCommandResult<HemocentroResponse>>("/hemocentro/obter-por-id", {
            idHemocentro: funcionario.idHemocentro
        });
        setHemocentro(response.data.data);
    };



    const detalhesEstoqueSanguineo = () => {
        if (hemocentro.estoquesSanguineos != undefined && hemocentro.estoquesSanguineos.length > 0) {

            return (
                <>
                    <FlatList
                        data={hemocentro.estoquesSanguineos}
                        renderItem={renderEstoque}
                        horizontal={true}
                    />
                </>
            )
        }
    };
    const detalhesHemocentro = () => {
        if (hemocentro.expedientes != undefined && hemocentro.estoquesSanguineos.length > 0) {
            return (
                <>

                    <CNPJDescricao>CNPJ : {hemocentro.cnpj.replace(/(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})/g, "\$1.\$2.\$3\/\$4\-\$5")}</CNPJDescricao>
                    {
                        hemocentro.expedientes.map((expediente) => {
                            let inicioParse = new Date(expediente.inicio).toTimeString().split(' ')[0].split(':');
                            let inicio = `${inicioParse[0]}:${inicioParse[1]}`;
                            let fimParse = new Date(expediente.fim).toTimeString().split(' ')[0].split(':');
                            let fim = `${fimParse[0]}:${fimParse[1]}`;
                            return (<ExpedienteDescricao key={expediente.id}>{`${expediente.diaSemana.nome} - ${inicio} ás ${fim}`}</ExpedienteDescricao>);
                        })
                    }
                    <SubTituloDetalhe><IconFeather name="phone" size={25} />Telefones</SubTituloDetalhe>
                    {
                        hemocentro.telefones.map((telefone, index) => {
                            return (<TelefoneDescricao key={index}>{`Telefone ${index + 1}: ${telefone.numero}`}</TelefoneDescricao>);
                        })
                    }
                </>
            );
        }
    };

    const detalhesEndereco = () => {
        if (hemocentro.endereco != undefined) {
            return (
                <>
                    <EnderecoDescricao>
                        {`${hemocentro.endereco.logradouro},${hemocentro.endereco.numero}`}
                    </EnderecoDescricao>

                    <EnderecoDescricao>
                        {`${hemocentro.endereco.cep.replace(/(\d{5})?(\d{3})/, "$1-$2")}`}
                    </EnderecoDescricao>
                </>
            );
        }
    };

    const renderEstoque = ({ item: estoque }) => {
        let image = critico;
        if (estoque.quantidadeBolsas < estoque.quantidadeMinimaBolsas) {
            image = critico;
        }
        else if (estoque.quantidadeBolsas > (estoque.quantidadeMinimaBolsas * 2)) {
            image = estavel;
        } else {
            image = alerta;
        }
        return (
            <ContainerEstoque>
                <Image source={image} />
                <TipoSanguineo>{estoque.tipoSanguineo.nome}</TipoSanguineo>
            </ContainerEstoque>);
    }
    useEffect(() => {
        if (focused) {
            obterDetalhesHemocentro();
        }
    }, [focused]);

    return (
        <Container>
            <TituloHemocentro>{hemocentro.nome}</TituloHemocentro>
            <ContainerDetalhes>
                <SubTituloWrapper>
                    <SubTituloDetalhe>ESTOQUE</SubTituloDetalhe>
                    <UpdateDetalhe onPress={() => {
                        navigation.navigate("EstoqueSanguineo");
                    }}>
                        <IconFeather name="tool" size={20} color="#C4284D" />
                    </UpdateDetalhe>
                </SubTituloWrapper>
                {
                    detalhesEstoqueSanguineo()
                }
            </ContainerDetalhes>
            <ContainerDetalhes>
                <SubTituloWrapper>
                    <SubTituloDetalhe><IconMaterialCommunity name="blood-bag" size={25} />Informações</SubTituloDetalhe>
                    <UpdateDetalhe onPress={() => {
                        navigation.navigate("EstoqueSanguineo");
                    }}>
                        <IconFeather name="tool" size={20} color="#C4284D" />
                    </UpdateDetalhe>
                </SubTituloWrapper>
                {
                    detalhesHemocentro()
                }
            </ContainerDetalhes>
            <ContainerDetalhes>
                <SubTituloDetalhe style={{ textAlign: 'center' }}><IconMaterial name="location-on" size={25} />Endereço Hemocentro</SubTituloDetalhe>
                {
                    detalhesEndereco()
                }
            </ContainerDetalhes>
        </Container>
    );
}

export default Hemocentro;
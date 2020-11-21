import { useNavigation } from '@react-navigation/native';
import React, { useCallback, useEffect, useState } from 'react';
import { Alert, Text } from 'react-native';
import { GenericCommandResult } from '../../../@types/GenericCommandResult';
import Button from '../../../components/Button';
import api from '../../../services/api';
import { Container, DataNascimento, Documento, Titulo, AgendamentoData } from './styles';

interface AgendamentoState {
    id: string;
    dataAgendamento: string;
    usuario: {
        nome: string;
        sobrenome: string;
        rg: string;
        cpf: string;
        dataNascimento: string;
        tipoSanguineo: {
            nome: string;
        }
    },
}

const AgendamentoUsuario = ({ route }) => {
    const { id } = route.params;

    const [agendamento, setAgendamento] = useState({} as AgendamentoState);
    const navigation = useNavigation();
    const obterAgendamento = async () => {
        const response = await api.get<GenericCommandResult<AgendamentoState>>(`/agendamento/${id}`);
        setAgendamento(response.data.data);
    };

    const tratarData = (date: string) => {
        let data = new Date(date);
        return new Date(new Date(data).setHours(data.getHours() + 3));
    }
    const retornaData = (date: Date) => {
        return [(date.getDate()), (date.getMonth() + 1), (date.getFullYear())].join('/')
    }
    const retornaDatetime = (date: Date) => {
        return `${[(date.getDate()), (date.getMonth() + 1), (date.getFullYear())].join('/')} ${date.getHours().toString().padStart(2, '0')}:${date.getMinutes().toString().padStart(2, '0')}`
    }

    const formatarRG = (rg: string) => {
        rg = rg.replace(/\D/g, "");
        rg = rg.replace(/(\d{2})(\d{3})(\d{3})(\d{1})$/, "$1.$2.$3-$4");
        return rg;
    }
    const formatarCPF = (cpf: string) => {
        cpf = cpf.replace(/(\d{3})(\d{3})(\d{3})(\d{2})$/, "$1.$2.$3-$4");
        return cpf;
    }
    const excluirAgendamento = useCallback(async () => {
        await api.delete(`/agendamento/${id}`);

        Alert.alert("Sucesso", "Agendamento excluido com sucesso!");
        navigation.navigate("Perfil");

    }, []);

    useEffect(() => {
        obterAgendamento();
    }, [id])
    return (
        <Container>
            {
                agendamento.id != undefined && (
                    <>
                        <Titulo>{`${agendamento.usuario.nome} ${agendamento.usuario.sobrenome}`}</Titulo>
                        <DataNascimento>{`${retornaData(tratarData(agendamento.usuario.dataNascimento))}`}</DataNascimento>
                        <Documento>{`RG - ${formatarRG(agendamento.usuario.rg)}`}</Documento>
                        <Documento>{`CPF - ${formatarCPF(agendamento.usuario.cpf)}`}</Documento>

                        <Titulo>Agendamento</Titulo>
                        <AgendamentoData>{`${retornaDatetime(tratarData(agendamento.dataAgendamento))}`}</AgendamentoData>
                    </>
                )
            }
            <Button onPress={excluirAgendamento}>Excluir</Button>
        </Container>
    )
}

export default AgendamentoUsuario;
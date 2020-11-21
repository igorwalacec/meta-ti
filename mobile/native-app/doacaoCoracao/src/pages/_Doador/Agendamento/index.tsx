import AsyncStorage from '@react-native-community/async-storage';
import { useIsFocused, useNavigation } from '@react-navigation/native';
import React, { useEffect, useState } from 'react'
import { Text } from 'react-native';
import QRCode from 'react-native-qrcode-svg';
import { GenericCommandResult } from '../../../@types/GenericCommandResult';
import api from '../../../services/api';
import { Container, QRCodeSangue, TituloAgendamento } from './styles';

interface AgendamentoState {
    id: string;
}

const Agendamento: React.FC = () => {
    const [agendamento, setAgendamento] = useState({} as AgendamentoState);
    const navigation = useNavigation();
    const focused = useIsFocused();
    const obterAgendamento = async () => {

        const token = await AsyncStorage.getItem('@MetaTi:token');
        api.get<GenericCommandResult<AgendamentoState[]>>("/agendamento/obter-por-usuario", {
            headers: {
                'Authorization': `Bearer ${token}`
            }
        }).then((response) => {
            setAgendamento(response.data.data[0]);
        }).catch((responseError) => {
            navigation.navigate("CadastroAgendamento");
        });
    }

    useEffect(() => {
        if (focused) {
            obterAgendamento();
        }
    }, [focused])

    return (
        <Container>
            <TituloAgendamento>Apresente seu QR Code ao hemocentro</TituloAgendamento>
            {
                agendamento.id != undefined && (
                    <QRCodeSangue
                        size={180}
                        value={agendamento.id}
                    />
                )
            }
        </Container>
    )
}

export default Agendamento;
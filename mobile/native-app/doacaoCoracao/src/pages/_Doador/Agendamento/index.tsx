import AsyncStorage from '@react-native-community/async-storage';
import { useIsFocused, useNavigation } from '@react-navigation/native';
import React, { useEffect, useState } from 'react'
import { Text } from 'react-native';
import { GenericCommandResult } from '../../../@types/GenericCommandResult';
import api from '../../../services/api';

interface AgendamentoState {
    id: String;
}

const Agendamento: React.FC = () => {
    const [agendamento, setAgendamento] = useState({} as AgendamentoState);
    const navigation = useNavigation();
    const focused = useIsFocused();
    const obterAgendamento = async () => {

        const token = await AsyncStorage.getItem('@MetaTi:token');
        api.get<GenericCommandResult<AgendamentoState>>("/agendamento/obter-por-usuario", {
            headers: {
                'Authorization': `Bearer ${token}`
            }
        }).then((response) => {
            setAgendamento(response.data.data);
        }).catch((responseError) => {
            navigation.navigate("CadastroAgendamento");
        });
    }

    useEffect(() => {
        if (focused) {
            obterAgendamento();
        }
    })

    return (
        <>
            <Text>react-native link react-native-svg</Text>
            {/* <QRCode
                value="http://awesome.link.qr"
            /> */}
        </>
    )
}

export default Agendamento;
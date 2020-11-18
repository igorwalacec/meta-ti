import { resolvePlugin } from '@babel/core';
import { useNavigation } from '@react-navigation/native';
import { FormHandles } from '@unform/core';
import { Form } from '@unform/mobile';
import React, { useCallback, useEffect, useRef, useState } from 'react';
import { Alert, Text, TextInput, View } from 'react-native';
import { TextInputMask } from 'react-native-masked-text';
import Icon from 'react-native-vector-icons/Feather';
import { GenericCommandResult } from '../../../@types/GenericCommandResult';
import Button from '../../../components/Button';
import DropDownList from '../../../components/DropDownList';
import Input from '../../../components/Input';
import InputMask from '../../../components/InputMask';
import api from '../../../services/api';
import { CadastrarHemocentro, CadastrarHemocentroText, Container } from './styles';
import DateTimePicker from '@react-native-community/datetimepicker';
import AsyncStorage from '@react-native-community/async-storage';
import { useAuth } from '../../../hooks/auth';

interface SubmitFormCadastro {
    nomeCompleto: string;
    email: string;
    senha: string;
    cpf: string;
    idHemocentro: string;
}

interface ResponseHemocentro {
    id: string;
    nome: string;
}

const CadastroAgendamento: React.FC = () => {
    const [date, setDate] = useState(new Date());
    const { usuario } = useAuth();
    const [showDatetime, setShowDatetime] = useState(false);
    const [showTime, setShowTime] = useState(false);

    const onChangeData = useCallback(async (event) => {
        const { timestamp } = event.nativeEvent;
        const currentDate = new Date(timestamp);
        setDate(currentDate);
        setShowTime(false);
        setShowDatetime(false);
    }, []);

    const formRef = useRef<FormHandles>(null);
    const navigation = useNavigation();

    const [hemocentros, setHemocentros] = useState([]);

    useEffect(() => {
        async function ObterHemocentros() {
            const response = await api.get<GenericCommandResult<Array<ResponseHemocentro>>>('hemocentro/obter-todos');

            const hemocentrosMap = response.data.data.map((value) => {
                return {
                    value: value.id,
                    label: value.nome,
                    icon: () => <Icon name="flag" size={18} color="#900" />,
                    disabled: false,
                    selected: false
                }
            });

            setHemocentros([...hemocentrosMap]);
        }

        ObterHemocentros();
        setDate(new Date());
    }, []);

    const cadastrar = async (dataSubmit) => {
        const dataAgendamento = new Date(date);
        const cadastroRequest =
        {
            idUsuario: usuario.id,
            idHemocentro: dataSubmit.idHemocentro,
            dataAgendamento: dataAgendamento
        };
        console.log(cadastroRequest);
        const token = await AsyncStorage.getItem('@MetaTi:token');
        api.post<GenericCommandResult<any>>('/agendamento/criar', cadastroRequest, {
            headers: {
                'Authorization': `Bearer ${token}`
            }
        })
            .then((response) => {
                Alert.alert("Sucesso!", "Agendamento feito com sucesso.");
                navigation.navigate("Agendamento");
            }).catch(({ response }) => {
                if (response.status == 400) {
                    Alert.alert("Alerta!", "Preencha todos os campos!");
                } else {
                    Alert.alert("Error", "Erro no servidor!");
                }
            })
    };

    return (
        <Container>
            <Form ref={formRef} style={{ width: '100%' }} onSubmit={cadastrar}>

                <Text>{date.toLocaleString()}</Text>
                <Button onPress={() => {
                    setShowDatetime(true)
                }} >Definir Data</Button>


                <Button onPress={() => {
                    setShowTime(true)
                }} >Definir Horário</Button>

                {showDatetime && (
                    <DateTimePicker
                        value={date}
                        mode="date"
                        is24Hour={true}
                        display="default"
                        onChange={onChangeData}
                    />
                )}
                {showTime && (
                    <DateTimePicker
                        value={date}
                        mode="time"
                        is24Hour={true}
                        display="default"
                        onChange={onChangeData}
                    />
                )}
                <DropDownList
                    searchable={true}
                    placeholder="Selecionar hemocentro..."
                    searchablePlaceholder="Pesquisar..."
                    searchablePlaceholderTextColor="gray"
                    searchableError={() => <Text>Hemocentro não encontrado</Text>}
                    name="idHemocentro"
                    items={hemocentros}
                />
            </Form>
            <Button onPress={() => { formRef.current?.submitForm() }}>
                Cadastrar
            </Button>
        </Container >
    );
};

export default CadastroAgendamento;
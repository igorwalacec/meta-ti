import { resolvePlugin } from '@babel/core';
import { useNavigation } from '@react-navigation/native';
import { FormHandles } from '@unform/core';
import { Form } from '@unform/mobile';
import React, { useCallback, useEffect, useRef, useState } from 'react';
import { Alert, KeyboardAvoidingView, Platform, SafeAreaView, ScrollView, Text, TextInput } from 'react-native';
import { TextInputMask } from 'react-native-masked-text';
import Icon from 'react-native-vector-icons/Feather';
import { GenericCommandResult } from '../../@types/GenericCommandResult';
import Button from '../../components/Button';
import DropDownList from '../../components/DropDownList';
import Input from '../../components/Input';
import InputMask from '../../components/InputMask';
import api from '../../services/api';
import { CadastrarHemocentro, CadastrarHemocentroText, Container } from './styles';

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

const CadastroFuncionario: React.FC = () => {
    const formRef = useRef<FormHandles>(null);
    const navigation = useNavigation();
    //Ref de inputs    
    const emailRef = useRef<TextInput>(null);
    const senhaRef = useRef<TextInput>(null);

    const navegarCadastroHemocentro = useCallback(() => {
        navigation.navigate("CadastroHemocentro");
    }, [navigation])

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
    }, []);

    const cadastrar = useCallback(async (data: SubmitFormCadastro) => {
        const cadastroRequest =
        {
            nomeCompleto: data.nomeCompleto,
            email: data.email,
            senha: data.senha,
            cpf: data.cpf,
            idHemocentro: data.idHemocentro
        };        

        api.post<GenericCommandResult<any>>('/funcionario/criar', cadastroRequest)
            .then((response) => {
                Alert.alert("Sucesso!", "Efetue o login.");
                navigation.navigate("LoginFuncionario");
            }).catch(({ response }) => {
                if (response.status == 400) {
                    Alert.alert("Alerta!", "Preencha todos os campos!");
                } else {
                    Alert.alert("Error", "Erro no servidor!");
                }
            })
    }, []);

    return (
        <Container>
            <Form ref={formRef} onSubmit={cadastrar}>
                <Input
                    autoCorrect={false}
                    name="nomeCompleto"
                    icon="user"
                    placeholder="Nome"
                    returnKeyType="next"
                    onSubmitEditing={() => {
                        emailRef.current?.focus();
                    }}
                />
                <Input
                    ref={emailRef}
                    name="email"
                    autoCapitalize="none"
                    keyboardType="email-address"
                    icon="mail"
                    placeholder="E-mail"
                    returnKeyType="next"
                    onSubmitEditing={() => {
                        senhaRef.current?.focus();
                    }}
                />
                <Input
                    ref={senhaRef}
                    name="senha"
                    autoCapitalize="none"
                    secureTextEntry
                    icon="lock"
                    placeholder="Senha"
                />
                <InputMask
                    useFormatted={false}
                    onChangeText={() => { }}
                    mask={"[000].[000].[000]-[00]"}
                    name="cpf"
                    icon="alert-circle"
                    placeholder="CPF"
                />
                <DropDownList
                    searchable={true}
                    placeholder="Selecionar hemocentro..."
                    searchablePlaceholder="Pesquisar..."
                    searchablePlaceholderTextColor="gray"
                    searchableError={() => <Text>Hemocentro não encontrado</Text>}
                    name="idHemocentro"
                    items={hemocentros}
                />
                <CadastrarHemocentro onPress={navegarCadastroHemocentro}>
                    <CadastrarHemocentroText>
                        Não encontrou seu hemocentro? Clique aqui!
                    </CadastrarHemocentroText>
                </CadastrarHemocentro>
            </Form>
            <Button onPress={() => { formRef.current?.submitForm() }}>
                Cadastrar
            </Button>
        </Container>
    );
};

export default CadastroFuncionario;
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
import { Container } from './styles';

interface ResponseError {
    response: {
        data: GenericCommandResult<any>;
        status: Number;
    }
}
interface ResponseEstadosDTO {
    id: number;
    nome: string;
    uf: string;
}
interface ResponseTipoSanguineoDTO {
    id: number;
    nome: string;
}

interface SubmitFormCadastro {
    nomeCompleto: string;
    email: string;
    senha: string;
    cpf: string;
    idHemocentro: string;
}

const CadastroFuncionario: React.FC = () => {
    const formRef = useRef<FormHandles>(null);
    const navigation = useNavigation();
    //Ref de inputs
    const sobrenomeRef = useRef<TextInput>(null);
    const emailRef = useRef<TextInput>(null);
    const senhaRef = useRef<TextInput>(null);

    const cadastrar = useCallback(async (data: SubmitFormCadastro) => {
        const cadastroRequest =
        {
            nomeCompleto: data.nomeCompleto,
            email: data.email,
            senha: data.senha,
            cpf: data.cpf,
            idHemocentro: data.idHemocentro
        };


        api.post<GenericCommandResult<any>>('Funcionario/criar', cadastroRequest)
            .then((response) => {
                Alert.alert("Sucesso!", "Efetue o login.");
                navigation.navigate("LoginUser");
            }).catch(({ response }: ResponseError) => {
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
                    name="nome"
                    icon="user"
                    placeholder="Nome"
                    returnKeyType="next"
                    onSubmitEditing={() => {
                        sobrenomeRef.current?.focus();
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
            </Form>
            <Button onPress={() => { formRef.current?.submitForm() }}>
                Enviar
                        </Button>
        </Container>
    );
};

export default CadastroFuncionario;
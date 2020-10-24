import { FormHandles } from '@unform/core';
import { Form } from '@unform/mobile';
import React, { useCallback, useEffect, useRef, useState } from 'react';
import { KeyboardAvoidingView, Platform, ScrollView, Text } from 'react-native';
import Icon from 'react-native-vector-icons/Feather';
import { GenericCommandResult } from '../../@types/GenericCommandResult';
import Button from '../../components/Button';
import DropDownList from '../../components/DropDownList';
import Input from '../../components/Input';
import InputMask from '../../components/InputMask';
import api from '../../services/api';
import { Container } from './styles';


interface ResponseDTO {
    id: number;
    nome: string;
    uf: string;
}

const CadastroUsuario: React.FC = () => {
    const formRef = useRef<FormHandles>(null);
    const [estados, setEstados] = useState([]);
    const [tipoSexo, setTipoSexo] = useState([
        {
            label: "Masculino",
            value: 1,
            icon: () => <Icon name="flag" size={18} color="#900" />,
            disabled: false,
            selected: false
        },
        {
            label: "Feminino",
            value: 1,
            icon: () => <Icon name="flag" size={18} color="#900" />,
            disabled: false,
            selected: false
        },
        {
            label: "Outros",
            value: 3,
            icon: () => <Icon name="flag" size={18} color="#900" />,
            disabled: false,
            selected: false
        },
    ]);
    const [cidades, setCidades] = useState([]);
    useEffect(() => {
        api.get<GenericCommandResult<Array<ResponseDTO>>>('Estado/obter-estados').then((response) => {
            const estadosDropDown = response.data.data.map((value) => {
                return {
                    label: value.nome,
                    value: value.id,
                    icon: () => <Icon name="flag" size={18} color="#900" />,
                    disabled: false,
                    selected: false
                };
            });
            setEstados([...estadosDropDown]);
        });
    }, []);

    const obterCidades = useCallback(async (value) => {
        var response = await api.get<GenericCommandResult<Array<ResponseDTO>>>(`/Cidade/obter-cidades/${value}`);

        const cidadeDropDown = response.data.data.map((value) => {
            return {
                label: value.nome,
                value: value.id,
                icon: () => <Icon name="flag" size={18} color="#900" />,
                disabled: false,
                selected: false
            };
        });
        setCidades([...cidadeDropDown]);
    }, [])

    return (
        <>
            <KeyboardAvoidingView
                style={{ flex: 1 }}
                behavior={Platform.OS === 'ios' ? 'padding' : undefined}
                enabled
            >
                <ScrollView
                    keyboardShouldPersistTaps="handled"
                    contentContainerStyle={{ flex: 1 }}
                >
                    <Container>
                        <Form ref={formRef} onSubmit={(data) => { console.log(data) }}>
                            <Input
                                autoCorrect={false}
                                name="nome"
                                icon="mail"
                                placeholder="Nome"
                                returnKeyType="next"
                                onSubmitEditing={() => {

                                }}
                            />
                            <Input
                                name="Sobrenome"
                                autoCorrect={false}
                                icon="lock"
                                placeholder="Sobrenome"
                                returnKeyType="next"
                                onSubmitEditing={() => {
                                    // formRef.current?.submitForm();
                                }}
                            />
                            <Input
                                name="Email"
                                autoCapitalize="none"
                                keyboardType="email-address"
                                icon="mail"
                                placeholder="E-mail"
                                returnKeyType="next"
                                onSubmitEditing={() => {
                                    // formRef.current?.submitForm();
                                }}
                            />
                            <Input
                                name="senha"
                                autoCapitalize="none"
                                secureTextEntry
                                icon="lock"
                                placeholder="Senha"
                                returnKeyType="next"
                                onSubmitEditing={() => {
                                    // formRef.current?.submitForm();
                                }}
                            />
                            <InputMask
                                onChangeText={() => { }}
                                useFormatted={false}
                                mask={"[00].[000].[000]-[_]"}
                                name="RG"
                                icon="lock"
                                placeholder="RG"
                                returnKeyType="next"
                                onSubmitEditing={() => {
                                    // formRef.current?.submitForm();
                                }}
                            />
                            <InputMask
                                useFormatted={false}
                                onChangeText={() => { }}
                                mask={"[000].[000].[000]-[00]"}
                                name="CPF"
                                icon="lock"
                                placeholder="CPF"
                                returnKeyType="next"
                                onSubmitEditing={() => {
                                    // formRef.current?.submitForm();
                                }}
                            />
                            <InputMask
                                useFormatted={true}
                                onChangeText={() => { }}
                                mask={"[00]/[00]/[0000]"}
                                name="dataNascimento"
                                icon="lock"
                                placeholder="Data Nascimento"
                                returnKeyType="next"
                                onSubmitEditing={() => {
                                    // formRef.current?.submitForm();
                                }}
                            />
                            <DropDownList
                                placeholder="Selecionar Sexo..."
                                name="tipoSexo"
                                items={tipoSexo}
                            />
                            <DropDownList
                                searchable={true}
                                placeholder="Selecionar estado..."
                                searchablePlaceholder="Pesquisar..."
                                searchablePlaceholderTextColor="gray"
                                searchableError={() => <Text>Estado não encontrado</Text>}
                                name="estado"
                                items={estados}
                                callback={obterCidades}
                            />
                            <DropDownList
                                searchable={true}
                                placeholder="Selecionar cidade..."
                                searchablePlaceholder="Pesquisar..."
                                searchablePlaceholderTextColor="gray"
                                searchableError={() => <Text>Cidade não encontrado</Text>}
                                name="cidade"
                                items={cidades}
                            />
                            {/* "idTipoSexo": 0,
                            "idTipoSanguineo": 0,                            
                            "logradouro": "string",
                            "complemento": "string",
                            "numero": "string",
                            "cep": "string" */}
                        </Form>
                        <Button onPress={() => { formRef.current?.submitForm() }}>
                            Enviar
                        </Button>
                    </Container>
                </ScrollView>
            </KeyboardAvoidingView>
        </>
    );
};

export default CadastroUsuario;
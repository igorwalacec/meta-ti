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
    nome: string;
    sobrenome: string;
    email: string;
    senha: string;
    rg: string;
    cpf: string;
    idTipoSexo: number;
    idTipoSanguineo?: number;
    dataNascimento: string;
    logradouro: string;
    complemento: string;
    numero: string;
    cep: string;
    idCidade: number;
}

const CadastroUsuario: React.FC = () => {
    const formRef = useRef<FormHandles>(null);
    const navigation = useNavigation();
    //Ref de inputs
    const sobrenomeRef = useRef<TextInput>(null);
    const emailRef = useRef<TextInput>(null);
    const senhaRef = useRef<TextInput>(null);
    const complementoRef = useRef<TextInput>(null);
    const numeroRef = useRef<TextInput>(null);

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
    const [tipoSanguineo, setTipoSanguineo] = useState([])
    useEffect(() => {
        api.get<GenericCommandResult<Array<ResponseEstadosDTO>>>('Estado/obter-estados').then((response) => {
            const estadosDropDown = response.data.data.map((value) => ({
                label: value.nome,
                value: value.id,
                icon: () => <Icon name="flag" size={18} color="#900" />,
                disabled: false,
                selected: false
            }));
            setEstados([...estadosDropDown]);
        });
        api.get<GenericCommandResult<Array<ResponseTipoSanguineoDTO>>>('/TipoSanguineo').then((response) => {
            const tipoSanguineoDropDown = response.data.data.map((value) => {
                return {
                    label: value.nome,
                    value: value.id,
                    icon: () => <Icon name="flag" size={18} color="#900" />,
                    disabled: false,
                    selected: false
                };
            });
            const defaultTipoSanguineo = {
                label: "Não sei",
                value: null,
                icon: () => <Icon name="flag" size={18} color="#900" />,
                disabled: false,
                selected: false
            }
            setTipoSanguineo([...tipoSanguineoDropDown, defaultTipoSanguineo]);
        });
    }, []);

    const obterCidades = useCallback(async (value) => {
        var response = await api.get<GenericCommandResult<Array<ResponseEstadosDTO>>>(`/Cidade/obter-cidades/${value}`);

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

    const cadastrar = useCallback(async (data: SubmitFormCadastro) => {


        const dateParts = data.dataNascimento.split("/");

        const dataFormatada = new Date(+dateParts[2], dateParts[1] - 1, +dateParts[0]).toJSON();

        const cadastroRequest =
        {
            nome: data.nome,
            sobrenome: data.sobrenome,
            email: data.email,
            senha: data.senha,
            rg: data.rg,
            cpf: data.cpf,
            idTipoSexo: data.idTipoSexo,
            idTipoSanguineo: data.idTipoSanguineo,
            dataNascimento: dataFormatada,
            logradouro: data.logradouro,
            complemento: data.complemento,
            numero: data.numero,
            cep: data.cep,
            idCidade: data.idCidade
        };


        api.post<GenericCommandResult<any>>('Usuario/criar-usuario', cadastroRequest)
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
        <>
            <KeyboardAvoidingView
                style={{ flex: 1 }}
                behavior={Platform.OS === 'ios' ? 'padding' : undefined}
                enabled
            >
                <SafeAreaView style={{ flex: 1 }}>
                    <ScrollView keyboardShouldPersistTaps="handled">
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
                                    ref={sobrenomeRef}
                                    name="sobrenome"
                                    autoCorrect={false}
                                    icon="user"
                                    placeholder="Sobrenome"
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
                                    onChangeText={() => { }}
                                    useFormatted={false}
                                    mask={"[00].[000].[000]-[_]"}
                                    name="rg"
                                    icon="alert-circle"
                                    placeholder="RG"
                                />
                                <InputMask
                                    useFormatted={false}
                                    onChangeText={() => { }}
                                    mask={"[000].[000].[000]-[00]"}
                                    name="cpf"
                                    icon="alert-circle"
                                    placeholder="CPF"
                                />
                                <InputMask
                                    useFormatted={true}
                                    onChangeText={() => { }}
                                    mask={"[00]/[00]/[0000]"}
                                    name="dataNascimento"
                                    icon="calendar"
                                    placeholder="Data Nascimento"
                                />
                                <DropDownList
                                    placeholder="Selecionar Sexo..."
                                    name="idTipoSexo"
                                    items={tipoSexo}
                                />
                                <DropDownList
                                    searchable={true}
                                    placeholder="Selecionar Tipo Sanguíneo"
                                    searchablePlaceholder="Pesquisar..."
                                    searchablePlaceholderTextColor="gray"
                                    searchableError={() => <Text>Estado não encontrado</Text>}
                                    name="idTipoSanguineo"
                                    items={tipoSanguineo}
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
                                    name="idCidade"
                                    items={cidades}
                                />
                                <Input
                                    name="logradouro"
                                    icon="navigation"
                                    placeholder="Endereço"
                                    returnKeyType="next"
                                    onSubmitEditing={() => {
                                        complementoRef.current?.focus();
                                    }}
                                />
                                <Input
                                    ref={complementoRef}
                                    name="complemento"
                                    icon="navigation"
                                    placeholder="Complemento"
                                    returnKeyType="next"
                                    onSubmitEditing={() => {
                                        numeroRef.current?.focus();
                                    }}
                                />
                                <Input
                                    ref={numeroRef}
                                    name="numero"
                                    icon="navigation"
                                    placeholder="Numero"
                                    returnKeyType="next"
                                    onSubmitEditing={() => {
                                        // formRef.current?.submitForm();
                                    }}
                                />
                                <InputMask
                                    onChangeText={() => { }}
                                    useFormatted={false}
                                    mask={"[00].[000]-[000]"}
                                    name="cep"
                                    icon="navigation"
                                    placeholder="CEP"
                                    returnKeyType="send"
                                    onSubmitEditing={() => {
                                        formRef.current?.submitForm();
                                    }}
                                />
                            </Form>
                            <Button onPress={() => { formRef.current?.submitForm() }}>
                                Enviar
                        </Button>
                        </Container>
                    </ScrollView>
                </SafeAreaView>
            </KeyboardAvoidingView>
        </>
    );
};

export default CadastroUsuario;
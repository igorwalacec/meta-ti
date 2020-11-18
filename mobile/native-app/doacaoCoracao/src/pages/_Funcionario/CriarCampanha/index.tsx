import AsyncStorage from '@react-native-community/async-storage';
import { useNavigation } from '@react-navigation/native';
import { FormHandles } from '@unform/core';
import { Form } from '@unform/mobile';
import React, { useCallback, useRef } from 'react';
import { Alert, TextInput } from 'react-native';
import Button from '../../../components/Button';
import Input from '../../../components/Input';
import api from '../../../services/api';
import { Container, ContainerCadastro } from './styles';

interface criarCampanhaSubmit {
    titulo: string;
    descricao: string;
}

const CriarCampanha = () => {
    const navigate = useNavigation();
    const criarCampanha = useCallback(async (data: criarCampanhaSubmit) => {

        const token = await AsyncStorage.getItem('@MetaTi:token');
        api.post("/campanha/criar", data, {
            headers: {
                'Authorization': `Bearer ${token}`
            }
        }).then((response) => {
            Alert.alert("Sucesso", "Campanha criada com sucesso!")
            navigate.goBack();
        }).catch(() => {
            Alert.alert("Alerta", "Preencha todos os campos!")
        })
    }, []);

    const formRef = useRef<FormHandles>(null);
    const descricao = useRef<TextInput>(null);
    return (
        <>
            <Container>
                <Form ref={formRef} onSubmit={criarCampanha}>
                    <Input
                        autoCorrect={true}
                        name="titulo"
                        icon="edit"
                        placeholder="Título"
                        returnKeyType="next"
                        onSubmitEditing={() => {
                            descricao.current?.focus();
                        }}
                    />

                    <Input
                        ref={descricao}
                        name="descricao"
                        icon="edit-2"
                        multiline={true}
                        placeholder="Descrição"
                        returnKeyType="send"
                        onSubmitEditing={() => {
                            formRef.current?.submitForm();
                        }}
                    />
                </Form>
            </Container>
            <ContainerCadastro>
                <Button onPress={() => {
                    formRef.current?.submitForm();
                }}>
                    CONTINUAR
                </Button>
            </ContainerCadastro>
        </>
    );
};

export default CriarCampanha;
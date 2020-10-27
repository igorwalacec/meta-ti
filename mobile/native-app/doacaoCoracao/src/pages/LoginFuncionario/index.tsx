import { useNavigation } from '@react-navigation/native';
import { FormHandles } from '@unform/core';
import { Form } from '@unform/mobile';
import React, { useCallback, useRef } from 'react';
import { Alert, TextInput } from 'react-native';
import Button from '../../components/Button';
import Input from '../../components/Input';
import { useAuth } from '../../hooks/auth';
import api from '../../services/api';
import { Container, ContainerCadastro, CadastroText, NaoPossueConta } from './styles';

interface SubmitFormLogin {
    email: string;
    senha: string;
}

const LoginFuncionario: React.FC = () => {
    const { signIn, usuario } = useAuth();
    const navigate = useNavigation();    
    const logar = useCallback(async (data: SubmitFormLogin) => {
        await signIn({
            email: data.email,
            senha: data.senha
        });
    }, []);

    const formRef = useRef<FormHandles>(null);
    const senhaRef = useRef<TextInput>(null);
    return (
        <Container>
            <Form ref={formRef} onSubmit={logar}>
                <Input
                    autoCorrect={false}
                    autoCapitalize="none"
                    keyboardType="email-address"
                    name="email"
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
                    icon="lock"
                    placeholder="Senha"
                    secureTextEntry
                    returnKeyType="send"
                    onSubmitEditing={() => {
                        formRef.current?.submitForm();
                    }}
                />
            </Form>
            <Button onPress={() => {
                formRef.current?.submitForm();
            }}>
                CONTINUAR
            </Button>

            <NaoPossueConta>
                Ainda não possui uma conta?
            </NaoPossueConta>
            <ContainerCadastro onPress={() => {
                navigate.navigate("CadastroFuncionario");
            }}>
                <CadastroText>
                    CADASTRAR
                </CadastroText>
            </ContainerCadastro>
        </Container>
    );
}

export default LoginFuncionario;
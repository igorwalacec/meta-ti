import { FormHandles } from '@unform/core';
import { Form } from '@unform/mobile';
import React, { useRef } from 'react';
import { TextInput } from 'react-native';
import Button from '../../components/Button';
import Input from '../../components/Input';
import { Container, ContainerCadastro, CadastroText, NaoPossueConta } from './styles';


const LoginUser: React.FC = () => {
    const formRef = useRef<FormHandles>(null);
    const senhaRef = useRef<TextInput>(null);
    return (
        <Container>
            <Form ref={formRef} onSubmit={(data) => { console.log(data) }}>
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
            <ContainerCadastro>
                <CadastroText>
                    CADASTRAR
                </CadastroText>
            </ContainerCadastro>
        </Container>
    );
}

export default LoginUser;
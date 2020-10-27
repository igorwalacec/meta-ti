import React, { useCallback } from 'react';
import Button from '../../components/Button';
import { Container, Descricao, Logo, Titulo } from './styles';

import logoImg from '../../assets/logoImg/drawable-hdpi/logo.png';
import { useNavigation } from '@react-navigation/native';

const SwitchLogin: React.FC = () => {
  const navigation = useNavigation();

  const acessarLoginUsuario = useCallback(() => {
    navigation.navigate('LoginUser');
  }, []);

  const acessarLoginFuncionario = useCallback(() => {
    navigation.navigate('LoginFuncionario');
  }, []);

  return (
    <Container>
      <Logo source={logoImg} />
      <Titulo>Bem vindo!</Titulo>
      <Descricao>Se identifique para começar.</Descricao>
      <Button onPress={acessarLoginUsuario}>DOADOR</Button>
      <Button onPress={acessarLoginFuncionario}>CENTRO DE COLETA</Button>
    </Container>
  );
};

export default SwitchLogin;

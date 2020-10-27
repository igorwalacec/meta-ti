import React from 'react';
import { Text, View } from 'react-native';
import Button from '../../components/Button';
import { useAuthFuncionario } from '../../hooks/funcionario/authFuncionario';

const HomeFuncionario: React.FC = () => {
    const { funcionario, signOut } = useAuthFuncionario();
    return (
        <View>
            <Text>Olá, {funcionario.nomeCompleto}</Text>
            <Button onPress={signOut}>Deslogar</Button>
        </View>
    );
}

export default HomeFuncionario;
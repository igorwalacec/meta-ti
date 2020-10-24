import React from 'react';
import { Text, View } from 'react-native';
import Button from '../../components/Button';
import { useAuth } from '../../hooks/auth';

const Home: React.FC = () => {
    const { usuario, signOut } = useAuth();
    return (
        <View>
            <Text>Olá, {usuario.nome}</Text>
            <Button onPress={signOut}>Deslogar</Button>
        </View>
    );
}

export default Home;
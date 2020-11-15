import React from 'react';
import { Text, View } from 'react-native';
import { useAuth } from '../../../hooks/auth';

const Hemocentro: React.FC = () => {
    const { usuario, signOut } = useAuth();
    return (
        <View>
            <Text>Hemocentro</Text>
        </View>
    );
}

export default Hemocentro;
import React from 'react';
import { Text, View } from 'react-native';
import { useAuth } from '../../../hooks/auth';

// const CadastroHemocentroParteDois: React.FC = ({ route, navigation }) => {
//     const { endereco, numero, longitude, latitude }: EnderecoProps = route.params;
const Hemocentro: React.FC = ({ route, navigation }) => {
    const { id } = route.params;
    return (
        <View>
            <Text>{id}</Text>
        </View>
    );
}

export default Hemocentro;
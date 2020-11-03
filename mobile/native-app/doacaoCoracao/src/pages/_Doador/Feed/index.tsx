import { useNavigation } from '@react-navigation/native';
import React from 'react';
import { Text, View } from 'react-native';
import Button from '../../../components/Button';

const Feed: React.FC = () => {
    const navigation = useNavigation();
    return (
        <View>
            <Text>FEED</Text>
            <Button onPress={() => { navigation.navigate("HemocentroDetalhes") }}>Hemocentro Detalhes</Button>
        </View>
    );
}

export default Feed;
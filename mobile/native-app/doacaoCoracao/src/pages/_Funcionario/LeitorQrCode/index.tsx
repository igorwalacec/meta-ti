import React from 'react';

import {
    StyleSheet,
    Text,
    Alert
} from 'react-native';

import QRCodeScanner from 'react-native-qrcode-scanner';
import { RNCamera } from 'react-native-camera';
import { useNavigation } from '@react-navigation/native';

const LeitorQrCode = () => {
    const navigation = useNavigation();

    const onSuccess = (e) => {
        const { data } = e;
        navigation.navigate("AgendamentoUsuario", { id: data });
    };


    return (
        <QRCodeScanner
            onRead={onSuccess}
            flashMode={RNCamera.Constants.FlashMode.off}
            topContent={
                <Text style={styles.centerText}>
                    Ler Agendamento
                </Text>
            }
        />
    );
}

export default LeitorQrCode;

const styles = StyleSheet.create({
    centerText: {
        flex: 1,
        fontSize: 18,
        padding: 32,
        color: '#777'
    },
    textBold: {
        fontWeight: '500',
        color: '#000'
    },
    buttonText: {
        fontSize: 21,
        color: 'rgb(0,122,255)'
    },
    buttonTouchable: {
        padding: 16
    }
});
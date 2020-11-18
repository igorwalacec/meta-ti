import QRCode from 'react-native-qrcode-svg';
import styled from 'styled-components/native';

export const Container = styled.View`
    background-color: #FFF;
    flex: 1;
    display: flex;
    align-items: center;
`;

export const TituloAgendamento = styled.Text`
    justify-content: center;
    align-items: center;
    text-align: center;
    font-size: 50px;
    color: #C4284D;
    margin-bottom: 50px;
`;

export const QRCodeSangue = styled(QRCode)`    
`;
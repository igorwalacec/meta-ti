import styled from 'styled-components/native';
import { RectButton } from 'react-native-gesture-handler';

export const Container = styled(RectButton)`
  width: 100%;
  height: 60px;
  background: #c4284d;
  border-radius: 5px;
  margin-top: 14px;
  justify-content: center;
  align-items: center;
`;

export const ButtonText = styled.Text`
  font-family: 'Arial';
  font-weight: bold;
  color: #fff;
  font-size: 18px;
`;

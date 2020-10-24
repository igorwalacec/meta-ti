import styled from 'styled-components/native';

export const Container = styled.View`
    flex: 1;
    background-color: #fff;
    justify-content: center;
    align-items: center;
    padding: 0 15px;
`;
export const ContainerCadastro = styled.TouchableOpacity`
    position: absolute;
    left: 0;
    bottom: 0;
    right: 0;
    background-color: #F5D2DA;
    padding: 15px 0px;
    justify-content: center;
    align-items: center;
    flex-direction: row;    
`;

export const NaoPossueConta = styled.Text`
    padding: 20px 0px 0px 0px;
    color: #C4284D;
    font-size: 14px;
`;

export const CadastroText = styled.Text`
    color: #C4284D;
    font-size: 18px;    
`;
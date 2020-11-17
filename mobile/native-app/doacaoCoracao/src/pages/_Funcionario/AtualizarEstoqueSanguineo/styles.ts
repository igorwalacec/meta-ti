import styled from 'styled-components/native';

export const Container = styled.ScrollView`
    flex: 1;
    background-color: #FFF;
    padding: 0px 20px;
    margin-bottom: 20px;
`;

export const TipoSanguineoWrapper = styled.View`
    display: flex;
    align-items: center;
    justify-content: center;
`;

export const LabelTipoSanguineo = styled.Text`
    font-size: 45px;
    color: #C4284D;
    font-weight: bold;
`;
export const Label = styled.Text`
    font-size: 15px;
    margin-top: 10px;
`;

export const TextInputSangueContainer = styled.View`
    width: 100%;
    height: 60px;
    padding: 0 16px;
    background: #FFF;    
    margin-bottom: 8px;
    border-width: 2px;
    border-color: transparent;
    border-bottom-color: #C4284D;    
    flex-direction: row;
    align-items: center;
`;
export const TextInputSangue = styled.TextInput`    
    flex: 1;
    color: #C4284D;
    font-size: 16px;
    font-family: 'Arial';
`;
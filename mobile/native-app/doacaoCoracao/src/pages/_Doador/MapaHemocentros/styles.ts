import styled from 'styled-components/native';

export const Container = styled.View`
    flex: 1;
    align-items: center;
    padding: 0px 10px;
    justify-content: center;
    background-color: #FFF;
`;

export const HemocentroContainer = styled.View`    
    position: absolute;
    width: 90%;    
    margin-left: 5%;
    border-radius: 5px;
    bottom: 10px;        
    padding: 0px 10px;        
    background-color: #C4284D;
    display: flex;
`;

export const HemocentroHeader = styled.View`
    height: 50px;    
    justify-content: center;
`;

export const HemocentroTitulo = styled.Text`
    text-align: left;
    color: #FFF;
    font-size: 18px;
    font-weight: bold;
`;

export const HemocentroBody = styled.View`
    flex-direction: row;
    height: 50px;
    align-items: center;
    padding-bottom: 10px;
`;

export const HemocentroEndereco = styled.Text`
    text-align: left;
    color: #FFF;
    font-size: 15px;
    font-weight: bold;
`;
export const HemocentroDetalhes = styled.TouchableOpacity`
    margin-left: auto;
    height: 40px;
    width: 40px;
    background-color: #FFF;
    align-items: center;
    justify-content: center;
    border-radius: 20px;
`;


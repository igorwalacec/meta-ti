import styled from 'styled-components/native';

export const Container = styled.SafeAreaView`
    display: flex;
    flex: 1;        
    align-content: center;
    background-color: #fff;
    padding: 20px 20px;
`;


export const FeedContainer = styled.View`
    min-height: 140px;
    width: 100%;
    background-color: #FFEEECE0;
    display: flex;   
    border-radius: 10px; 
    padding: 10px 10px;
    margin-bottom: 15px;
`;

export const FeedInfomacoes = styled.View`
    height: 70px;    
    justify-content: center;
`;

export const InformacaoUsuario = styled.View`
    flex-direction: row;
    align-items: center;    
    margin-bottom: 10px;
`;

export const AvatarUsuario = styled.View`
    background-color: black;
    justify-content: center;
    align-items: center;
    align-content: center;    
    width: 40px;
    height: 40px;
    border-radius: 40px;      
`;

export const NomeUsuario = styled.Text`
    margin-left: 10px;
    font-weight: bold;
`;

export const TipoSanguineoUsuario = styled.Text`
    margin-left: 10px;
    font-size: 15px;
    color: #C4284D;
    font-weight: bold;
`;

export const DataPostagem = styled.Text`
    margin-left: auto;    
    color: #C4284D;
`;
export const Detalhes = styled.Text`
    font-size: 16px;    
    text-align: justify;
`;


export const InformacoesHemocentro = styled.View`
    flex-direction: row;
    align-items: center;    
    margin-top: 25px;
`;

export const NomeHemocentro = styled.Text`
    margin-bottom: 10px;
    font-size: 18px;
    font-weight: bold;
`;

export const DetalhesHemocentro = styled.TouchableOpacity`
    margin-left: auto;
    width: 30px;
    height: 30px;
    background-color: #000;
    border-radius: 30px;
`;
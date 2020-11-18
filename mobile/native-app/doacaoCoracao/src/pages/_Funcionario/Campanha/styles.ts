import styled from 'styled-components/native';
import { Collapse } from 'accordion-collapse-react-native';

export const Container = styled.SafeAreaView`
    display: flex;
    flex: 1;        
    align-content: center;
    background-color: #fff;
    padding: 20px 20px;
`;

export const ContainerNotificacaoSemHemocentro = styled(Collapse)`
    background-color: #FFEEEC;
    margin-bottom: 10px;
`;

export const ContainerNotificacao = styled(Collapse)`
    background-color: #C4284D;
    margin-bottom: 10px;
`;

export const TituloSemNotificacao = styled.Text`      
    font-size: 16px;
    color: #C4284D; 
    font-weight: bold;
`;
export const DescricaoSemNotificacao = styled.Text`      
    font-size: 14px;
    color: #4D3C3F; 
    font-weight: bold;    
`;
export const BotaoDetalheHemocentro = styled.TouchableOpacity`
    margin-left: 15px;
    width: 60px;
    height: 60px;
    background-color: #FFF;    
    justify-content: center;
    align-items: center;
    border-radius: 30px;
`;
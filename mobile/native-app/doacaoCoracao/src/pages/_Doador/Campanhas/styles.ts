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
    font-size: 25px;
    color: #C4284D; 
    font-weight: bold;
`;

export const DescricaoWrapper = styled.View`
    flex-direction: row;
`;

export const DescricaoSemNotificacao = styled.Text`      
    font-size: 20px;
    color: #4D3C3F; 
    font-weight: bold;    
`;

export const HemocentroWrapper = styled.View`
    border-top-width: 1px;
    border-top-color: #C4284D;
    margin-top: 15px;
    padding-top: 15px;
    display: flex;
    flex-direction: row;
    justify-content: space-between;    
`;
export const HemocentroInfoWrapper = styled.View`
    flex-direction: column;    
`;

export const NomeHemocentro = styled.Text`
    font-size: 22px;
    font-weight: bold;
`;

export const EnderecoHemocentro = styled.Text`
    font-size: 15px;
    font-weight: bold;
`;

export const BotaoDetalheHemocentro = styled.TouchableOpacity`
    margin-left: 15px;
    width: 60px;
    height: 60px;
    background-color: #000;        
    border-radius: 30px;
    justify-content: center;
    align-items: center;
`;
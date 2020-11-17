import styled from 'styled-components/native';

export const Container = styled.SafeAreaView`
    flex: 1;
    background-color: #FFF;
    display: flex;
    align-items: center;    
`;

export const TituloHemocentro = styled.Text`
    margin-top: 15px;
    font-size: 50px;
    color: #C4284D;
    font-weight: bold;
    margin-bottom: 25px;
`;

export const SubTituloDetalhe = styled.Text`    
    font-size: 25px;
    color: #C4284D;
    justify-content: center;
    align-items: center;
    display: flex;
    padding-left: 10px;
    padding-right: 10px;
`;

export const ContainerDetalhes = styled.View`
    border-style: solid; 
    border-left-color: #C4284D; 
    border-left-width: 10px;
    width: 100%;
    padding-top: 15px;        
    padding-bottom: 15px;
    margin-bottom: 15px;
`;



export const ContainerEstoque = styled.View`
    border: 1px;
    border-color: #d0d0d0;
    height: 120px;
    align-items: center;
    justify-content: center;
    display:flex;
    width: 200px;
    border-radius: 10px;    
    flex-direction: row;
    margin: 15px 10px;
`;

export const TipoSanguineo = styled.Text`    
    padding-left: 25px;
    font-size: 40px;    
    font-weight: bold;
    color: #C4284D;
`;

export const CNPJDescricao = styled.Text`
    margin-top: 10px;
    margin-bottom: 10px;
    text-align: center;
    font-size: 15px;
`;
export const ExpedienteDescricao = styled.Text`
    margin-top: 5px;
    text-align: center;
    font-size: 15px;
`;
export const TelefoneDescricao = styled.Text`
    margin-top: 5px;
    text-align: center;
    font-size: 15px;
`;
export const EnderecoDescricao = styled.Text`
    margin-top: 5px;
    text-align: center;
    font-size: 15px;
`;
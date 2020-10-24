import styled, { css } from 'styled-components/native';
import FeatherIcon from 'react-native-vector-icons/Feather';
import TextInputMask from 'react-native-text-input-mask';

interface ContainerProps {
    isFocused: boolean;
    isErrored: boolean;
}

export const Container = styled.View<ContainerProps>`
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
    
    ${props =>
        props.isErrored &&
        css`
            border-color: #c53030;
        `
    }
    
    ${props =>
        props.isFocused &&
        css`
            border-bottom-color: red;
        `
    }
`;

export const TextInput = styled(TextInputMask)`
    flex: 1;
    color: #C4284D;
    font-size: 16px;
    font-family: 'Arial';
    text-transform: uppercase;
`;

export const Icon = styled(FeatherIcon)`
    margin-right: 16px;
`;

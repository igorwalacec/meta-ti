import { TouchableOpacityProps } from 'react-native';
import styled, { css } from 'styled-components/native';

interface ContainerProps {
    position: {
        left: number,
        right: number,
        bottom: number,
        top: number
    }
}


export const Container = styled.TouchableOpacity<ContainerProps>`
    position: absolute;    
    display: flex;
    align-items: center;
    justify-content: center;
    width: 60px;
    height: 60px;
    border-radius: 30px;
    background-color: #C4284D;    
    ${props =>
        props.position.top == 0 &&
        css`
            bottom: ${props.position.bottom}px;
        `
    }    
    ${props =>
        props.position.bottom == 0 &&
        css`
            top: ${props.position.top}px;
        `
    }            
    ${props =>
        props.position.left == 0 &&
        css`
            right: ${props.position.right}px;
        `
    }            
    ${props =>
        props.position.right == 0 &&
        css`
            left: ${props.position.left}px;
        `
    }                    
`;
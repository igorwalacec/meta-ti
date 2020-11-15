import React from 'react';
import { TouchableOpacityProps } from 'react-native';
import Icon from 'react-native-vector-icons/Feather';
import { Container } from './styles';

interface FloatButtonProps extends TouchableOpacityProps {
    position: {
        left: number,
        right: number,
        bottom: number,
        top: number
    },
    icon: string
}

const FloatButton: React.FC<FloatButtonProps> = ({ position, icon, ...rest }) => {
    return (
        <Container position={position} {...rest}>
            <Icon name={icon} size={20} color={'#FFF'} />
        </Container>);
};

export default FloatButton;
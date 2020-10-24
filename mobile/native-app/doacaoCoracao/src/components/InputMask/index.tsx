import React, {
    useState,
    useCallback,
    useEffect,
    useRef,
    useImperativeHandle,
    forwardRef,
} from 'react';
import { useField } from '@unform/core';

import { Container, TextInput, Icon } from './styles';
import { TextInputMaskProps } from 'react-native-text-input-mask';

interface InputProps extends TextInputMaskProps {
    name: string;
    icon: string;
    containerStyle?: object;
    useFormatted: Boolean;
}

interface InputValueReference {
    value: string;
}

interface InputRef {
    focus(): void;
}

const InputMask: React.RefForwardingComponent<InputRef, InputProps> = ({ name, icon, useFormatted = false, containerStyle = {}, ...rest }, ref) => {
    const { registerField, defaultValue = '', fieldName, error } = useField(name);

    const inputElementRef = useRef<any>(null);
    const inputValueRef = useRef<InputValueReference>({ value: defaultValue });

    const [isFocused, setIsFocused] = useState(false);
    const [isFilled, setIsFilled] = useState(false);

    const handleInputFocus = useCallback(() => {
        setIsFocused(true);
    }, []);

    const handleInputBlur = useCallback(() => {
        setIsFocused(false);
        setIsFilled(!!inputValueRef.current.value);
    }, []);

    useEffect(() => {
        inputValueRef.current.value = defaultValue;
    }, [defaultValue]);

    useImperativeHandle(ref, () => ({
        focus() {
            inputElementRef.current.focus();
        },
    }));

    useEffect(() => {
        registerField<string>({
            name: fieldName,
            ref: inputValueRef.current,
            path: 'value',
            setValue(ref: any, value: string) {
                inputValueRef.current.value = value.toUpperCase();
                inputElementRef.current.setNativeProps({ text: value.toUpperCase() });
            },
            clearValue(ref: any) {
                inputValueRef.current.value = '';
                inputElementRef.current.clear();
            },
        });
    }, [fieldName, registerField]);

    rest.onChangeText = (formatted, extracted) => {
        if (extracted != undefined) {
            if (useFormatted) {
                inputValueRef.current.value = formatted.toUpperCase();
            } else {
                inputValueRef.current.value = extracted.toUpperCase();
            }
        }
    }

    return (
        <Container isFocused={isFocused} isErrored={!!error}>
            <Icon name={icon} size={20} color={isFocused || isFilled ? '#C4284D' : '#F5D2DA'} />
            <TextInput
                ref={inputElementRef}
                keyboardAppearance="dark"
                placeholderTextColor="#C4284D"
                defaultValue={defaultValue}
                onFocus={handleInputFocus}
                onBlur={handleInputBlur}
                {...rest}
            />
        </Container>
    );
};

export default forwardRef(InputMask);

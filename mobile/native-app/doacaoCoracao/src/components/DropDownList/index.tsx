import { useField } from '@unform/core';
import React, { useEffect, useRef } from 'react';
import DropDownPicker from 'react-native-dropdown-picker';
import { DropDown } from './styles';

interface DropDownReference {
    value: string;
}

interface DropDownProps extends DropDownPicker {
    name: string;
    callback?: any;
    containerStyle?: object;
}

const DropDownList: React.FC<DropDownProps> = ({ name, callback = null, containerStyle = {}, ...rest }) => {
    const { registerField, defaultValue = '', fieldName, error } = useField(name);

    const dropDownElementRef = useRef<any>(null);
    const dropDownValueRef = useRef<DropDownReference>({ value: defaultValue });

    useEffect(() => {
        dropDownValueRef.current.value = defaultValue;
    }, [defaultValue]);



    useEffect(() => {
        registerField<string>({
            name: fieldName,
            ref: dropDownValueRef.current,
            path: 'value',
            setValue(ref: any, value: string) {
                dropDownValueRef.current.value = value;
                dropDownElementRef.current.setNativeProps({ text: value });
            },
            clearValue(ref: any) {
                dropDownValueRef.current.value = '';
                dropDownElementRef.current.clear();
            },
        });
    }, [fieldName, registerField]);

    return (
        <DropDown
            containerStyle={{ height: 50, marginTop: 10, marginBottom: 10 }}
            onChangeItem={async ({ value }) => {
                dropDownValueRef.current.value = value;
                if (callback != null || callback != undefined)
                    await callback(value);
            }}
            dropDownStyle={{ backgroundColor: '#fafafa' }}
            itemStyle={{
                justifyContent: 'flex-start'
            }}
            {...rest}
        />
    )

};

export default DropDownList;
import { FormHandles } from '@unform/core';
import { Form } from '@unform/mobile';
import React, { useCallback, useEffect, useRef, useState } from 'react'
import { Alert, ScrollView, Text } from 'react-native';
import DropDownPicker from 'react-native-dropdown-picker';
import Icon from 'react-native-vector-icons/Feather';
import { GenericCommandResult } from '../../../@types/GenericCommandResult';
import Button from '../../../components/Button';
import DropDownList from '../../../components/DropDownList';
import Input from '../../../components/Input';
import InputMask from '../../../components/InputMask';
import api from '../../../services/api';
import { Container } from './styles';

interface EnderecoProps {
    endereco: string;
    numero: string;
    latitude: number;
    longitude: number;
}
interface ResponseEstadosDTO {
    id: number;
    nome: string;
    uf: string;
}

const CadastroHemocentroParteDois: React.FC = ({ route, navigation }) => {
    const { endereco, numero, longitude, latitude }: EnderecoProps = route.params;
    const [estados, setEstados] = useState([]);
    const [cidades, setCidades] = useState([]);
    const formRef = useRef<FormHandles>(null);
    const cidadeDropdownPicker = useRef<DropDownPicker>(null);

    useEffect(() => {
        api.get<GenericCommandResult<Array<ResponseEstadosDTO>>>('Estado/obter-estados').then((response) => {
            const estadosDropDown = response.data.data.map((value) => ({
                label: value.nome,
                value: value.id,
                icon: () => <Icon name="flag" size={18} color="#900" />,
                disabled: false,
                selected: false
            }));
            setEstados([...estadosDropDown]);
        });
    }, []);

    const obterCidades = useCallback(async (value) => {
        var response = await api.get<GenericCommandResult<Array<ResponseEstadosDTO>>>(`/Cidade/obter-cidades/${value}`);

        const cidadeDropDown = response.data.data.map((value) => {
            return {
                label: value.nome,
                value: value.id,
                icon: () => <Icon name="flag" size={18} color="#900" />,
                disabled: false,
                selected: false
            };
        });
        setCidades([...cidadeDropDown]);
    }, [])

    const cadastrarHemocentro = useCallback(async (data) => {
        console.log(data);
        const cadastroRequest =
        {
            nome: data.nome,
            cnpj: data.cnpj,
            logradouro: !data.endereco ? endereco : data.endereco,
            complemento: data.complemento,
            numero: !data.numero ? numero : data.numero,
            cep: data.cep,
            latitude: latitude.toString(),
            longitude: longitude.toString(),
            idCidade: data.idCidade
        };
        console.log(cadastroRequest);
        api.post<GenericCommandResult<any>>('/Hemocentro/criar', cadastroRequest)
            .then((response) => {
                Alert.alert("Sucesso!", "Aguarde aprovação do seu hemocentro. Tente mais tarde!");
                navigation.navigate("SwitchLogin");
            }).catch(({ response }) => {
                if (response.status == 400) {
                    Alert.alert("Alerta!", "Preencha todos os campos!");
                } else {
                    Alert.alert("Error", "Erro no servidor!");
                }
            })
    }, []);

    return (
        <>
            <ScrollView keyboardShouldPersistTaps="handled">
                <Container>
                    <Form ref={formRef} onSubmit={cadastrarHemocentro}>
                        <Input
                            name="nome"
                            icon="heart"
                            placeholder="Nome"
                        />
                        <InputMask
                            useFormatted={false}
                            mask={"[99].[999].[999]/[9999]-[99]"}
                            keyboardType="number-pad"
                            onChangeText={() => { }}
                            name="cnpj"
                            icon="file"
                            placeholder="CNPJ" />
                        <DropDownList
                            searchable={true}
                            placeholder="Selecionar estado..."
                            searchablePlaceholder="Pesquisar..."
                            searchablePlaceholderTextColor="gray"
                            searchableError={() => <Text>Estado não encontrado</Text>}
                            name="estado"
                            items={estados}
                            callback={obterCidades}
                        />
                        <DropDownList
                            searchable={true}
                            placeholder="Selecionar cidade..."
                            searchablePlaceholder="Pesquisar..."
                            searchablePlaceholderTextColor="gray"
                            searchableError={() => <Text>Cidade não encontrado</Text>}
                            name="idCidade"
                            items={cidades}
                        />
                        <Input
                            name="endereco"
                            defaultValue={endereco}
                            icon="map-pin"
                            placeholder="Endereço"
                            returnKeyType="next"
                            onSubmitEditing={() => {

                            }}
                        />
                        <Input
                            name="complemento"
                            icon="map-pin"
                            placeholder="Complemento"
                            returnKeyLabel="next"
                            onSubmitEditing={() => {

                            }}
                        />
                        <Input
                            name="numero"
                            defaultValue={numero}
                            icon="map-pin"
                            placeholder="Número"
                        />
                        <InputMask
                            onChangeText={() => { }}
                            useFormatted={false}
                            keyboardType="number-pad"
                            mask={"[00].[000]-[000]"}
                            name="cep"
                            icon="navigation"
                            placeholder="CEP"
                            returnKeyType="send"
                            onSubmitEditing={() => {
                                formRef.current?.submitForm();
                            }}
                        />
                    </Form>
                    <Button onPress={() => {
                        formRef.current?.submitForm();
                    }}>Cadastrar</Button>
                </Container>
            </ScrollView>
        </>
    );

}

export default CadastroHemocentroParteDois;
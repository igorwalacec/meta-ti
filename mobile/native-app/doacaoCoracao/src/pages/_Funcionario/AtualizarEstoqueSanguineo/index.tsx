import AsyncStorage from '@react-native-community/async-storage';
import { CurrentRenderContext, useNavigation } from '@react-navigation/native';
import React, { useCallback, useEffect, useState } from 'react'
import { Alert, Slider, Text } from 'react-native';
import { not } from 'react-native-reanimated';
import { GenericCommandResult } from '../../../@types/GenericCommandResult';
import Button from '../../../components/Button';
import { TextInput } from '../../../components/Input/styles';
import { useAuthFuncionario } from '../../../hooks/funcionario/authFuncionario';
import api from '../../../services/api';
import { Container, Label, LabelTipoSanguineo, TextInputSangue, TextInputSangueContainer, TipoSanguineoWrapper } from './styles';

interface EstoqueSanguineoState {
    idTipoSanguineo: number,
    idHemocentro: string;
    quantidadeBolsas: number,
    quantidadeMinimaBolsas: number
    nome: string;
}
interface EstoqueSanguineoResponse {
    id: string;
    idTipoSanguineo: number,
    idHemocentro: string;
    quantidadeBolsas: number,
    quantidadeMinimaBolsas: number
}
const EstoqueSanguineo = () => {

    const [estoqueSanguineo, setEstoqueSanguineo] = useState<EstoqueSanguineoState[]>([] as EstoqueSanguineoState[]);
    const { funcionario } = useAuthFuncionario();
    const navigation = useNavigation();

    useEffect(() => {
        const estoqueDefault = [
            {
                idTipoSanguineo: 1,
                IdHemocentro: funcionario.idHemocentro,
                quantidadeBolsas: 0,
                quantidadeMinimaBolsas: 0,
                nome: "A+"
            }, {
                idTipoSanguineo: 2,
                IdHemocentro: funcionario.idHemocentro,
                quantidadeBolsas: 0,
                quantidadeMinimaBolsas: 0,
                nome: "A-"
            }, {
                idTipoSanguineo: 3,
                IdHemocentro: funcionario.idHemocentro,
                quantidadeBolsas: 0,
                quantidadeMinimaBolsas: 0,
                nome: "AB+"
            }, {
                idTipoSanguineo: 4,
                IdHemocentro: funcionario.idHemocentro,
                quantidadeBolsas: 0,
                quantidadeMinimaBolsas: 0,
                nome: "AB-"
            }, {
                idTipoSanguineo: 5,
                IdHemocentro: funcionario.idHemocentro,
                quantidadeBolsas: 0,
                quantidadeMinimaBolsas: 0,
                nome: "B+"
            }, {
                idTipoSanguineo: 6,
                IdHemocentro: funcionario.idHemocentro,
                quantidadeBolsas: 0,
                quantidadeMinimaBolsas: 0,
                nome: "B-"
            }, {
                idTipoSanguineo: 7,
                IdHemocentro: funcionario.idHemocentro,
                quantidadeBolsas: 0,
                quantidadeMinimaBolsas: 0,
                nome: "O+"
            }, {
                idTipoSanguineo: 8,
                IdHemocentro: funcionario.idHemocentro,
                quantidadeBolsas: 0,
                quantidadeMinimaBolsas: 0,
                nome: "O-"
            }
        ];

        obterTipoSanguineoHemocentro(estoqueDefault);
    }, []);

    const atualizarEstoqueSanguineo = async () => {
        const data = {
            dadosEstoqueSanguineo: estoqueSanguineo
        }

        const token = await AsyncStorage.getItem('@MetaTi:token');

        await api.put("/estoqueSanquineo/atualizar", data, {
            headers: {
                'authorization': `Bearer ${token}`
            }
        })

        Alert.alert("Sucesso", "Estoque atualizado com sucesso!");
        navigation.goBack();
    };

    const obterTipoSanguineoHemocentro = async (estoqueSanguineoDefault: EstoqueSanguineoState[]) => {
        const token = await AsyncStorage.getItem('@MetaTi:token');
        console.log(token);
        const response = await api.get<GenericCommandResult<EstoqueSanguineoResponse[]>>("/estoqueSanquineo", {
            headers: {
                'authorization': `Bearer ${token}`
            }
        })

        const estoqueSanguineoNovo = estoqueSanguineoDefault.map((item) => {
            const estoqueSanguineoHemocentro = response.data.data.find(x => x.idTipoSanguineo == item.idTipoSanguineo && x.id != null);
            if (estoqueSanguineoHemocentro) {
                item.quantidadeBolsas = estoqueSanguineoHemocentro.quantidadeBolsas;
                item.quantidadeMinimaBolsas = estoqueSanguineoHemocentro.quantidadeMinimaBolsas;

                return item;
            } else {
                return item;
            }
        });
        await setEstoqueSanguineo(estoqueSanguineoNovo);
    }
    return (
        <Container>
            {
                estoqueSanguineo.map(item => {
                    return (
                        <TipoSanguineoWrapper key={item.idTipoSanguineo}>
                            <LabelTipoSanguineo>{item.nome}</LabelTipoSanguineo>
                            <Label>Quantiade Bolsas: {item.quantidadeBolsas}</Label>
                            <TextInputSangueContainer>


                                <TextInputSangue
                                    value={item.quantidadeBolsas.toString()}
                                    keyboardType={"number-pad"}
                                    onChangeText={(value) => {
                                        const estoqueNovo = estoqueSanguineo.map(estoque => {
                                            if (estoque.idTipoSanguineo == item.idTipoSanguineo) {
                                                if (value == "") {
                                                    estoque.quantidadeBolsas = 0;
                                                } else {
                                                    estoque.quantidadeBolsas = parseInt(value);
                                                }
                                            }
                                            return estoque;
                                        })
                                        setEstoqueSanguineo(estoqueNovo);
                                    }}
                                />
                            </TextInputSangueContainer>

                            <Label>Quantiade Minima Bolsas: {item.quantidadeMinimaBolsas}</Label>
                            <TextInputSangueContainer>
                                <TextInputSangue
                                    value={item.quantidadeMinimaBolsas.toString()}
                                    keyboardType={"number-pad"}
                                    onChangeText={(value) => {
                                        const estoqueNovo = estoqueSanguineo.map(estoque => {
                                            if (estoque.idTipoSanguineo == item.idTipoSanguineo) {
                                                if (value == "") {
                                                    estoque.quantidadeMinimaBolsas = 0;
                                                } else {
                                                    estoque.quantidadeMinimaBolsas = parseInt(value);
                                                }
                                            }
                                            return estoque;
                                        })
                                        setEstoqueSanguineo(estoqueNovo);
                                    }}
                                /></TextInputSangueContainer>
                        </TipoSanguineoWrapper>
                    );
                })
            }
            <Button onPress={atualizarEstoqueSanguineo}>Atualizar</Button>
        </Container>
    )

}


export default EstoqueSanguineo;
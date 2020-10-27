import React, {
    createContext,
    useCallback,
    useState,
    useContext,
    useEffect,
} from 'react';
import AsyncStorage from '@react-native-community/async-storage';
import { Alert } from 'react-native';
import { GenericCommandResult } from '../../@types/GenericCommandResult';
import api from '../../services/api';

interface AuthState {
    token: string;
    funcionario: {
        id: string;
        nomeCompleto: string;
        email: string;
        idHemocentro: string;
    }
}
interface SignCredentials {
    email: string;
    senha: string;
}

interface AuthContextData {
    funcionario: {
        id: string;
        nomeCompleto: string;
        email: string;
        idHemocentro: string;
    }
    loading: boolean;
    signIn(credentials: SignCredentials): Promise<void>;
    signOut(): void;
}

interface ResponseDTO {
    funcionario: {
        id: string,
        nomeCompleto: string,
        email: string,
        idHemocentro: string
    },
    token: string;
}
interface ResponseError {
    response: {
        data: GenericCommandResult<DataError>;
        status: Number;
    }
}
interface DataError {
    Errors: [{ message: string }]
}

const AuthContext = createContext<AuthContextData>({} as AuthContextData);

const AuthProvider: React.FC = ({ children }) => {
    const [data, setData] = useState<AuthState>({} as AuthState);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        async function loadStoragedData(): Promise<void> {
            const [token, funcionario] = await AsyncStorage.multiGet([
                '@MetaTi:token',
                '@MetaTi:funcionario',
            ]);

            if (token[1] && funcionario[1]) {
                setData({ token: token[1], funcionario: JSON.parse(funcionario[1]) });
            }

            setLoading(false);
        }

        loadStoragedData();
    }, []);

    const signIn = useCallback(async ({ email, senha }) => {
        console.log(email)
        console.log(senha)
        api.post<GenericCommandResult<ResponseDTO>>(
            'Funcionario/get-token',
            {
                email: email,
                senha: senha,
            },
        ).then((response) => {
            console.log(response)
            const { token, funcionario } = response.data.data;

            AsyncStorage.multiSet([
                ['@MetaTi:token', token],
                ['@MetaTi:funcionario', JSON.stringify(funcionario)],
            ]).then(() => {
                setData({ token, funcionario });
            });
        }).catch(({ response }: ResponseError) => {
            if (response.status == 400) {
                Alert.alert("Alerta!", response.data.message);
            } else {
                Alert.alert("Error", "Erro no servidor!");
            }
        });
    }, []);

    const signOut = useCallback(async () => {
        await AsyncStorage.multiRemove(['@MetaTi:token', '@MetaTi:funcionario']);

        setData({} as AuthState);
    }, []);

    return (
        <AuthContext.Provider value={{ funcionario: data.funcionario, loading, signIn, signOut }}>
            {children}
        </AuthContext.Provider>
    );
};

function useAuthFuncionario(): AuthContextData {
    const context = useContext(AuthContext);

    if (!context) {
        throw new Error('useAuth must be use within an AuthProvider');
    }

    return context;
}

export { AuthProvider, useAuthFuncionario };

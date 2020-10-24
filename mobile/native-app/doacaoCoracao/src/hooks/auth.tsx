import React, {
    createContext,
    useCallback,
    useState,
    useContext,
    useEffect,
} from 'react';
import AsyncStorage from '@react-native-community/async-storage';
import api from '../services/api';
import { GenericCommandResult } from '../@types/GenericCommandResult';
import { Alert } from 'react-native';

interface AuthState {
    token: string;
    usuario: {
        id: string;
        nome: string;
        email: string;
    }
}
interface SignCredentials {
    email: string;
    senha: string;
}

interface AuthContextData {
    usuario: {
        id: string;
        nome: string;
        email: string;
    };
    loading: boolean;
    signIn(credentials: SignCredentials): Promise<void>;
    signOut(): void;
}

interface ResponseDTO {
    usuario: {
        id: string;
        nome: string;
        email: string;
    }
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
            const [token, usuario] = await AsyncStorage.multiGet([
                '@MetaTi:token',
                '@MetaTi:usuario',
            ]);

            if (token[1] && usuario[1]) {
                setData({ token: token[1], usuario: JSON.parse(usuario[1]) });
            }

            setLoading(false);
        }

        loadStoragedData();
    }, []);

    const signIn = useCallback(async ({ email, senha }) => {
        api.post<GenericCommandResult<ResponseDTO>>(
            'Usuario/get-token',
            {
                email: email,
                senha: senha,
            },
        ).then((response) => {
            console.log(response)
            const { token, usuario } = response.data.data;

            AsyncStorage.multiSet([
                ['@MetaTi:token', token],
                ['@MetaTi:usuario', JSON.stringify(usuario)],
            ]).then(() => {
                setData({ token, usuario });
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
        await AsyncStorage.multiRemove(['@MetaTi:token', '@MetaTi:usuario']);

        setData({} as AuthState);
    }, []);

    return (
        <AuthContext.Provider value={{ usuario: data.usuario, loading, signIn, signOut }}>
            {children}
        </AuthContext.Provider>
    );
};

function useAuth(): AuthContextData {
    const context = useContext(AuthContext);

    if (!context) {
        throw new Error('useAuth must be use within an AuthProvider');
    }

    return context;
}

export { AuthProvider, useAuth };

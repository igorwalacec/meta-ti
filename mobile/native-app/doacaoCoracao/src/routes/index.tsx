import React from 'react';
import { ActivityIndicator, View } from 'react-native';
import AuthRoutes from './auth.routes';
import AppRoutes from './doador/app.routes';
import AppRoutesFuncionario from './app.routes.funcionario';

import { useAuth } from '../hooks/auth';
import { useAuthFuncionario } from '../hooks/funcionario/authFuncionario';

const Routes: React.FC = () => {
    const { usuario, loading } = useAuth();
    const { funcionario, loading: loading2 } = useAuthFuncionario();
    
    if (loading) {
        return (
            <View style={{ flex: 1, justifyContent: 'center', alignItems: 'center' }}>
                <ActivityIndicator size="large" color="#999" />
            </View>
        );
    }
    if (loading2) {
        return (
            <View style={{ flex: 1, justifyContent: 'center', alignItems: 'center' }}>
                <ActivityIndicator size="large" color="#999" />
            </View>
        );
    }

    if (usuario) {
        return <AppRoutes />
    }
    if (funcionario) {
        return <AppRoutesFuncionario />
    } else {
        return <AuthRoutes />
    }

};

export default Routes;

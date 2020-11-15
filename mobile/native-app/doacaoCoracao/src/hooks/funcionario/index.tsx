import React from 'react';
import { AuthProvider } from './authFuncionario';

const AppProviderFuncionario: React.FC = ({ children }) => (
    <AuthProvider>{children}</AuthProvider>
);

export default AppProviderFuncionario;

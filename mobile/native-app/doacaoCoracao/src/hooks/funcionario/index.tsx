import React from 'react';
import { AuthProvider } from './authFuncionario';

const AppProvider: React.FC = ({ children }) => (
    <AuthProvider>{children}</AuthProvider>
);

export default AppProvider;

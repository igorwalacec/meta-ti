import React from 'react';
import { createStackNavigator } from '@react-navigation/stack';
import Hemocentro from '../../../pages/_Funcionario/Hemocentro';
import EstoqueSanguineo from '../../../pages/_Funcionario/AtualizarEstoqueSanguineo';
import Campanha from '../../../pages/_Funcionario/Campanha';
import CriarCampanha from '../../../pages/_Funcionario/CriarCampanha';
import LeitorQrCode from '../../../pages/_Funcionario/LeitorQrCode';
import AgendamentoUsuario from '../../../pages/_Funcionario/AgendamentoUsuario';


const App = createStackNavigator();

export const MainStackNavigator: React.FC = () => (
    <App.Navigator
        screenOptions={{
            headerTintColor: '#C4284D',
            headerStyle: { backgroundColor: '#fff', elevation: 0 }
        }}
    >
        <App.Screen name="Perfil" component={Hemocentro} />
        <App.Screen name="EstoqueSanguineo" options={{ title: "Estoque Sanguíneo" }} component={EstoqueSanguineo} />
        <App.Screen name="Campanhas" options={{ title: "Campanhas" }} component={Campanha} />
        <App.Screen name="CriarCampanha" options={{ title: "Adicionar Campanha" }} component={CriarCampanha} />
        <App.Screen name="LeitorAgendamento" options={{ title: "Leitor" }} component={LeitorQrCode} />
        <App.Screen name="AgendamentoUsuario" options={{ title: "Agendamento" }} component={AgendamentoUsuario} />
    </App.Navigator>
);
import React from 'react';
import { View, StyleSheet } from 'react-native';
import {
    Avatar,
    Title,
    Drawer,
} from 'react-native-paper';
import {
    DrawerContentScrollView,
    DrawerItem
} from '@react-navigation/drawer';
import logoImg from '../../../../assets/logoImg/drawable-hdpi/logo.png';
import IconMaterialC from 'react-native-vector-icons/MaterialIcons';
import IconMaterial from 'react-native-vector-icons/MaterialIcons';
import IconAntDesign from 'react-native-vector-icons/AntDesign';
import IconFontisto from 'react-native-vector-icons/Fontisto';
import IconEntypo from 'react-native-vector-icons/Entypo';
import IconSimple from 'react-native-vector-icons/SimpleLineIcons';
import { useAuth } from '../../../../hooks/auth';


const DrawerContent = (props) => {
    const { usuario, signOut } = useAuth();
    return (
        <View style={{ flex: 1 }}>
            <DrawerContentScrollView {...props}>
                <View style={styles.drawerContent}>
                    <View style={styles.userInfoSection}>
                        <View style={{ flexDirection: 'row', marginTop: 15 }}>
                            <Avatar.Image
                                source={logoImg}
                                size={50}
                            />
                            <View style={{ marginLeft: 15, flexDirection: 'column' }}>
                                <Title style={styles.title}>{usuario.nome}</Title>
                            </View>
                        </View>
                    </View>
                    <Drawer.Section style={styles.drawerSection}>
                        <DrawerItem
                            icon={({ color, size }) => (
                                <IconAntDesign
                                    name="calendar"
                                    color={color}
                                    size={size}
                                />
                            )}
                            label="Agendamento"
                            onPress={() => { props.navigation.navigate('Home') }}
                        />
                        <DrawerItem
                            icon={({ color, size }) => (
                                <IconEntypo
                                    name="documents"
                                    color={color}
                                    size={size}
                                />
                            )}
                            label="Campanhas"
                            onPress={() => { props.navigation.navigate('Campanhas') }}
                        />
                        <DrawerItem
                            icon={({ color, size }) => (
                                <IconAntDesign
                                    name="addusergroup"
                                    color={color}
                                    size={size}
                                />
                            )}
                            label="Convide um amigo"
                            onPress={() => { props.navigation.navigate('Home') }}
                        />
                        <DrawerItem
                            icon={({ color, size }) => (
                                <IconFontisto
                                    name="history"
                                    color={color}
                                    size={size}
                                />
                            )}
                            label="Histórico"
                            onPress={() => { props.navigation.navigate('Home') }}
                        />
                        <DrawerItem
                            icon={({ color, size }) => (
                                <IconAntDesign
                                    name="infocirlceo"
                                    color={color}
                                    size={size}
                                />
                            )}
                            label="Informativos"
                            onPress={() => { props.navigation.navigate('Home') }}
                        />
                        <DrawerItem
                            icon={({ color, size }) => (
                                <IconAntDesign
                                    name="infocirlceo"
                                    color={color}
                                    size={size}
                                />
                            )}
                            label="Orientações"
                            onPress={() => { props.navigation.navigate('Home') }}
                        />
                        <DrawerItem
                            icon={({ color, size }) => (
                                <IconSimple
                                    name="present"
                                    color={color}
                                    size={size}
                                />
                            )}
                            label="Recompensas"
                            onPress={() => { props.navigation.navigate('Home') }}
                        />
                        <DrawerItem
                            icon={({ color, size }) => (
                                <IconFontisto
                                    name="blood-test"
                                    color={color}
                                    size={size}
                                />
                            )}
                            label="Teste Aptidão"
                            onPress={() => { props.navigation.navigate('Home') }}
                        />
                        <DrawerItem
                            icon={({ color, size }) => (
                                <IconAntDesign
                                    name="infocirlceo"
                                    color={color}
                                    size={size}
                                />
                            )}
                            label="Sobre nós"
                            onPress={() => { props.navigation.navigate('Home') }}
                        />
                    </Drawer.Section>
                </View>
            </DrawerContentScrollView>
            <Drawer.Section style={styles.bottomDrawerSection}>
                <DrawerItem
                    icon={({ color, size }) => (
                        <IconMaterialC
                            name="exit-to-app"
                            color={color}
                            size={size}
                        />
                    )}
                    label="Deslogar"
                    onPress={() => { signOut() }}
                />
            </Drawer.Section>
        </View>
    );
}

const styles = StyleSheet.create({
    drawerContent: {
        flex: 1,
    },
    userInfoSection: {
        paddingLeft: 20,
    },
    title: {
        fontSize: 16,
        marginTop: 3,
        fontWeight: 'bold',
    },
    caption: {
        fontSize: 14,
        lineHeight: 14,
    },
    row: {
        marginTop: 20,
        flexDirection: 'row',
        alignItems: 'center',
    },
    section: {
        flexDirection: 'row',
        alignItems: 'center',
        marginRight: 15,
    },
    paragraph: {
        fontWeight: 'bold',
        marginRight: 3,
    },
    drawerSection: {
        marginTop: 15,
    },
    bottomDrawerSection: {
        marginBottom: 15,
        borderTopColor: '#f4f4f4',
        borderTopWidth: 1
    },
    preference: {
        flexDirection: 'row',
        justifyContent: 'space-between',
        paddingVertical: 12,
        paddingHorizontal: 16,
    },
});

export default DrawerContent;
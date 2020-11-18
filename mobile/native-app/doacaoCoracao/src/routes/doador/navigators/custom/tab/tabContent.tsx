import React from "react";
import Icon from "react-native-vector-icons/Feather";
import IconFontAwesome from "react-native-vector-icons/FontAwesome";
import { Container, ButtonTab } from "./styles";

const TabBarCustom = ({ state, descriptors, navigation }) => {

    const DeParaIcons = [
        {
            key: "Perfil",
            value: "user"
        },
        {
            key: "Notificacoes",
            value: "bell"
        },
        {
            key: "Agendamento",
            value: "qrcode"
        },
        {
            key: "MapaHemocentros",
            value: "map-pin"
        },
        {
            key: "Feed",
            value: "heart"
        }
    ];

    return (
        <Container>
            {state.routes.map((route, index) => {

                const { options } = descriptors[route.key];

                const label =
                    options.tabBarLabel !== undefined
                        ? options.tabBarLabel
                        : options.title !== undefined
                            ? options.title
                            : route.name;

                const iconName = DeParaIcons.find(x => x.key == label)?.value;


                const isFocused = state.index === index;

                const onPress = () => {
                    const event = navigation.emit({
                        type: 'tabPress',
                        target: route.key,
                    });

                    if (!isFocused && !event.defaultPrevented) {
                        navigation.navigate(route.name);
                    }
                };

                const onLongPress = () => {
                    navigation.emit({
                        type: 'tabLongPress',
                        target: route.key,
                    });
                };

                return (
                    <ButtonTab
                        key={label}
                        accessibilityRole="button"
                        accessibilityLabel={options.tabBarAccessibilityLabel}
                        testID={options.tabBarTestID}
                        onPress={onPress}
                        onLongPress={onLongPress}
                    >
                        {
                            iconName == "qrcode" && (
                                <IconFontAwesome name={iconName ? iconName : "mail"} size={45} color={isFocused ? '#C4284D' : '#C4284D'} />
                            )
                        }
                        {
                            iconName != "qrcode" && (
                                <Icon name={iconName ? iconName : "mail"} size={35} color={isFocused ? '#C4284D' : '#C4284D'} />
                            )
                        }
                    </ButtonTab>
                );
            })}
        </Container>
    );
}

export default TabBarCustom;
import { StyleSheet } from "react-native";

import EditScreenInfo from "../../components/EditScreenInfo";
import { Text, View } from "../../components/Themed";

export default function TabTwoScreen() {
  return (
    <View style={styles.container}>
      <View
        style={styles.separator}
        lightColor="#eee"
        darkColor="rgba(255,255,255,0.1)"
      />
      <Text style={styles.aboutText}>Snack App</Text>
      <Text style={styles.aboutText}>We show you snack prices </Text>
      <Text style={styles.aboutText}>You buy more snacks! </Text>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    alignItems: "center",
    justifyContent: "center",
  },
  title: {
    fontSize: 25,
    fontWeight: "bold",
  },
  separator: {
    marginVertical: 30,
    height: 1,
    width: "80%",
  },
  aboutText: {
    fontSize: 20,
    marginHorizontal: 20,
    textAlign: "center",
    marginVertical: 10,
  },
});

import { StyleSheet, FlatList } from "react-native";

import EditScreenInfo from "../../components/EditScreenInfo";
import { Text, View } from "../../components/Themed";

const products = [
  { id: "1", name: "Product 1" },
  { id: "2", name: "Product 2" },
  { id: "3", name: "Product 3" },
  // Add more products as needed
];

const ProductItem = ({ item }: { item: any }) => (
  <View>
    <Text>{item.name}</Text>
  </View>
);

export default function MainScreen() {
  return (
    <View style={styles.container}>
      <Text style={styles.title}>Tab Juicer</Text>
      <Text>Yooo testing baby</Text>
      <FlatList
        data={products}
        renderItem={ProductItem}
        keyExtractor={(item) => item.id}
      />
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
    fontSize: 20,
    fontWeight: "bold",
  },
  separator: {
    marginVertical: 30,
    height: 1,
    width: "80%",
  },
});

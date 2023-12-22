import { StyleSheet, FlatList, Image, View, Text } from "react-native";

// Mock products array
const products = [
  { id: "1", name: "Product 1", price: 10.99, image: "" },
  { id: "2", name: "Product 2", price: 12.99, image: "" },
  { id: "3", name: "Product 3", price: 9.99, image: "" },
  // Add more products as needed
];

const ProductItem = ({ item }: { item: any }) => (
  <View style={styles.item}>
    {item.image ? (
      <Image source={{ uri: item.image }} style={styles.image} />
    ) : (
      <View style={styles.placeholderImage} />
    )}
    <View style={styles.textContainer}>
      <Text style={styles.itemName}>{item.name}</Text>
      <Text style={styles.itemPrice}>${item.price}</Text>
    </View>
  </View>
);

export default function MainScreen() {
  return (
    <View style={styles.container}>
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
    backgroundColor: "#86efac",
  },
  title: {
    fontSize: 20,
    fontWeight: "bold",
    marginBottom: 10,
  },
  item: {
    flexDirection: "row",
    padding: 10,
    marginVertical: 8,
    marginHorizontal: 16,
    alignItems: "center",
    backgroundColor: "#eee",
  },
  image: {
    width: 100,
    height: 100,
    borderRadius: 50,
  },
  placeholderImage: {
    width: 100,
    height: 100,
    backgroundColor: "#ccc",
  },
  textContainer: {
    marginLeft: 10,
    flex: 1,
  },
  itemName: {
    fontSize: 16,
    fontWeight: "bold",
  },
  itemPrice: {
    fontSize: 14,
  },
});

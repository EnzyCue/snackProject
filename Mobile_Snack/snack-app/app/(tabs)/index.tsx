import { StyleSheet, FlatList, Image, View, Text } from "react-native";

const products = [
  {
    id: "1",
    name: "Product 1",
    priceWoolworths: 10.99,
    priceColes: 11.49,
    image: "",
  },
  {
    id: "2",
    name: "Product 2",
    priceWoolworths: 12.99,
    priceColes: 12.49,
    image: "",
  },
  {
    id: "3",
    name: "Product 3",
    priceWoolworths: 9.99,
    priceColes: 9.49,
    image: "",
  },
  // Add more products as needed
];

const ProductItem = ({ item }) => (
  <View style={styles.item}>
    {item.image ? (
      <Image source={{ uri: item.image }} style={styles.image} />
    ) : (
      <View style={styles.placeholderImage} />
    )}
    <View style={styles.textContainer}>
      <Text style={styles.itemName}>{item.name}</Text>
      <Text style={styles.itemPrice}>
        Woolworths: ${item.priceWoolworths.toFixed(2)}
      </Text>
      <Text style={styles.itemPrice}>Coles: ${item.priceColes.toFixed(2)}</Text>
    </View>
  </View>
);

export default function MainScreen() {
  return (
    <View style={styles.container}>
      <FlatList
        data={products}
        renderItem={({ item }) => <ProductItem item={item} />}
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
    borderRadius: 10,
    // iOS shadow properties
    shadowColor: "#000",
    shadowOffset: {
      width: 0,
      height: 5,
    },
    shadowOpacity: 0.1,
    shadowRadius: 3,
    // Android elevation
    elevation: 5,
  },

  image: {
    width: 100,
    height: 100,
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
    marginBottom: 4,
  },
});

const calculateTotalPrice = require("./calculateTotalPrice");

describe("calculateTotalPrice", () => {

    test("should return correct total for valid cart items", () => {
        // Arrange
        const cartItems = [
            { price: 100, quantity: 2 },
            { price: 50, quantity: 1 },
        ];

        // Act
        const result = calculateTotalPrice(cartItems);

        // Assert
        expect(result).toBe(250);
    });

    test("should return 0 for an empty cart", () => {
        // Arrange
        const cartItems = [];

        // Act
        const result = calculateTotalPrice(cartItems);

        // Assert
        expect(result).toBe(0);
    });

    test("should throw an error for invalid item data", () => {
        // Arrange
        const cartItems = [{ price: -10, quantity: 2 }];

        // Act & Assert
        expect(() => calculateTotalPrice(cartItems)).toThrow("Invalid item data");
    });

    test("should throw an error when cartItems is not an array", () => {
        // Arrange
        const cartItems = null;

        // Act & Assert
        expect(() => calculateTotalPrice(cartItems)).toThrow("cartItems must be an array");
    });
});
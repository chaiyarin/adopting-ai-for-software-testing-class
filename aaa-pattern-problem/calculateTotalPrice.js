function calculateTotalPrice(cartItems) {

    if (!Array.isArray(cartItems)) {
        throw new Error("cartItems must be an array");
    }

    return cartItems.reduce((total, item) => {
        if (!item.price || !item.quantity || item.price < 0 || item.quantity < 0) {
            throw new Error("Invalid item data");
        }
        return total + item.price * item.quantity;
    }, 0);

}

module.exports = calculateTotalPrice;
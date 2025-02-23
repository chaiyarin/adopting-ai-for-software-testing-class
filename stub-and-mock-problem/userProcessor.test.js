// userProcessor.test.js
const { UserService, getUserGreeting } = require("./userProcessor");

describe("UserProcessor with Stub", () => {

    it("should return a greeting message using stubbed user data", () => {
        // Create a stub for getUser method
        const userServiceStub = new UserService();
        userServiceStub.getUser = jest.fn().mockReturnValue({ id: 1, name: "Alice" });

        // Call function with stubbed data
        const greeting = getUserGreeting(userServiceStub);

        // Assertions
        expect(greeting).toBe("Hello, Alice!");
        expect(userServiceStub.getUser).toHaveBeenCalledTimes(1);
    });

});
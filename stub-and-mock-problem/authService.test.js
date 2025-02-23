// authService.test.js
const { NotificationService, handleUserLogin } = require("./authService");

describe("handleUserLogin with Mock", () => {
    it("should call sendNotification exactly once", () => {
        // Create a mock instance of NotificationService
        const notificationServiceMock = new NotificationService();
        notificationServiceMock.sendNotification = jest.fn(); // Mock the function

        // Call function that should trigger sendNotification
        handleUserLogin(notificationServiceMock);

        // Verify the mock was called once
        expect(notificationServiceMock.sendNotification).toHaveBeenCalledTimes(1);
        expect(notificationServiceMock.sendNotification).toHaveBeenCalledWith("User logged in");
    });
});
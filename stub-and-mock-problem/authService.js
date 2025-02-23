// authService.js
class NotificationService {
    sendNotification(message) {
        console.log("Sending notification:", message);
    }
}

function handleUserLogin(notificationService) {
    // Function logic
    notificationService.sendNotification("User logged in");
}

module.exports = { NotificationService, handleUserLogin };
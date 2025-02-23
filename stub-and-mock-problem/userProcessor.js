class UserService {

    getUser() {
        // This function should fetch user data, but we will stub it in the test
        return { id: 1, name: "John Doe" };
    }

}

// Function that processes user data
function getUserGreeting(userService) {

    const user = userService.getUser();
    return `Hello, ${user.name}!`; // Logic we want to test

}

module.exports = { UserService, getUserGreeting };
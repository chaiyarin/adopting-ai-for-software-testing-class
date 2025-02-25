export function isValidUsername(username) {
    if (username.length < 6 || username.length > 15) {
        return false;
    }
    if (username[0] !== username[0].toUpperCase()) {
        return false;
    }
    for (let i = 0; i < username.length; i++) {
        if (!username[i].match(/[a-zA-Z0-9]/)) {
            return false;
        }
    }
    for (let i = 0; i < username.length - 1; i++) {
        if (username[i] === username[i + 1]) {
            return false;
        }
    }
    return true;
}

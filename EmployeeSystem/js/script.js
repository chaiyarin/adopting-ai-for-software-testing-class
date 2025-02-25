import { isValidUsername } from './usernameValidation.js';

document.addEventListener('DOMContentLoaded', (event) => {
    const usernameInput = document.getElementById('usernameInput');
    usernameInput.addEventListener('input', (event) => {
        const username = event.target.value;
        console.log(username);
        if (!isValidUsername(username)) {
            usernameInput.style.borderColor = 'red';
        } else {
            usernameInput.style.borderColor = '';
        }
    });
});
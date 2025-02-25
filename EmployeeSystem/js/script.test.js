import { isValidUsername } from './usernameValidation.js';

test('valid username with capital letter and numbers', () => {
    expect(isValidUsername('JohnDoe123')).toBe(true);
});

test('valid username with minimum length', () => {
    expect(isValidUsername('JohnD1')).toBe(true);
});

test('valid username with maximum length', () => {
    expect(isValidUsername('JohnDoe1234567')).toBe(true);
});

test('invalid username with less than 6 characters', () => {
    expect(isValidUsername('John')).toBe(false);
});

test('invalid username with more than 15 characters', () => {
    expect(isValidUsername('JohnDoe1234567890')).toBe(false);
});

test('invalid username without capital letter', () => {
    expect(isValidUsername('johndoe')).toBe(false);
});

test('invalid username with special characters', () => {
    expect(isValidUsername('JohnDoe!@#')).toBe(false);
});

test('invalid username with repeated characters', () => {
    expect(isValidUsername('JohnnDoe')).toBe(false);
});

const {test, expect} = require('@playwright/test');

test('Veryfy "All Books" link is visible', async ({page}) => {
    await page.goto('http://localhost:3000/');
    await page.waitForSelector('nav.navbar');

    const allBooksLink = await page.$('a[href="/catalog"]');
    const isLinkVisible = await allBooksLink.isVisible();

    expect(isLinkVisible).toBe(true);
});

test('Veryfy "Login" button is visible', async ({page}) => {
    await page.goto('http://localhost:3000/');
    await page.waitForSelector('nav.navbar');

    const loginLink = await page.$('a[href="/login"]');
    const isLoginVisible = await loginLink.isVisible();

    expect(isLoginVisible).toBe(true);
});

test('Veryfy "Register" button is visible', async ({page}) => {
    await page.goto('http://localhost:3000/');
    await page.waitForSelector('nav.navbar');

    const registerLink = await page.$('a[href="/register"]');
    const isRegisterVisible = await registerLink.isVisible();

    expect(isRegisterVisible).toBe(true);
});

test('Veryfy "All Books" link is visible after user login', async ({page}) => {
    await userLogedIn(page);   

    const allBooksLink = await page.$('a[href="/catalog"]');
    const isLinkVisible = await allBooksLink.isVisible();

    expect(isLinkVisible).toBe(true);
});

test('Veryfy "My book" button is visible after user login', async ({page}) => {
    await userLogedIn(page);
    await page.waitForSelector('#user');

    const myBookLink = await page.$('a[href="/profile"]');
    const isVisible = await myBookLink.isVisible();

    expect(isVisible).toBe(true);
});

test('Veryfy "Add Books" button is visible after user login', async ({page}) => {
    await userLogedIn(page);
    await page.waitForSelector('#user');

    const addBookLink = await page.$('a[href="/create"]');
    const isVisible = await addBookLink.isVisible();

    expect(isVisible).toBe(true);
});

test('Veryfy "Email address" is visible after user login', async ({page}) => {
    await userLogedIn(page);
    await page.waitForSelector('#user');

    const emailAddressLink = await page.$('#user>span');
    const isVisible = await emailAddressLink.isVisible();

    expect(isVisible).toBe(true);
});

test('Login with valid credentials', async ({page}) => {
    await userLogedIn(page);    

    await page.$('a[href="/catalog"]');    

    expect(page.url()).toBe('http://localhost:3000/catalog');
});


async function userLogedIn(page) {
    await page.goto('http://localhost:3000/login');
    await page.fill('input[name="email"]', 'peter@abv.bg');
    await page.fill('input[name="password"]', '123456');
    await page.click('input[type="submit"]');
} 
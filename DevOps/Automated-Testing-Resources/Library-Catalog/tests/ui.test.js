const {test, expect} = require('@playwright/test');

const adminEmail = 'peter@abv.bg';
const adminPassword = '123456';

const userEmail = randomNumber() +'newuser@abv.bg' 
const userPassword = '111111'
const userRepeadPassword = '111111'

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
    await adminLogin(page, adminEmail, adminPassword);   

    const allBooksLink = await page.$('a[href="/catalog"]');
    const isLinkVisible = await allBooksLink.isVisible();

    expect(isLinkVisible).toBe(true);
});

test('Veryfy "My book" button is visible after user login', async ({page}) => {
    await adminLogin(page, adminEmail, adminPassword);
    await page.waitForSelector('#user');

    const myBookLink = await page.$('a[href="/profile"]');
    const isVisible = await myBookLink.isVisible();

    expect(isVisible).toBe(true);
});

test('Veryfy "Add Books" button is visible after user login', async ({page}) => {
    await adminLogin(page, adminEmail,adminPassword);
    await page.waitForSelector('#user');

    const addBookLink = await page.$('a[href="/create"]');
    const isVisible = await addBookLink.isVisible();

    expect(isVisible).toBe(true);
});

test('Veryfy "adminEmail address" is visible after user login', async ({page}) => {
    await adminLogin(page, adminEmail, adminPassword);
    await page.waitForSelector('#user');

    const adminEmailAddressLink = await page.$('#user>span');
    const isVisible = await adminEmailAddressLink.isVisible();

    expect(isVisible).toBe(true);
});

test('Login with valid credentials', async ({page}) => {
    await adminLogin(page, adminEmail, adminPassword);    

    await page.$('a[href="/catalog"]');    

    expect(page.url()).toBe('http://localhost:3000/catalog');
});

test('Login with empty form should return alert', async ({page}) => {
    await adminLogin(page, "", "");

    page.on('dalog', async dialog => {
        expect(dialog.type()).toContain('alert');
        expect(dialog.message()).toContain('All fields are required!');
        await dialog.accept();   
    })   
    
    await page.$('a[href="/login"]');    

    expect(page.url()).toBe('http://localhost:3000/login');
});

test('Login with empty adminEmail should return alert', async ({page}) => {
    await adminLogin(page, "", adminPassword);

    page.on('dalog', async dialog => {
        expect(dialog.type()).toContain('alert');
        expect(dialog.message()).toContain('All fields are required!');
        await dialog.accept();   
    })   
    
    await page.$('a[href="/login"]');    

    expect(page.url()).toBe('http://localhost:3000/login');
});

test('Login with empty adminPassword should return alert', async ({page}) => {
    await adminLogin(page, adminEmail, "");

    page.on('dalog', async dialog => {
        expect(dialog.type()).toContain('alert');
        expect(dialog.message()).toContain('All fields are required!');
        await dialog.accept();   
    })   
    
    await page.$('a[href="/login"]');    

    expect(page.url()).toBe('http://localhost:3000/login');
});

test('Register with valid credentials', async ({page}) => {
    
    await userRegister(page, userEmail, userPassword, userRepeadPassword);    

    await page.$('a[href="/catalog"]');    

    expect(page.url()).toBe('http://localhost:3000/catalog');
});

test('Register with empty fields should return alert', async ({page}) => {
    
    await userRegister(page, " ", " ", " ");
    
    page.on('dalog', async dialog => {
        expect(dialog.type()).toContain('alert');
        expect(dialog.message()).toContain('All fields are required!');
        await dialog.accept();   
    })   

    await page.$('a[href="/register"]');    

    expect(page.url()).toBe('http://localhost:3000/register');
});

async function adminLogin(page, adminEmail, adminPassword) {
    await page.goto('http://localhost:3000/login');
    await page.fill('input[name="email"]', adminEmail);
    await page.fill('input[name="password"]', adminPassword);    
    await page.click('input[type="submit"]');
} 

async function userRegister(page, userEmail, userPassword, repeatPassword) {
    await page.goto('http://localhost:3000/register');
    await page.fill('input[name="email"]', userEmail);
    await page.fill('input[name="password"]', userPassword);
    await page.fill('input[name="confirm-pass"]', repeatPassword);
    await page.click('input[type="submit"]');
} 

function randomNumber() {
    let number = Math.floor(Math.random() * 10000000000);
    return number;    
}
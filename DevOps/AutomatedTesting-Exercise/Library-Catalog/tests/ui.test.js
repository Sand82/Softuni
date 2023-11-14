const {test, expect} = require('@playwright/test');

const adminEmail = 'peter@abv.bg';
const adminPassword = '123456';

const userEmail = randomNumber() +'newuser@abv.bg' 
const userPassword = '111111'
const userRepeatPassword = '111111'

const bookTitle = 'Test Book';
const bookDescription = 'Test Book description';
const bookimageUrl = 'https://example.com/book-image.jpg';
const bookType = 'Fiction';

const URL = 'http://localhost:3000';

test('Veryfy "All Books" link is visible', async ({page}) => {
    await page.goto(URL);
    await page.waitForSelector('nav.navbar');

    const allBooksLink = await page.$('a[href="/catalog"]');
    const isLinkVisible = await allBooksLink.isVisible();

    expect(isLinkVisible).toBe(true);
});

test('Veryfy "Login" button is visible', async ({page}) => {
    await page.goto(URL);                            
    await page.waitForSelector('nav.navbar');

    const loginLink = await page.$('a[href="/login"]');
    const isLoginVisible = await loginLink.isVisible();

    expect(isLoginVisible).toBe(true);
});

test('Veryfy "Register" button is visible', async ({page}) => {
    await page.goto(URL);
    await page.waitForSelector('nav.navbar');

    const registerLink = await page.$('a[href="/register"]');
    const isRegisterVisible = await registerLink.isVisible();

    expect(isRegisterVisible).toBe(true);
});

test('Veryfy welcome email text is visible', async ({page}) => {

    await adminLogin(page, adminEmail, adminPassword);      

    const welcome = await page.textContent('#user span');
    
    expect(welcome).toBe(`Welcome, ${adminEmail}`);
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

    expect(page.url()).toBe(`${URL}/catalog`);
});

test('Login with empty form should return alert', async ({page}) => {
    await adminLogin(page, "", "");

    await alertMessage(page);
    
    await page.$('a[href="/login"]');    

    expect(page.url()).toBe(`${URL}/login`);
});

test('Login with empty adminEmail should return alert', async ({page}) => {
    await adminLogin(page, "", adminPassword);

    await alertMessage(page);
    
    await page.$('a[href="/login"]');    

    expect(page.url()).toBe(`${URL}/login`);
});

test('Login with empty adminPassword should return alert', async ({page}) => {
    await adminLogin(page, adminEmail, "");

    alertMessage(page);
    
    await page.$('a[href="/login"]');    

    expect(page.url()).toBe(`${URL}/login`);
});

test('Register with valid credentials', async ({page}) => {
    
    await userRegister(page, userEmail, userPassword, userRepeatPassword);    

    await page.$('a[href="/catalog"]');    

    expect(page.url()).toBe(`${URL}/catalog`);
});

test('Register with empty fields should return alert', async ({page}) => {
    
    await userRegister(page, " ", " ", " ");
    
    await alertMessage(page);

    await page.$('a[href="/register"]');    

    expect(page.url()).toBe(`${URL}/register`);
});

test('Register with empty email should return alert', async ({page}) => {
    
    await userRegister(page, " ", userPassword, userRepeatPassword);
    
    await alertMessage(page);

    await page.$('a[href="/register"]');    

    expect(page.url()).toBe(`${URL}/register`);
});

test('Register with empty password should return alert', async ({page}) => {
    
    await userRegister(page, userEmail, " ", userRepeatPassword);
    
    await alertMessage(page);

    await page.$('a[href="/register"]');    

    expect(page.url()).toBe(`${URL}/register`);
});

test('Register with empty repeat password should return alert', async ({page}) => {
    
    await userRegister(page, userEmail, userPassword, " ");
    
    await alertMessage(page);

    await page.$('a[href="/register"]');    

    expect(page.url()).toBe(`${URL}/register`);
});

test('Register with diferent password and repeat password should return alert', async ({page}) => {
    
    await userRegister(page, userEmail, userPassword, "123456");
    
    await alertMessage(page);

    await page.$('a[href="/register"]');    

    expect(page.url()).toBe(`${URL}/register`);
});

test('Add book with correct data', async ({page}) => {
    
    await adminLogin(page, adminEmail, adminPassword); 

    await createBook(page, bookTitle, bookDescription, bookimageUrl, bookType);    

    await page.waitForURL(`${URL}/catalog`);

    expect(page.url()).toBe(`${URL}/catalog`);    
});

test('Add book with empty title fields should return alert', async ({page}) => {
    
    await adminLogin(page, adminEmail, adminPassword); 

    await createBook(page, "", bookDescription, bookimageUrl, bookType);
    
    await alertMessage(page);

    await page.$('a[href="/create"]');

    expect(page.url()).toBe(`${URL}/create`);    
});

test('Add book with empty description fields should return alert', async ({page}) => {
    
    await adminLogin(page, adminEmail, adminPassword); 

    await createBook(page, bookTitle, "", bookimageUrl, bookType);
    
    await alertMessage(page);

    await page.$('a[href="/create"]');

    expect(page.url()).toBe(`${URL}/create`);    
});

test('Add book with empty Image Url fields should return alert', async ({page}) => {
    
    await adminLogin(page, adminEmail, adminPassword); 

    await createBook(page, bookTitle, bookDescription, "", bookType);
    
    await alertMessage(page);

    await page.$('a[href="/create"]');

    expect(page.url()).toBe(`${URL}/create`);    
});

test('Add book with empty book type fields should return alert', async ({page}) => {
    
    await adminLogin(page, adminEmail, adminPassword); 

    await createBook(page, bookTitle, bookDescription, "", bookType);
    
    await alertMessage(page);

    await page.$('a[href="/create"]');

    expect(page.url()).toBe(`${URL}/create`);    
});

test('login user see All book displayed', async ({page}) => {
    
    await adminLogin(page, adminEmail, adminPassword); 

    await page.waitForSelector('.dashboard');

    const booksElements = await page.$$('.other-books-list li');

    expect(booksElements.length).toBeGreaterThan(0);   
});

test('When book in All book are zero should return proper message', async ({page}) => {
    
    await adminLogin(page, adminEmail, adminPassword); 

    await page.waitForSelector('.dashboard');

    const noBooksMessage = await page.textContent('.no-books');

    expect(noBooksMessage).toBe('No books in database!');   
});

test('login user see Details page', async ({page}) => {
    
    await adminLogin(page, adminEmail, adminPassword);

    await page.waitForURL(`${URL}/catalog`);
    
    await page.click('a[href="/catalog"]');  
    await page.waitForSelector('.otherBooks');  
    await page.click('.otherBooks a.button');  
    await page.waitForSelector('.book-information');  

    const detailsPageTitle = await page.textContent('.book-information h3');

    expect(detailsPageTitle).toBe('Test Book');   
});

test('Guest user see Details page', async ({page}) => {    
   
    await page.goto(URL);    
    
    await page.click('a[href="/catalog"]');  
    await page.waitForSelector('.otherBooks');  
    await page.click('.otherBooks a.button');  
    await page.waitForSelector('.book-information');  

    const detailsPageTitle = await page.textContent('.book-information h3');

    expect(detailsPageTitle).not.toBeNull();   
});

test('Details page should content all information', async ({page}) => {
        
    await page.goto(URL);    
    
    await page.click('a[href="/catalog"]');  
    await page.waitForSelector('.otherBooks');  
    await page.click('.otherBooks a.button');  
    await page.waitForSelector('.book-information');  

    const detailsPageTitle = await page.textContent('.book-information h3');
    const typePageTitle = await page.textContent('.type');
    const imagePageTitle = await page.textContent('.img');

    expect(detailsPageTitle).not.toBeNull();   
    expect(typePageTitle).not.toBeNull();   
    expect(imagePageTitle).not.toBeNull();   
});

test('Details page should content like button for non creator', async ({page}) => {
        
    await userRegister(page, userEmail, userPassword, userRepeatPassword);    
    
    await page.click('a[href="/catalog"]');
    await page.waitForURL(`${URL}/catalog`);
    await page.click('.otherBooks a.button');   

    const like = await page.textContent('.actions a');
       
    expect(like).toEqual('Like');   
});

test('Details page should like button for creator', async ({page}) => {
        
    await adminLogin(page, 'john@abv.bg', adminPassword);    
    
    await page.click('a[href="/catalog"]');
    await page.waitForURL(`${URL}/catalog`);
    await page.click('.otherBooks a.button');   

    const like = await page.textContent('.actions a');
       
    expect(like).toBe('Like');   
});

test('Details page should be visible Edit and Delete buttons for creator', async ({page}) => {
        
    await adminLogin(page, 'john@abv.bg', adminPassword);    
    
    await page.click('a[href="/catalog"]');
    await page.waitForURL(`${URL}/catalog`);
    await page.click('.otherBooks a.button');   

    const editButton = await page.textContent('.actions a');    
       
    expect(editButton).toBe('Edit');       
});

test('Logout should work properly', async ({page}) => {
        
    await adminLogin(page, 'john@abv.bg', adminPassword);

    const logout = await page.$('a[href="javascript:void(0)"]');
    await logout.click();

    const redirect = page.url();
    expect(redirect).toBe(`${URL}/catalog`);   
});

async function alertMessage(page) {
    page.on('dalog', async dialog => {
        expect(dialog.type()).toContain('alert');
        expect(dialog.message()).toContain('All fields are required!');
        await dialog.accept();   
    })   
}

async function adminLogin(page, adminEmail, adminPassword) {
    await page.goto(`${URL}/login`);
    await page.fill('input[name="email"]', adminEmail);
    await page.fill('input[name="password"]', adminPassword);    
    await page.click('input[type="submit"]');
} 

async function userRegister(page, userEmail, userPassword, repeatPassword) {
    await page.goto(`${URL}/register`);
    await page.fill('input[name="email"]', userEmail);
    await page.fill('input[name="password"]', userPassword);
    await page.fill('input[name="confirm-pass"]', repeatPassword);
    await page.click('input[type="submit"]');
} 

async function createBook(page, title, description, imageUrl, type){

    await page.click('a[href="/create"]');  
    await page.waitForSelector('#create-form');
    await page.fill('#title', title);
    await page.fill('#description', description);  
    await page.fill('#image', imageUrl);
    await page.selectOption('#type', type);
    
    await page.click('#create-form input[type="submit"]')
}

function randomNumber() {
    let number = Math.floor(Math.random() * 10000000000);
    return number;    
}
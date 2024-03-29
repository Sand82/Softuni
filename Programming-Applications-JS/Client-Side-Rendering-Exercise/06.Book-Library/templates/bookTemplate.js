import { html } from '../../node_modules/lit-html/lit-html.js';
import { ifDefined } from '../../node_modules/lit-html/directives/if-defined.js';

export let allFormsTemplate = (forms) => html `${forms.map(el => formTemplate(el))}`

export let formTemplate = (form) => html`
<form @submit=${form.submitHandler} class="${ifDefined(form.class)}" id=${form.id}>
    ${form.type === 'edit'
         ? html`<input type="hidden" name="id" .value =${form.idValue}>` 
         : ''}
    <h3>${form.title}</h3>
    <label>${form.title}</label>
    <input id="title" type="text" name="title" placeholder="Title..." .value =${form.titleValue}>
    <label>AUTHOR</label>
    <input id="author" type="text" name="author" placeholder="Author..." .value =${form.authorValue}>
    <input type="submit" value=${form.submitText}>
</form>
`
export let bookTemplate = (book, editHandler,deleteHandler) => html`
<tr class="book" data-id=${book._id}>
    <td>${book.title}</td>
    <td>${book.author}</td>
    <td>
        <button class="edit" @click=${editHandler}>Edit</button>
        <button class="delete" @click=${deleteHandler}>Delete</button>
    </td>
</tr>
`
export let allBooksTemplate = (books, editHandler,deleteHandler) => html`${books.map(b => bookTemplate(b, editHandler,deleteHandler))}`;

export let tableTemplate = (books, editHandler, deleteHandler)=> html`
<table>
        <thead>
            <tr>
                <th>Title</th>
                <th>Author</th>
                <th>Action</th>
            </tr>
        </thead>
        <tbody id="books-container">
           ${allBooksTemplate(books, editHandler, deleteHandler)}
        </tbody>
    </table>
`;



export let bookLibralyTemplate = (books, forms, loadBooksHeandler, editHandler) => html`
<button id="loadBooks" @click=${loadBooksHeandler}>LOAD ALL BOOKS</button>
${tableTemplate(books, editHandler)}
${allFormsTemplate(forms)}
`
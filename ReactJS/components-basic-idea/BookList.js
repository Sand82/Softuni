import {Book} from './Book.js'

export const BookList = (props) => {
    return (
        <ul>
            <Book  
                title={props.books[0].title} 
                author={props.books[0].author} 
                description={props.books[0].description} 
            />
            <Book 
                title={props.books[1].title} 
                author={props.books[1].author} 
                description={props.books[1].description} 
            />
            <Book 
                title={props.books[2].title} 
                author={props.books[2].author} 
                description={props.books[2].description} 
            />
        </ul>
    );
} 
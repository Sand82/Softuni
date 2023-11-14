const chai =require('chai');
const chaiHttp =require('chai-http');
const server =require('./server');
const expect = chai.expect;

chai.use(chaiHttp);

describe('Book API', () => {
    let bookId;

    let id = "1";
    let title = "test Book";
    let author = "Test Author";
    let bookObject = 'object'
    let bookArray = 'array'

    it('should POST a book', (done) => {
        const book = {id : id, title: title, author: author}

        chai.request(server)
            .post('/books')
            .send(book)
            .end((err, res) => {
                if(err){
                    done();
                }
                expect(res).to.have.status(201);
                expect(res.body).to.be.a(bookObject);
                expect(res.body.id).to.be.equal(id);            
                expect(res.body.author).to.be.equal(author);
                expect(res.body.title).to.be.equal(title);
                bookId = res.body.id;
                done();
             });
    });

    it('should GET all books', (done) => {
        chai.request(server)    
            .get('/books')
            .end((err, res) => {
                if(err){
                    done();
                }
                expect(res).to.have.status(200);
                expect(res.body).to.be.a(bookArray);
                done();
            });

    });

    it('should GET Test Book', (done) => {
        chai.request(server)    
            .get(`/books/${bookId}`)
            .end((err, res) => {
                if(err){
                    done();
                }
                expect(res).to.have.status(200);
                expect(res.body).to.be.a(bookObject);
                expect(res.body.id).to.be.equal(id);            
                expect(res.body.author).to.be.equal(author);
                expect(res.body.title).to.be.equal(title);
                done();
            });

    });

    it('should Update Test Book', (done) => {

        let updatedBookAouthor = "Updated author";
        let updatedBooktitle = "Updated book";
        let updatedBook = {id : id, title: updatedBooktitle, author: updatedBookAouthor};

        chai.request(server)    
            .put(`/books/${bookId}`)
            .send(updatedBook)
            .end((err, res) => {
                if(err){
                    done();
                }
                expect(res).to.have.status(200);
                expect(res.body).to.be.a(bookObject);
                expect(res.body.id).to.be.equal(id);            
                expect(res.body.author).to.be.equal(updatedBookAouthor);
                expect(res.body.title).to.be.equal(updatedBooktitle);
                done();
            });

    });

    it('should GET, PUT or DELETE return 404 for non-existing book', (done) => {
        chai.request(server)    
            .get(`/books/400`)
            .end((err, res) => {
                if(err){
                    done();
                }
                expect(res).to.have.status(404); 
            });

        chai.request(server)    
            .put(`/books/400`)
            .send({id: "400", title: "Non existing title", author: "No exsisting author"})
            .end((err, res) => {
                if(err){
                    done();
                }
                expect(res).to.have.status(404); 
            });

        chai.request(server)    
            .delete(`/books/400`)
            .end((err, res) => {
                if(err){
                    done();
                }
                expect(res).to.have.status(404);                
                done();
            });

    });
})

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
})

using LAB_LTW_API.Data;
using LAB_LTW_API.Models.Domain;
using LAB_LTW_API.Models.DTO;

namespace LAB_LTW_API.Repositories
{
    public class SQLBookRepository : IBookRepository
    {
        private readonly AppDbContext _dbContext;
        public SQLBookRepository(AppDbContext dpContext)
        {
            _dbContext = dpContext;
        }
        public List<BookWithAuthorAndPublisherDTO> GetAllBooks(string? filterOn = null, string?
filterQuery = null,
 string? sortBy = null, bool isAscending = true, int pageNumber = 1, int
pageSize = 1000)
        {
            var allBooksDTO = _dbContext.Books.Select(book => new BookWithAuthorAndPublisherDTO
            {
                Id = book.BooksId,
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead && book.DateRead != null ? book.DateRead : null,
                Rate = book.IsRead ? book.Rate : null,
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                PublisherName = book.Publishers.Name,
                AuthorName = book.Book_Authors.Select(n => n.Authors.FullName).ToList(),
            }).AsQueryable();
            //filtering
            if (string.IsNullOrWhiteSpace(filterOn) == false &&
           string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if (filterOn.Equals("title", StringComparison.OrdinalIgnoreCase))
                {
                    allBooksDTO = allBooksDTO.Where(x => x.Title.Contains(filterQuery));
                }
            }
            //sorting
            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if (sortBy.Equals("title", StringComparison.OrdinalIgnoreCase))
                {
                    allBooksDTO = isAscending ? allBooksDTO.OrderBy(x => x.Title) :
                   allBooksDTO.OrderByDescending(x => x.Title);
                }
            }
            var skipResults = (pageNumber - 1) * pageSize;
            return allBooksDTO.Skip(skipResults).Take(pageSize).ToList();
        }

        public BookWithAuthorAndPublisherDTO GetBookById(int id)
        {
            var bookWithDomain = _dbContext.Books.Where(n => n.BooksId == id);
            //Map Domain Model to DTOs
            var bookWithIdDTO = bookWithDomain.Select(book => new BookWithAuthorAndPublisherDTO()
            {
                Id = book.BooksId,
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.DateRead,
                Rate = book.Rate,
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                PublisherName = book.Publishers.Name,
                AuthorName = book.Book_Authors.Select(n => n.Authors.FullName).ToList()
            }).FirstOrDefault();
            return bookWithIdDTO;
        }

        public AddBookRequestDTO AddBook(AddBookRequestDTO addBookRequestDTO)
        {
            var bookDomainModel = new Books
            {
                Title = addBookRequestDTO.Title,
                Description = addBookRequestDTO.Description,
                IsRead = addBookRequestDTO.IsRead,
                DateRead = addBookRequestDTO.DateReaad,
                Rate = addBookRequestDTO.Rate,
                Genre = addBookRequestDTO.Genre,
                CoverUrl = addBookRequestDTO.CoverUrl,
                DateAdded = addBookRequestDTO.DateAdded,
                PublishersId = addBookRequestDTO.PublisherID
            };
            _dbContext.Books.Add(bookDomainModel);
            _dbContext.SaveChanges();
            foreach (var id in addBookRequestDTO.AuthorIds)
            {
                var _book_author = new Book_Author()
                {
                    BooksId = bookDomainModel.BooksId,
                    AuthorsId = id
                };
                _dbContext.Books_Author.Add(_book_author);
                _dbContext.SaveChanges();
            }
            return addBookRequestDTO;
        }


        public AddBookRequestDTO? UpdateBookById(int id, AddBookRequestDTO bookDTO)
        {
            var bookDomain = _dbContext.Books.FirstOrDefault(n => n.BooksId == id);
            if (bookDomain != null)
            {
                bookDomain.Title = bookDTO.Title;
                bookDomain.Description = bookDTO.Description;
                bookDomain.IsRead = bookDTO.IsRead;
                bookDomain.DateRead = bookDTO.DateReaad;
                bookDomain.Rate = bookDTO.Rate;
                bookDomain.Genre = bookDTO.Genre;
                bookDomain.CoverUrl = bookDTO.CoverUrl;
                bookDomain.DateAdded = bookDTO.DateAdded;
                bookDomain.PublishersId = bookDTO.PublisherID;
            }
            var existingAuthors = _dbContext.Books_Author.Where(a => a.BooksId == id).ToList();
            _dbContext.Books_Author.RemoveRange(existingAuthors);

            foreach (var authorId in bookDTO.AuthorIds)
            {
                var _book_author = new Book_Author
                {
                    BooksId = id,
                    AuthorsId = authorId
                };
                _dbContext.Books_Author.Add(_book_author);
            }
            _dbContext.SaveChanges();
            return bookDTO;
        }

        public Books? DeleteBookById(int id)
        {
            var bookDomain = _dbContext.Books.FirstOrDefault(n => n.BooksId == id);
            if (bookDomain != null)
            {
                _dbContext.Books.Remove(bookDomain);
                _dbContext.SaveChanges();
            }
            return bookDomain;
        }
    }
}

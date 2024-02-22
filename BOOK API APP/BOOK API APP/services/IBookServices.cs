using BOOK_API_APP.Model;

namespace BOOK_API_APP.services
{
    public interface IBookServices
    {
        public Task<List<BookDetails>> BookListAsync();
        public Task<BookDetails> GetBookDetailsByIdAsync(string BookId);
        public Task AddBookAsync(BookDetails bookdetails);
        public Task UpdateBookAsync(string BookId,BookDetails bookdetails);
        public Task DeleteBookAsync(string BookId);

    }
}

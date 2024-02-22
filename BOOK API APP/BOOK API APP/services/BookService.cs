using BOOK_API_APP.Configuration;
using BOOK_API_APP.Model;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;
using MongoDB.Driver;


namespace BOOK_API_APP.services
{
    public class BookService:IBookServices
    {
        private readonly IMongoCollection<BookDetails> bookCollection;
        public BookService(IOptions<BookDbSettings> bookDatabaseSetting)
        {
            var mongoClient = new MongoClient(bookDatabaseSetting.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(bookDatabaseSetting.Value.DatabaseName);
            bookCollection = mongoDatabase.GetCollection<BookDetails>(bookDatabaseSetting.Value.BookCollectionName);

        }
        
        public async Task<List<BookDetails>> BookListAsync()
        {
            return await bookCollection.Find(_=>true).ToListAsync();
        }
        public async Task<BookDetails> GetBookDetailsByIdAsync(string BookId)
        {
            return await bookCollection.Find(x=>x.Id == BookId).FirstOrDefaultAsync();
        }
        public async Task AddBookAsync(BookDetails bookDetails)
        {
             await bookCollection.InsertOneAsync(bookDetails);
        }
        public  async Task UpdateBookAsync(string BookId,BookDetails bookDetails)
        {
            await bookCollection.ReplaceOneAsync(x => x.Id == BookId, bookDetails);
        }
        public async Task DeleteBookAsync(string BookId)
        {
            await bookCollection.DeleteOneAsync(x => x.Id == BookId);
        }
    }
}

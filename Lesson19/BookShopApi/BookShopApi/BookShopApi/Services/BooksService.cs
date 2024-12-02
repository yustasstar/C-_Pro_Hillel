using BookShopApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BookShopApi.Services
{
    public class BooksService
    {
        private readonly IMongoCollection<Book> _booksCollection;

        public BooksService(IOptions<BookStoreDatabaseSettings> bookStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(bookStoreDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(bookStoreDatabaseSettings.Value.DatabaseName);

            _booksCollection = mongoDatabase.GetCollection<Book>(bookStoreDatabaseSettings.Value.BooksCollectionName);
        }

        public async Task<List<Book>> GetAsync() => await _booksCollection.Find(_ => true).ToListAsync();

        public async Task<Book> GetAsync(string bookId) => await _booksCollection.Find(x => x.Id == bookId).FirstOrDefaultAsync();

        public async Task CreateAsync(Book book) => await _booksCollection.InsertOneAsync(book);

        public async Task UpdateAsync(string bookId, Book updatedBook) => await _booksCollection.ReplaceOneAsync(x => x.Id == bookId, updatedBook);

        public async Task DeleteAsync(string bookId) => await _booksCollection.DeleteOneAsync(x => x.Id == bookId);
    }
}

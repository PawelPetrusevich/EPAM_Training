namespace Service
{
    using Repository;

    public class BookService
    {
        private readonly IRepository bookListStorage;

        public BookService(string path)
        {
            this.bookListStorage = new BinnaryRepository(path);
        }
        
    }
}

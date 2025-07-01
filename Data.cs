namespace LibraryManagementSystem
{
    using static Constants;
    public class Data
    {
        public List<Book> Books { get; private set; }

        private StreamReader reader;
        private StreamWriter writer;

        public void Save()
        {
            // TODO: Implement Save functionality
            throw new NotImplementedException();
        }

        public List<Book> LoadBooks()
        {
            throw new NotImplementedException();
        }
        
    }
}

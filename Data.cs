namespace LibraryManagementSystem
{
    using System.Text.Json;
    using static Constants;
    public class Data
    {
        public List<Book> Books { get; private set; }

        private StreamReader reader;
        private StreamWriter writer;

        public Data()
        {
            LoadBooks();
        }

        public void Save()
        {
            StreamWriter writer = new StreamWriter(filePath);
            using (writer)
            {
                string jsonData = JsonSerializer.Serialize(Books);
                writer.Write(jsonData);
            }
        }

        public void LoadBooks()
        {
            Books = new List<Book>();
            try
            {
                reader = new StreamReader(filePath);
                using (reader)
                {
                    string jsonData = reader.ReadToEnd();
                    if (!string.IsNullOrEmpty(jsonData))
                    {
                        Books = JsonSerializer.Deserialize<List<Book>>(jsonData)!;
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Books = new List<Book>();
            }            
        }

        public List<Book> GetAvailableBooks()
        {
            return Books.Where(b => b.IsAvailable).ToList() ?? new List<Book>();
        }

        public List<Book> GetBorrowedBooks()
        {
            return Books.Where(b => !b.IsAvailable).ToList() ?? new List<Book>();
        }

    }
}

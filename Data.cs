namespace LibraryManagementSystem
{
    using System.Text.Json;
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

        public void LoadBooks()
        {
            reader = new StreamReader(filePath);
            using (reader)
            {
                string jsonData = reader.ReadToEnd();
                Books = JsonSerializer.Deserialize<List<Book>>(jsonData)!;
            }
            Books ??= new List<Book>();
        }
        
    }
}

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
            StreamWriter writer = new StreamWriter(filePath);
            using (writer)
            {
                string jsonData = JsonSerializer.Serialize(Books);
                writer.Write(jsonData);
            }
        }

        public List<Book> LoadBooks()
        {
            throw new NotImplementedException();
        }
        
    }
}

namespace LibraryManagementSystem
{
#nullable disable

    public class Book
    {
        public string ISBN { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public int Year { get; set; }

        public decimal Price { get; set; }

        public bool IsAvailable { get; set; }

        public string BorrowerName { get; set; }

        public Book(string title, string author, int year, decimal price)
        {
            ISBN = Guid.NewGuid().ToString(); // generate unique id for the book
            Title = title;
            Author = author;
            Year = year;
            Price = price;
            IsAvailable = true;
            BorrowerName = "";
        }
    }
}


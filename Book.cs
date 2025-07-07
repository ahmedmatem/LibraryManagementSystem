namespace LibraryManagementSystem
{
#nullable disable

    /// <summary>
    /// Model for book item in a library.
    /// </summary>
    /// <param name="title">The new title of the book.</param>
    /// <exception cref="InvalidDataException">Throws an exception if user input is invalid </throw>
    public class Book
    {
        private string title;
        private string author;
        private int year;
        private decimal price;
        private bool isAvailable;
        private string borrowerName;

        public string ISBN { get; set; }

        public string Title 
        {
            get { return title; }
            set
            {
                if (!string.IsNullOrEmpty(value.Trim()))
                {
                    title = value;
                }
                throw new InvalidDataException("Невалидно име на книга.");
            }
        }

        public string Author
        {
            get { return author; }
            set
            {
                if (!string.IsNullOrEmpty(value.Trim()))
                {
                    author = value;
                }
                throw new InvalidDataException("Невалидно име на автор.");
            }
        }

        public int Year
        {
            get { return year; }
            set
            {

                if(1800 <= year && year <= DateTime.Now.Year)
                {
                    year = value;
                    return;
                }
                throw new InvalidDataException($"Годината на издаване трябва да е между 01/01/1800 и {DateTime.Now.ToShortDateString}");
            }
        }


        public decimal Price
        {
            get { return price; }
            set
            {
                if(value <= 0)
                {
                    throw new InvalidDataException("Цената трябва да е положително число.");
                }
                price = value;
            }
        }

        public bool IsAvailable
        {
            get { return isAvailable; }
            set 
            {
                isAvailable = value;
                // if book was set as available the borrower name will be cleared automatically.
                if (isAvailable)
                {
                    borrowerName = string.Empty;
                }
            }
        }

        public string BorrowerName
        {
            get { return borrowerName; }
            set
            {
                if (!string.IsNullOrEmpty(value.Trim()))
                {
                    borrowerName = value;
                }
                throw new InvalidDataException("Невалидно име на заемател.");
            }
        }

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


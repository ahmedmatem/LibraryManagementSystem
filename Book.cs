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

        public string ISBN { get; set; }

        public string Title 
        {
            get { return title; }
            set
            {
                if (string.IsNullOrEmpty(value.Trim()))
                {
                    throw new InvalidDataException("Невалидно име на книга.");
                }

                title = value;
            }
        }

        public string Author
        {
            get { return author; }
            set
            {
                if (string.IsNullOrEmpty(value.Trim()))
                {
                    throw new InvalidDataException("Невалидно име на автор.");
                }

                author = value;
            }
        }

        public int Year
        {
            get { return year; }
            set
            {

                if(value < 1800 || DateTime.Now.Year < value)
                {
                    throw new InvalidDataException($"Годината на издаване трябва да е между 01/01/1800 и {DateTime.Now.ToShortDateString}");
                }

                year = value;
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
                    BorrowerName = string.Empty;
                }
            }
        }

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

        public override string ToString()
        {
            return !isAvailable ?
                $"{Title}, {Year}, {Author} - {BorrowerName}" :
                $"{Title}, {Year}, {Author}";
        }
    }
}


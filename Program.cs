

namespace LibraryManagementSystem
{
    public class Program
    {
        private static Data data = new Data();

        public static void Main(string[] args)
        {
            DisplayMenu();

            string choice;
            while ((choice = Console.ReadLine()) != "x")
            {
                switch (choice)
                {
                    case "1": // Add a new book
                        Book newBook = DisplayAddBookUI();
                        data.Books.Add(newBook);
                        data.Save();
                        break;
                    case "2": // Borrow a book
                        DisplayBorrowBookUI(data.GetAvailableBooks());
                        data.Save();
                        break;
                    case "3": // Return a borrowed book
                        DisplayReturnBookUI(data.GetBorrowedBooks());
                        data.Save();
                        break;
                    case "4": // List all books
                        DisplayAllBooksUI(data.Books);
                        break;
                    case "5": // List all borrowed books
                        DisplayAllBorrowedBooksUI(data.GetBorrowedBooks());
                        break;
                    default:
                        break;
                }
            }
        }

        private static void DisplayReturnBookUI(List<Book> borrowedBooks)
        {
            throw new NotImplementedException();
        }

        private static void DisplayAllBorrowedBooksUI(List<Book> borrowedBooks)
        {
            throw new NotImplementedException();
        }

        private static void DisplayAllBooksUI(List<Book> books)
        {
            throw new NotImplementedException();
        }

        private static Book DisplayBorrowBookUI(List<Book> availableBooks)
        {
            throw new NotImplementedException();
        }

        private static void DisplayMenu()
        {
            // TODO: Implement application menu
        }

        private static Book DisplayAddBookUI()
        {
            // TODO: Implement Display adding of a new book
            throw new NotImplementedException();
        }
    }
}

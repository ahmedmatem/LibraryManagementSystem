

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
                        BackToMenu("Книгата бе заета успешно.");
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
            //TODO:Ahmed
            throw new NotImplementedException();
        }

        private static void DisplayAllBorrowedBooksUI(List<Book> borrowedBooks)
        {
            //TODO:Petkova
            throw new NotImplementedException();
        }

        private static void DisplayAllBooksUI(List<Book> books)
        {
            //TODO: Petkova
            throw new NotImplementedException();
        }

        private static void DisplayBorrowBookUI(List<Book> availableBooks)
        {
            //TODO:Ahmed
            Console.WriteLine("==========[ Заемане на книга ]==========");
            Console.WriteLine();
            Console.WriteLine("Списък на всички налични книги");
            Console.WriteLine();
            int bookIndex = 0;
            foreach (var book in availableBooks)
            {
                Console.WriteLine($"{bookIndex++:d2}. {book.Title}");
            }
            Console.WriteLine();

            Console.Write("Въведете номера на книгата, която искате да заемете: ");
            int selectedBookIndex = int.Parse(Console.ReadLine()!) - 1;

            Console.Write("Име на заемателя: ");
            string borrowerName = Console.ReadLine()!;

            Book selectedBook = availableBooks[selectedBookIndex];
            selectedBook.IsAvailable = false;
            selectedBook.BorrowerName = borrowerName;
        }

        private static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("==================[ М Е Н Ю ]==================");
            Console.WriteLine("|                                              |");
            Console.WriteLine("|  [1] ▶ Добавяне на книга                     |");
            Console.WriteLine("|  [2] ▶ Заемане на книга                      |");
            Console.WriteLine("|  [3] ▶ Връщане на книга                      |");
            Console.WriteLine("|  [4] ▶ Спарвка за всички книги               |");
            Console.WriteLine("|  [5] ▶ Справка за заети книги                |");
            Console.WriteLine("|  [x] ▶ Изход                                 |");
            Console.WriteLine("|                                              |");
            Console.WriteLine("===============================================");
            Console.Write("> Изберете опция: ");
        }

        private static Book DisplayAddBookUI()
        {
            // TODO: Implement Display adding of a new book
            //TODO:Ahmed
            throw new NotImplementedException();
        }

        private static void BackToMenu(string resultMessage)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(resultMessage);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.Write("Натиснете ENTER към меню ");
            Console.ReadLine();
        }
    }
}

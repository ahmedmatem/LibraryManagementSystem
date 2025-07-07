

using System.Text;

namespace LibraryManagementSystem
{
    public class Program
    {
        private static Data data = new Data();

        public static void Main(string[] args)
        {
            SetIOEncoding();

            DisplayMenu();

            string choice;
            string message = "";
            bool success = true;
            while ((choice = Console.ReadLine()) != "x")
            {
                switch (choice)
                {
                    case "1": // Add a new book
                        try
                        {
                            // throw InvalidDataException if some invalid date was typed for a book
                            Book newBook = DisplayAddBookUI();
                            data.Books.Add(newBook);
                            data.Save();
                            message = "Успешно добавена книга.";
                            success = true;
                        }
                        catch(InvalidDataException e)
                        {
                            message = e.Message;
                            success = false;
                        }
                        BackToMenu(message, success);
                        break;
                    case "2": // Borrow a book
                        success = DisplayBorrowBookUI(data.GetAvailableBooks());
                        if (success)
                        {
                            data.Save();message = "Книгата бе заета успешно.";
                            message = "Книгата бе заета успешно.";
                        }
                        else
                        {
                            message = "Възникна грешка при заемане на книга.";
                        }
                        BackToMenu(message, success);
                        break;
                    case "3": // Return a borrowed book
                        DisplayReturnBookUI(data.GetBorrowedBooks());
                        data.Save();
                        BackToMenu("");
                        break;
                    case "4": // List all books
                        DisplayAllBooksUI(data.Books);
                        BackToMenu("");
                        break;
                    case "5": // List all borrowed books
                        DisplayAllBorrowedBooksUI(data.GetBorrowedBooks());
                        BackToMenu("");
                        break;
                    default:
                        break;
                }
            }
        }

        private static void SetIOEncoding()
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
        }

        private static void DisplayReturnBookUI(List<Book> borrowedBooks)
        {
            Console.Clear();
            Console.WriteLine("========[ Спесък на заетите книги ]==========");
            Console.WriteLine();
            int bookIndex = 0;

            if(borrowedBooks.Count == 0)
            {
                Console.WriteLine("Няма книги за връщане");
                Console.WriteLine();
                return;
            }

            foreach (Book book in borrowedBooks)
            {
                Console.WriteLine($"▶ {++bookIndex:d3}. {book}");
            }

            Console.WriteLine();
            Console.Write("Въведете номера на книгата, която искате да върнете: ");
            int selectedBookIndex;
            if(int.TryParse(Console.ReadLine()!, out selectedBookIndex))
            {
                if (selectedBookIndex - 1 < borrowedBooks.Count)
                {
                    Book selectedBook = borrowedBooks[selectedBookIndex - 1];
                    selectedBook.IsAvailable = true;
                    selectedBook.BorrowerName = "";
                    Console.WriteLine("Книгата е върната успешно.");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("[ Грешен номер на книга. ]");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("[ Грешен номер на книга. ]");
                Console.WriteLine();
            }          
        }

        private static void DisplayAllBorrowedBooksUI(List<Book> borrowedBooks)
        {
            Console.Clear();
            Console.WriteLine("========[ Спесък на заетите книги ]==========");
            Console.WriteLine();
            foreach (Book book in borrowedBooks)
            {
                Console.WriteLine($"▶ {book}");
            }

        }

        private static void DisplayAllBooksUI(List<Book> books)
        {
            Console.Clear();
            Console.WriteLine("========[ Списък на всички книги ]==========");
            Console.WriteLine();
            if(books.Count > 0)
            {
                foreach (Book book in books)
                {
                    Console.WriteLine($"▶ {book}");
                }
            }
            else
            {
                Console.WriteLine("[ Няма налични книги ]");
            }
        }

        private static bool DisplayBorrowBookUI(List<Book> availableBooks)
        {
            bool success = true;
            Console.Clear();

            Console.WriteLine("==========[ Заемане на книга ]==========");
            Console.WriteLine();
            Console.WriteLine("Списък на всички налични книги");
            Console.WriteLine();
            int bookIndex = 0;
            if(availableBooks.Count > 0)
            {
                foreach (var book in availableBooks)
                {
                    Console.WriteLine($"{++bookIndex:d2}. {book}");
                }
                Console.WriteLine();

                Console.Write("Въведете номера на книгата, която искате да заемете: ");
                int selectedBookIndex = int.Parse(Console.ReadLine()!) - 1;

                // Validate inde of selected book
                if(selectedBookIndex < availableBooks.Count)
                {
                    Console.Write("Име на заемателя: ");
                    string borrowerName = Console.ReadLine()!;

                    Book selectedBook = availableBooks[selectedBookIndex];
                    selectedBook.IsAvailable = false;
                    selectedBook.BorrowerName = borrowerName;
                }
                else
                {
                    success = false;
                    Console.WriteLine("[ Грешен номер на книга. ]");
                }
            }
            else
            {
                success = false;
                Console.WriteLine("[ Няма налични книги ]");
            }

            return success;
        }

        private static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("==================[ М Е Н Ю ]==================");
            Console.WriteLine("|                                              |");
            Console.WriteLine("|  [1] ▶ Добавяне на книга                     |");
            Console.WriteLine("|  [2] ▶ Заемане на книга                      |");
            Console.WriteLine("|  [3] ▶ Връщане на книга                      |");
            Console.WriteLine("|  [4] ▶ Спрaвка за всички книги               |");
            Console.WriteLine("|  [5] ▶ Справка за заети книги                |");
            Console.WriteLine("|  [x] ▶ Изход                                 |");
            Console.WriteLine("|                                              |");
            Console.WriteLine("===============================================");
            Console.Write("> Изберете опция: ");
        }

        private static Book DisplayAddBookUI()
        {
            Console.Clear();
            Console.WriteLine("=====[ Добави книга ]=====");
            Console.WriteLine();
            Console.Write("Въведи заглавие: "); 
            string title = Console.ReadLine();

            Console.Write("Въведи автор: ");
            string author = Console.ReadLine();
            
            Console.Write("Въведи година: ");
            int year;
            if(!int.TryParse(Console.ReadLine(), out year))
            {
                throw new InvalidDataException("Въвели сте невалидни данни за книгата.");
            }

            Console.Write("Въведи цена: ");
            decimal price;
            if(!decimal.TryParse(Console.ReadLine(), out price))
            {
                throw new InvalidDataException("Въвели сте невалидни данни за книгата.");
            }

            Console.WriteLine();
            try
            {
                Book newBook = new Book(title, author, year, price);
                return newBook;
            }
            catch(InvalidDataException e)
            {
                throw new InvalidDataException(e.Message);
            }
        }

        private static void BackToMenu(string message, bool success = true)
        {
            Console.ForegroundColor = success ? ConsoleColor.Green : ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();
            Console.Write("Натиснете ENTER към меню ");
            Console.ReadLine();
            DisplayMenu();
        }
    }
}

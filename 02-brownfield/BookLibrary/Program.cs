using BookLibrary.Services;
using BookLibrary.Models;

namespace BookLibrary;

class Program
{
    static void Main(string[] args)
    {
        var bookService = new BookService();

        Console.WriteLine("=== Book Library System ===\n");

        if (args.Length == 0)
        {
            ShowHelp();
            return;
        }

        var command = args[0].ToLower();

        try
        {
            switch (command)
            {
                case "add":
                    HandleAdd(bookService, args);
                    break;

                case "list":
                    HandleList(bookService, args);
                    break;

                case "search":
                    HandleSearch(bookService, args);
                    break;

                case "checkout":
                    HandleCheckout(bookService, args);
                    break;

                case "return":
                    HandleReturn(bookService, args);
                    break;

                case "remove":
                    HandleRemove(bookService, args);
                    break;

                default:
                    Console.WriteLine($"Unknown command: {command}");
                    ShowHelp();
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Environment.Exit(1);
        }
    }

    static void ShowHelp()
    {
        Console.WriteLine("Usage: booklibrary <command> [options]\n");
        Console.WriteLine("Commands:");
        Console.WriteLine("  add <title> <author> <isbn>     - Add a new book");
        Console.WriteLine("  list                             - List all books");
        Console.WriteLine("  search <title|author> <term>     - Search books");
        Console.WriteLine("  checkout <book-id> <borrower>    - Check out a book");
        Console.WriteLine("  return <book-id>                 - Return a book");
        Console.WriteLine("  remove <book-id>                 - Remove a book");
    }

    static void HandleAdd(BookService service, string[] args)
    {
        if (args.Length < 4)
        {
            Console.WriteLine("Usage: booklibrary add <title> <author> <isbn>");
            return;
        }

        var title = args[1];
        var author = args[2];
        var isbn = args[3];

        var book = service.AddBook(title, author, isbn);
        Console.WriteLine($"Book added successfully!");
        Console.WriteLine($"ID: {book.Id}");
        Console.WriteLine($"Title: {book.Title}");
        Console.WriteLine($"Author: {book.Author}");
    }

    static void HandleList(BookService service, string[] args)
    {
        var books = service.GetAllBooks();

        if (books.Count == 0)
        {
            Console.WriteLine("No books in the library.");
            return;
        }

        Console.WriteLine($"Total books: {books.Count}\n");
        foreach (var book in books)
        {
            PrintBook(book);
        }
    }

    static void HandleSearch(BookService service, string[] args)
    {
        if (args.Length < 3)
        {
            Console.WriteLine("Usage: booklibrary search <title|author> <term>");
            return;
        }

        var searchType = args[1].ToLower();
        var searchTerm = args[2];

        IReadOnlyList<Book> results = searchType switch
        {
            "title" => service.SearchByTitle(searchTerm),
            "author" => service.SearchByAuthor(searchTerm),
            _ => throw new ArgumentException($"Invalid search type: {searchType}. Use 'title' or 'author'.")
        };

        if (results.Count == 0)
        {
            Console.WriteLine("No books found.");
            return;
        }

        Console.WriteLine($"Found {results.Count} book(s):\n");
        foreach (var book in results)
        {
            PrintBook(book);
        }
    }

    static void HandleCheckout(BookService service, string[] args)
    {
        if (args.Length < 3)
        {
            Console.WriteLine("Usage: booklibrary checkout <book-id> <borrower>");
            return;
        }

        if (!Guid.TryParse(args[1], out var bookId))
        {
            Console.WriteLine("Invalid book ID format.");
            return;
        }

        var borrower = args[2];

        service.CheckoutBook(bookId, borrower);
        Console.WriteLine($"Book checked out successfully to {borrower}.");
    }

    static void HandleReturn(BookService service, string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: booklibrary return <book-id>");
            return;
        }

        if (!Guid.TryParse(args[1], out var bookId))
        {
            Console.WriteLine("Invalid book ID format.");
            return;
        }

        service.ReturnBook(bookId);
        Console.WriteLine("Book returned successfully.");
    }

    static void HandleRemove(BookService service, string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: booklibrary remove <book-id>");
            return;
        }

        if (!Guid.TryParse(args[1], out var bookId))
        {
            Console.WriteLine("Invalid book ID format.");
            return;
        }

        var removed = service.RemoveBook(bookId);
        if (removed)
            Console.WriteLine("Book removed successfully.");
        else
            Console.WriteLine("Book not found.");
    }

    static void PrintBook(Book book)
    {
        Console.WriteLine($"ID: {book.Id}");
        Console.WriteLine($"Title: {book.Title}");
        Console.WriteLine($"Author: {book.Author}");
        Console.WriteLine($"ISBN: {book.ISBN}");
        Console.WriteLine($"Status: {book.Status}");
        if (book.Status == BookStatus.CheckedOut)
        {
            Console.WriteLine($"Borrowed by: {book.Borrower}");
            Console.WriteLine($"Checkout date: {book.CheckoutDate:yyyy-MM-dd}");
        }
        Console.WriteLine();
    }
}

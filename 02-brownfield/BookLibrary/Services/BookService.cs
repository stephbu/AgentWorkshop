using BookLibrary.Models;

namespace BookLibrary.Services;

/// <summary>
/// Service for managing books in the library.
/// </summary>
public class BookService
{
    private readonly List<Book> _books = new();

    /// <summary>
    /// Adds a new book to the library.
    /// </summary>
    public Book AddBook(string title, string author, string isbn)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be empty", nameof(title));

        if (string.IsNullOrWhiteSpace(author))
            throw new ArgumentException("Author cannot be empty", nameof(author));

        if (string.IsNullOrWhiteSpace(isbn))
            throw new ArgumentException("ISBN cannot be empty", nameof(isbn));

        var book = new Book
        {
            Id = Guid.NewGuid(),
            Title = title,
            Author = author,
            ISBN = isbn,
            Status = BookStatus.Available,
            AddedDate = DateTime.UtcNow
        };

        _books.Add(book);
        return book;
    }

    /// <summary>
    /// Gets all books in the library.
    /// </summary>
    public IReadOnlyList<Book> GetAllBooks()
    {
        return _books.AsReadOnly();
    }

    /// <summary>
    /// Searches for books by title (case-insensitive partial match).
    /// </summary>
    public IReadOnlyList<Book> SearchByTitle(string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return new List<Book>().AsReadOnly();

        return _books
            .Where(b => b.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
            .ToList()
            .AsReadOnly();
    }

    /// <summary>
    /// Searches for books by author (case-insensitive partial match).
    /// </summary>
    public IReadOnlyList<Book> SearchByAuthor(string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return new List<Book>().AsReadOnly();

        return _books
            .Where(b => b.Author.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
            .ToList()
            .AsReadOnly();
    }

    /// <summary>
    /// Gets a book by its ID.
    /// </summary>
    public Book? GetBookById(Guid id)
    {
        return _books.FirstOrDefault(b => b.Id == id);
    }

    /// <summary>
    /// Checks out a book.
    /// </summary>
    public void CheckoutBook(Guid bookId, string borrower)
    {
        var book = GetBookById(bookId);
        if (book == null)
            throw new InvalidOperationException($"Book with ID {bookId} not found");

        if (book.Status != BookStatus.Available)
            throw new InvalidOperationException($"Book '{book.Title}' is not available for checkout");

        if (string.IsNullOrWhiteSpace(borrower))
            throw new ArgumentException("Borrower name cannot be empty", nameof(borrower));

        book.Status = BookStatus.CheckedOut;
        book.Borrower = borrower;
        book.CheckoutDate = DateTime.UtcNow;
    }

    /// <summary>
    /// Returns a checked-out book.
    /// </summary>
    public void ReturnBook(Guid bookId)
    {
        var book = GetBookById(bookId);
        if (book == null)
            throw new InvalidOperationException($"Book with ID {bookId} not found");

        if (book.Status != BookStatus.CheckedOut)
            throw new InvalidOperationException($"Book '{book.Title}' is not checked out");

        book.Status = BookStatus.Available;
        book.Borrower = null;
        book.CheckoutDate = null;
    }

    /// <summary>
    /// Removes a book from the library.
    /// </summary>
    public bool RemoveBook(Guid bookId)
    {
        var book = GetBookById(bookId);
        if (book == null)
            return false;

        if (book.Status == BookStatus.CheckedOut)
            throw new InvalidOperationException($"Cannot remove book '{book.Title}' while it is checked out");

        _books.Remove(book);
        return true;
    }

    /// <summary>
    /// Gets all books that are currently checked out.
    /// </summary>
    public IReadOnlyList<Book> GetCheckedOutBooks()
    {
        return _books
            .Where(b => b.Status == BookStatus.CheckedOut)
            .ToList()
            .AsReadOnly();
    }
}

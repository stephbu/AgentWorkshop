namespace BookLibrary.Models;

public enum BookStatus
{
    Available,
    CheckedOut,
    Reserved
}

public class Book
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string ISBN { get; set; } = string.Empty;
    public BookStatus Status { get; set; }
    public DateTime AddedDate { get; set; }
    public string? Borrower { get; set; }
    public DateTime? CheckoutDate { get; set; }
}

namespace BooksLibraryManagement.Entities;

public enum BookGenre
{
    Fiction,
    Mistery,
    Romance
}

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public BookGenre Genre { get; set; } = BookGenre.Mistery;
    public Double Price { get; set; }
    public int QuantityInStock { get; set; }
}

using BooksLibraryManagement.Entities;

namespace BooksLibraryManagement.Communication.Request;

public class RequestBookCreateJson
{
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public BookGenre Genre { get; set; }
    public Double Price { get; set; }
    public int QuantityInStock { get; set; } = 0;
}

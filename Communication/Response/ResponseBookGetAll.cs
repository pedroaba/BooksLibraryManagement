using BooksLibraryManagement.Entities;

namespace BooksLibraryManagement.Communication.Response;

public class ResponseBookGetAll
{
    public List<Book> books { get; set; } = new();
}

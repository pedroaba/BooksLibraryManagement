namespace BooksLibraryManagement.Communication.Request;

public class RequestBookUpdateJson
{
    public string Title { get; set; } = string.Empty;
    public int QuantityInStock { get; set; }
    public Double Price { get; set; }
}

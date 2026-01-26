public class BookNode
{
    public Book Data { get; set; }
    public BookNode Next { get; set; }

    public BookNode(Book book)
    {
        Data = book;
        Next = null;
    }
}

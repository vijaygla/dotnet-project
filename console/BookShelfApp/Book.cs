public class Book
{
    public int BookId { get; private set; }
    public string Title { get; private set; }
    public string Author { get; private set; }

    public Book(int bookId, string title, string author)
    {
        BookId = bookId;
        Title = title;
        Author = author;
    }
}

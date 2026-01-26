public class GenreEntry
{
    public string Genre { get; private set; }
    public BookLinkedList BookList { get; private set; }

    public GenreEntry(string genre)
    {
        Genre = genre;
        BookList = new BookLinkedList();
    }
}


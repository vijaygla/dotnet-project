public class LibraryService
{
    private CustomGenreMap genreMap;

    public LibraryService()
    {
        genreMap = new CustomGenreMap(20);
    }

    public void AddBook()
    {
        Console.Write("Enter Genre: ");
        string genre = Console.ReadLine();

        Console.Write("Enter Book Id: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Title: ");
        string title = Console.ReadLine();

        Console.Write("Enter Author: ");
        string author = Console.ReadLine();

        Book book = new Book(id, title, author);
        GenreEntry entry = genreMap.GetOrCreateGenre(genre);
        entry.BookList.AddBook(book);
    }

    public void RemoveBook()
    {
        Console.Write("Enter Genre: ");
        string genre = Console.ReadLine();

        Console.Write("Enter Book Id: ");
        int id = Convert.ToInt32(Console.ReadLine());

        GenreEntry entry = genreMap.GetOrCreateGenre(genre);
        entry.BookList.RemoveBook(id);
    }

    public void DisplayLibrary()
    {
        genreMap.DisplayLibrary();
    }
}

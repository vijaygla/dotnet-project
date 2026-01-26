public class CustomGenreMap
{
    private GenreEntry[] genreEntries;
    private int count;

    public CustomGenreMap(int size)
    {
        genreEntries = new GenreEntry[size];
        count = 0;
    }

    public GenreEntry GetOrCreateGenre(string genre)
    {
        for (int i = 0; i < count; i++)
        {
            if (genreEntries[i].Genre.Equals(genre))
            {
                return genreEntries[i];
            }
        }

        GenreEntry newEntry = new GenreEntry(genre);
        genreEntries[count] = newEntry;
        count++;
        return newEntry;
    }

    public void DisplayLibrary()
    {
        if (count == 0)
        {
            Console.WriteLine("Library is empty.");
            return;
        }

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine("\nGenre: " + genreEntries[i].Genre);
            genreEntries[i].BookList.DisplayBooks();
        }
    }
}


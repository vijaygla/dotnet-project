namespace BookBuddy
{
    internal interface IBookBuddy
    {
        void AddBook(string title, string author);
        void SortBooksAlphabetically();
        void SearchByAuthor(string author);
        void ExportBooks();
    }
}


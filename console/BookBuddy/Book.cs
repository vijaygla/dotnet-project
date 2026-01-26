namespace BookBuddy
{
    internal class Book
    {
        private string title;
        private string author;

        public Book(string title, string author)
        {
            this.title = title;
            this.author = author;
        }

        public string GetTitle()
        {
            return title;
        }

        public string GetAuthor()
        {
            return author;
        }

        public override string ToString()
        {
            return title + " - " + author;
        }
    }
}

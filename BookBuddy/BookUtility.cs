using System;
using System.Collections;

namespace BookBuddy
{
    internal class BookUtility : IBookBuddy
    {
        private ArrayList books = new ArrayList();

        // Add book
        public void AddBook(string title, string author)
        {
            string book = title + " - " + author;
            books.Add(book);
            Console.WriteLine("Book added successfully!");
        }

        // Sort books alphabetically
        public void SortBooksAlphabetically()
        {
            try
            {
                if (books.Count == 0)
                    throw new Exception("Book list is empty!");

                books.Sort();
                Console.WriteLine("Books sorted alphabetically.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Search book by author
        public void SearchByAuthor(string author)
        {
            try
            {
                if (books.Count == 0)
                    throw new Exception("No books available!");

                bool found = false;

                foreach (string book in books)
                {
                    string[] parts = book.Split(" - ");

                    if (parts.Length != 2)
                        throw new InvalidBookFormatException("Invalid book format found!");

                    if (parts[1].Equals(author, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("Found: " + parts[0] + " by " + parts[1]);
                        found = true;
                    }
                }

                if (!found)
                    Console.WriteLine("No books found for this author.");
            }
            catch (InvalidBookFormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Convert ArrayList to Array (Export)
        public void ExportBooks()
        {
            try
            {
                if (books.Count == 0)
                    throw new Exception("No books to export!");

                string[] bookArray = (string[])books.ToArray(typeof(string));

                Console.WriteLine("\nExported Books:");
                foreach (string book in bookArray)
                {
                    Console.WriteLine(book);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

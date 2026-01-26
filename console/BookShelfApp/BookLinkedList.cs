public class BookLinkedList
{
    private BookNode head;

    public void AddBook(Book book)
    {
        if (Contains(book.BookId))
        {
            Console.WriteLine("Duplicate book not allowed.");
            return;
        }

        BookNode newNode = new BookNode(book);

        if (head == null)
        {
            head = newNode;
            return;
        }

        BookNode temp = head;
        while (temp.Next != null)
        {
            temp = temp.Next;
        }
        temp.Next = newNode;
    }

    public void RemoveBook(int bookId)
    {
        if (head == null)
        {
            Console.WriteLine("No books available.");
            return;
        }

        if (head.Data.BookId == bookId)
        {
            head = head.Next;
            Console.WriteLine("Book removed successfully.");
            return;
        }

        BookNode current = head;
        while (current.Next != null)
        {
            if (current.Next.Data.BookId == bookId)
            {
                current.Next = current.Next.Next;
                Console.WriteLine("Book removed successfully.");
                return;
            }
            current = current.Next;
        }

        Console.WriteLine("Book not found.");
    }

    public bool Contains(int bookId)
    {
        BookNode temp = head;
        while (temp != null)
        {
            if (temp.Data.BookId == bookId)
                return true;
            temp = temp.Next;
        }
        return false;
    }

    public void DisplayBooks()
    {
        if (head == null)
        {
            Console.WriteLine("No books in this genre.");
            return;
        }

        BookNode temp = head;
        while (temp != null)
        {
            Console.WriteLine("BookId: " + temp.Data.BookId +
                              ", Title: " + temp.Data.Title +
                              ", Author: " + temp.Data.Author);
            temp = temp.Next;
        }
    }
}

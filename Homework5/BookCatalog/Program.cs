using System;

namespace BookCatalog
{
    class Program
    {
        static void Main(string[] args)
        {
            Catalog bookCatalog = new Catalog();

            Book book1 = new Book("book1", new DateTime(2022, 03, 01), "123-4-56-789012-3", "Author1", "Author2");
            Book book2 = new Book("book2", new DateTime(2022, 03, 01), "1234567890128", "Author3", "Author4");

            bookCatalog.AddBook(book1);
            Console.WriteLine(bookCatalog.GetBook("1234567890123").Title);

            bookCatalog.AddBook(book2);

            Console.WriteLine(bookCatalog.GetBook("123-4-56-789012-8").Title);

            var book2Authors = bookCatalog.GetBook("123-4-56-789012-8").Authors;

            foreach (var item in book2Authors)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(bookCatalog.GetBook("123-4-56-789012-8").PublicationDate?.ToShortDateString());
        }
    }
}

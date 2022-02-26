using System;
using System.Collections.Generic;
using System.Linq;

namespace BookCatalog
{
    class Catalog
    {
        private List<Book> CatalogOfBooks = new List<Book>();

        public void AddBook(Book book)
        {
            if (book is null)
            {
                throw new ArgumentNullException();
            }

            var bookAlradyInCatalog = CatalogOfBooks.Find(x => x.Equals(book));

            if (bookAlradyInCatalog is not null)
            {
                CatalogOfBooks[CatalogOfBooks.IndexOf(bookAlradyInCatalog)] = book;
            }
            else
            {
                CatalogOfBooks.Add(book);
            }
        }

        public Book GetBook(string ISBN)
        {
            ISBN = ISBN.UnifyISBN();

            foreach (var book in CatalogOfBooks)
            {
                if (book.ISBN.Equals(ISBN))
                {
                    return book;
                }
            }

            throw new Exception("There is no book with ISBN provided");
        }
    }
}

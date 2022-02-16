using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog
{
    public class Book
    {
        public string Title { get; }
        public DateTime? PublicationDate { get; }
        public HashSet<string> Authors = new HashSet<string>();
        public string ISBN { get; }

        public Book(string title, DateTime? publicationDate, string ISBN, params string[] authors)
        {

        }
    }
}

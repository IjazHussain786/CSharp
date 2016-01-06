using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultimediaShop.MultimediaItems
{
    public class Book : Item
    {
        private string author;

        public Book(string id, string title, decimal price, string author, IList<string> genres)
            : base(id, title, price, genres)
        {
            this.Author = author;
        }

        public Book(string id, string title, decimal price, string author, string genre)
            : this(id, title, price, author, new List<string> { genre })
        {
        }

        public string Author
        {
            get
            {
                return this.author;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Book author", "Book author cannot be null, empty or whitespace.");
                }
                if (value.Length < 3)
                {
                    throw new ArgumentNullException("Book author", "Book author should be at least 3 symbols long.");
                }

                this.author = value;
            }
        }
    }
}

using MultimediaShop.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultimediaShop.MultimediaItems
{
    public abstract class Item : IItem
    {
        private string id;
        private string title;
        private decimal price;
        
        public Item(string id, string title, decimal price)
        {
            this.ID = id;
            this.Title = title;
            this.Price = price;
            this.Genres = null;
        }

        public Item(string id, string title, decimal price, IList<string> genres)
            : this(id, title, price)
        {
            this.ID = id;
            this.Title = title;
            this.Price = price;
            this.Genres = genres;
        }
        
        public string ID
        {
            get
            {
                return this.id;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Item ID", "ID cannot be null, empty or whitespace.");
                }
                if (value.Length < 4)
                {
                    throw new ArgumentNullException("Item ID", "ID should be at least 4 symbols long.");
                }

                this.id = value;
            }
        }

        public string Title
        {
            get
            {
                return this.title;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Item title", "Title cannot be null, empty or whitespace.");
                }

                this.title = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Item price", "Price cannot be negative.");
                }

                this.price = value;
            }
        }

        public IList<string> Genres { get; private set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(string.Format("{0} {1}", this.GetType().Name, this.ID));
            result.AppendLine(string.Format("Title: {0:F2}", this.Title));
            result.AppendLine(string.Format("Price: {0:F2}", this.Price));
            result.AppendLine(string.Format("Genres: {0}", string.Join(", ", this.Genres)));

            return result.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultimediaShop.MultimediaItems
{
    public class Movie : Item
    {
        private int length;

        public Movie(string id, string title, decimal price, IList<string> genres, int length)
            : base(id, title, price, genres)
        {
            this.Minutes = length;
        }

        public Movie(string id, string title, decimal price, string genre, int length)
            : this(id, title, price, new List<string> { genre }, length)
        {
        }

        public int Minutes
        {
            get
            {
                return this.length;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Movie length", "Length cannot be negative.");
                }

                this.length = value;
            }
        }
    }
}

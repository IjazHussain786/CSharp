using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultimediaShop.MultimediaItems
{
    public class Game : Item
    {
        public Game(string id, string title, decimal price, IList<string> genres)
            : base(id, title, price, genres)
        {
            this.AgeRestriction = AgeRestriction.Minor;
        }

        public Game(string id, string title, decimal price, IList<string> genres, AgeRestriction ageRestriction)
            : this(id, title, price, genres)
        {
            this.AgeRestriction = ageRestriction;
        }

        public Game(string id, string title, decimal price, string genre, AgeRestriction ageRestriction)
            : this(id, title, price, new List<string> { genre }, ageRestriction)
        {
        }

        public AgeRestriction AgeRestriction { get; private set; }
    }
}

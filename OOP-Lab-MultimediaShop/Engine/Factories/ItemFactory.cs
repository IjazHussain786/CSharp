using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultimediaShop.MultimediaItems;
using MultimediaShop.Interfaces;

namespace MultimediaShop.Engine.Factories
{
    public class ItemFactory
    {
        public IItem CreateItem(string type, string itemParameters)
        {
            var itemParams = GetItemParams(itemParameters);

            switch (type)
            {
                case "book":
                    {
                        string id = itemParams["id"];
                        string title = itemParams["title"];
                        string author = itemParams["author"];
                        decimal price = decimal.Parse(itemParams["price"]);
                        string genre = itemParams["genre"];
                        return new Book(id, title, price, author, genre);
                    }
                case "video":
                    {
                        string id = itemParams["id"];
                        string title = itemParams["title"];
                        decimal price = decimal.Parse(itemParams["price"]);
                        string genre = itemParams["genre"];
                        int length = int.Parse(itemParams["length"]);
                        return new Movie(id, title, price, genre, length);
                    }
                case "game":
                    {
                        string id = itemParams["id"];
                        string title = itemParams["title"];
                        decimal price = decimal.Parse(itemParams["price"]);
                        string genre = itemParams["genre"];
                        AgeRestriction ageRestriction = ToEnum(itemParams["ageRestriction"]);
                        return new Game(id, title, price, genre, ageRestriction);
                    }
                default:
                    throw new NotSupportedException("Item type not supported.");
            }
        }

        private static IDictionary<string, string> GetItemParams(string paramsString)
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            string[] pairs = paramsString.Split('&');

            foreach (var pair in pairs)
            {
                string[] keyValuePair = pair.Split('=');
                keyValuePairs[keyValuePair[0]] = keyValuePair[1];
            }

            return keyValuePairs;
        }

        private static AgeRestriction ToEnum(string enumString)
        {
            AgeRestriction ageRestriction = (AgeRestriction)Enum.Parse(typeof(AgeRestriction), enumString);
            return ageRestriction;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultimediaShop.MultimediaItems;
using MultimediaShop.ManagingSales;
using MultimediaShop.ManagingRents;
using MultimediaShop.Interfaces;
using MultimediaShop.Engine;

namespace MultimediaShop
{
    public class MultimediaShopMain
    {
        static void Main()
        {
            ICommandManager commandManager = new CommandManager();
            IAppEngine engine = new AppEngine(commandManager);
            engine.Run();
            
            //Item sallingerBook = new Book("4adwlj4", "Catcher in the Rye", 20.00m, "J. D. Salinger", ItemGenre.Drama);
            //Item threeManBook = new Book("84djesd", "Three Men in a Boat", 39.99m, "Jerome K. Jerome", ItemGenre.ShortStory);
            //Item acGame = new Game("9gkjdsa", "AC Revelations", 78.00m, ItemGenre.RPG, AgeRestriction.Teen);
            //Item bubbleSplashGame = new Game("r8743jf", "Bubble Splash", 7.80m, ItemGenre.Action);
            //Item godfatherMovie = new Movie("483252j", "The Godfather", 99.00m, ItemGenre.Drama, 178);
            //Item dieHardMovie = new Movie("9853kfds", "Die Hard 4", 9.90m, ItemGenre.Action, 144);

            //DateTime today = DateTime.Now;
            //DateTime fiveYearsAgo = today.AddYears(-5);
            //Sale dieHardSale = new Sale(dieHardMovie, fiveYearsAgo);
            //Console.WriteLine(dieHardSale.DateOfPurchase); // 1/30/2015 2:31:55 PM (today)
            //Sale acSale = new Sale(acGame);
            //Console.WriteLine(acSale.DateOfPurchase); // 1/30/2010 2:31:55 PM


            //DateTime afterOneWeek = today.AddDays(30);
            //Rent bookRent = new Rent(sallingerBook, today, afterOneWeek);
            //Console.WriteLine(bookRent.RentState); // Pending

            //DateTime lastMonth = today.AddDays(-34);
            //DateTime lastWeek = today.AddDays(-8);
            //Rent movieRent = new Rent(godfatherMovie, lastMonth, lastWeek);
            //Console.WriteLine(movieRent.RentState); // Overdue

            //Console.WriteLine(movieRent.RentFine);
            //movieRent.ReturnItem();
            //Console.WriteLine(movieRent.RentState); // Returned
            //Console.WriteLine(movieRent.DateOfReturn); // 1/30/2015 2:41:53 PM
            //Console.WriteLine(movieRent.RentFine); // 7.9200
        }
    }
}

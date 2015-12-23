using SimpleRPGGame.Characters;
using SimpleRPGGame.Interfaces;
using SimpleRPGGame.Items;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleRPGGame;
using System.Reflection;
using SimpleRPGGame.Attributes;

namespace SimpleRPGGame.Engine
{
    class GameEngine
    {
        private const int MapWidth = 10;
        private const int MapHeight = 10;
        private const int InitialNumberOfEnemies = 10;
        private const int InitialNumberOfItems = 10;
        private static readonly Random random = new Random(); 
        private readonly IInputReader reader;
        private readonly IRenderer renderer;
        private readonly string[] characterNames = { "Pesho", "Gosho", "Vanyo", "Tseko", "Tako", "Vako"};
        private IList<GameObject> characters;
        private IList<GameObject> items;
        private Player player;
        public GameEngine(IInputReader reader, IRenderer renderer)
        {
            this.renderer = renderer;
            this.reader = reader;
            this.characters = new List<GameObject>();
            this.items = new List<GameObject>();
        }
        public bool IsRunning { get; private set; }
        public void Run()
        {
            this.IsRunning = true;
            this.renderer.WriteLine("Please enter name for player.");
            string playerName = this.reader.ReadLine();
            this.player = new Player(new Position(0, 0), 'P', 500, 100, playerName);
            this.characters.Add(this.player);
            this.PopulateEnemies();
            this.PopulateItems();
            while (IsRunning)
            {
                string command = this.reader.ReadLine();
                try
                {
                    this.ExecuteCommand(command);
                }
                catch (ArgumentOutOfRangeException aor)
                {
                    this.renderer.WriteLine(aor.Message);
                }
            }
        }

        private void PopulateEnemies()
        {
            for (int i = 0; i < InitialNumberOfEnemies; i++)
            {
               GameObject enemy = this.CreateEnemy();
                this.characters.Add(enemy);
            }
        }
        private GameObject CreateEnemy()
        {
            int currentX = random.Next(1, MapWidth);
            int currentY = random.Next(1, MapHeight);
            bool containsEnemy = this.characters.Any(e => e.Position.X == currentX && e.Position.Y == currentY);
            while (containsEnemy)
            {
                currentY = random.Next(1, MapHeight);
                currentX = random.Next(1, MapWidth);
                containsEnemy = this.characters.Any(e => e.Position.X == currentX && e.Position.Y == currentY);
            }
            int nameIndex = random.Next(0, characterNames.Length);
            string name = characterNames[nameIndex];
            var enemyTypes = Assembly.GetExecutingAssembly().GetTypes().
                Where(t => t.CustomAttributes.Any(a => a.AttributeType == typeof(EnemyAttribute))).ToArray();
            var enemyType = enemyTypes[random.Next(enemyTypes.Length)];
            GameObject character = Activator.CreateInstance(enemyType, new Position(currentX, currentY), name) as GameObject;
            return character;
        }

        private void PopulateItems()
        {
            for (int i = 0; i < InitialNumberOfItems; i++)
            {
                GameObject item = this.CreateItem();
                this.items.Add(item);
            }
        }
        private GameObject CreateItem()
        {
            int currentX = random.Next(1, MapWidth);
            int currentY = random.Next(1, MapHeight);
            bool containsItem = this.items.Any(i => i.Position.X == currentX && i.Position.Y == currentY);
            bool containsEnemy = this.characters.Any(e => e.Position.X == currentX && e.Position.Y == currentY);
            while (containsItem && containsEnemy)
            {
                currentY = random.Next(1, MapHeight);
                currentX = random.Next(1, MapWidth);
                containsItem = this.items.Any(i => i.Position.X == currentX && i.Position.Y == currentY);
                containsEnemy = this.characters.Any(e => e.Position.X == currentX && e.Position.Y == currentY);
            }
            return new HealingPotion(new Position(currentX, currentY), 10);
        }
        private void ExecuteCommand(string command)
        {
            string[] commandArgs = command.Split();
            switch (commandArgs[0])
            {
                case "help":
                    this.ExecuteHelpCommand();
                    break;
                case "map":
                    this.PrintMap();
                    break;
                case "left":
                case "right":
                case "up":
                case "down":
                    this.MovePlayer(command);
                    break;
                case "status":
                    Console.WriteLine(this.player);
                    break;
                case "heal":
                    this.player.Heal();
                    break;
                case "clear":
                    this.renderer.Clear();
                    break;
                case "exit":
                    this.IsRunning = false;
                    break;
            }
        }

        private void MovePlayer(string command)
        {
            this.player.Move(command);
            Character enemy = this.characters.Cast<Character>().FirstOrDefault(e => e.Position.X == this.player.Position.X &&
                e.Position.Y == this.player.Position.Y && e.Health > 0 && e.ObjectSymbol != this.player.ObjectSymbol);
            if (enemy != null)
            {
                this.EnterBattle(enemy);
            }
            Item item = this.items.Cast<Item>().FirstOrDefault(i => i.Position.X == this.player.Position.X &&
                i.Position.Y == this.player.Position.Y && i.ItemState == ItemState.Available);
            if (item != null)
            {
                this.player.AddItemToInventory(item);
                item.ItemState = ItemState.Collected;
                this.renderer.WriteLine("Potion collected!");
            }
        }

        private void EnterBattle(Character enemy)
        {
            while (true)
            {
                this.player.Attack(enemy);
                if (enemy.Health <= 0)
                {
                    this.renderer.WriteLine("enemy killed");
                    this.characters.Remove(enemy);
                    break;
                }
                enemy.Attack(this.player);
                if (this.player.Health <= 0)
                {
                    this.renderer.WriteLine("player died");
                    this.ExecuteCommand("exit");
                    break;
                }
            }
        }

        private void PrintMap()
        {
            StringBuilder output = new StringBuilder();
            for (int row = 0; row < MapHeight; row++)
            {
                for (int col = 0; col < MapWidth; col++)
                {
                    GameObject character = this.characters.Cast<Character>().
                        FirstOrDefault(c => c.Position.X == col && c.Position.Y == row && c.Health > 0);
                    GameObject item = this.items.Cast<Item>().
                        FirstOrDefault(i => i.Position.X == col && i.Position.Y == row && i.ItemState == ItemState.Available);
                    if (character == null & item == null)
                    {
                        output.Append(".");
                    }
                    else if (character != null)
                    {
                        output.Append(character.ObjectSymbol);
                    }
                    else
                    {
                        output.Append(item.ObjectSymbol);
                    }
                }
                output.AppendLine();
            }
            this.renderer.WriteLine(output.ToString());
        }

        private void ExecuteHelpCommand()
        {
            string helpInfo = File.ReadAllText("../../HelpInfo.txt");
            this.renderer.WriteLine(helpInfo);
        }
    }
}

namespace BookStore
{
    using BookStore.Interfaces;
    using Engine;
    using UI;

    public class BookStoreMain
    {
        public static void Main()
        {
            IRenderer renderer = new ConsoleRenderer();
            IInputHandler inputHandler = new InputHandler();
            BookStoreEngine engine = new BookStoreEngine(inputHandler, renderer);
            engine.Run();
        }
    }
}

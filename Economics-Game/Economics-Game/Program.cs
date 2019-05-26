using System;
using System.Linq;

namespace Economics_Game
{
    internal class Program
    {
        private static readonly UserInterface _userInterface;
        public static bool Exit;
        static Program()
        {
            //todo: obv these values shouldn't be empty.
            _userInterface = new UserInterface(new Firm(), Enumerable.Empty<Product>());
        }
        public static void Main(string[] args)
        {
            var timeHandler = new TimeHandler();
            
            GameLoop();

            Console.WriteLine("Thanks for playing.");
            Console.ReadLine();
        }

        private static void GameLoop()
        {
            while (!Exit)
            {
                var action = _userInterface.GetAction();
                action.ExecuteAction();
            }
        }
    }
}
using System;
using System.Linq;

namespace Economics_Game
{
    internal class Program
    {
        private static readonly UserInterface _userInterface;
        static Program()
        {
            //todo: obv these values shouldn't be empty.
            _userInterface = new UserInterface(new Firm(), Enumerable.Empty<Product>());
        }
        public static void Main(string[] args)
        {
            var timeHandler = new TimeHandler();
            
            var action = _userInterface.GetAction();
            
            action.ExecuteAction();

            Console.WriteLine("Thanks for playing.");
        }
    }
}
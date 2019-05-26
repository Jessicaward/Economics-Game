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
            _userInterface.GetAction();
        }
    }
}
using System;
using Economics_Game.Contract;

namespace Economics_Game.Test
{
    /// <summary>
    /// This is just a test class. Please only use for testing purposes
    /// </summary>
    public class FakeAction : IAction
    {
        private readonly string _name;
        public FakeAction(string name)
        {
            _name = name;
        }
        public void ExecuteAction()
        {
            Console.WriteLine($"Executing fake action: {_name}");
        }
    }
}
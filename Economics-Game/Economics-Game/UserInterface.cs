using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Economics_Game
{
    public class UserInterface
    {
        public UserInterface(Firm firm, IEnumerable<Product> products)
        {
            _mainMenuOptions = new Dictionary<int, string>
            {
                {1, "Products"},
                {2, "Staff"},
                {3, "Location"},
                {4, "Monthly report"}
            };
            _firm = firm;
            _products = products;
        }

        //todo: instead of being int, string... this could be int, tempObject, to include title and submenu?
        private readonly Dictionary<int, string> _mainMenuOptions;
        private readonly Firm _firm;
        private readonly IEnumerable<Product> _products;
        
        public void GetAction()
        {
            //This will return *something* for the game to do.
            //for example, increase price of item (which will in turn decrease demand.
            //throw new NotImplementedException();
            
            //This is not the game loop, this is just a loop to make sure the user doesn't select 
            //-2 = start state.
            //-1 = invalid input state.
            //anything above 0 is a valid menu option.
            var input = -2;
            while (input < 0)
            {
                Console.Clear();
                if (input == -1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That was an invalid input, please try again.");
                    Console.ResetColor();
                }
                WriteMenu();
                input = GetUserInput();
            }
        }

        private void WriteMenu()
        {
            if (_mainMenuOptions != null && _mainMenuOptions.Any())
            {
                foreach (var option in _mainMenuOptions)
                {
                    Console.WriteLine(option.Key + ". " + option.Value);
                }
            }
        }

        private int GetUserInput()
        {
            var input = Console.ReadLine();
            if (int.TryParse(input, out var intput))
            {
                return intput;
            }

            if (string.IsNullOrWhiteSpace(input))
            {
                return -1;
            }
            
            switch (input.ToLower())
            {
                case "products":
                    return 1;
                case "staff":
                    return 2;
                case "location":
                    return 3;
                case "monthly report":
                    return 4;
                default:
                    return -1;
            }
        }

        private string WriteProductsMenu()
        {
            
        }
    }
}
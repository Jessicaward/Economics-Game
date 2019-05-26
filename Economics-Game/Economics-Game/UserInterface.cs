using System;
using System.Collections.Generic;
using System.Linq;
using Economics_Game.Contract;
using Economics_Game.Model;
using Economics_Game.Test;

namespace Economics_Game
{
    public class UserInterface
    {
        public UserInterface(Firm firm, IEnumerable<Product> products)
        {
            //todo: populate actions
            //todo: populate submenus
            _mainMenuOptions = new List<MenuOption>
            {
                new MenuOption()
                {
                    Index = 1,
                    Option= "Products",
                    Action = new FakeAction("Products"),
                    Submenu = new List<MenuOption>()
                    {
                        new MenuOption()
                        {
                            Index = 5,
                            Option = "New product",
                            Action = new FakeAction("New Product"),
                            Submenu = null
                        },
                        new MenuOption()
                        {
                            Index = 6,
                            Option = "View existing products",
                            Action = null,
                            Submenu = null
                        }
                    }
                },
                new MenuOption()
                {
                    Index = 2,
                    Option = "Staff",
                    Action = null,
                    Submenu = new List<MenuOption>()
                    {
                        new MenuOption()
                        {
                            Index = 7,
                            Option = "Hire new staff member",
                            Action = new FakeAction("Hire new member"),
                            Submenu = null
                        },
                        new MenuOption()
                        {
                            Index = 8,
                            Option = "View existing staff members",
                            Action = null,
                            Submenu = null
                        }
                    }
                },
                new MenuOption()
                {
                    Index = 3,
                    Option = "Location",
                    Action = null,
                    Submenu = new List<MenuOption>()
                    {
                        new MenuOption()
                        {
                            Index = 9,
                            Option = "Move location",
                            Action = null,
                            Submenu = null
                        },
                        new MenuOption()
                        {
                            Index = 10,
                            Option = "View all possible locations",
                            Action = null,
                            Submenu = null
                        }
                    }
                },
                new MenuOption()
                {
                    Index = 4,
                    Option = "View monthly economic report",
                    Action = null,
                    Submenu = null
                }
            };
            
            _firm = firm;
            _products = products;
        }

        private readonly IEnumerable<MenuOption> _mainMenuOptions;
        private readonly Firm _firm;
        private readonly IEnumerable<Product> _products;
        
        public IAction GetAction()
        {
            //This will return *something* for the game to do.
            //for example, increase price of item (which will in turn decrease demand.
            
            //This is not the game loop, this is just a loop to make sure the user doesn't select 
            //-2 = start state.
            //-1 = invalid input state.
            //anything above 0 is a valid menu option.
            IAction action = null;
            var input = -2;
            var currentOptions = _mainMenuOptions;
            while (action == null)
            {
                Console.Clear();
                if (input == -1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That was an invalid input, please try again.");
                    Console.ResetColor();
                }
                
                WriteMenu(currentOptions);
                input = GetUserInput();
                var option = GetOption(input, currentOptions);

                if (option != null)
                {
                    action = option.Action;
                    currentOptions = option.Submenu;
                }
            }

            return action;
        }

        private void WriteMenu(IEnumerable<MenuOption> menu)
        {
            if (menu != null && menu.Any())
            {
                foreach (var option in menu)
                {
                    Console.WriteLine(option.Index + ". " + option.Option);
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

        //Recursive method, stay back or it will rip your head off.
        private MenuOption GetOption(int index, IEnumerable<MenuOption> options)
        {
            if (options == null || !options.Any())
            {
                return null;
            }
            foreach (var option in options)
            {
                if (option.Index == index)
                {
                    return option;
                }
                
                var action = GetOption(index, option.Submenu);
                if (action != null)
                {
                    return action;
                }
            }

            return null;
        }
    }
}
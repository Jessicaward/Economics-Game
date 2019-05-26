using System.Collections.Generic;
using Economics_Game.Contract;

namespace Economics_Game
{
    class MenuOption
    {
        public int Index { get; set; }
        public string Option { get; set; }
        public IEnumerable<MenuOption> Submenu { get; set; }
        public IAction Action { get; set; }
    }
}
using System.Collections.Generic;

namespace Economics_Game
{
    public class Firm
    {
        public string Name { get; set; }
        public FirmType Type { get; set; }
        public IEnumerable<Product> Products { get; set; } 
    }
}
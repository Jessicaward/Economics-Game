namespace Economics_Game
{
    public class Product
    {
        public string Name { get; set; }
        
        /// <summary>
        /// Percentage based
        /// 0% = nobody wants it, at all.. no buyers.
        /// 50% = 50% chance that customer will buy the product
        /// 100% = everybody wants it.. every customer buys one.
        /// </summary>
        public int Demand { get; set; }
        
        /// <summary>
        /// This will indicate the count of the product that can be made. Refreshed every week
        /// </summary>
        public int Supply { get; set; }
        public decimal Price { get; set; }
        public decimal CostToMake { get; set; }
        
        /// <summary>
        /// 1 = awful
        /// 2 = ok
        /// 3 = good
        /// 4 = fantastic
        /// </summary>
        public int QualityLevel { get; set; }
    }
}
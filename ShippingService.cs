namespace Task
{
    public class ShippingService : IShippmentHandler
    {

        public static double GetShippingCost(Dictionary<Product, int> shippingProducts)
        {
            double totalCost = 0d;
            double pricePerGramm = 2;
            foreach (var order in shippingProducts)
            {
                
                var product =order.Key;
                var quantity = order.Value;
                if (!product.IsShippable) continue;
                totalCost+= CalculateShippingFeesPerProduct(quantity,pricePerGramm,product.Weight);
            }
            return totalCost;
        }
        public static double CalculateShippingFeesPerProduct(int quantity,double pricePerGramm,double weight)
        {
            return weight * pricePerGramm * quantity;
        }
        public void GetName()
        {
            throw new NotImplementedException();
        }

        public double GetWeight()
        {
            throw new NotImplementedException();
        }
    }
}

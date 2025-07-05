using System.Collections;
using System.Text;

namespace Task
{
    public class Customer
    {
        public double Balance { get; set; }
        public Dictionary<Product,int> Cart { get; set; }= new Dictionary<Product, int>();
        
        public void Add(Product product,int quantity) {

            try
            {
                product.Order(quantity, this);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

            
        
        }
        public void CheckOut()
        {

            #region only for printing 
            StringBuilder shippingDetails = new StringBuilder();
            shippingDetails.AppendLine("** Shipment notice **");
            StringBuilder receipt = new StringBuilder();
            receipt.AppendLine("** Checkout receipt **");
            #endregion


            Dictionary<Product, int> shippingProducts = new Dictionary<Product, int>();
            double cartWeight = 0d;
            double subTotal = 0d;
            foreach (var order in Cart)
            {
                var product = order.Key;
                var quantity=order.Value;
                var productTotalCost=product.Price * quantity;
                subTotal += productTotalCost;

                if (product.IsShippable)
                {
                    shippingProducts.Add(product,quantity);
                    double productTotalWeight =( product.Weight * quantity);
                    cartWeight += productTotalWeight;
                    shippingDetails.AppendLine($"{quantity}x {product.Name,-20} {productTotalWeight,-3}g");
                }
                receipt.AppendLine($"{quantity}x {product.Name,-20}     {productTotalCost,-3}");

            }
            var shippingCost = ShippingService.GetShippingCost(shippingProducts);


            #region only for printing
            receipt.AppendLine("----------------------");
            receipt.AppendLine($"{"Subtotal",-8} {subTotal,-3}");
            receipt.AppendLine($"{"Shipping",-8} {shippingCost,-3}");
            receipt.AppendLine($"{"Amount",-8} {subTotal+shippingCost,-3}");
            Console.WriteLine(shippingDetails.ToString());
            Console.WriteLine(receipt.ToString());
            #endregion

        }

       
    }
}

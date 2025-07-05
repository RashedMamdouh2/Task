using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public class Product
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public int  Quantity { get; set; }
        public bool CanExpire { get; set; }
        public DateTime ExpiryDate { get; set; }=DateTime.Now.AddYears(2);
        public bool IsShippable { get; set; }
        public float Weight { get; set; }
        public void Order(int quantity, Customer customer)
        {
            ValidateExpiryDate();
            ValidateQuantity(quantity);
            
            ValidateCustomerBalance(quantity,customer);

            ManageCustomerCart(quantity,customer);
            
            
        }

        private void ManageCustomerCart(int quantity, Customer customer)
        {
            this.Quantity -= quantity;
            customer.Balance -= CalculateCost(quantity); ;

            if (customer.Cart.ContainsKey(this))
            {
                customer.Cart[this] += quantity;
            }
            else
            {
                customer.Cart.Add(this, quantity);

            }
        }

        private void ValidateCustomerBalance(int quantity, Customer customer)

        {
            double TotalCost = CalculateCost(quantity);
            double shippingFees = 0d;
            if (this.IsShippable)
            {
                shippingFees += ShippingService.CalculateShippingFeesPerProduct(quantity, pricePerGramm: 2, this.Weight);
            }

            if( customer.Balance < TotalCost+shippingFees)
            {
                throw new Exception(message: "Customer doesn't have enough balance");

            }
        }

        private void ValidateQuantity(int quantity)
        {
            if(quantity > this.Quantity)
            {
                throw new Exception(message: "There Is No Enough Quantity Of This Product");

            }
        }

        private void ValidateExpiryDate()
        {
            if(CanExpire && DateTime.Now.CompareTo(ExpiryDate) >= 0)
            {
                throw new Exception($"{Name} is Expired");

            }
        }
        private float CalculateCost(int quantity)
        {
            return quantity * this.Price;
        }

        public override bool Equals(object? obj)
        {
            var product2 = obj as Product;
            if (product2 is  null)
            {
                return false;
            }
            return string.Equals(this.Name,product2.Name);
        }
        public override int GetHashCode()
        {
            int hash = 17;
            hash += this.Name.GetHashCode() * 23;
            return hash;
        }

    }
}

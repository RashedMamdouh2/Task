using Task;
using Task.Entities;

public static class Program
{

    public static void Main(string[] args) { 
    
    
    
    
    
            Product biscuits = new Product {     Name= "Biscuits",             CanExpire=true,IsShippable=true,Price=5f,Quantity=30,Weight=1};
            Product cheese = new Product {       Name= "Cheese",               CanExpire=true,IsShippable=true,Price=100f,Quantity=200,Weight=2};
            Product tv = new Product {           Name="Televesion",            CanExpire=false,IsShippable=true,Price=7000f,Quantity=20,Weight=4000};
            Product mobile = new Product {       Name= "Mobile",               CanExpire=false,IsShippable=true,Price=900f,Quantity=200,Weight=200};
            Product scratchCards = new Product { Name= "Mobile scratch cards", CanExpire=false,IsShippable=false,Price=50f,Quantity=4000,Weight=0};

            cheese.ExpiryDate= new DateTime(2017,8,20);

        var customer = new Customer { Balance = 1000 };

        //customer.Add(cheese,2);//expired
        //customer.Add(tv, 3);//insufficent balance
        //customer.Add(scratchCards, 31200);//not enough quantity

        //customer.Add(mobile, 1);//no enough balance for shippment fees 

        customer.Add(biscuits, 2);//Successful 
        customer.CheckOut();

    }
    
}
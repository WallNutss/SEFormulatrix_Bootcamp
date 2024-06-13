using System;


public class Program{
    
    static void Main(){

        List<Product> products = new List<Product>
        {
            new Product
            {
                ProductID = 1,
                ProductName = "Banana-tastic Boogers",
                Description = "Fresh bananas with a twist of humor.",
                ProductPrice = 8500
            },
            new Product
            {
                ProductID = 2,
                ProductName = "Whole Milk",
                Description = "Creamy and fresh whole milk.",
                ProductPrice = 50000
            },
            new Product
            {
                ProductID = 3,
                ProductName = "Chicken Breast",
                Description = "Lean and tender chicken breasts.",
                ProductPrice = 85000
            },
            new Product
            {
                ProductID = 4,
                ProductName = "Brown Rice",
                Description = "Nutritious and hearty brown rice.",
                ProductPrice = 40000
            },
            new Product
            {
                ProductID = 5,
                ProductName = "Broccoli",
                Description = "Fresh green broccoli.",
                ProductPrice = 30000
            },
            new Product
            {
                ProductID = 6,
                ProductName = "Cheddar Chuckles Cheese",
                Description = "Cheddar cheese that brings a smile.",
                ProductPrice = 70000
            },
            new Product
            {
                ProductID = 7,
                ProductName = "Olive Oil",
                Description = "Pure and healthy olive oil.",
                ProductPrice = 130000
            },
            new Product
            {
                ProductID = 8,
                ProductName = "Belly Bean Black Beans",
                Description = "Canned black beans for your belly.",
                ProductPrice = 18000
            },
            new Product
            {
                ProductID = 9,
                ProductName = "Wacky Wheat Bread",
                Description = "Wholesome wheat bread with a fun twist.",
                ProductPrice = 35000
            },
            new Product
            {
                ProductID = 10,
                ProductName = "Eggs",
                Description = "Fresh farm eggs.",
                ProductPrice = 45000
            }
        };


        List<Customer> customers = new List<Customer>{
            new Customer{CustomerID = 1, CustomerName = "John Fon Due"},
            new Customer{CustomerID = 2, CustomerName = "Milk A Fountaine"}
        };

        // Try to connect to database
        using(dbConnection conn = new()){
            conn.CanConnect();
        }        

        // Adding initialization data to Products
        // using(dbConnection conn = new()){
        //     foreach(var product in products){
        //         conn.AddProductToProducts(product);
        //     }
        // }
        // using(dbConnection conn = new()){
        //     foreach(var customer in customers){
        //         conn.AddCustomerToCustomers(customer);
        //     }
        // }

        // Trying to add data order
        // Where it had from order side, many-to-one relationship with customer
        // using(dbConnection conn = new()){
        //     Customer customer = conn.GetSpesificCustomer(2);

        //     Order order = new Order{
        //         OrderDescription = "It is for meal prep on Saturday"
        //     };
        //     List<ProductWithQuantity> productWithQuantitiesOrder = new List<ProductWithQuantity>{
        //         new ProductWithQuantity{
        //             Products = conn.GetProduct(5),
        //             Quantity = 2
        //         },
        //         new ProductWithQuantity{
        //             Products = conn.GetProduct(2),
        //             Quantity = 14
        //         },
        //     };
            
        //     try{
        //         conn.AddOrderWithDetails(productWithQuantitiesOrder,order,customer.CustomerID);
        //     }catch(Exception e){
        //         Console.WriteLine(e.Message);
        //     }
        // }

        // Try to read list of products and list of customer
        // using(dbConnection conn = new()){
        //     conn.ReadListProducts();
        //     Console.WriteLine("=================");
        //     conn.ReadListCustomers();
        // }

        // Try to read list of order history of each Customer
        using(dbConnection conn = new()){
            Console.WriteLine("List of Order made by Customer");
            Console.WriteLine("=================");
            conn.ReadCustomerOrders();
        }

        // Delete Data about spesific Order of Product
        // using(dbConnection conn = new()){
        //     Console.WriteLine("=================");
        //     conn.RemoveOrder(7);
        // }

        // Update, in this usecase I'm gonna update the just the product
        // Because I'm to lazy to make the endpoint for the other tables
        // using(dbConnection conn = new()){
        //     conn.UpdateProduct(2, null, null, 9145);
        // }
    }
}

public class OrderProductWithQuantity{
    public Order order {get;set;} = null!;
    public List<ProductWithQuantity> productWithQuantities {get;set;} = null!;
}

public class ProductWithQuantity{
    public Product Products {get;set;} = null!;
    public int Quantity {get;set;}
}

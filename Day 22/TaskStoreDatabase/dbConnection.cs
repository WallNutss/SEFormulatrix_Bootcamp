using System;

public class dbConnection : IDisposable{
    public TokoKelontong db;
    private bool disposed = false;
    public dbConnection(){
        db = new TokoKelontong();
    }
    public void CanConnect(){
        bool isConnect = db.Database.CanConnect();
        if(isConnect){
            Console.WriteLine($"Database is connected"); 
        }else{
            Console.WriteLine($"Database is not connected"); 
        }
    }

    public void ReadListCustomers(){
        List<Customer> customers = db.Customers.ToList();
        Console.WriteLine("List of Customer in the database");
        foreach (var customer in customers){
            Console.WriteLine($"{customer.CustomerID} : {customer.CustomerName}");
        }
    }
    public void AddCustomerToCustomers(Customer customer){
        db.Customers.Add(customer);
        db.SaveChanges();
    }

    public Customer GetSpesificCustomer(int CustomerID){
        Customer customer = db.Customers.Where(c => c.CustomerID == CustomerID).FirstOrDefault();
        if(customer != null){
            return customer;
        }else{
            return null;
        }
    }
    public void ReadListProducts(){
        List<Product> products = db.Products.ToList();
        Console.WriteLine("List of Products in the database");
        foreach (var product in products){
            Console.WriteLine($"Product ID : {product.ProductID}  {product.ProductName} price of {product.ProductPrice}, Description : {product.Description}");
        }
    }

    public void AddProductToProducts(Product product){
        db.Products.Add(product);
        db.SaveChanges();
    }

    public void AddOrder(Order order, int customerID){
        Order orderAdd = new Order{
            OrderDescription = order.OrderDescription,
            CustomerID = customerID
        };
        db.Orders.Add(orderAdd);
        db.SaveChanges();
        Console.WriteLine("Order List has been added!");
    }

    // Because this is db connection, I need to implement the dispose method
    // Althought Norhtwind already have this dispose method, but
    // Because I wrapped the connection again inside another class which is dbConnection
    // I need to dispose them
    public void Dispose(){ // This will called first
        Dispose(true); // Then will called the method overload
        GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposing) // This will called last 
    {
        if (!disposed){
            if (disposing){
                // Dispose managed resources
                if (db != null){
                    db.Dispose();
                    db = null;
                }
            }
            // Dispose unmanaged resources status
            disposed = true;
        }
    }
}
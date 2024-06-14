// using System;

// public class dbConnection : IDisposable{
//     public TokoKelontong db;
//     private bool disposed = false;
//     public dbConnection(){
//         db = new TokoKelontong();
//     }
//     public void CanConnect(){
//         bool isConnect = db.Database.CanConnect();
//         if(isConnect){
//             Console.WriteLine($"Database is connected"); 
//         }else{
//             Console.WriteLine($"Database is not connected"); 
//         }
//     }

//     public void ReadListCustomers(){
//         List<Customer> customers = db.Customers.ToList();
//         Console.WriteLine("List of Customer in the database");
//         foreach (var customer in customers){
//             Console.WriteLine($"{customer.CustomerID} : {customer.CustomerName}");
//         }
//     }
//     public void AddCustomerToCustomers(Customer customer){
//         db.Customers.Add(customer);
//         db.SaveChanges();
//     }

//     public Customer GetSpesificCustomer(int CustomerID){
//         Customer customer = db.Customers.Where(c => c.CustomerID == CustomerID).FirstOrDefault();
//         if(customer != null){
//             return customer;
//         }else{
//             return null;
//         }
//     }
//     public void ReadListProducts(){
//         List<Product> products = db.Products.ToList();
//         Console.WriteLine("List of Products in the database");
//         foreach (var product in products){
//             Console.WriteLine($"Product ID : {product.ProductID}  {product.ProductName} price of {product.ProductPrice}, Description : {product.Description}");
//         }
//     }

//     public void AddProductToProducts(Product product){
//         db.Products.Add(product);
//         db.SaveChanges();
//     }

//     public Product GetProduct(int id){
//         Product product = db.Products.Where(p => p.ProductID  == id).FirstOrDefault();
//         if(product != null){
//             return product;
//         }else{
//             return null;
//         }
//     }
//     public void UpdateProduct(int ID, string productName, string description, int price){
//         Product product = db.Products.Find(ID);
//         if(product != null){
//             if(productName != null){
//                 product.ProductName = productName;
//             }
//             if(description != null){
//                 product.Description = description;
//             }
//             if(price != 0){
//                 product.ProductPrice = price;
//             }
//             db.SaveChanges();
//             Console.WriteLine($"Product {ID} was successfully updated in the database");
//         }else{
//             Console.WriteLine($"Product {ID} was not found in the database");
//         }
        
//     }
    

//     public void AddOnlyOrder(Order order, int customerID, List<Product>products){
//         Order orderAdd = new Order{
//             OrderID = order.OrderID,
//             OrderDescription = order.OrderDescription,
//             CustomerID = customerID
//         };
//         db.Orders.Add(orderAdd);

//         db.SaveChanges();
//         Console.WriteLine("Order List has been added!");
//     }

//     public void AddOrderWithDetails(List<ProductWithQuantity> productWithQuantityOrder, Order order, int customerID){
//         Order orderAdd = new Order{
//             OrderDescription = order.OrderDescription,
//             CustomerID = customerID
//         };
//         // Try to search the order first, is it already exist?
//         Order orderSearch = db.Orders.Where(o => o.OrderDescription == orderAdd.OrderDescription).FirstOrDefault<Order>();
//         // Ok now save it
//         if(orderSearch == null){
//             // Save the order first
//             db.Orders.Add(orderAdd);
//             db.SaveChanges();
//             Console.WriteLine("Order Task has been added!");

//             Order order1 = GetOrder(order.OrderDescription);

//             foreach(var product in productWithQuantityOrder){
//                 Console.WriteLine($"Order ID : {order1.OrderID}");
//                 Console.WriteLine($"Product ID : {product.Products.ProductID}");

//                 // Then add the details
//                 OrderDetail orderDetail = new(){
//                     OrderID = order1.OrderID,
//                     ProductID = product.Products.ProductID,
//                     ProductQuantity = product.Quantity
//                 };
//                 db.OrderDetails.Add(orderDetail);
//                 db.SaveChanges();
//                 Console.WriteLine("Order List Detail has been added!");
//             }
//         }else{
//             throw new Exception("Order is already exist, please put new Order!");
//         }
//     }

//     public Order GetOrder(string OrderDescription){
//         Order? order = db.Orders.Where(o => o.OrderDescription == OrderDescription).FirstOrDefault<Order>();
//         if(order != null){
//             return order;
//         }
//         return null;
//     }

//     public void RemoveOrder(int OrderID){
//         Order? order = db.Orders.Find(OrderID);
//         if(order != null){
//             try{
//                 db.Orders.Remove(order);
//                 db.SaveChanges();
//                 Console.WriteLine($"Order {order.OrderID} has been removed from database");
//             }catch(Exception e){
//                 Console.WriteLine(e.Message);
//             }
//         }else{
//             Console.WriteLine("Order was not found");
//         }
//     }

//     public void ReadCustomerOrders(){
//         List<Customer> customers = db.Customers.ToList();
//         foreach(var customer in customers){
//             Console.WriteLine($"{customer.CustomerID} : {customer.CustomerName}");
//             List<Order> orders = db.Orders.Where(o => o.CustomerID == customer.CustomerID).ToList();
//             foreach(var order in orders){
//                 List<OrderDetail> orderDetails = db.OrderDetails.Where(o => o.OrderID == order.OrderID).ToList();
//                 foreach(var orderDetail in orderDetails){
//                     // Get Product
//                     Product product = db.Products.Find(orderDetail.ProductID);
//                     if(product != null){
//                         Console.WriteLine($"    OrderID{order.OrderID,-3} ID{product.ProductID,-3} {product.ProductName,-25} Quantity:{orderDetail.ProductQuantity,-3} Price: {product.ProductPrice,8}");
//                     }else{
//                         Console.WriteLine($"    No Product was found in the database");
//                     }
//                 }
//             }
//             Console.WriteLine("=================");
//         }
//     }

//     // Because this is db connection, I need to implement the dispose method
//     // Althought Norhtwind already have this dispose method, but
//     // Because I wrapped the connection again inside another class which is dbConnection
//     // I need to dispose them
//     public void Dispose(){ // This will called first
//         Dispose(true); // Then will called the method overload
//         GC.SuppressFinalize(this);
//     }
//     protected virtual void Dispose(bool disposing) // This will called last 
//     {
//         if (!disposed){
//             if (disposing){
//                 // Dispose managed resources
//                 if (db != null){
//                     db.Dispose();
//                     db = null;
//                 }
//             }
//             // Dispose unmanaged resources status
//             disposed = true;
//         }
//     }
// }
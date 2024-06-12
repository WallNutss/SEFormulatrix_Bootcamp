// using System;

// public class dbConnection : IDisposable{
//     public NorthWind db;
//     private bool disposed = false;
//     public dbConnection(){
//         db = new NorthWind();
//         CanConnect();
//     }
//     private void CanConnect(){
//         bool isConnect = db.Database.CanConnect();
//         Console.WriteLine($"Database can connect? : {isConnect}");
//     }

//     public void ReadCategories(){
//         List<Categories> categories = db.Categories.ToList();
//         foreach (var category in categories){
//             Console.WriteLine(category.CategoryName);
//         }
//     }
//     public void AddDataToCategories(Categories categories){
//         db.Categories.Add(categories);
//         db.SaveChanges();
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
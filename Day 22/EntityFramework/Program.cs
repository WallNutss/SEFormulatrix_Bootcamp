using Microsoft.EntityFrameworkCore;

class Program {
    static void Main() {
        // Test Connection to the Database
        using (NorthWind db = new()){
            bool isActive = db.Database.CanConnect();
            Console.WriteLine(isActive);
            List<Category> categories = db.Categories.ToList();
            foreach (var category in categories){
                Console.WriteLine(category.CategoryName);
            }

        }
        // Accesing another tables which is the Regions
        using (NorthWind db = new()){
            List<Regions> regions = db.Regions.ToList();
            foreach (var region in regions){
                Console.WriteLine(region.RegionDescription);
            }

        }

        // Try to create individual data
        // using(NorthWind db = new()){
        //     Category categories = new();
        //     // Hold the data to temp object in the program
        //     categories.CategoryName = "Coffee";
        //     categories.Description = "Nescafe, Arabica, and Jamaica";

        //     // Move the data from the object to db object
        //     db.Categories.Add(categories);

        //     // Save the data
        //     db.SaveChanges();
        //     Console.WriteLine("{0} with description of {1} has been added to database!", categories.CategoryName, categories.Description);
        // }
        
        // Try to update some data from the name
        //     using(NorthWind db = new()){

        //     // Try to search particular row that have the name of Produce
        //     Category categories = db.Categories.Where(data => data.CategoryName == "Warmindo").First<Category>();

        //     // Change the data of the particular filter data spesific
        //     categories.Description = "This Warminod is getting edited";

        //     // Update the data
        //     db.SaveChanges();
        // }

        // // Try to find spesific categories data through ID
        // using(NorthWind db = new()){
        //     Category categories = db.Categories.Find(9);

        //     // Try to console it
        //     Console.WriteLine($"Categorie name : {categories.CategoryName}, ID : {categories.CategoryID}, Description : {categories.Description}");
        // }

        // Try to delete some data row category, I'll try to delete Warmindo again
        using(NorthWind db = new()){

            // Try to search particular row that have the name of Produce
            Category? category = db.Categories.FirstOrDefault(c => c.CategoryID == 15);
        
            if (category != null){
                db.Categories.Remove(category);
                db.SaveChanges();
                Console.WriteLine("Data Category Has been Deleted");
            }
            // Update the data
            db.SaveChanges();
        }


    }
}
class Program {
    static void Main() {
        using (NorthWind db = new()){
            bool isActive = db.Database.CanConnect();
            Console.WriteLine(isActive);
            List<Category> categories = db.Categories.ToList();
            foreach (var category in categories){
                Console.WriteLine(category.CategoryName);
            }

        }

        using (NorthWind db = new()){
            List<Regions> regions = db.Regions.ToList();
            foreach (var region in regions){
                Console.WriteLine(region.RegionDescription);
            }

        }

        // // Try to create individual data
        // using(NorthWind db = new()){
        //     Categories categories = new();
        //     // Hold the data to temp object in the program
        //     categories.CategoryName = "Warmindo";
        //     categories.Description = "Warung Bu Yayuk is the best, Makan ayam bakar";

        //     // Move the data from the object to db object
        //     db.Categories.Add(categories);

        //     // Save the data
        //     db.SaveChanges();

        //     // what is the difference between those two?
        // }
        
        // Try to update some data from the name
        //     using(NorthWind db = new()){

        //     Try to search particular row that have the name of Produce
        //     Categories categories = db.Categories.Where(data => data.CategoryName == "Warmindo").First<Categories>();

        //     Change the data of the particular filter data spesific
        //     categories.Description = "This Warminod is getting edited";

        //     Update the data
        //     db.SaveChanges();
        // }

        // // Try to find spesific categories data through ID
        // using(NorthWind db = new()){
        //     Categories categories = db.Categories.Find(9);

        //     // Try to console it
        //     Console.WriteLine($"Categorie name : {categories.CategoryName}, ID : {categories.CategoryId}, Description : {categories.Description}");
        // }

        // Try to delete some data, I'll try to delete Warmindo again
        // using(NorthWind db = new()){

        //     // Try to search particular row that have the name of Produce
        //     Categories categories = db.Categories.Where(data => data.CategoryName == "Warmindo").First<Categories>();

        //     // Temporarly hold the queries
        //     db.Remove(categories);

        //     // Update the data
        //     db.SaveChanges();
        // }


    }
}
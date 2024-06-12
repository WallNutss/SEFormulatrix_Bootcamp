class Program {
    static void Main() {
        using (NorthWind db = new())
        {
            bool isActive = db.Database.CanConnect();
            Console.WriteLine(isActive);
            List<Categories> categories = db.Categories.ToList();
            foreach (var category in categories)
            {
                Console.WriteLine(category.CategoryName);
            }
        }
    }
}
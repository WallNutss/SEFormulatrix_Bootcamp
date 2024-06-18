using Microsoft.AspNetCore.Mvc;

public class CategoryController : Controller{
    private readonly Database _db;
    public CategoryController (Database db){
        _db = db;
    }

    public IActionResult Index(){
        List<Category> categories = _db.Categories.ToList();
        return View(categories);
    }
}
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;

public class CategoryController : Controller{
    private INotyfService _notyf;
    private readonly Database _db;
    public CategoryController (Database db, INotyfService notfy){
        _db = db;
        _notyf = notfy;
    }

    public IActionResult Index(){
        if(TempData["success"] != null){
            _notyf.Success($"{TempData["success"]}");
        }
        if(TempData["delete"] != null){
            _notyf.Warning($"{TempData["delete"]}");
        }
        List<Category> categories = _db.Categories.ToList();
        return View(categories);
    }
    public IActionResult Create(){ 
        List<Category> categories = _db.Categories.ToList();
        return View(categories);
    }

    [HttpPost]
    public IActionResult Create(Category category){
        // Maybe I should Implement try catch here in case, then popup for that
        _db.Categories.Add(category); 
        _db.SaveChanges();
        TempData["success"] = $"Category {category.CategoryName} with ID{category.CategoryID} has been created!"; // This will be run too and will be redirect to Index
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int? id){
        if(id == null || id==0){
            return NotFound();
        }
        Category category = _db.Categories.Find(id);
        return View(category);
    }

    [HttpPost]
    public IActionResult Edit(Category category){
        Category categoryEditTarget = _db.Categories.Find(category.CategoryID);
        categoryEditTarget.CategoryName = category.CategoryName;
        categoryEditTarget.Description = category.Description;
        
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int? id){
        if(id == null || id==0){
            return NotFound();
        }
        Category category = _db.Categories.Find(id);
        return View(category);
    }

    
    [HttpPost] // Implicityly Getting response from the HTML From
    public IActionResult Delete(Category category){
        Category categoreRemoveTarget = _db.Categories.Find(category.CategoryID);
        
        _db.Remove(categoreRemoveTarget);
        _db.SaveChanges();
        TempData["delete"] = $"Category {category.CategoryName} with ID{category.CategoryID} has been deleted!"; // This will be run too and will be redirect to Index
        return RedirectToAction("Index");
    }
}
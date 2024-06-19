using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class ProductController : Controller{
    private INotyfService _notyf;
    private readonly Database _db;
    public ProductController (Database db,INotyfService notfy){
        _db = db;
        _notyf = notfy;
    }

    public IActionResult Index(){
        if(TempData["success"] != null){
            _notyf.Success($"{TempData["success"]}");
        }
        if(TempData["update"] != null){
            _notyf.Success($"{TempData["update"]}");
        }
        if(TempData["delete"] != null){
            _notyf.Success($"{TempData["delete"]}");
        }
        // So in default 
        List<Product> products = _db.Products.Include(p => p.Category)
                                             .ToList();
        return View(products);
    }
    public IActionResult Add(){
        TempData["categories"] = _db.Categories.ToList();
        return View();
    }
    [HttpPost]
    public IActionResult Add(Product product){
        _db.Products.Add(product);
        _db.SaveChanges();
        TempData["success"] = $"Product {product.ProductName} has been added to List of Products!"; // This will be run too and will be redirect to Index
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int? id){
        if(id == null || id==0){
            return NotFound();
        }
        TempData["categories"] = _db.Categories.ToList();
        try{
            Product product = _db.Products.Find(id);
            return View(product);
        }catch(Exception ex){
            return NotFound(ex.Message);
        }
    }
    [HttpPost]
    public IActionResult Edit(Product product){
        Product productEditTarget = _db.Products.Find(product.ProductID);
        productEditTarget.ProductName = product.ProductName;
        productEditTarget.Description = product.Description;
        productEditTarget.ProductPrice = product.ProductPrice;
        productEditTarget.CategoryID = product.CategoryID;
        
        TempData["update"] = $"Product {productEditTarget.ProductName} has been updated!"; // This will be run too and will be redirect to Index
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int? id){
        if(id == null || id==0){
            return NotFound();
        }
        TempData["categories"] = _db.Categories.ToList();
        try{
            Product product = _db.Products.Find(id);
            return View(product);
        }catch(Exception ex){
            return NotFound(ex.Message);
        }
    }
    [HttpPost]
    public IActionResult Delete(Product product){
        Product productRemoveTarget = _db.Products.Find(product.ProductID);
        
        _db.Remove(productRemoveTarget);
        _db.SaveChanges();
        TempData["delete"] = $"Product {product.ProductID} has been deleted!"; // This will be run too and will be redirect to Index
        return RedirectToAction("Index");
    }
}
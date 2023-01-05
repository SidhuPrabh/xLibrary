using Microsoft.AspNetCore.Mvc;
using Library.DataAccess;
using Library.Models;
using Library.DataAccess.Repository.IRepository;

namespace LibraryWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class Product : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public Product(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> objProductList = _unitOfWork.Product.GetAll();
            return View(objProductList);
        }


        //GET
        public IActionResult Upsert(int? id)
        {
            if (id == null || id == 0)
            {
                //create product
                return NotFound();
            }
            else
            {
                //update product
            }
            
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Product obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Product updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var categoryFromDb = _db.Product.Find(id);
            var ProductFromDb = _unitOfWork.Product.GetFirstOrDefault(c => c.Id == id);
            //var categoryFromDb = _db.Product.SingleOrDefault(c => c.Id == id);
            if (ProductFromDb == null)
            {
                return NotFound();
            }
            return View(ProductFromDb);
        }
        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.Product.GetFirstOrDefault(c => c.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Product.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Product deleted successfully";
            return RedirectToAction("Index");
        }
    }
}

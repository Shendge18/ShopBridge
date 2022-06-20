using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopBridge.Data;
using ShopBridgeDAL.Models;

namespace ShopBridge.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext _db;
        public AdminController(ApplicationDbContext db)
        {
            _db = db;
        }


        #region Product Type

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                var DbData = _db.ProductTypes.ToList();
                return View(DbData);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public ActionResult AddProducts()
        {
            try
            {
                return View();

            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProducts(ProductTypeDALmodel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.ProductTypes.Add(model);
                    await _db.SaveChangesAsync();
                    TempData["save"] = "Product type has been saved";
                    return RedirectToAction(nameof(Index));
                }

                return View(model);
            }
            catch (Exception)
            {
                throw;
            }

        }


        public ActionResult EditProduct(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var productType = _db.ProductTypes.Find(id);
                if (productType == null)
                {
                    return NotFound();
                }
                return View(productType);
            }
            catch (Exception)
            {
                throw;
            }

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProduct(ProductTypeDALmodel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Update(model);
                    await _db.SaveChangesAsync();
                    TempData["edit"] = "Product type has been updated";
                    return RedirectToAction(nameof(Index));
                }

                return View(model);
            }
            catch (Exception)
            {
                throw;
            }

        }



        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var productType = _db.ProductTypes.Find(id);
                if (productType == null)
                {
                    return NotFound();
                }
                return View(productType);
            }
            catch (Exception)
            {

                throw;
            }

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(ProductTypeDALmodel model)
        {
            try
            {
                return RedirectToAction(nameof(Index));

            }
            catch (Exception)
            {
                throw;
            }

        }


        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var productType = _db.ProductTypes.Find(id);
                if (productType == null)
                {
                    return NotFound();
                }
                return View(productType);
            }
            catch (Exception)
            {

                throw;
            }

        }

  

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id, ProductTypeDALmodel model)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                if (id != model.Id)
                {
                    return NotFound();
                }

                var productType = _db.ProductTypes.Find(id);
                if (productType == null)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    _db.Remove(productType);
                    await _db.SaveChangesAsync();
                    TempData["delete"] = "Product type has been deleted";
                    return RedirectToAction(nameof(Index));
                }

                return View(model);
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion


        #region Product Category

        public IActionResult ProductCategory()
        {
            try
            {
                return View(_db.ProductCategories.ToList());
            }
            catch (Exception)
            {
                throw;
            }
        }


        public ActionResult AddProductCategory()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProductCategory(ProductCategoryDALModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.ProductCategories.Add(model);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(ProductCategory));
                }

                return View(model);
            }
            catch (Exception)
            {
                throw;
            }
            
        }


        public ActionResult EditProductCategory(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var productcategories = _db.ProductCategories.Find(id);
                if (productcategories == null)
                {
                    return NotFound();
                }
                return View(productcategories);
            }
            catch (Exception)
            {
                throw;
            }
            
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProductCategory(ProductCategoryDALModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Update(model);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(ProductCategory));
                }

                return View(model);
            }
            catch (Exception)
            {
                throw;
            }
            
        }


        public ActionResult ProductCategoryDetails(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var productcategory = _db.ProductCategories.Find(id);
                if (productcategory == null)
                {
                    return NotFound();
                }
                return View(productcategory);
            }
            catch (Exception)
            {
                throw;
            }
            
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ProductCategoryDetails(ProductCategoryDALModel model)
        {
            try
            {
                return RedirectToAction(nameof(ProductCategory));
            }
            catch (Exception)
            {
                throw;
            }

        }


        public ActionResult DeleteProductCategory(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var productcategory = _db.ProductCategories.Find(id);
                if (productcategory == null)
                {
                    return NotFound();
                }
                return View(productcategory);
            }
            catch (Exception)
            {
                throw;
            }
            
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProductCategory(int? id, ProductCategoryDALModel model)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                if (id != model.Id)
                {
                    return NotFound();
                }

                var productcategory = _db.ProductCategories.Find(id);
                if (productcategory == null)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    _db.Remove(productcategory);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(ProductCategory));
                }

                return View(model);
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        #endregion


        #region Products

        public IActionResult Products()
        {
            try
            {
                return View(_db.Products.Include(c => c.ProductTypes).Include(f => f.ProductCategory).ToList());

            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Products(decimal? lowAmount, decimal? largeAmount)
        {
            try
            {
                var products = _db.Products.Include(c => c.ProductTypes).Include(c => c.ProductCategory)
                               .Where(c => c.Price >= lowAmount && c.Price <= largeAmount).ToList();
                if (lowAmount == null || largeAmount == null)
                {
                    products = _db.Products.Include(c => c.ProductTypes).Include(c => c.ProductCategory).ToList();
                }
                return View(products);
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        public IActionResult CreateProduct()
        {
            try
            {
                ViewData["productTypeId"] = new SelectList(_db.ProductTypes.ToList(), "Id", "ProductType");
                ViewData["ProductCategoryId"] = new SelectList(_db.ProductCategories.ToList(), "Id", "Name");
                return View();
            }
            catch (Exception)
            {
                throw;
            }
          
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct(ProductDALModel productmodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var searchProduct = _db.Products.FirstOrDefault(c => c.CompanyName == productmodel.CompanyName);
                    if (searchProduct != null)
                    {
                        ViewBag.message = "This product is already exist";
                        ViewData["productTypeId"] = new SelectList(_db.ProductTypes.ToList(), "Id", "ProductType");
                        ViewData["ProductCategoryId"] = new SelectList(_db.ProductCategories.ToList(), "Id", "Name");
                        return View(productmodel);
                    }

                    _db.Products.Add(productmodel);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Products));
                }

                return View(productmodel);
            }
            catch (Exception)
            {
                throw;
            }
           
        }


        public ActionResult EditProductItem(int? id)
        {
            try
            {
                ViewData["productTypeId"] = new SelectList(_db.ProductTypes.ToList(), "Id", "ProductType");
                ViewData["ProductCategoryId"] = new SelectList(_db.ProductCategories.ToList(), "Id", "Name");
                if (id == null)
                {
                    return NotFound();
                }

                var product = _db.Products.Include(c => c.ProductTypes).Include(c => c.ProductCategory)
                    .FirstOrDefault(c => c.Id == id);
                if (product == null)
                {
                    return NotFound();
                }
                return View(product);
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProductItem(ProductDALModel products)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Products.Update(products);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Products));
                }

                return View(products);
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        public ActionResult ProductDetails(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var product = _db.Products.Include(c => c.ProductTypes).Include(c => c.ProductCategory)
                    .FirstOrDefault(c => c.Id == id);
                if (product == null)
                {
                    return NotFound();
                }
                return View(product);
            }
            catch (Exception)
            {
                throw;
            }
           
        }


        public ActionResult DeleteProduct(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var product = _db.Products.Include(c => c.ProductCategory).Include(c => c.ProductTypes).Where(c => c.Id == id).FirstOrDefault();
                if (product == null)
                {
                    return NotFound();
                }
                return View(product);
            }
            catch (Exception)
            {
                throw;
            }
           
        }


        [HttpPost]
        [ActionName("DeleteProduct")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProductConfirm(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var product = _db.Products.FirstOrDefault(c => c.Id == id);
                if (product == null)
                {
                    return NotFound();
                }

                _db.Products.Remove(product);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Products));
            }
            catch (Exception)
            {
                throw;
            }
            
        }


        #endregion


    }
}

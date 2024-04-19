using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.DataAccess.Repository.IRepository;
using ProyectoFinal.Models;
using ProyectoFinal.Utility;

namespace ProyectoFinalPWA.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = $"{SD.Role_User_Admin},{SD.Role_User_Employee}")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Category> objCategoryList = _unitOfWork.Category.GetAll().ToList();


            return View(objCategoryList);
        }

        public IActionResult Upsert(int? id)
        {
            if (id == null || id == 0)
            {
                return View(new Category());

            }
            else
            {
                Category category = _unitOfWork.Category.GetFirstOrDefault(com => com.Id == id);
                return View(category);
            }
        }

        [HttpPost]
        public IActionResult Upsert(Category category)
        {
            if (ModelState.IsValid)
            {
                if (category.Id == 0)
                {
                    _unitOfWork.Category.Add(category);
                }
                else
                {
                    _unitOfWork.Category.Update(category);
                }
                _unitOfWork.Save();
                TempData["success"] = "Operacion realizad con exito";
                return RedirectToAction("Index");
            }
            else
            {
                return View(category);
            }
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Category> objCategoryList = _unitOfWork.Category.GetAll().ToList();
            return Json(new { data = objCategoryList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var CategoryToBeDeleted = _unitOfWork.Category.GetFirstOrDefault(com => com.Id == id);
            if (CategoryToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error al eliminar categoria" });
            }

            _unitOfWork.Category.Remove(CategoryToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Categoria eliminada exitosamente" });
        }

        #endregion

    }
}

using CRUDWithADODotNet.DataAccessLayer;
using CRUDWithADODotNet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CRUDWithADODotNet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly EmployeeDataAccessLayer _employeeDataAccessLayer;
        public HomeController(ILogger<HomeController> logger, EmployeeDataAccessLayer employeeDataAccessLayer)
        {
            _logger = logger;
            _employeeDataAccessLayer = employeeDataAccessLayer;
        }

        public IActionResult Index()
        {
            List<EmployeeModel> employeeModels = _employeeDataAccessLayer.GetAllEmployees();
            return View(employeeModels);
        }

        public IActionResult AddUpdateEmployees()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddUpdateEmployees(EmployeeModel employeeModel)
        {
            try
            {
                _employeeDataAccessLayer.AddUpdateEmployees(employeeModel);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
                throw;
            }

        }

        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            EmployeeModel emp = _employeeDataAccessLayer.GetEmployeesById(Id);
            return View(emp);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeModel employeeModel)
        {
            try
            {
                _employeeDataAccessLayer.AddUpdateEmployees(employeeModel);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
                throw;
            }

        }

        [HttpGet]
        public IActionResult Details(int? Id)
        {
            EmployeeModel emp = _employeeDataAccessLayer.GetEmployeesById(Id);
            return View(emp);
        }

        [HttpGet]
        public IActionResult Delete(int? Id)
        {
          EmployeeModel emp = _employeeDataAccessLayer.GetEmployeesById(Id);
            return View(emp);
        }
        [HttpPost]
        public IActionResult Delete(EmployeeModel employeeModel)
        {
            try
            {
                _employeeDataAccessLayer.DeleteEmployeesById(employeeModel.Id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
                throw;
            }
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

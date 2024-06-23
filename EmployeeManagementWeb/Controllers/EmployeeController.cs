using EmployeeManagementWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace EmployeeManagementWeb.Controllers
{
    public class EmployeeController : Controller
    {
        Uri baseAddress = new Uri("http://localhost:29111/api/");
        private readonly HttpClient _client;
        public EmployeeController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }
        [HttpGet]
        public IActionResult EmployeeDeatil()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EmployeeDeatil(Employee employee)
        {
            try
            {
                string data = JsonConvert.SerializeObject(employee);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage httpResponse = _client.PostAsync(_client.BaseAddress + "Employee/addEmployee", content).Result;
                if (httpResponse.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Employee Details Add Sucessfuly!";
                    return RedirectToAction("GetAll_EmployeeDeatil", "Employee");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
            return View();
        }
        [HttpGet]
        public IActionResult GetAll_EmployeeDeatil()
        {
            List<Employee> list = new List<Employee>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "Employee/getAllEmployeeDeatils").Result;
            if (response.IsSuccessStatusCode)
            {
                string data=response.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<Employee>>(data);
            }
            return View(list);
        }
        [HttpGet]
        public IActionResult EditEmployeeDeatil(int id)
        {
            try
            {
                Employee employee = new Employee();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "Employee/getEmpById?id=" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    employee = JsonConvert.DeserializeObject<Employee>(data);
                }
            return View(employee);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }
        [HttpPost]
        public IActionResult EditEmployeeDeatil(Employee employee)
        {
            try
            {
                //if (employee.Id!=0)
                //{
                //    return BadRequest();
                //}
                string data = JsonConvert.SerializeObject(employee);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + "Employee/UpdateEmp", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("EmployeeDeatil");
                }
                return View(employee);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }
        [HttpGet]
        public IActionResult DeleteEmployeeDeatil(int Id)
        {
            try
            {
                Employee employee = new Employee();
                HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + "Employee/EmpDeleted?Id=" + Id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                }
                return RedirectToAction(nameof(EmployeeDeatil));
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }
    }
}

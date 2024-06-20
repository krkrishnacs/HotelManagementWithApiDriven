using EmployeeManagementWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Newtonsoft.Json;
using NuGet.Protocol.Plugins;
using System.Text;

namespace EmployeeManagementWeb.Controllers
{
    public class AccountController : Controller
    {
        Uri baseAddress = new Uri("http://localhost:29111/api/");
        private readonly HttpClient _client;
        public AccountController()
        {
            _client=new HttpClient();
            _client.BaseAddress = baseAddress;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Register register)
        {
            try
            {
                string data=JsonConvert.SerializeObject(register);
                StringContent content = new StringContent(data,Encoding.UTF8,"application/json");
                HttpResponseMessage httpResponse = _client.PostAsync(_client.BaseAddress + "Account/register", content).Result;
                if (httpResponse.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Register Sucessfuly!";
                    //return RedirectToAction("Account/Register");
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Login login)
        {
            try
            {
                string data = JsonConvert.SerializeObject(login);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage httpResponse = _client.PostAsync(_client.BaseAddress + "Account/login",content).Result;
               // string message = "This is a simple string message.";
                if (httpResponse.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Login Sucessfuly!";
                    //var result = new ContentResult
                    //{
                    //    Content = message,
                    //    ContentType = "text/plain"
                    //};
                    //return result;
                    //return RedirectToAction("Home/Index");
                    return RedirectToAction("Index", "Home");
                    //return message;
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
            return View();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebApiCrud.Models;

namespace WebApiCrud.Controllers
{
    public class CrudMvcController : Controller
    {
        // GET: CrudMvc

        HttpClient client = new HttpClient();
        public ActionResult GetEmp()
        {
            List<Employee> emp_list = new List<Employee>();
            client.BaseAddress = new Uri("https://localhost:44328/api/CrudApi");
            var response = client.GetAsync("CrudApi");
            response.Wait();


            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<Employee>>();
                display.Wait();
                emp_list = display.Result;

            }
            return View(emp_list);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            client.BaseAddress = new Uri("https://localhost:44328/api/CrudApi");
            var response = client.PostAsJsonAsync<Employee>("CrudApi",emp);
            response.Wait();


            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("GetEmp");

            }
            return View();
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Employee e = null;
            client.BaseAddress = new Uri("https://localhost:44328/api/CrudApi");
            var response = client.GetAsync("CrudApi?id="+id.ToString());
            response.Wait();


            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Employee>();
                display.Wait();
                e = display.Result;

            }
            return View(e);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Employee e = null;
            client.BaseAddress = new Uri("https://localhost:44328/api/CrudApi");
            var response = client.GetAsync("CrudApi?id=" + id.ToString());
            response.Wait();


            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Employee>();
                display.Wait();
                e = display.Result;

            }
            return View(e);
        }
        [HttpPost]
        public ActionResult Edit(Employee e)
        {
            client.BaseAddress = new Uri("https://localhost:44328/api/CrudApi");
            var response = client.PutAsJsonAsync<Employee>("CrudApi", e);
            response.Wait();


            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("GetEmp");

            }
            return View("Edit");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Employee e = null;
            client.BaseAddress = new Uri("https://localhost:44328/api/CrudApi");
            var response = client.GetAsync("CrudApi?id=" + id.ToString());
            response.Wait();


            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Employee>();
                display.Wait();
                e = display.Result;

            }
            return View(e);
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            client.BaseAddress = new Uri("https://localhost:44328/api/CrudApi");
            var response = client.DeleteAsync("CrudApi/"+id.ToString());
         
            response.Wait();


            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("GetEmp");

            }
            return View("Delete");
        }
    }
}
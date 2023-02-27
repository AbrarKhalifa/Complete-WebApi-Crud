using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiCrud.Models;

namespace WebApiCrud.Controllers
{
    public class CrudApiController : ApiController
    {
        DB_WEB_API_CRUDEntities db = new DB_WEB_API_CRUDEntities();

        [HttpGet]
        public IHttpActionResult GetAllEmployees()
        {
            List<Employee> list = db.Employees.ToList();
            return Ok(list);
        }
        //public List<Employee> GetAllEmployees()         --- both will work
        //{

        //    return db.Employees.ToList();
        //}

        // this is for getting one result
        [HttpGet]
        public IHttpActionResult getone(int id)
        {
            var emp = db.Employees.Where(x => x.id == id).SingleOrDefault();
            return Ok(emp);
        }

        // this is for insert
        [HttpPost]
        public IHttpActionResult EmpInsert(Employee e)
        {
            db.Employees.Add(e);
            db.SaveChanges();
            return Ok();
        }

        // this is for update
        [HttpPut]
        public IHttpActionResult EmpUpdate(Employee e)
        {
            db.Entry(e).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return Ok();
        }

        // delete 
        [HttpDelete]
        public IHttpActionResult DeleteOne(int id)
        {
            var emp = db.Employees.Find(id);
            db.Employees.Remove(emp);
            db.SaveChanges();
            return Ok();
        }
    }
}

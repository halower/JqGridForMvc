using System.Collections.Generic;
using System.Web.Mvc;
using HalowerHub.JqGrid;
using JQgridTest.Models;

namespace JQgridTest.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ContentResult PersonListData()
        {
            var persons = new List<Person>
            {
                new Person {Id = 1, Name = " 小1", Password = "123456"},
                new Person {Id = 2, Name = "小2", Password = "123456"},
                new Person {Id = 3, Name = "小3", Password = "123456"},
                new Person {Id = 4, Name = "小4", Password = "123456"},
                new Person {Id = 5, Name = "小5", Password = "123456"}
            };
            return Content(persons.Pagination(this));
        }
    }
}
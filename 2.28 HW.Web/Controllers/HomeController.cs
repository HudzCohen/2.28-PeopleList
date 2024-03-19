using _2._28_HW.Data;
using _2._28_HW.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _2._28_HW.Web.Controllers
{
    public class HomeController : Controller
    {
        private string _connectionString = @"Data Source=.\sqlexpress; Initial Catalog=PersonDBO; Integrated Security=true;";

        public IActionResult Index()
        {
            var db = new PeopleDB(_connectionString);

            PeopleViewModel vm = new()
            {
                People = db.GetPeople()
            };
            if (TempData["ppl-message"] != null)
            {
                vm.Message = (string)TempData["ppl-message"];
            }

            return View(vm);
        }

        public IActionResult AddPeople()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPeople(List<Person> p)
        {
            var db = new PeopleDB(_connectionString);
            db.AddMany(p);
            if (p.Count > 1)
            {
                TempData["ppl-message"] = "People added successfully!";
            }
            else if(p.Count > 0)
            {
                TempData["ppl-message"] = "Person added successfully";
            }
            return Redirect("/home/index");
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TagHelpersInASPNETCoreMVC.Models;

namespace TagHelpersInASPNETCoreMVC.Controllers
{
    public class FormTagHelperEgController : Controller
    {
        //Create a Variable to Hold List of Students
        //This is going to be our data source
        private List<Student> listStudents = new List<Student>();
        public FormTagHelperEgController()
        {
            //Within the Constructor we are Initializing listStudents variable
            //In Real-Time, we will get the data from the database
            listStudents = new List<Student>()
            {
               new Student() { StudentId = 101, Name = "Suri", Branch = Branch.CSE, Gender = Gender.Male, Address = "A1-2018", Email = "James@g.com" },
               new Student() { StudentId = 102, Name = "Mouni", Branch = Branch.ETC, Gender = Gender.Female, Address = "A1-2019", Email = "Priyanka@g.com" },
               new Student() { StudentId = 103, Name = "Bujji", Branch = Branch.CSE, Gender = Gender.Male, Address = "A1-2020", Email = "David@g.com" },
               new Student() { StudentId = 104, Name = "Puchuku", Branch = Branch.Mech, Gender = Gender.Male, Address = "A1-2021", Email = "Pranaya@g.com" }
            };
        }
        public ViewResult Index()
        {
            //returning all the students
            return View(listStudents);
        }
        public ViewResult Details(int Id)
        {
            //returning the student based on the Student Id
            var studentDetails = listStudents.FirstOrDefault(std => std.StudentId == Id);
            return View(studentDetails);
        }
        [HttpGet]
        public ViewResult Create()
        {
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();

            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem { Text = "None", Value = "1" },
                new SelectListItem { Text = "CSE", Value = "2" },
                new SelectListItem { Text = "ETC", Value = "3" },
                new SelectListItem { Text = "Mech", Value = "4" }
            };
            return View();
        }
    }
}

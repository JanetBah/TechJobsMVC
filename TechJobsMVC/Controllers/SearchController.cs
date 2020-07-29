using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVC.Data;
using TechJobsMVC.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsMVC.Controllers
{
    public class SearchController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.columns = ListController.ColumnChoices;
            return View();
        }

        // TODO #3: Create an action method to process a search request and render the updated search view. 
        public IActionResult Results(string searchType, string searchTerm)
        {
            ViewBag.columns = ListController.ColumnChoices;

            if(string.IsNullOrEmpty(searchTerm)|| searchType == "all")
            {
                List<Job>jobsFound = JobData.FindAll();
                ViewBag.jobs = jobsFound;
            }
            else
            {
                List<Job> jobsFound  = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.jobs = jobsFound;
            }

            ViewBag.title = "Search Results";
            ViewBag.searchTerm = searchTerm;
            ViewBag.searchType = searchType;

            return View("Index");
        }
    }
}

using CoreSelect_List.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CoreSelect_List.Data;
using CoreSelect_List.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CoreSelect_List.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly SelexctListContext _context;

        public HomeController(SelexctListContext context)
        {
            _context = context;
        }
        public IActionResult List()
        {
            List<Customer> customers = _context.Customers_dj
                .Include(c => c.Country)
                .Include(cy => cy.city).ToList();
            return View(customers);
        }
        [HttpGet]
        public IActionResult Create()
        {
            CustomerCreateModel customerCreateModel = new CustomerCreateModel();
            customerCreateModel.Customer = new Customer();
            //retrive countries from countrie table and orderate by name and then convert to asp select list item 
            List<SelectListItem> countries = _context.Country_Djs
                .OrderBy(n => n.Name)
                .Select(n => new SelectListItem
                {
                    Value = n.Code,
                    Text = n.Name
                }).ToList();
            customerCreateModel.Countries = countries;
            // below we create empty select list for 1st time without selected countries
            customerCreateModel.Cities = new List<SelectListItem>();
            return View(customerCreateModel);
        }
        [HttpPost]
        public ActionResult Create(CustomerCreateModel cust)
        {
            _context.Add(cust.Customer);
            _context.SaveChanges();
            return RedirectToAction("List");
        }
        [HttpGet]
        public ActionResult GetCities(string CountryCode)
        {
            if(!string.IsNullOrWhiteSpace(CountryCode) && CountryCode.Length == 3)
            {
                List<SelectListItem> citiesSel = _context.City_Djs
                    .Where(c => c.CountryCode == CountryCode)
                    .OrderBy(n => n.Name)
                    .Select(n =>
                    new SelectListItem
                    {
                        Value = n.Code,
                        Text = n.Name
                    }).ToList();
                return Json(citiesSel);
            }
            return null;
        }
       
        public IActionResult Index()
        {
            return View();
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

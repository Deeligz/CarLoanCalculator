using CarLoanCalculator.Helpers;
using CarLoanCalculator.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CarLoanCalculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult LoanPage()
        {
            Loan model = new Loan();
            
            model.Payment = 0;
            model.TotalInterest = 0;
            model.TotalCost = 0;
            model.Rate = 3.5M;
            model.Amount = 15000M;
            model.Term = 60;
            
            
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LoanPage(Loan model)
        {
            LoanHelper loanHelper = new LoanHelper();

            Loan newLoan = loanHelper.GetPayments(model);
            
            return View(newLoan);
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
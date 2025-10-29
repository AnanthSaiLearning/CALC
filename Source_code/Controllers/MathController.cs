using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;

namespace MathOperationApp.Controllers
{
    public class MathController : Controller
    {
        // GET: /Math/
        public IActionResult Index()
        {
            ViewBag.Result = "";
            return View();
        }

        // POST: /Math/
        [HttpPost]
        public IActionResult Index(string? expression)
        {
            string result;

            // ✅ Handle null or empty input
            if (string.IsNullOrWhiteSpace(expression))
            {
                ViewBag.Result = "Enter an expression";
                return View();
            }

            try
            {
                // ✅ Replace calculator symbols for evaluation
                expression = expression
                    .Replace("×", "*")
                    .Replace("÷", "/")
                    .Replace("%", "*0.01");

                // ✅ Evaluate safely using DataTable
                var dataTable = new DataTable();
                var value = dataTable.Compute(expression, null);

                result = Convert.ToString(value) ?? "0";
            }
            catch
            {
                result = "Invalid Expression";
            }

            ViewBag.Result = result;
            return View();
        }
    }
}
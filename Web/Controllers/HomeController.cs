using ClosedXML.Excel;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.IO;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOrderService _orderService;

        public HomeController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            var model = OrderViewModel.GetInstance();
            return View(model);
        }

        [HttpGet]
        public IActionResult GetOrdersByDateFilter(DateTime dateFrom, DateTime dateTo)
        {
            var model = OrderViewModel.GetInstance();
            model.DateFrom = dateFrom;
            model.DateTo = dateTo;
            model.Orders = _orderService.Get(dateFrom, dateTo);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult GetOrdersExcel()
        {
            using (var workbook = new XLWorkbook())
            {
                var model = OrderViewModel.GetInstance();
                var worksheet = workbook.Worksheets.Add("Orders");
                var currentRow = 2;
                worksheet.Cell(currentRow, 2).Value = "Order price";
                worksheet.Cell(currentRow, 3).Value = "Order date";
                foreach (var order in model.Orders)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 2).Value = order.Price;
                    worksheet.Cell(currentRow, 3).Value = order.Date.ToString("dd.MM.yyyy");
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "orders.xlsx");
                }
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

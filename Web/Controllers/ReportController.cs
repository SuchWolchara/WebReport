using ClosedXML.Excel;
using Domain;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.IO;
using Web.Models;

namespace Web.Controllers
{
    public class ReportController : Controller
    {
        private readonly IOrderService _orderService;

        private ReportViewModel _model => ReportViewModel.GetInstance();

        public ReportController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            return View(_model);
        }

        [HttpGet]
        public IActionResult GetOrdersByDateFilter(DateTime dateFrom, DateTime dateTo)
        {
            _model.DateFrom = dateFrom;
            _model.DateTo = dateTo;
            return UpdateView();
        }

        [HttpPost]
        public IActionResult AddOrder(int price, DateTime date)
        {
            _orderService.Set(EntityStates.Insert, price: price, date: date);
            return UpdateView();
        }

        [HttpPost]
        public IActionResult UpdateOrder(Guid id, int price, DateTime date)
        {
            _orderService.Set(EntityStates.Update, id, price, date);
            return UpdateView();
        }

        [HttpPost]
        public IActionResult DeleteOrder(Guid id)
        {
            _orderService.Set(EntityStates.Delete, id);
            return UpdateView();
        }

        [HttpGet]
        public IActionResult GetReportExcel()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Orders");
                var currentRow = 2;
                worksheet.Cell(currentRow, 2).Value = "Order price";
                worksheet.Cell(currentRow, 3).Value = "Order date";
                foreach (var order in _model.Orders)
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
                        "report.xlsx");
                }
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private IActionResult UpdateView()
        {
            _model.Orders = _orderService.Get(_model.DateFrom, _model.DateTo);
            return RedirectToAction("Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace JsonDecimalFloatTailZero.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost, Route("api/[Controller]")]
        public IActionResult Post([FromBody]TestViewModel vm)
        {
            return Ok(vm);
        }
    }

    public class TestViewModel
    {
        public TestDto Dto { get; set; }
    }

    public class TestDto
    {
        public decimal? MeasureValue { get; set; }
    }
}

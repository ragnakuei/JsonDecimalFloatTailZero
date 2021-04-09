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
            vm.Dto.MeasureValue *= 1.0m;

            return Ok(vm);
        }
    }

    public class TestViewModel
    {
        public TestDto Dto { get; set; }
    }

    public class TestDto
    {
        [JsonConverter(typeof(StringNullableDecimalJsonConverter))]
        public decimal? MeasureValue { get; set; }
    }

    public class StringNullableDecimalJsonConverter : JsonConverter<decimal?>
    {
        public override decimal? Read(ref Utf8JsonReader    reader,
                                      Type                  typeToConvert,
                                      JsonSerializerOptions options)
        {
            if (Decimal.TryParse(reader.GetString(), out var result))
            {
                return result;
            }

            return null;
        }

        public override void Write(Utf8JsonWriter        writer,
                                   decimal?              nullableDecimal,
                                   JsonSerializerOptions options) =>
            writer.WriteStringValue(nullableDecimal.ToString());
    }
}

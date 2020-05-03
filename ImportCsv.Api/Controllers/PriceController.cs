using ImportCsv.Api.Contracts;
using ImportCsv.Api.Domains.price;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace ImportCsv.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    public class PriceController
    {
        private readonly ILogger<PriceController> _logger;
        private readonly IReadPriceCsv<PriceDtc> _readPriceCsv;

        public PriceController(ILogger<PriceController> logger, IReadPriceCsv<PriceDtc> readPriceCsv)
        {
            _logger = logger;
            _readPriceCsv = readPriceCsv;
        }

        [HttpGet]
        public IEnumerable<PriceDtc> UploadPrice()
        {
            return _readPriceCsv.Execute();
        }
    }

}
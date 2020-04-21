using System.Collections.Generic;
using ImportCsv.app.commands.price;
using ImportCsv.app.domains;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ImportCsv.app.Controllers
{
    [Route("api/[controller]")]
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
        public IEnumerable<PriceDtc> Get()
        {
            return _readPriceCsv.Execute();
        }
        
    }
    
}
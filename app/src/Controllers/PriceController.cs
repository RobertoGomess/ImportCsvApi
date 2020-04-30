using System.Collections.Generic;
using App.src.commands.price;
using App.src.domains;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace App.src.Controllers
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
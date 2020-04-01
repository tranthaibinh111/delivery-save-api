using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ann_web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeliverySaveController : ControllerBase
    {
        private readonly ILogger<DeliverySaveController> _logger;
        private DeliverySaveService _service;

        public DeliverySaveController(ILogger<DeliverySaveController> logger)
        {
            _logger = logger;
            _service = new DeliverySaveService();
        }

        [HttpPost]
        [Route("suggestion-street")]
        public IActionResult suggestionStreet([FromForm]DeliverySaveSuggestionStreetModel data) 
        {
            var result = _service.suggestionStreet(data);
            
            return Ok(result);
        }

        [HttpPost]
        [Route("calculate-fee")]
        public IActionResult calculateFee([FromForm]DeliverySaveCalculateFeeModel data) {
            var result = _service.calculateFee(data);
            
            return Ok(result);
        } 
    }
}

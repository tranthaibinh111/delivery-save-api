using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using ann_web.Models.DeliverySave;

using ann_web.Services;


namespace ann_web.Controllers
{
  [ApiController]
  [Route("delivery-save")]
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
    public IActionResult suggestionStreet([FromBody]SuggestionStreetModel data)
    {
      var result = _service.suggestionStreet(data);

      return Ok(result);
    }

    [HttpPost]
    [Route("calculate-fee")]
    public IActionResult calculateFee([FromBody]CalculateFeeModel data)
    {
      var result = _service.calculateFee(data);

      return Ok(result);
    }

    [HttpPost]
    [Route("register-order")]
    public IActionResult registerOrder([FromBody]RegisterOrderModel data)
    {
      if (data.products.Count == 0)
        return BadRequest("Danh sách sản phẩm đang rỗng");

      var result = _service.registerOrder(data.products, data.order);
      return Ok(result);
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using ViewModels;

namespace API_Converted.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemApiController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;
        public OrderItemApiController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<OrderItemViewModel> GetById(int id)
        {
            var orderItemById = _orderItemService.GetById(id);
            if (orderItemById == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"This {id} does not exist");
            }
            return orderItemById;
        }

        [HttpPost]
        public IActionResult Add(OrderItemViewModel order)
        {
            _orderItemService.Save(order);
            return StatusCode(StatusCodes.Status201Created, "Your item was added.");
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            _orderItemService.Delete(id);
            return StatusCode(StatusCodes.Status200OK, "Succesufuly deleted order!");
        }
    }
}

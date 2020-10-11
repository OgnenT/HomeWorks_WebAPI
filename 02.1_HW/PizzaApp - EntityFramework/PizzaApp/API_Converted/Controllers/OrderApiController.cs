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
    public class OrderApiController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderApiController(IOrderService orderService)
        {
            _orderService = orderService;
        }

       
        [HttpGet]
        [Route("{id}")]
        public ActionResult<OrderViewModel> GetById(int id)
        {
            var orderById = _orderService.GetById(id);
            if (orderById == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"This {id} does not exist");
            }
            return orderById;
        }

        [HttpPost]
        public IActionResult Add(OrderViewModel order)
        {
            _orderService.AddOrderForCustomer(order.CustomerId);
            return StatusCode(StatusCodes.Status201Created, "Your order was added.");
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            _orderService.Delete(id);
            return StatusCode(StatusCodes.Status200OK, "Succesufuly deleted order!");
        }
    }
}

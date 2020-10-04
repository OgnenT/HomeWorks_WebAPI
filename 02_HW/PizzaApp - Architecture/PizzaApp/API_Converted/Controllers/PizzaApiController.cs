using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using DataAccess;
using DomainModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Converted.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaApiController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Pizza>> GetAll()
        {
            return StaticDatabase.Pizzas;
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Pizza> GetById(int id)
        {
            var pizza = StaticDatabase.Pizzas.FirstOrDefault(x => x.Id == id);
            if (pizza == null)
            {
                StatusCode(StatusCodes.Status404NotFound, $"This {id} does not exist!");
            }
            return pizza;
        }

        [HttpPost]
        public IActionResult Add(Pizza pizza)
        {
            var newPizza = new Pizza(pizza.Name, pizza.Description, pizza.ImageUrl);
            StaticDatabase.Pizzas.Add(newPizza);
            return StatusCode(StatusCodes.Status201Created, $"You add your {pizza.Name}  pizza");
        }

        [HttpDelete("{id}")]
        public ActionResult<Pizza> DeleteById(int id)
        {
            var pizzaToDelete = StaticDatabase.Pizzas.SingleOrDefault(x => x.Id == id);
            if (pizzaToDelete == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"This pizza Id: {id} not exist");
            }
            StaticDatabase.Pizzas.Remove(pizzaToDelete);
            return StatusCode(StatusCodes.Status201Created, $"You delete pizza with id: {id}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using DomainModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Converted.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizeApiController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<PizzaSize>> GetAll()
        {
            return StaticDatabase.PizzaSizes;
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<PizzaSize> GetById(int id)
        {
            var pizza = StaticDatabase.PizzaSizes.FirstOrDefault(x => x.Id == id);
            if (pizza == null)
            {
                StatusCode(StatusCodes.Status404NotFound, $"This {id} does not exist!");
            }
            return pizza;
        }

        [HttpPost]
        public IActionResult Add(PizzaSize pizza)
        {
            var newPizzaSize = new PizzaSize(pizza.Pizza, pizza.Size, pizza.Price);
            StaticDatabase.PizzaSizes.Add(newPizzaSize);
            return StatusCode(StatusCodes.Status201Created, $"You add your {pizza.Pizza.Name}  pizza");
        }

        [HttpDelete("{id}")]
        public ActionResult<PizzaSize> DeleteById(int id)
        {
            var PizzaSizeToDelete = StaticDatabase.PizzaSizes.SingleOrDefault(x => x.Id == id);
            if (PizzaSizeToDelete == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"This pizzaSize Id: {id} not exist");
            }
            StaticDatabase.PizzaSizes.Remove(PizzaSizeToDelete);
            return StatusCode(StatusCodes.Status201Created, $"You delete pizzaSize with id: {id}");
        }

    }
}

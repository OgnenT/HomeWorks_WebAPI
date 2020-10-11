using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using DomainModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using ViewModels;

namespace API_Converted.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaApiController : ControllerBase
    {
        private readonly IPizzaService _pizzaService;
        public PizzaApiController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        [HttpGet]
        public ActionResult<List<PizzaViewModel>> GetAll()
        {
            return _pizzaService.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<PizzaViewModel> GetById(int id)
        {
            var pizzaById = _pizzaService.GetById(id);
            if (pizzaById == null)
            {
                StatusCode(StatusCodes.Status404NotFound, $"This {id} does not exist");
            }
            return pizzaById;
        }

        [HttpPost]
        public IActionResult Add(PizzaViewModel pizza)
        {
            _pizzaService.Save(pizza);
            return StatusCode(StatusCodes.Status201Created, "Your Pizza was added.");
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            _pizzaService.Delete(id);
            return StatusCode(StatusCodes.Status200OK, "Pizza was succesufuly deleted");
        }
    }
}

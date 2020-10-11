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
    public class PizzaSizeController : ControllerBase
    {
        private readonly IPizzaSizeService _pizzaSizeService;
        public PizzaSizeController(IPizzaSizeService pizzaSizeService)
        {
            _pizzaSizeService = pizzaSizeService;
        }

        [HttpGet]
        public ActionResult<List<PizzaSizeViewModel>> GetAll()
        {
            return _pizzaSizeService.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<PizzaSizeViewModel> GetById(int id)
        {
            var pizzaById = _pizzaSizeService.GetById(id);
            if (pizzaById == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"This {id} does not exist");
            }
            return pizzaById;
        }

        [HttpPost]
        public IActionResult Add(PizzaSizeViewModel pizza)
        {
            _pizzaSizeService.Save(pizza);
            return StatusCode(StatusCodes.Status200OK, "Succesufuly added!");
        }
    }
}

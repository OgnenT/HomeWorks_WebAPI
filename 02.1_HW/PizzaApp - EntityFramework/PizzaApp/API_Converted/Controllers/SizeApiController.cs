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
    public class SizeApiController : ControllerBase
    {
        private readonly ISizeService _pizzaSizeService;
        public SizeApiController(ISizeService pizzaSizeRepo)
        {
            _pizzaSizeService = pizzaSizeRepo;
        }

        [HttpGet]
        public ActionResult<List<SizeViewModel>> GetAll()
        {
            return _pizzaSizeService.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<SizeViewModel> GetById(int id)
        {
            var pizzaSizeById = _pizzaSizeService.GetById(id);
            if (pizzaSizeById == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"This {id} does not exist");
            }
            return pizzaSizeById;
        }

        [HttpPost]
        public IActionResult Add(SizeViewModel pizza)
        {
            _pizzaSizeService.Save(pizza);
            return StatusCode(StatusCodes.Status201Created, "Your Pizza was added.");
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            _pizzaSizeService.Delete(id);
            return StatusCode(StatusCodes.Status200OK, "Succesufuly deleted!");
        }
    }
}

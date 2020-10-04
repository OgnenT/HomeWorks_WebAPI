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
    public class PizzaSizeApiController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Size>> GetAll()
        {
            return StaticDatabase.Sizes;
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Size> GetById(int id)
        {
            var pizzaById = StaticDatabase.Sizes.SingleOrDefault(x => x.Id == id);
            if (pizzaById == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"This pizza id: {id} does not exist");
            }
            return pizzaById;
            //return StatusCode(StatusCodes.Status201Created, "Done");
        }

        [HttpDelete("{id}")]
        public ActionResult<Size> DeleteById(int id)
        {
            var pizzaToDelete = StaticDatabase.Sizes.SingleOrDefault(x => x.Id == id);
            if (pizzaToDelete == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"This id: {id} does not exist");
            }

            StaticDatabase.Sizes.Remove(pizzaToDelete);
            return StatusCode(StatusCodes.Status201Created, $"Deleted successfully");
        }

        [HttpPost]
        public ActionResult<Size> AddNew(Size size) //Ovde imam prasanje zosto ne moze vaka da se resi so check na ID. (zaradi generiranjeto na random Id)
        {
            var newPizzaS = new Size(size.Name, size.Description);
            int newPizzaSId = newPizzaS.Id;

            var checkIfExist = StaticDatabase.Sizes.SingleOrDefault(x => x.Id == newPizzaSId);
            if (checkIfExist == null)
            {
                StaticDatabase.Sizes.Add(newPizzaS);
                return StatusCode(StatusCodes.Status201Created, "Your new pizza size was added");
            }
            else
            {
                return StatusCode(StatusCodes.Status409Conflict, "Already exist");
            }
        }
    }
}

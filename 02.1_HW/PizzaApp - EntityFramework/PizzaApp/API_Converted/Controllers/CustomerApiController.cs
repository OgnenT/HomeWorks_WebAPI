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
    public class CustomerApiController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerApiController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public ActionResult<List<CustomerViewModel>> GetAll()
        {
            return _customerService.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<CustomerViewModel> GetById(int id)
        {
            var customerById = _customerService.GetById(id);
            if (customerById == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"This {id} does not exist");
            }
            return customerById;
        }

        [HttpPost]
        public IActionResult Add(CustomerViewModel customer)
        {
            _customerService.Save(customer);
            return StatusCode(StatusCodes.Status201Created, "Your customer was added.");
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            _customerService.Delete(id);
            return StatusCode(StatusCodes.Status200OK, "Succesufuly deleted!");
        }
    }
}

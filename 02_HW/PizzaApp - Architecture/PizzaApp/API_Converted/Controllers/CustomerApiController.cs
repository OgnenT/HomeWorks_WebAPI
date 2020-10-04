using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;
using DataAccess;
using DomainModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Converted.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerApiController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Customer>> GetAll()
        {
            return StaticDatabase.Customers;
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Customer> GetById(int id)
        {
            var customer = StaticDatabase.Customers.FirstOrDefault(x => x.Id == id);
            if (customer == null)
            {
                StatusCode(StatusCodes.Status404NotFound, $"This {id} does not exist!");
            }
            return customer;
        }

        [HttpPost]
        public IActionResult Add(Customer customer)
        {
            var newCustomer = new Customer(customer.FirstName, customer.LastName, customer.Address, customer.Phone);
            StaticDatabase.Customers.Add(newCustomer);
            return StatusCode(StatusCodes.Status201Created, $"You add new customer: {customer.FirstName} {customer.LastName}");
        }

        [HttpDelete("{id}")]
        public ActionResult<Customer> DeleteById(int id)
        {
            var customerToDelete = StaticDatabase.Customers.SingleOrDefault(x => x.Id == id);
            if (customerToDelete == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"This customer Id: {id} does not exist");
            }
            StaticDatabase.Customers.Remove(customerToDelete);
            return StatusCode(StatusCodes.Status201Created, $"You delete customer with id: {id}");
        }
    }
}

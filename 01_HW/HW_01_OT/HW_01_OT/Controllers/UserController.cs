using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HW_01_OT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        [Route("users")]
        public ActionResult<List<string>> GetAllUsers()
        {
            //return Ok(StaticDB.UserNames);
            return StatusCode(StatusCodes.Status201Created, StaticDB.UserNames);
        }

        //[HttpGet]
        //[Route("{id}")]
        //public ActionResult<string> GetById(int id)
        //{
        //    try
        //    {
        //        if (id >= StaticDB.UserNames.Count)
        //        {
        //            return StatusCode(StatusCodes.Status404NotFound, $"There are only {StaticDB.UserNames.Count} items in the list!");
        //        }
        //        if (id < 0)
        //        {
        //            return StatusCode(StatusCodes.Status404NotFound, $"Only positive numbers!");
        //        }
        //        return Ok(StaticDB.UserNames[id]);

        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status409Conflict, $"Error, you need Admin help ({ex.Message})");
        //    }
        //}

        [HttpPost]
        public async  Task<IActionResult> AddNewUser()
        {
            try
            {
                using (StreamReader streaReader = new StreamReader(Request.Body))
                {
                    var userName = await streaReader.ReadToEndAsync();
                    StaticDB.UserNames.Add(userName);
                    return StatusCode(StatusCodes.Status201Created, "New name was added.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status409Conflict, $"Error, this is your message {ex.Message}");
            }

        }
    }
}

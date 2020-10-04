using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using HW_01_OT.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HW_01_OT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BonusController : ControllerBase
    {
        [HttpGet]
        [Route("allUsers")]
        public ActionResult<List<User>> GetAllUsers()
        {
            return Ok(StaticDB.UsersList);
        }

        [HttpPost]
        public async Task<IActionResult> NewUser()
        {
            try
            {
                using (StreamReader streamReader = new StreamReader(Request.Body))
                {
                    string content = await streamReader.ReadToEndAsync();
                    User newUser = JsonConvert.DeserializeObject<User>(content);
                    StaticDB.UsersList.Add(newUser);
                    return StatusCode(StatusCodes.Status201Created, "Created");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status409Conflict, "Error");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<User> DeleteById(int id)
        {
            var userToDelete = StaticDB.UsersList.SingleOrDefault(x => x.Id == id);
            if (userToDelete == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "No such a user");
            }
            StaticDB.UsersList.Remove(userToDelete);

            return StatusCode(StatusCodes.Status201Created, "Deleted successfully");
        }

    }
}

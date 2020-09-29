using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW_01_OT.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public User(int id, string fName, string lName)
        {
            Id = id;
            FirstName = fName;
            LastName = lName;
        }
    }

}

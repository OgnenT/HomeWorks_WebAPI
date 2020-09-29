using HW_01_OT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW_01_OT
{
    public static class StaticDB
    {
        public static List<string> UserNames = new List<string>
        {
            "Ognen",
            "Gorjan",
            "Biljana",
            "Sofija",
            "Stevo"
        };

        public static List<User> UsersList = new List<User>()
        {
            new User ( 1, "Ognen", "Temelkovski" ),
            new User ( 2, "Gorjan", "Temelkovski" ),
            new User ( 3, "Biljana", "Temelkovska" )
        };
    }
}

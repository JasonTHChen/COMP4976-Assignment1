using LmycDataLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LmycWebSite.Models
{
    public class DummyData
    {
        public static List<ApplicationUser> GetAdmins()
        {
            List<ApplicationUser> users = new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    UserName = "a",
                    Email = "a@a.a",
                    FirstName = "Jason",
                    LastName = "Chen",
                    Street = "3700 Willingdon Ave",
                    City = "Burnaby",
                    Province = "BC",
                    PostalCode = "V5G 3H2",
                    Country = "Canada",
                    MobileNumber = "(604) 434-5734",
                    SailingExperience = 50
                }
            };

            return users;
        }


        public static List<ApplicationUser> GetMembers()
        {
            List<ApplicationUser> users = new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    UserName = "m",
                    Email = "m@m.m",
                    FirstName = "Siri",
                    LastName = "Apple",
                    Street = "3700 Willingdon Ave",
                    City = "Burnaby",
                    Province = "BC",
                    PostalCode = "V5G 3H2",
                    Country = "Canada",
                    MobileNumber = "(604) 434-5734",
                    SailingExperience = 2
                }
            };

            return users;
        }
    }
}
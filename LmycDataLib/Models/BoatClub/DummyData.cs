using LmycDataLib.Models;
using LmycDataLib.Models.BoatClub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LmycWebSite
{
    public class DummyData
    {
        public static List<Boat> GetBoats(ApplicationDbContext db)
        {
            List<Boat> boats = new List<Boat>()
            {
                new Boat()
                {
                    BoatName = "King George",
                    Picture = "http://www.lmyc.ca/sites/default/files/content/pages/sharqui%20photo.jpg",
                    LengthInFeet = 33,
                    Make = "LMYC",
                    Year = 2016,
                    CreationDate = DateTime.Today,
                    User = db.Users.FirstOrDefault(u => u.UserName == "a")
                },

                new Boat()
                {
                    BoatName = "QueensBorough",
                    Picture = "http://www.lmyc.ca/sites/default/files/content/pages/white%20swan.jpg",
                    LengthInFeet = 50,
                    Make = "Vancouvoat",
                    Year = 2018,
                    CreationDate = DateTime.Today,
                    User = db.Users.FirstOrDefault(u => u.UserName == "a")
                },

                new Boat()
                {
                    BoatName = "Otter",
                    Picture = "http://www.lmyc.ca/sites/default/files/Lightcurefleetpic.jpg",
                    LengthInFeet = 33,
                    Make = "The Otter Company",
                    Year = 2017,
                    CreationDate = DateTime.Today,
                    User = db.Users.FirstOrDefault(u => u.UserName == "a")
                },

                new Boat()
                {
                    BoatName = "WaffleBoat",
                    Picture = "http://www.lmyc.ca/sites/default/files/content/pages/frankie.jpg",
                    LengthInFeet = 28,
                    Make = "Waffle Incorporations",
                    Year = 2018,
                    CreationDate = DateTime.Today,
                    User = db.Users.FirstOrDefault (u => u.UserName == "a" )
                },

                new Boat()
                {
                    BoatName = "KoiSailer",
                    Picture = "http://www.lmyc.ca/sites/default/files/content/pages/Small%20pegasus.jpg",
                    LengthInFeet = 22,
                    Make = "Koi & Co.",
                    Year = 2018,
                    CreationDate = DateTime.Today,
                    User = db.Users.FirstOrDefault (u => u.UserName == "a" )
                },

            };
            return boats;
        }
    }
}
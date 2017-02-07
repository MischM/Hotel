using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagement.Models
{
    public class Hotel
    {
        private int hotelID;
        private string description;
        private int stars;

        //Constructors
        public Hotel(int id, string desc, int stars)
        {
            HotelID = id;
            Description = desc;
            Stars = stars;
        }

        //Methodes
        public int HotelID
        {
            get { return hotelID; }
            set { hotelID = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public int Stars
        {
            get { return stars; }
            set { stars = value; }
        }
    }
}
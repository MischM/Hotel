using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel.Data
{
    public class HotelRepository
    {
        private static List<Hotel> hotels = new List<Hotel>();
        static HotelRepository()
        {
            hotels.Add(new Hotel(1, "Hotel zur Post", 2));
            hotels.Add(new Hotel(2, "Hotel Rebstock", 3));
            hotels.Add(new Hotel(3, "Wellness Hotel", 4));
        }
        public List<Hotel> FindAll()
        {
            return hotels;
        }
        public Hotel FindById(int id)
        {
            return hotels.Where(h => h.HotelID == id).FirstOrDefault();
        }
        public void Delete(int id)
        {
            var hotel = FindById(id);
            hotels.Remove(hotel);
        }
        public void Save(Hotel h)
        {
            if(h.HotelID == 0)
            {
                hotels.Add(h);
                h.HotelID = hotels.Max(htl => htl.HotelID) + 1;
            }
            else
            {
                var hotel = FindById(h.HotelID);
                hotel.Description = h.Description;
                hotel.Stars = h.Stars;
            }
        }
    }
}
using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagement.Data
{
    public class HotelRepositoryDB
    {
        //private static List<Hotel> hotels = new List<Hotel>();
        static HotelRepositoryDB()
        {/*
            hotels.Add(new Hotel(1, "Hotel zur Post", 2));
            hotels.Add(new Hotel(2, "Hotel Rebstock", 3));
            hotels.Add(new Hotel(3, "Wellness Hotel", 4));
        */}
        public IEnumerable<Hotel> FindAll()
        {
            HotelDBEntities ctx = new HotelDBEntities();
            return ctx.Hotels;
        }
        public Hotel FindById(int id)
        {
            HotelDBEntities ctx = new HotelDBEntities();
            ctx.Configuration.LazyLoadingEnabled = false;
            return ctx.Hotels.FirstOrDefault(h => h.HotelID == id);
        }
        public void Delete(int id)
        {
            var hotel = FindById(id);
            Delete(hotel);
        }
        public void Delete(Hotel h)
        {
            HotelDBEntities ctx = new HotelDBEntities();
            ctx.Hotels.Attach(h);
            ctx.Entry(h).State = System.Data.Entity.EntityState.Deleted;
            ctx.Hotels.Remove(h);
            ctx.SaveChanges();
        }


        public void Save(Hotel h)
        {
            HotelDBEntities ctx = new HotelDBEntities();
            if (h.HotelID == 0)
            {//neues Hotel einfügen
                ctx.Hotels.Add(h);
                ctx.SaveChanges();
            }
            else
            {//bestehende Hotel aktualisieren
                ctx.Hotels.Attach(h);
                ctx.Entry(h).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
            }
        }
        public void Dispose()
        {

        }
    }
}
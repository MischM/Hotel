﻿using HotelManagement.Data;
using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagement.Controllers
{
    public class HotelController : Controller
    {
        private List<SelectListItem> CreateStars()
        {
            SelectListItem it1 = new SelectListItem() { Value = "5", Text = "Fünf Stene, De Luxe" };
            SelectListItem it2 = new SelectListItem() { Value = "4", Text = "Vier Sterne, First Class" };
            SelectListItem it3 = new SelectListItem() { Value = "3", Text = "Drei Sterne, Komfort" };
            SelectListItem it4 = new SelectListItem() { Value = "2", Text = "Zwei Sterne, Standard" };
            SelectListItem it5 = new SelectListItem() { Value = "1", Text = "Ein Stern, Tourist" };
            List<SelectListItem> hotelKlassList = new List<SelectListItem> { it1, it2, it3, it4, it5 };
            return hotelKlassList;
        }


        // GET: Hotel
        public ActionResult Index()
        {
            HotelRepository rep = new HotelRepository();
            List<Hotel> hotels = rep.FindAll();
            return View(hotels);
        }
        public ActionResult Edit(int id)
        {
            var rep = new HotelRepository();
            var hotel = rep.FindById(id);
            ViewBag.StarSelection = CreateStars();
            return View(hotel);
        }
        [HttpPost]
        public ActionResult Edit(Hotel h)
        {
            HotelRepository rep = new HotelRepository();
            rep.Save(h);
            ViewBag.Message = "Hotel gespeichert";
            ViewBag.StarSelection = CreateStars();
            return View(h);
        }
        public ActionResult Delete(int id)
        {
            HotelRepository rep = new HotelRepository();
            rep.Delete(id);
            return Index();
        }
        public ActionResult Create()
        {
            HotelRepository rep = new HotelRepository();
            Hotel h = new Hotel(0, "neues Hotel", 0);
            rep.Save(h);
            return Index();
        }

    }
}
﻿using Inta.Turizm.Business.Abstract;
using Inta.Turizm.Dto.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Inta.Turizm.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }
        // GET: api/<HotelController>
        [HttpGet]
        public HotelDto Get()
        {
            //return _hotelService.Find(null, new string[] { "HotelImages", "HotelImages.HotelVersions" }).Data;

            return _hotelService.Get(v=> v.Id>0 && v.HotelImages.Any(), new string[] { "HotelImages"}).Data;
        }

        // GET api/<HotelController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {

            return "value";
        }

        // POST api/<HotelController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<HotelController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HotelController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

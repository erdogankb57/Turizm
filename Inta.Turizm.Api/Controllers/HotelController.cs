using Inta.Turizm.Business.Abstract;
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
        public List<HotelDto> Get()
        {
            //return _hotelService.Find(null, new string[] { "HotelImages", "HotelImages.HotelVersions" }).Data;

            //return _hotelService.GetById(1).Data;
            return _hotelService.Find(v => v.Id > 0, new string[] { "HotelImages" }, 0, 10).Data;
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

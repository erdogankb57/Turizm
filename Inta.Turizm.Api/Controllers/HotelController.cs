using Inta.Turizm.Business.Abstract;
using Inta.Turizm.Core.Model;
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
        public DataResult<List<HotelDto>> Get()
        {
            return _hotelService.Find(v => v.Id > 0, new string[] { "HotelImages" }, 0, 10);
        }

        [HttpGet("{id}")]
        public DataResult<HotelDto> Get(int id)
        {
            return _hotelService.Get(v=> v.Id == id, new string[] { "HotelImages" });
        }

        [HttpPost]
        public DataResult<HotelDto> Post([FromBody] HotelDto value)
        {
            return _hotelService.Save(value);
        }

        public DataResult<HotelDto> Put([FromBody] HotelDto value)
        {
            return _hotelService.Update(value);
        }

        public DataResult<HotelDto> Delete(int id)
        {
            var dto = _hotelService.Get(v => v.Id == id).Data;
            return _hotelService.Update(dto);
        }
    }
}

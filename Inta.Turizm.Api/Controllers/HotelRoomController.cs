using Inta.Turizm.Business.Abstract;
using Inta.Turizm.Core.Model;
using Inta.Turizm.Dto.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inta.Turizm.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelRoomController : ControllerBase
    {
        private IHotelRoomService _hotelService;

        public HotelRoomController(IHotelRoomService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet]
        public DataResult<List<HotelRoomDto>> Get()
        {
            return _hotelService.Find(v => v.Id > 0, new string[] { "HotelRoomImages" }, 0, 10);
        }

        [HttpGet("{id}")]
        public DataResult<HotelRoomDto> Get(int id)
        {
            return _hotelService.Get(v => v.Id == id, new string[] { "HotelImages" });
        }

        [HttpPost]
        public DataResult<HotelRoomDto> Post([FromBody] HotelRoomDto value)
        {
            return _hotelService.Save(value);
        }

        [HttpPut]
        public DataResult<HotelRoomDto> Put([FromBody] HotelRoomDto value)
        {
            return _hotelService.Update(value);
        }

        [HttpDelete]
        public DataResult<HotelRoomDto> Delete(int id)
        {
            return _hotelService.Delete(id);
        }
    }
}

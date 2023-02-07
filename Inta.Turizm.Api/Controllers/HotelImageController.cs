using Inta.Turizm.Business.Abstract;
using Inta.Turizm.Core.Model;
using Inta.Turizm.Dto.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inta.Turizm.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelImageController : ControllerBase
    {
        private IHotelImageService _hotelService;

        public HotelImageController(IHotelImageService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet]
        public DataResult<List<HotelImageDto>> Get()
        {
            return _hotelService.Find(v => v.Id > 0, new string[] { "HotelImages", "HotelRooms", "HotelRooms.HotelRoomImages" }, 0, 10);
        }

        [HttpGet("{id}")]
        public DataResult<HotelImageDto> Get(int id)
        {
            return _hotelService.Get(v => v.Id == id, new string[] { "HotelImages" });
        }

        [HttpPost]
        public DataResult<HotelImageDto> Post([FromBody] HotelImageDto value)
        {
            return _hotelService.Save(value);
        }

        [HttpPut]
        public DataResult<HotelImageDto> Put([FromBody] HotelImageDto value)
        {
            return _hotelService.Update(value);
        }

        [HttpDelete]
        public DataResult<HotelImageDto> Delete(int id)
        {
            return _hotelService.Delete(id);
        }
    }
}

using Inta.Turizm.Business.Abstract;
using Inta.Turizm.Core.Model;
using Inta.Turizm.Dto.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inta.Turizm.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelRoomImageController : ControllerBase
    {
        private IHotelRoomImageService _hotelService;

        public HotelRoomImageController(IHotelRoomImageService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet]
        public DataResult<List<HotelRoomImageDto>> Get()
        {
            return _hotelService.Find(v => v.Id > 0, new string[] { "HotelImages", "HotelRooms", "HotelRooms.HotelRoomImages" }, 0, 10);
        }

        [HttpGet("{id}")]
        public DataResult<HotelRoomImageDto> Get(int id)
        {
            return _hotelService.Get(v => v.Id == id, new string[] { "HotelImages" });
        }

        [HttpPost]
        public DataResult<HotelRoomImageDto> Post([FromBody] HotelRoomImageDto value)
        {
            return _hotelService.Save(value);
        }

        [HttpPut]
        public DataResult<HotelRoomImageDto> Put([FromBody] HotelRoomImageDto value)
        {
            return _hotelService.Update(value);
        }

        [HttpDelete]
        public DataResult<HotelRoomImageDto> Delete(int id)
        {
            return _hotelService.Delete(id);
        }
    }
}

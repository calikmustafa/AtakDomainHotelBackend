using AtakDomainHotelBackend.API.Helpers;
using AtakDomainHotelBackend.API.Validation;
using AtakDomainHotelBackend.Core.DTOs;
using AtakDomainHotelBackend.Core.Entity;
using AtakDomainHotelBackend.Core.Pagination;
using AtakDomainHotelBackend.Service.UnitOfWork;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace AtakDomainHotelBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<HotelController> _logger;
        private readonly IMapper _mapper;

        public HotelController(IUnitOfWork unitOfWork, ILogger<HotelController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetHotelList([FromQuery] PagingParams pagingParams)
        {
            try
            {
                List<Expression<Func<Hotel, bool>>> expressions = new List<Expression<Func<Hotel, bool>>>();
                if (pagingParams.Searchtext != null)
                {
                    Expression<Func<Hotel, bool>> condition = hotel => (
                  hotel.name.ToUpper().Contains(pagingParams.Searchtext.ToUpper()) ||
                  hotel.address.ToUpper().Contains(pagingParams.Searchtext.ToUpper()) ||
                  hotel.contact.Contains(pagingParams.Searchtext) ||
                  hotel.phone.Contains(pagingParams.Searchtext) ||
                  hotel.uri.Contains(pagingParams.Searchtext)


                  );
                    expressions.Add(condition);
                }
               

                int datacount = _unitOfWork.HotelWithStarsRepository.GetAllTableCount(expressions);

              IEnumerable<Hotel> list = _unitOfWork.HotelWithStarsRepository.GetAll();
                

                Response.AddPagination(pagingParams.PageNumber, pagingParams.PageSize, datacount, datacount / pagingParams.PageSize, pagingParams.Searchtext, pagingParams.Orderby, pagingParams.OrderbyAsc);
                return Ok(list);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        [HttpGet("{stars}")]
        public async Task<IActionResult> GetListHotelByStars(int stars)
        {

            var list = await _unitOfWork.HotelWithStarsRepository.GetListHotelByStars(stars);
            var hotelToReturn= _mapper.Map<IEnumerable<HotelListDTO>>(list);
            return Ok(hotelToReturn);
        }
        
        [HttpPost]
        public async Task< IActionResult> Insert([FromBody] Hotel hotel)
        {
            try
            {
                
                ValidationTool.Validate(new HotelValidation(), hotel);
                await _unitOfWork.HotelWithStarsRepository.AddAsync(hotel);
                await _unitOfWork.SaveAll();
                return Ok("Model is valid,Hotel is Added");
            }
            catch (Exception error)
            {
                _logger.LogError(error.Message);
                return BadRequest("Hotel Verisi Yüklenirken Bir Hata oluştu"+error.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromBody] Hotel hotel, int id)
        {

            ValidationTool.Validate(new HotelValidation(), hotel);

            if (hotel.id != id)
            {
                return BadRequest("Gönderilen veriler eşleşmiyor");
            }
            try
            {

                Hotel oldHotel = await _unitOfWork.HotelWithStarsRepository.FirstOrDefaultAsync(e => e.id == id);

                _unitOfWork.HotelWithStarsRepository.Update(hotel, oldHotel);
                await _unitOfWork.SaveAll();
                return Ok("Model is valid for update");
            }
            catch (Exception error)
            {
                _logger.LogError(error.Message);
                return BadRequest("Veri güncellenirken bir hata oluştu. Hata: " + error.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var oldData = await _unitOfWork.HotelWithStarsRepository.FirstOrDefaultAsync(x => x.id == id);
                _unitOfWork.HotelWithStarsRepository.Remove(oldData);
                await _unitOfWork.SaveAll();
                return Ok();
            }
            catch (Exception error)
            {
                _logger.LogError(error.Message);
                return BadRequest("Veri silinirken bir hata oluştu. Hata: " + error.Message);
            }
        }

       

    }
}

using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TravelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourController : ControllerBase
    {
        private readonly ITourService _tourService;
        public TourController(ITourService tourService)
        {
            _tourService = tourService;
        }
        [HttpGet("GetAllTours")]
        public IActionResult GetProduct()
        {
            var result = _tourService.GetAllTour();
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetTour")]
        public IActionResult Get(int id)
        {
            var result = _tourService.GetTour(id);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("AddTour")]
        public IActionResult Add(Tour tour)
        {
            var result = _tourService.Add(tour);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("DeleteTour")]
        public IActionResult Delete(int id)
        {
            var result = _tourService.Delete(id);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

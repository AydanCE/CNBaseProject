using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TravelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuideController : ControllerBase
    {
        private readonly IGuideService _guideService;
        public GuideController(IGuideService guideService)
        {
            _guideService = guideService;
        }
        [HttpGet("GetGuide")]
        public IActionResult Get(int id)
        {
            var result = _guideService.GetGuide(id);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetAllGuides")]
        public IActionResult GetAllGuide()
        {
            var result = _guideService.GetAllGuide();
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetAllGuidesByTour")]
        public IActionResult GetAllGuidesByTour(int tourId)
        {
            var result = _guideService.GetAllGuidesByTour(tourId);
            if( result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("AddGuide")]
        public IActionResult Add(Guide guide)
        {
            var result = _guideService.Add(guide);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("DeleteGuide")]
        public IActionResult Delete(int id)
        {
            var result = _guideService.Delete(id);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

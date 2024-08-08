using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TravelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController(IOrderDetailService orderDetailService) : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService = orderDetailService;
        [HttpGet("GetAllOrderDetails")]
        public IActionResult GetAll()
        {
            var result = _orderDetailService.GetAllOrderDetails();
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("AddOrderDetail")]
        public IActionResult Add(OrderDetail orderDetail)
        {
            var result = _orderDetailService.AddOrderDetail(orderDetail);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

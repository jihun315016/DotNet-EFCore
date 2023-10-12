using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using PizzaApp.SQLite.Data;
using PizzaApp.SQLite.Models;
using PizzaApp.SQLite.Services;

namespace PizzaApp.SQLite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        CouponService _service;

        public CouponController(CouponService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Coupon> GetAll()
        {
            return _service.GetAll();
        }
    }
}

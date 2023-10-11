using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using PizzaApp.SQLite.Data;
using PizzaApp.SQLite.Models;

namespace PizzaApp.SQLite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        PromotionsContext _context;

        public CouponController(PromotionsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Coupon> Get()
        {
            return _context.Coupons.AsNoTracking().ToList();
        }
    }
}

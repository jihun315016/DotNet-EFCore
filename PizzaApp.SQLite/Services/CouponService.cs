using Microsoft.EntityFrameworkCore;
using PizzaApp.SQLite.Data;
using PizzaApp.SQLite.Models;

namespace PizzaApp.SQLite.Services;

public class CouponService
{
    private readonly PromotionsContext _context;

    public CouponService(PromotionsContext context)
    {
        _context = context;
    }

    public IEnumerable<Coupon> GetAll()
    {        
        return _context.Coupons
            .AsNoTracking()
            .ToList();
    }
}
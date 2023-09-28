using Microsoft.EntityFrameworkCore;
using PizzaApp.Data;
using PizzaApp.Models;
using SQLitePCL;

namespace PizzaApp.Services;

public class PizzaService
{
    private readonly PizzaContext _context;

    /// <summary>
    /// Program 클래스의 AddSqlite 메서드로 주입한 종속성(PizzaContext) 등록
    /// </summary>
    /// <param name="context"></param>
    public PizzaService(PizzaContext context)
    {
        _context = context;
    }

    public IEnumerable<Pizza> GetAll()
    {        
        return _context.Pizzas
            .AsNoTracking() // 조회 용도이므로 변경 사항을 추적하지 않는다.
            .ToList();
    }

    public Pizza? GetById(int id)
    {
        return _context.Pizzas
            .Include(p => p.Toppings)
            .Include(p => p.Sauce)
            .AsNoTracking()
            .SingleOrDefault(p => p.Id == id);
    }

    public Pizza? Create(Pizza newPizza)
    {
        throw new NotImplementedException();
    }

    public void AddTopping(int PizzaId, int ToppingId)
    {
        throw new NotImplementedException();
    }

    public void UpdateSauce(int PizzaId, int SauceId)
    {
        throw new NotImplementedException();
    }

    public void DeleteById(int id)
    {
        throw new NotImplementedException();
    }
}
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

    public Pizza Create(Pizza newPizza)
    {
        _context.Pizzas.Add(newPizza);
        _context.SaveChanges();

        return newPizza;
    }

    public void AddTopping(int PizzaId, int ToppingId)
    {
        var pizzaToUpdate = _context.Pizzas.Find(PizzaId);
        var toppingToAdd = _context.Toppings.Find(ToppingId);

        if (pizzaToUpdate is null || toppingToAdd is null)
        {
            throw new InvalidOperationException("Pizza or topping does not exist");
        }

        if (pizzaToUpdate.Toppings is null)
        {
            pizzaToUpdate.Toppings = new List<Topping>();
        }

        pizzaToUpdate.Toppings.Add(toppingToAdd);
        _context.SaveChanges();
    }

    public void UpdateSauce(int PizzaId, int SauceId)
    {
        // PizzaId 피자의 소스를 SauceId로 변경
        var pizzaToUpdate = _context.Pizzas.Find(PizzaId);
        var sauceToUpdate = _context.Sauces.Find(SauceId);

        if (pizzaToUpdate is null || sauceToUpdate is null)
        {
            // 유효하지 않을 때 발생하는 예외
            throw new InvalidOperationException("Pizza or sauce does not exist");
        }

        pizzaToUpdate.Sauce = sauceToUpdate;
        _context.SaveChanges();
    }

    public void DeleteById(int id)
    {
        var pizzaToDelete = _context.Pizzas.Find(id);
        if (pizzaToDelete is not null)
        {
            _context.Pizzas.Remove(pizzaToDelete);
            _context.SaveChanges();
        }
    }
}
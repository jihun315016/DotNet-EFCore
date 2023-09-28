using Microsoft.EntityFrameworkCore;
using PizzaApp.Data;
using PizzaApp.Models;
using SQLitePCL;

namespace PizzaApp.Services;

public class PizzaService
{
    private readonly PizzaContext _context;

    /// <summary>
    /// Program Ŭ������ AddSqlite �޼���� ������ ���Ӽ�(PizzaContext) ���
    /// </summary>
    /// <param name="context"></param>
    public PizzaService(PizzaContext context)
    {
        _context = context;
    }

    public IEnumerable<Pizza> GetAll()
    {        
        return _context.Pizzas
            .AsNoTracking() // ��ȸ �뵵�̹Ƿ� ���� ������ �������� �ʴ´�.
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
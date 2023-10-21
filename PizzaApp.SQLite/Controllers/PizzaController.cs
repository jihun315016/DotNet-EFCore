using Microsoft.AspNetCore.Mvc;
using PizzaApp.SQLite.Models;
using PizzaApp.SQLite.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PizzaApp.SQLite.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PizzaController : ControllerBase
{
    PizzaService _service;

    public PizzaController(PizzaService service)
    {
        _service = service;
    }

    [HttpGet]
    public IEnumerable<Pizza> GetAll()
    {
        return _service.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<Pizza> GetById(int id)
    {
        var pizza = _service.GetById(id);

        if (pizza is not null)
        {
            return pizza;
        }
        else
        {
            return NotFound();
        }
    }


    [HttpPost]
    public IActionResult Create(Pizza newPizza)
    {
        var pizza = _service.Create(newPizza);
        return CreatedAtAction(nameof(GetById), new { id = pizza!.Id }, pizza);
    }

    [HttpPut("addtopping")]
    public IActionResult AddTopping(PizzaTopping pizzaTopping)
    {
        var pizzaToUpdate = _service.GetById(pizzaTopping.PizzasId);

        if (pizzaToUpdate is not null)
        {
            _service.AddTopping(pizzaTopping.PizzasId, pizzaTopping.ToppingsId);
            return NoContent();
        }
        else
        {
            return NotFound();
        }
    }

    [HttpDelete("deletesource")]
    public IActionResult Delete(Pizza deletePizza)
    {
        var pizza = _service.GetById(deletePizza.Id);

        if (pizza is not null)
        {
            _service.DeleteById(deletePizza.Id);
            return Ok();
        }
        else
        {
            return NotFound();
        }
    }
}

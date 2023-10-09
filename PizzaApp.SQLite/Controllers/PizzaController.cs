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

    [HttpPut("{id}/addtopping")]
    public IActionResult AddTopping(int id, int toppingId)
    {
        var pizzaToUpdate = _service.GetById(id);

        if (pizzaToUpdate is not null)
        {
            _service.AddTopping(id, toppingId);
            return NoContent();
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPut("{id}/updatesauce")]
    public IActionResult UpdateSauce(int id, int sauceId)
    {
        var pizzaToUpdate = _service.GetById(id);

        if (pizzaToUpdate is not null)
        {
            _service.UpdateSauce(id, sauceId);
            return NoContent();
        }
        else
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var pizza = _service.GetById(id);

        if (pizza is not null)
        {
            _service.DeleteById(id);
            return Ok();
        }
        else
        {
            return NotFound();
        }
    }
}

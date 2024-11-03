using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class ClienteController : ControllerBase
{
    private readonly ClienteContext _context;

    public ClienteController(ClienteContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Cliente>> GetClientes()
    {
        return _context.Clientes.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<Cliente> GetCliente(int id)
    {
        var cliente = _context.Clientes.Find(id);
        if (cliente == null)
        {
            return NotFound();
        }
        return cliente;
    }

    [HttpPost]
    public ActionResult<Cliente> PostCliente(Cliente cliente)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Clientes.Add(cliente);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetCliente), new { id = cliente.Id }, cliente);
    }

    [HttpPut("{id}")]
    public IActionResult PutCliente(int id, Cliente cliente)
    {
        if (id != cliente.Id || !ModelState.IsValid)
        {
            return BadRequest();
        }

        var existingCliente = _context.Clientes.Find(id);
        if (existingCliente == null)
        {
            return NotFound();
        }

        existingCliente.CPF = cliente.CPF;
        existingCliente.Email = cliente.Email;
        existingCliente.Nome = cliente.Nome;
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCliente(int id)
    {
        var cliente = _context.Clientes.Find(id);
        if (cliente == null)
        {
            return NotFound();
        }

        _context.Clientes.Remove(cliente);
        _context.SaveChanges();

        return NoContent();
    }
}
using Dojo.BLL;
using Dojo.DAO.Context;
using Microsoft.AspNetCore.Mvc;

namespace Dojo.WebApp.Controllers;

[ApiController]
[Route("Controller")]

public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    //Get
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var usuario = await _usuarioService.GetAllAsync();
        return Ok(usuario);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var usuario = await _usuarioService.GetByIdAsync(id);

        if (usuario == null)
          return NotFound();

        return Ok(usuario);
    }

    //Post
    [HttpPost]
    public async Task<IActionResult> Post(Usuario usuario)
    {
      await _usuarioService.AddAsync(usuario);
      return CreatedAtAction(nameof(Get), new {Id = usuario.Id}, usuario);

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Usuario usuario)
    {
        if(id != usuario.Id)
        
            return BadRequest("O id informado não igual ao id do usuáro ifnormado no objeto!");

        await _usuarioService.UpdateAsync(usuario);

        return NoContent();
        
    }

    [HttpDelete ("{id}")]
    public async Task<IActionResult> Delete(int id) 
    {
        await _usuarioService.DeleteAsync(id);
        return NoContent();
    }


}


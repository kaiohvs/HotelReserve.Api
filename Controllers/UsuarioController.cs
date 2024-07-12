using HotelReserve.Api.Models;
using HotelReserve.Api.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly UsuarioService _usuarioService;

    public UsuarioController(UsuarioService service)
    {
        _usuarioService = service;
    }

    [HttpPost("registrar")]
    public IActionResult Registrar([FromBody] Usuario usuario)
    {
        var novoUsuario = _usuarioService.RegistrarUsuario(usuario.Nome, usuario.Email, usuario.Senha);

        if (novoUsuario == null)
        {
            return BadRequest("Usuário já existe.");
        }

        return Ok(novoUsuario);
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] Usuario usuario)
    {
        var usuarioAutenticado = _usuarioService.VerificarLogin(usuario.Email, usuario.Senha);

        if (usuarioAutenticado == null)
        {
            return Unauthorized("E-mail ou senha incorretos.");
        }

        return Ok("Login bem-sucedido!");
    }
}

using Application.DTOs;
using Domain.Contract.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

/// <summary>
/// Gerencia operações de usuários.
/// </summary>
[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _service;
    public UserController(IUserService service) => _service = service;

    /// <summary>
    /// Retorna todos os usuários.
    /// </summary>
    [HttpGet()]
    public async Task<IActionResult> Get() => Ok(await _service.Get());

    /// <summary>
    /// Retorna um usuário específico por ID.
    /// </summary>
    /// <param name="id">O ID do usuário.</param>
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get([FromRoute] int id) => Ok(await _service.Get(id));

    /// <summary>
    /// Cria um novo usuário.
    /// </summary>
    /// <param name="request">O objeto DTO contendo as informações do usuário.</param>
    [HttpPost()]
    public async Task<IActionResult> Create([FromBody] UserDto request) => Ok(await _service.Create(request));

    /// <summary>
    /// Atualiza as informações de um usuário.
    /// </summary>
    /// <param name="request">O objeto DTO contendo as novas informações do usuário.</param>
    [HttpPut()]
    public async Task<IActionResult> Update([FromBody] UserDto request) => Ok(await _service.Update(request));

    /// <summary>
    /// Remove um usuário específico.
    /// </summary>
    /// <param name="id">O ID do usuário.</param>
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Remove([FromRoute] int id) => Ok(await _service.Remove(id));
}

using Application.DTOs;
using Domain.Contract.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _service;
    public UserController(IUserService service)
    {
        _service = service;
    }

    [HttpGet()]
    public async Task<IActionResult> Get() => Ok(await _service.Get());

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get([FromRoute] int id) => Ok(await _service.Get(id));

    [HttpPost()]
    public async Task<IActionResult> Create([FromBody] UserDto request) => Ok(await _service.Create(request));

    [HttpPut()]
    public async Task<IActionResult> Update([FromBody] UserDto request) => Ok(await _service.Update(request));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Remove([FromRoute] int id) => Ok(await _service.Remove(id));
}
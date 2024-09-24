﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RandomUserGeneratorPaschoalotto.Application.Services;
using RandomUserGeneratorPaschoalotto.Domain.Entities;

namespace RandomUserGeneratorPaschoalotto.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("create")]
        public async Task<ActionResult<List<User>>> CreateMultipleUsers(int count)
        {
            var newUsers = await _userService.GenerateAndAddRandomUsers(count);

            return Ok(newUsers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _userService.GetUsuarios(id);

            return Ok(user);
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            var users = await _userService.GetUsuario();

            return Ok(users);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.IdUser)
            {
                return BadRequest("O IdUsuario informado está incorreto.");
            }

            var result = await _userService.UpdateUser(id, user);

            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DelUser(int id)
        {
            if (id == null)
            {
                return BadRequest("O IdUsuario informado está incorreto.");
            }

            var result = await _userService.DeleteUser(id);

            if (!result)
            {
                return NotFound();
            }
            
            return Ok(result);
        }
    }
}
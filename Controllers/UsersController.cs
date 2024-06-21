using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs;
using api.DTOs.Users;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public UsersController(ApplicationDBContext context)
        {
            _context = context;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _context.Users.ToListAsync();

            var userDto =  users.Select(s => s.ToUsersDto());

            return Ok(users);
        }

        [HttpGet("{id}")]
        [Authorize]

        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var users = await _context.Users.FindAsync(id);

            if(users == null)
            {
                return NotFound();
            }

            return Ok(users.ToUsersDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUsersRequestDto usersDto)
        {
            
            var usersModel = usersDto.ToUsersFromCreateDTO();
            await _context.Users.AddAsync(usersModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new {id = usersModel.UserID}, usersModel.ToUsersDto());

        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateUsersRequestDto updateDto)
        {
            var usersModel = await _context.Users.FirstOrDefaultAsync(x => x.UserID == id);

            if (usersModel == null)
            {
                return NotFound();
            }

            usersModel.FullNames = updateDto.FullNames;
            usersModel.EmailAddress = updateDto.EmailAddress;
            usersModel.Password = updateDto.Password;
            usersModel.ConfirmPassword = updateDto.ConfirmPassword;
            usersModel.IsActive = updateDto.IsActive;

            await _context.SaveChangesAsync();

            return Ok(usersModel.ToUsersDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var usersModel = await _context.Users.FirstOrDefaultAsync(x => x.UserID == id);

            if(usersModel ==null)
            {
                return NotFound();
            }

            _context.Users.Remove(usersModel);

            await _context.SaveChangesAsync();

            return NoContent();

        }
        
    }
}
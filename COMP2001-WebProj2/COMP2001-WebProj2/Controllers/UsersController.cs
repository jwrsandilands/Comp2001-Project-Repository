using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using COMP2001_WebProj2.Models;

namespace COMP2001_WebProj2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataAccess _context;

        public UsersController(DataAccess context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<IActionResult> Get(User user)
        {
            SqlParameter verified;
            verified = new SqlParameter("@Verified","");
            verified.Direction = System.Data.ParameterDirection.Output;
            verified.Size = 2;

            var rowsaffected = _context.Database.ExecuteSqlRaw("EXEC @Verified = ValidateUser @Email, @Password",
                new SqlParameter("@Email", user.Email.ToString()),
                new SqlParameter("@Password", user.Password.ToString()),
                verified);
            
            return Ok();
        }


        // PUT: api/Users/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult Put(int id, User user)
        {
            //if (id != user.Userid)
            //{
            //    return BadRequest();
            //}

            //_context.Entry(user).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!GetValidation(user))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            var rowsaffected = _context.Database.ExecuteSqlRaw("EXEC UpdateUser @FirstName, @LastName, @Email, @Password, @id",
                new SqlParameter("@FirstName", user.FirstName.ToString()),
                new SqlParameter("@LastName", user.LastName.ToString()),
                new SqlParameter("@Email", user.Email.ToString()),
                new SqlParameter("@Password", user.Password.ToString()),
                new SqlParameter("@id", id));


            return Ok();
        }

        // POST: api/Users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public IActionResult PostUser(User user)
        {
            string httpNum;
            string accountNum;

            string outmessage = "testtext";
            SqlParameter response;
            response = new SqlParameter("@ResponseMessage", outmessage);
            response.Size = 100;
            response.Direction = System.Data.ParameterDirection.Output;

            Register register = new Register();


            var rowsaffected = _context.Database.ExecuteSqlRaw("EXEC Register @FirstName, @LastName, @Email, @Password, @ResponseMessage OUTPUT",
            new SqlParameter("@FirstName", user.FirstName.ToString()),
            new SqlParameter("@LastName", user.LastName.ToString()),
            new SqlParameter("@Email", user.Email.ToString()),
            new SqlParameter("@Password", user.Password.ToString()),
            response);            

                
            outmessage = response.Value.ToString();

            httpNum = outmessage.Substring(0, 3);
            if (httpNum.Equals("200"))
            {
                accountNum = "'UserID':" + outmessage.Substring(3, 1);
                return Ok(accountNum);
            }
            else if (httpNum.Equals("208"))
            {
                return StatusCode(208);
            }
            else
            {
                return StatusCode(404);
            }


        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var rowsaffected = _context.Database.ExecuteSqlRaw("EXEC DeleteUser @id",
                new SqlParameter("@id", id));

            return Ok();
        }

        private bool GetValidation(User user)
        {
            return _context.Users.Any(e => e.Email == user.Email && e.Password == user.Password);
        }

        private void Register(User user, out string message)
        {
            message = null;
        }
    }
}

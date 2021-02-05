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
            //verify user details using class
            bool verify = GetValidation(user);

            //verification message based on result
            if (!verify)
            {
                return Ok("{'verified': false}");
            }
            else if(verify)
            {
                return Ok("{'verified': true}");
            }
            else
            {
                return Ok("{'verified': false}");
            }
        }


        // PUT: api/Users/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult Put(int id, User user)
        {
            //execute procedure
            var rowsaffected = _context.Database.ExecuteSqlRaw("EXEC UpdateUser @FirstName, @LastName, @Email, @Password, @id",
                new SqlParameter("@FirstName", user.FirstName.ToString()),
                new SqlParameter("@LastName", user.LastName.ToString()),
                new SqlParameter("@Email", user.Email.ToString()),
                new SqlParameter("@Password", user.Password.ToString()),
                new SqlParameter("@id", id));

            //confirm update
            return StatusCode(204);
        }

        // POST: api/Users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public IActionResult PostUser(User user)
        {
            //variables
            string outmessage, httpNum, accountNum;

            //use register class to register details
            Register(user, out outmessage);

            //return the appropriate status and info
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
            //execute procedure
            var rowsaffected = _context.Database.ExecuteSqlRaw("EXEC DeleteUser @id",
                new SqlParameter("@id", id));

            //confirm deletion
            return Ok();
        }

        private bool GetValidation(User user)
        {
            //set up return value
            SqlParameter verified;
            verified = new SqlParameter("@Verified", "");
            verified.Direction = System.Data.ParameterDirection.Output;
            verified.Size = 1;

            //execute procedure
            var rowsaffected = _context.Database.ExecuteSqlRaw("EXEC @Verified = ValidateUser @Email, @Password",
                new SqlParameter("@Email", user.Email.ToString()),
                new SqlParameter("@Password", user.Password.ToString()),
                verified);

            //return result depending on the returned value
            if (verified.Value.ToString().Equals("0"))
            {
                return false;
            }
            else if (verified.Value.ToString().Equals("1"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Register(User user, out string outmessage)
        {

            //setup output from procedure
            outmessage = "text";
            SqlParameter response;
            response = new SqlParameter("@ResponseMessage", outmessage);
            response.Size = 100;
            response.Direction = System.Data.ParameterDirection.Output;

            //execute procedure
            var rowsaffected = _context.Database.ExecuteSqlRaw("EXEC Register @FirstName, @LastName, @Email, @Password, @ResponseMessage OUTPUT",
            new SqlParameter("@FirstName", user.FirstName.ToString()),
            new SqlParameter("@LastName", user.LastName.ToString()),
            new SqlParameter("@Email", user.Email.ToString()),
            new SqlParameter("@Password", user.Password.ToString()),
            response);

            //set outgoing response
            outmessage = response.Value.ToString();
        }
    }
}

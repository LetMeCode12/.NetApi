using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Repository;
using Models;
using Microsoft.EntityFrameworkCore;
using Seciurity;

namespace myApi.Controllers
{
    [ApiController]
    
    public class UserController : ControllerBase
    {

        private readonly _DbContext _context;

        public UserController(_DbContext context){
            this._context= context;
        }

        [HttpPost("/user/add")]
        public ActionResult<User> addUser(User user){
            user.Login.Password= Hashing.HashPassword(user.Login.Password);
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        [HttpGet("/user/getAll")]
        public ActionResult<List<Boolean>> getAll(){
                        
            return _context.Users.Include(e=>e.Login).ToList().Select(e=>Hashing.ValidatePassword("Hello",e.Login.Password)).ToList();
        }
        [HttpGet("/user/getLogins")]
        public ActionResult<List<UserLogin>> getAllLogins(){
                        
            return _context.UserLogins.Include(e=>e.User).ToList();
        }

        [HttpGet("/user/ok")]
        public ActionResult<string> ok(){
            return "ok";
        }
    }
}
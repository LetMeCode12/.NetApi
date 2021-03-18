using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Microsoft.EntityFrameworkCore;
using Seciurity;

namespace myApi.Controllers
{
    [ApiController]
    
    public class UserController : ControllerBase
    {

        private readonly UserDbContext _context;
        private readonly LoginUserDbContext LoginUserDbContext;

        public UserController(UserDbContext context, LoginUserDbContext loginUserDbContext){
            this._context= context;
            this.LoginUserDbContext= loginUserDbContext;
        }

        [HttpPost("/user/add")]
        public ActionResult<User> addUser(User user){
            user.Login.Password= Hashing.HashPassword(user.Login.Password);
            _context.User.Add(user);
            _context.SaveChanges();
            return user;
        }

        [HttpGet("/user/getAll")]
        public ActionResult<List<Boolean>> getAll(){
                        
            return _context.User.Include(e=>e.Login).ToList().Select(e=>Hashing.ValidatePassword("Hello",e.Login.Password)).ToList();
        }
        [HttpGet("/user/getLogins")]
        public ActionResult<List<UserLogin>> getAllLogins(){
                        
            return LoginUserDbContext.UserLogin.Include(e=>e.User).ToList();
        }

        [HttpGet("/user/ok")]
        public ActionResult<string> ok(){
            return "ok";
        }
    }
}
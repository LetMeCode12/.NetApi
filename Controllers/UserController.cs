using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Repository;
using Models;

namespace myApi.Controllers
{
    [ApiController]
    
    public class UserController : ControllerBase
    {

        private readonly UserRepository _context;

      public UserController(UserRepository context){
          this._context= context;
      }

        [HttpPost("/user/add")]
        public ActionResult<User> addUser(User user){

            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        [HttpGet("/user/getAll")]
        public ActionResult<List<User>> getAll(){

            return _context.Users.ToList();
        }

        [HttpGet("/user/ok")]
        public ActionResult<string> ok(){
            return "ok";
        }
    }
}